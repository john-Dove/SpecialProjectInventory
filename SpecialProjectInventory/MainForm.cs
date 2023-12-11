using System;
using System.Windows.Forms;
using static SpecialProjectInventory.LoginForm;
using static SpecialProjectInventory.ProjectUtility;

namespace SpecialProjectInventory
{
    public partial class MainForm : Form
    {
        private readonly Timer notificationTimer = new Timer();
        private DateTime _lastAlertCheckTime = DateTime.MinValue;

        public static string UserRole { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        // Shows subform form in mainform
        private Form activeForm = null;

        public void OpenChildForm(Form childForm)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panMain.Controls.Add(childForm);
            panMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void BtncusProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductForm());
        }

        private void BtncusOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderForm());
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            // Hides the MainForm
            Hide();

            // Creates a new instance of the login form and shows it
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

            // Closes the MainForm after logging out
            Close();
            UserSession.IsUserLoggedIn = false;
        }
        public void SetWelcomeMessage(string username)
        {

            LblWelcomeMsg.Text = $"SIGNED IN AS,\n{username.ToUpper()}";
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            ReportModule reportModule = new ReportModule();
            reportModule.ShowDialog();
        }

        private void BtncusUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserformForm());
        }

        private void BtncusCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CustomerForm());
        }

        private void BtncusCategories_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CategoryForm());
        }

        private void BtnMainAlerts_Click(object sender, EventArgs e)
        {
            AlertsForm alertsForm = new AlertsForm(UserRole);
            alertsForm.LoadAlerts();
            OpenChildForm(alertsForm);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            if (UserSession.IsUserLoggedIn)
            {
                notificationTimer.Interval = 60000;
                notificationTimer.Tick += new EventHandler(NotificationTimer_Tick);
                notificationTimer.Start();
                
            }
            else
            {
                Logger.LogMessage("User is not logged in, timer not started.", nameof(NotificationTimer_Tick));
            }

            // Presets for main buttons
            BtncusUsers.Visible = BtncusCustomer.Visible = BtncusCategories.Visible = false;
            BtncusProduct.Visible = BtncusOrders.Visible = BtnMainAlerts.Visible = false;

            // Report button is always visible
            BtnReport.Visible = true;

            // Presets for label visibility
            LblProduct.Visible = LblCustomers.Visible = LblCategories.Visible = false;
            LblUsers.Visible = LblOrders.Visible = LblAlerts.Visible = false;
            LblReports.Visible = true; // Always visible

            // Checks for Admin privileges
            if (RoleHelper.IsAdmin())
            {
                BtncusUsers.Visible = BtncusCustomer.Visible = BtncusCategories.Visible = true;
                BtncusProduct.Visible = BtncusOrders.Visible = BtnMainAlerts.Visible = true;

                LblProduct.Visible = LblCustomers.Visible = LblCategories.Visible = true;
                LblUsers.Visible = LblOrders.Visible = LblAlerts.Visible = true;
            }

            // Checks for Manager privileges
            if (RoleHelper.IsManager())
            {
                BtncusUsers.Visible = BtncusCustomer.Visible = BtncusCategories.Visible = true;
                BtncusProduct.Visible = BtncusOrders.Visible = BtnMainAlerts.Visible = true;

                LblProduct.Visible = LblCustomers.Visible = LblCategories.Visible = true;
                LblUsers.Visible = LblOrders.Visible = LblAlerts.Visible = true;
            }

            // Checks for Employee privileges
            if (RoleHelper.IsEmployee())
            {
                BtncusProduct.Visible = BtnMainAlerts.Visible = true;

                LblProduct.Visible = LblAlerts.Visible = true;
            }
        }

        private void ShowNotificationHere(string message)
        {
            // Passes 'UserRole' as an additional argument to the NotificationForm constructor
            NotificationForm notificationPopup = new NotificationForm(this, message, UserRole)
            {
                // Sets the location of the notification window
                StartPosition = FormStartPosition.Manual
            };
            var bottomRightCorner = Screen.GetWorkingArea(this).Location;
            bottomRightCorner.X += Screen.GetWorkingArea(this).Width - notificationPopup.Width;
            bottomRightCorner.Y += Screen.GetWorkingArea(this).Height - notificationPopup.Height;
            notificationPopup.Location = bottomRightCorner;
            notificationPopup.Show();
        }


        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            if (UserSession.IsUserLoggedIn)
            {
                if (CheckForNewAlerts())
                {
                    string message = "You have new alerts!";
                    ShowNotificationHere(message);
                }
            }
            else
            {
                notificationTimer.Stop();
            }

        }

        private bool CheckForNewAlerts()
        {
            
            AlertManager alertManager = new AlertManager(DatabaseConfig.ConnectionString);

            bool hasNewAlerts = false;

            try
            {
                // Checks for low stock alerts
                hasNewAlerts |= CheckLowStockAlerts(alertManager, _lastAlertCheckTime);
                
                // Checks for expiring product alerts
                hasNewAlerts |= alertManager.CheckExpiringProductAlerts(_lastAlertCheckTime);
                
                // Updates _lastAlertCheckTime after checking alerts
                _lastAlertCheckTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, nameof(CheckForNewAlerts));
            }
            
            return hasNewAlerts;
        }

        private bool CheckLowStockAlerts(AlertManager alertManager, DateTime lastCheckedTime)
        {
            bool newAlerts = false;
            var lowStockProducts = alertManager.GetAllProductsWithLowStockThreshold(lastCheckedTime);

            foreach (var product in lowStockProducts)
            {
                int alertID = alertManager.GetAlertID("Low-Stock");

       
                if (alertID != -1)
                {
                    string message = $"Low stock alert for {product.Name} (ID: {product.Id}). Only {product.Quantity} items left.";
                    alertManager.LogAlert(message, alertID, product.Id);
                    alertManager.UpdateProductLastCheckedTime(product.Id);
                    newAlerts = true;
                }
                else
                {
                    // Logs a warning if the alertID is invalid
                    Logger.LogMessage($"[MainForm] Warning: Invalid AlertID received for {product.Name} (ID: {product.Id})", nameof(CheckLowStockAlerts));

                }
            }

            return newAlerts;
        }



    }
}
