using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using static SpecialProjectInventory.AlertManager;

namespace SpecialProjectInventory
{
    public partial class ProductModuleForm : Form
    {
        // Property to track if the form is in edit mode and the ID of the product being edited
        public int? EditingProductId { get; set; } = null;

        // Private fields to store original values
        private int originalQuantity;
        private decimal originalPrice;
        private decimal originalLowStockThreshold;
        private bool originalIsPerishable;
        private DateTime? originalExpiryDate;
        

        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
            
        }

        public void Clear()
        {
            txtPName.Clear();
            txtPQTY.Clear();
            txtPprice.Clear();
            txtPDes.Clear();
            CmbCatCategory.Text = "";
            DtExpiryDate.Visible = false; // Resets visibility of DtExpiryDate
            NudReorderLevel.Value = NudReorderLevel.Minimum; // Resets NudReorderLevel
        }


        public void LoadCategory()
        {
            //comboCat.Items.Clear();
            using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
            {
                using (SqlCommand cm = new SqlCommand("SELECT catname FROM tbCategory", connection))
                {
                    connection.Open();
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CmbCatCategory.Items.Add(dr[0].ToString());
                        }
                    }
                }
            }
            // Adds an event handler for SelectedIndexChanged event
            CmbCatCategory.SelectedIndexChanged += CmbCatCategory_SelectedIndexChanged;
        }

        public void ConfigureForAlerts()
        {
            txtPName.Enabled = false;
            txtPDes.Enabled = false;
            CmbCatCategory.Enabled = false;
            txtPprice.Enabled = false;
            btnSavePM.Enabled = false;
          
            txtPQTY.Enabled = true;
            DtExpiryDate.Enabled = true;
            DtpThresholdDate.Enabled = true;
            NudReorderLevel.Enabled = true;
        }
                
        public void LoadProductDetails(int productId)
        {
            EditingProductId = productId;
            try
            {
                using (var connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                {
                    
                    var query = "SELECT pname, pqty, pprice, pdescription, pcategory, lowstockthreshold, expiredatee, isPerishable FROM tbProduct WHERE pid = @pid";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@pid", productId);

                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtPName.Text = reader["pname"].ToString();
                                txtPQTY.Text = reader["pqty"].ToString();
                                txtPprice.Text = reader["pprice"].ToString();
                                txtPDes.Text = reader["pdescription"].ToString();
                                CmbCatCategory.SelectedItem = reader["pcategory"].ToString();
                                NudReorderLevel.Value = Convert.ToDecimal(reader["lowstockthreshold"]);

                                if (!reader.IsDBNull(reader.GetOrdinal("expiredatee")))
                                {
                                    //var expiryDate = reader.GetDateTime(reader.GetOrdinal("expiredatee"));
                                    //MessageBox.Show($"Debug: Expiry date read from database is {expiryDate}"); 
                                    DtExpiryDate.Value = reader.GetDateTime(reader.GetOrdinal("expiredatee"));
                                    DtExpiryDate.Visible = true;
                                }
                                else
                                {
                                    DtExpiryDate.Visible = false;
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("isPerishable")))
                                {
                                    bool isPerishable = reader.GetBoolean(reader.GetOrdinal("isPerishable"));
                                    RdBtnPerishable.Checked = isPerishable;
                                    RdBtnNonPerishable.Checked = !isPerishable;
                                    originalIsPerishable = isPerishable;
                                }

                                // Stores original values for comparison during update
                                originalQuantity = Convert.ToInt32(txtPQTY.Text);
                                originalPrice = Convert.ToDecimal(txtPprice.Text);
                                originalLowStockThreshold = NudReorderLevel.Value;
                                originalExpiryDate = DtExpiryDate.Visible ? (DateTime?)DtExpiryDate.Value.Date : null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading product details: " + ex.Message);
            }
        }

        public void LoadProductIdsFromAlerts(List<AlertLogEntry> activeAlerts)
        {
            CmbProductIDs.Items.Clear();

            foreach (var alert in activeAlerts)
            {
               
                CmbProductIDs.Items.Add(alert.ProductID.ToString());
            }

            if (CmbProductIDs.Items.Count > 0)
            {
                CmbProductIDs.SelectedIndex = 0; // Selects the first item by default
            }
        }


        public void EnableConfigurationMode(bool enable, List<AlertLogEntry> activeAlerts = null)
        {
            // Toggles visibility and enabled state based on whether we're in configuration mode
            CmbProductIDs.Visible = enable;
            CmbProductIDs.Enabled = enable;

            LblPid.Visible = !enable;

            if (enable)
            {
                // Checks if activeAlerts is provided
                if (activeAlerts != null)
                {
                    // Populates the ComboBox with product IDs from the provided alerts
                    LoadProductIdsFromAlerts(activeAlerts);
                }
                else
                {
                    // If no active alerts are provided, retrieves them internally
                    AlertManager alertManager = new AlertManager(SpecialProjectInventory.DatabaseConfig.ConnectionString);
                    activeAlerts = alertManager.GetActiveAlerts();
                    LoadProductIdsFromAlerts(activeAlerts);
                }
            }
            else
            {
                // Ensures the Label displays the product ID
                if (EditingProductId.HasValue)
                {
                    LblPid.Text = EditingProductId.Value.ToString();
                }
            }
        }



        private void PicBoxClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnSavePM_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        string query = "INSERT INTO tbProduct(pname, pqty, pprice, pdescription, pcategory, lowstockthreshold, expiredatee, isPerishable) " +
                                       "VALUES(@pname, @pqty, @pprice, @pdescription, @pcategory, @lowstockthreshold, @expiredatee, @isPerishable)";

                        using (SqlCommand cm = new SqlCommand(query, connection))
                        {
                            cm.Parameters.AddWithValue("@pname", txtPName.Text);
                            cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(txtPQTY.Text));
                            cm.Parameters.AddWithValue("@pprice", Convert.ToDecimal(txtPprice.Text));
                            cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                            cm.Parameters.AddWithValue("@pcategory", CmbCatCategory.Text);
                            cm.Parameters.AddWithValue("@lowstockthreshold", NudReorderLevel.Value);

                            // Determines whether the product is perishable based on the selected radio button
                            bool isPerishable = RdBtnPerishable.Checked;
                            cm.Parameters.AddWithValue("@isPerishable", isPerishable);

                            // Only includes the expiry date if the product is perishable
                            if (isPerishable && DtExpiryDate.Visible)
                            {
                                cm.Parameters.AddWithValue("@expiredatee", DtExpiryDate.Value.Date);
                            }
                            else
                            {
                                cm.Parameters.AddWithValue("@expiredatee", DBNull.Value);
                            }

                            connection.Open();
                            cm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Product has been successfully saved.");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdatePM_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtPQTY.Text, out int currentQuantity))
                {
                    MessageBox.Show("Quantity is not in the correct format.");
                    return; // Exits the method if parsing failed
                }

                if (!decimal.TryParse(txtPprice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal currentPrice))
                {
                    MessageBox.Show("Price is not in the correct format.");
                    return; // Exits the method if parsing failed
                }

                decimal currentLowStockThreshold = NudReorderLevel.Value;
                DateTime? currentExpiryDate = DtExpiryDate.Visible ? DtExpiryDate.Value.Date : (DateTime?)null;
                bool currentIsPerishable = RdBtnPerishable.Checked;

                // Determines the correct Product ID based on the visibility of the ComboBox or Label
                int productId = CmbProductIDs.Visible ? Convert.ToInt32(CmbProductIDs.SelectedValue) : Convert.ToInt32(LblPid.Text);

                // Compares current form values to original values
                bool quantityChanged = originalQuantity != currentQuantity;
                bool priceChanged = originalPrice != currentPrice;
                bool lowStockThresholdChanged = originalLowStockThreshold != currentLowStockThreshold;
                bool expiryDateChanged = originalExpiryDate != currentExpiryDate;
                bool isPerishableChanged = originalIsPerishable != currentIsPerishable;

                // Adds a check for lastCheckedOn update
                bool updateLastCheckedOn = true;

                if (quantityChanged || priceChanged || lowStockThresholdChanged || expiryDateChanged || isPerishableChanged || updateLastCheckedOn)
                {
                    if (MessageBox.Show("Are you sure you want to update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                        {
                            List<string> setClauses = new List<string>();
                            if (quantityChanged) setClauses.Add("pqty = @pqty");
                            if (priceChanged) setClauses.Add("pprice = @pprice");
                            if (lowStockThresholdChanged) setClauses.Add("lowstockthreshold = @lowstockthreshold");
                            if (expiryDateChanged) setClauses.Add("expiredatee = @expiredatee");
                            if (isPerishableChanged) setClauses.Add("isPerishable = @isPerishable");
                            if (updateLastCheckedOn) setClauses.Add("lastCheckedOn = GETDATE()");
                            
                            string setClause = string.Join(", ", setClauses);
                            string query = $"UPDATE tbProduct SET pname = @pname, pdescription = @pdescription, pcategory = @pcategory, {setClause} WHERE pid = @pid";
                            using (var cm = new SqlCommand(query, connection))
                            {
                                cm.Parameters.AddWithValue("@pname", txtPName.Text);
                                cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                                cm.Parameters.AddWithValue("@pcategory", CmbCatCategory.Text);
                                if (quantityChanged) cm.Parameters.AddWithValue("@pqty", currentQuantity);
                                if (priceChanged) cm.Parameters.AddWithValue("@pprice", currentPrice);
                                if (lowStockThresholdChanged) cm.Parameters.AddWithValue("@lowstockthreshold", currentLowStockThreshold);
                                if (expiryDateChanged) cm.Parameters.AddWithValue("@expiredatee", currentExpiryDate.HasValue ? (object)currentExpiryDate.Value : DBNull.Value);
                                if (isPerishableChanged) cm.Parameters.AddWithValue("@isPerishable", currentIsPerishable);
                                cm.Parameters.AddWithValue("@pid", productId);

                                connection.Open();
                                cm.ExecuteNonQuery();
                                MessageBox.Show("Product has been successfully updated!");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No changes detected. Product update canceled.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the product: " + ex.Message);
            }
        }

        

        private void BtnClearPM_Click(object sender, EventArgs e)
        {
            Clear();
            btnSavePM.Enabled = true;
            btnUpdatePM.Enabled = false;


        }

        private void CmbCatCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Checks whether the selected category is "Groceries"
            bool isGroceries = CmbCatCategory.SelectedItem.ToString() == "Groceries";

            DtExpiryDate.Visible = isGroceries; // Shows or hides expiry date for groceries
            DtpThresholdDate.Visible = isGroceries; // Shows or hides threshold date for groceries
            RdBtnPerishable.Visible = isGroceries; // Shows or hides perishable radio button
            RdBtnNonPerishable.Visible = isGroceries; // Shows or hides non-perishable radio button

            // If the category is not Groceries, then we assume the product is not perishable
            // and we set the non-perishable radio button to checked.
            if (!isGroceries)
            {
                RdBtnNonPerishable.Checked = true;
            }
        }

        private void CmbProductIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProductIDs.SelectedItem != null)
            {
                if (int.TryParse(CmbProductIDs.SelectedItem.ToString(), out int selectedProductId))
                {
                    LoadProductDetails(selectedProductId);
                }
                else
                {
                    MessageBox.Show("The selected product ID is not in a valid format.");
                }
            }
        }
    }
}
