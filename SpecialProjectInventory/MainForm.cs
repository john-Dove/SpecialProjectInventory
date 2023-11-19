using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
//using System.Text;

namespace SpecialProjectInventory
{
    public partial class MainForm : Form
    {
        private readonly Timer notificationTimer = new Timer();

        public static string UserRole { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        // Shows subform form in mainform
        private Form activeForm = null;

        private void OpenChildForm(Form childForm)
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
            AlertsForm alertsForm = new AlertsForm();
            alertsForm.LoadAlerts();
            OpenChildForm(alertsForm);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            notificationTimer.Interval = 60000;
            notificationTimer.Tick += new EventHandler(NotificationTimer_Tick);
            notificationTimer.Start();

            // Presets for main buttons
            BtncusUsers.Visible = false;
            BtncusCustomer.Visible = false;
            BtncusCategories.Visible = false;
            BtncusProduct.Visible = false;
            BtncusOrders.Visible = false;
            BtnReport.Enabled = RoleHelper.IsAdmin() || RoleHelper.IsManager();


            // Checks for Admin privileges
            if (RoleHelper.IsAdmin())
            {
                BtncusUsers.Visible = true;
                BtncusCustomer.Visible = true;
                BtncusCategories.Visible = true;
                BtncusProduct.Visible = true;
                BtncusOrders.Visible = true;
            }

            // Checks for Manager privileges
            if (RoleHelper.IsManager())
            {
                BtncusUsers.Visible = true;
                BtncusCustomer.Visible = true;
                BtncusCategories.Visible = true;
                BtncusProduct.Visible = true;
                BtncusOrders.Visible = true;
            }

            // Checks for Employee privileges
            if (RoleHelper.IsEmployee())
            {
                BtncusProduct.Visible = true;
               
            }

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

        }
        public void SetWelcomeMessage(string username)
        {
            
            LblWelcomeMsg.Text = $"SIGNED IN AS,\n{username.ToUpper()}";
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            // Check if the user has the permission to generate reports
            if (!RoleHelper.IsAdmin() && !RoleHelper.IsManager())
            {
                MessageBox.Show("You do not have permission to generate reports.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                   
                    DataTable inventoryData = ProjectUtility.GetInventoryData(); 

                    string reportPath = @"C:\Users\Nathaniel Manning\Desktop\Special Project\Reports\ReportsInventoryReport.csv";

                    // Calls the method to generate the report
                    ProjectUtility.GenerateInventoryReport(inventoryData, reportPath);

                    // Informs the user that the report was generated successfully
                    MessageBox.Show("Report generated successfully at " + reportPath, "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Informs the user that there was an error
                    MessageBox.Show("Failed to generate report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void ShowNotificationHere(string message)
        {
            NotificationForm notificationPopup = new NotificationForm(message)
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
            
            if (CheckForNewAlerts())
            {
                var message = "You have new alerts!";
                ShowNotificationHere(message);
            }
        }

       
        private bool CheckForNewAlerts()
        {
            AlertManager alertManager = new AlertManager(DatabaseConfig.ConnectionString);

            bool hasNewAlerts = false;
            DateTime lastCheckedTime = alertManager.GetLastCheckedTime();

            // Ensures lastCheckedTime is within SQL Server's date range
            if (lastCheckedTime < new DateTime(1753, 1, 1))
            {
                lastCheckedTime = new DateTime(1753, 1, 1);
            }

            try
            {
                var lowStockProducts = alertManager.GetAllProductsWithLowStockThreshold(lastCheckedTime);
                if (lowStockProducts.Any())
                {
                    foreach (var product in lowStockProducts)
                    {
                        int alertID = alertManager.GetAlertID("Low-Stock");
                        if (alertID != -1)
                        {
                            string message = $"Low stock alert for {product.Name} (ID: {product.Id}). Only {product.Quantity} items left.";
                            alertManager.LogAlert(message, alertID, product.Id);
                            alertManager.UpdateProductLastCheckedTime(product.Id);
                            hasNewAlerts = true; // Sets hasNewAlerts to true here to indicate a new alert was logged
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for new alerts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return hasNewAlerts;
        }

       
    }
}
