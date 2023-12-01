using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class AlertsForm : Form
    {
        private readonly string _userRole;

        public AlertsForm(string role)
        {
            InitializeComponent();
            _userRole = role;
            DgvAlerts.AutoGenerateColumns = false;
            DgvAlerts.CellClick += DgvAlerts_CellClick;

            AddResolveButtonColumn();
            LoadAlerts();
            AdjustControlsBasedOnRole();
        }

        public void LoadAlerts()
        {
            DgvAlerts.Rows.Clear(); // Clears existing rows before loading new ones.

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    // Includes productID in your SELECT statement
                    string query = "SELECT logID, alertID, triggeredOn, message, productID FROM tbAlertLog WHERE isResolved = 0";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                // Gets the productID
                                int productID = dr.IsDBNull(4) ? -1 : dr.GetInt32(4);

                                // Using column names to retrieve data
                                DgvAlerts.Rows.Add(
                                    dr["logID"].ToString(),     // logID
                                    dr["alertID"].ToString(),   // alertID
                                    Convert.ToDateTime(dr["triggeredOn"]).ToString("g"), // triggeredOn
                                    dr["message"].ToString(),   // message
                                    productID.ToString()        // productID
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading alerts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdjustControlsBasedOnRole()
        {
            // Disables the resolve button for non-admin and non-manager users
            if (_userRole != "Admin" && _userRole != "Manager")
            {
                DgvAlerts.Columns["Resolve"].Visible = false; // Hides the resolve button column
                BtnAlertConfig.Enabled = false; // Disables the alert configuration button
            }
        }

        private void AddResolveButtonColumn()
        {
            if (!DgvAlerts.Columns.Contains("Resolve"))
            {
                DataGridViewButtonColumn resolveButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Resolve",
                    Text = "Resolve",
                    UseColumnTextForButtonValue = true
                };
                DgvAlerts.Columns.Add(resolveButtonColumn);
            }
        }

        private void DgvAlerts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Checks if the click is on a resolve button
            if (e.ColumnIndex == DgvAlerts.Columns["Resolve"].Index && e.RowIndex >= 0)
            {
                try
                {
                    int logID = Convert.ToInt32(DgvAlerts.Rows[e.RowIndex].Cells["logID"].Value);
                    int productID = Convert.ToInt32(DgvAlerts.Rows[e.RowIndex].Cells["productID"].Value);

                    AlertManager alertManager = new AlertManager(DatabaseConfig.ConnectionString);

                    // Gets the product threshold.
                    int threshold = alertManager.GetProductThreshold(productID);

                    // Checks whether the alert can be resolved based on the threshold.
                    if (alertManager.CanResolveAlert(productID, threshold))
                    {
                        // Resolves the alert, passing both logID and productID.
                        alertManager.ResolveAlert(logID, productID);
                        LoadAlerts(); // Refreshes the data grid view
                    }
                    else
                    {
                        MessageBox.Show("Alert cannot be resolved as the stock is still below the threshold.", "Alert Not Resolved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAlertConfig_Click(object sender, EventArgs e)
        {
            // Ensures only Admin and Manager roles can access the configuration
            if (_userRole == "Admin" || _userRole == "Manager")
            {
                AlertManager alertManager = new AlertManager(SpecialProjectInventory.DatabaseConfig.ConnectionString);
                var activeAlerts = alertManager.GetActiveAlerts();

                if (activeAlerts.Any()) // Checks if there are any active alerts
                {
                    ProductModuleForm productModuleForm = new ProductModuleForm();

                    // Configures the form for alerts and pass the active alerts
                    productModuleForm.ConfigureForAlerts();

                    // Enables configuration mode which will show the ComboBox
                    productModuleForm.EnableConfigurationMode(true);

                    // Loads the product IDs into the ComboBox
                    productModuleForm.LoadProductIdsFromAlerts(activeAlerts);

                    // Pre-loads the form with the details of the first product in the alert list
                    var firstAlertedProduct = activeAlerts.First();
                    productModuleForm.LoadProductDetails(firstAlertedProduct.ProductID);

                    // Shows the form as a dialog
                    productModuleForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No active alerts at the moment.", "No Alerts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to configure alerts.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void CBtnSettings_Click(object sender, EventArgs e)
        {
            AlertSettings alertSettings = new AlertSettings();
            alertSettings.ShowDialog();
        }
    }

}