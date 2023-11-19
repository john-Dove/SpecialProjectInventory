using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class AlertsForm : Form
    {
        public AlertsForm()
        {
            InitializeComponent();
            DgvAlerts.AutoGenerateColumns = false;
            DgvAlerts.CellClick += DgvAlerts_CellClick;
            AddResolveButtonColumn();

        }

        public void LoadAlerts()
        {
            int i = 0;
            DgvAlerts.Rows.Clear(); // Clears existing rows before loading new ones.

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    string query = "SELECT logID, alertID, triggeredOn, message FROM tbAlertLog WHERE isResolved = 0";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                i++;
                                // Using column indices to retrieve data
                                DgvAlerts.Rows.Add(
                                    dr[0].ToString(), // logID
                                    dr[1].ToString(), // alertID
                                    Convert.ToDateTime(dr[2]).ToString("g"), // triggeredOn
                                    dr[3].ToString()  // message
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

                    if (alertManager.CanResolveAlert(productID))
                    {
                        alertManager.ResolveAlert(logID);
                        MessageBox.Show("Alert resolved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        }

        private void DgvAlerts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
