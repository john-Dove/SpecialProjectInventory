using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            txtPDes.Enabled = false;
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
                    var query = "SELECT pname, pqty, pprice, pdescription, pcategory, lowstockthreshold, expiredatee FROM tbProduct WHERE pid = @pid";
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
                                    DtExpiryDate.Value = reader.GetDateTime(reader.GetOrdinal("expiredatee"));
                                    DtExpiryDate.Visible = true;
                                    DtpThresholdDate.Visible = true;
                                }
                                else
                                {
                                    DtExpiryDate.Visible = false;
                                    DtpThresholdDate.Visible = false;
                                }

                                // Stores original values for comparison during update
                                originalQuantity = Convert.ToInt32(txtPQTY.Text);
                                originalPrice = Convert.ToDecimal(txtPprice.Text);
                                originalLowStockThreshold = NudReorderLevel.Value;
                                originalExpiryDate = DtExpiryDate.Visible ? DtExpiryDate.Value.Date : (DateTime?)null;
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
                // Retrieves current form values
                int currentQuantity = Convert.ToInt32(txtPQTY.Text);
                decimal currentPrice = Convert.ToDecimal(txtPprice.Text);
                decimal currentLowStockThreshold = NudReorderLevel.Value;
                DateTime? currentExpiryDate = DtExpiryDate.Visible ? DtExpiryDate.Value.Date : (DateTime?)null;
                bool currentIsPerishable = RdBtnPerishable.Checked; // Assuming RdBtnPerishable indicates if the product is perishable

                // Compare current form values to original values
                bool quantityChanged = originalQuantity != currentQuantity;
                bool priceChanged = originalPrice != currentPrice;
                bool lowStockThresholdChanged = originalLowStockThreshold != currentLowStockThreshold;
                bool expiryDateChanged = originalExpiryDate != currentExpiryDate;
                bool isPerishableChanged = originalIsPerishable != currentIsPerishable;

                if (quantityChanged || priceChanged || lowStockThresholdChanged || expiryDateChanged || isPerishableChanged)
                {
                    if (MessageBox.Show("Are you sure you want to update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                        {
                            var query = "UPDATE tbProduct SET pname = @pname, " +
                                        (quantityChanged ? "pqty = @pqty, " : "") +
                                        (priceChanged ? "pprice = @pprice, " : "") +
                                        "pdescription = @pdescription, pcategory = @pcategory, " +
                                        (lowStockThresholdChanged ? "lowstockthreshold = @lowstockthreshold, " : "") +
                                        (expiryDateChanged ? "expiredatee = @expiredatee, " : "") +
                                        (isPerishableChanged ? "isPerishable = @isPerishable, " : "") +
                                        "WHERE pid = @pid";
                            using (var cm = new SqlCommand(query, connection))
                            {
                                cm.Parameters.AddWithValue("@pname", txtPName.Text);
                                if (quantityChanged) cm.Parameters.AddWithValue("@pqty", currentQuantity);
                                if (priceChanged) cm.Parameters.AddWithValue("@pprice", currentPrice);
                                cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                                cm.Parameters.AddWithValue("@pcategory", CmbCatCategory.Text);
                                if (lowStockThresholdChanged) cm.Parameters.AddWithValue("@lowstockthreshold", currentLowStockThreshold);
                                if (expiryDateChanged) cm.Parameters.AddWithValue("@expiredatee", currentExpiryDate);
                                if (isPerishableChanged) cm.Parameters.AddWithValue("@isPerishable", currentIsPerishable);
                                cm.Parameters.AddWithValue("@pid", LblPid.Text);

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

    }
}
