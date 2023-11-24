using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class AlertSettings : Form
    {
        public AlertSettings()
        {
            InitializeComponent();
        }

        private void BtnSaveAlert_Click(object sender, EventArgs e)
        {
            // Validates the input first
            if (string.IsNullOrWhiteSpace(TxtBxAlertType.Text))
            {
                MessageBox.Show("Alert Type is a required field.");
                return;
            }

            bool isEnabled = RdBtnYes.Checked;

            string connectionString = SpecialProjectInventory.DatabaseConfig.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO alertsettings (alertType, threshold, isEnabled) VALUES (@alertType, @threshold, @isEnabled)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@alertType", TxtBxAlertType.Text);
                    command.Parameters.AddWithValue("@threshold", UdAlertThreshold.Value);
                    command.Parameters.AddWithValue("@isEnabled", isEnabled);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Alert setting saved successfully.");

                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void BtnUpdateAlert_Click(object sender, EventArgs e)
        {
            // Validates the input first
            if (string.IsNullOrWhiteSpace(TxtBxAlertID.Text))
            {
                MessageBox.Show("Alert ID is required to update an alert setting.");
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtBxAlertType.Text))
            {
                MessageBox.Show("Alert Type is a required field.");
                return;
            }

            if (!int.TryParse(TxtBxAlertID.Text, out int alertID))
            {
                MessageBox.Show("Please enter a valid Alert ID.");
                return;
            }

            bool isEnabled = RdBtnYes.Checked;

            string connectionString = SpecialProjectInventory.DatabaseConfig.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE tbAlertSettings SET alertType = @alertType, threshold = @threshold, isEnabled = @isEnabled WHERE alertID = @alertID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@alertID", alertID);
                    command.Parameters.AddWithValue("@alertType", TxtBxAlertType.Text);
                    command.Parameters.AddWithValue("@threshold", UdAlertThreshold.Value);
                    command.Parameters.AddWithValue("@isEnabled", isEnabled);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Alert setting updated successfully.");
                            ClearForm();
                            LoadDataIntoGrid();
                        }
                        else
                        {
                            MessageBox.Show("No alert setting found with the given ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while updating the alert setting: " + ex.Message);
                    }
                }
            }
        }




        private void ClearForm()
        {
            // Clears all controls or reset to default state
            TxtBxAlertID.Clear();
            TxtBxAlertType.Clear();
            UdAlertThreshold.Value = UdAlertThreshold.Minimum;
            RdBtnYes.Checked = false;
            RdBtnNo.Checked = false;
        }

        private void BtnClearAlert_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void PcBxCloseAlert_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvAlertSettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Checks whether the click is on a valid row (not the header).
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DgvAlertSettings.Rows[e.RowIndex];

                TxtBxAlertID.Text = row.Cells["alertID"].Value.ToString();
                TxtBxAlertType.Text = row.Cells["alertType"].Value.ToString();

                // Handles the threshold value for the NumericUpDown control
                if (decimal.TryParse(row.Cells["threshold"].Value.ToString(), out decimal thresholdValue))
                {
                    // Ensures the value is within the range of the NumericUpDown control
                    thresholdValue = Math.Max(thresholdValue, UdAlertThreshold.Minimum);
                    thresholdValue = Math.Min(thresholdValue, UdAlertThreshold.Maximum);

                    UdAlertThreshold.Value = thresholdValue;
                }
                else
                {
                    // Handles the situation where the threshold value is not a valid decimal
                    UdAlertThreshold.Value = UdAlertThreshold.Minimum;
                }

                bool isEnabled = Convert.ToBoolean(row.Cells["isEnabled"].Value);
                RdBtnYes.Checked = isEnabled;
                RdBtnNo.Checked = !isEnabled;
            }
        }

        private void AlertSettings_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();

        }

        private void LoadDataIntoGrid()
        {
            string query = "SELECT alertID, alertType, threshold, isEnabled FROM tbAlertSettings";
            string connectionString = SpecialProjectInventory.DatabaseConfig.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                DgvAlertSettings.DataSource = dataTable;
            }
        }

    }


}
