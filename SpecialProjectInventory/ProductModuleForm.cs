using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class ProductModuleForm : Form
    {
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
            comboCat.Text = "";

        }

        public void LoadCategory()
        {
            comboCat.Items.Clear();
            using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
            {
                using (SqlCommand cm = new SqlCommand("SELECT catname FROM tbCategory", connection))
                {
                    connection.Open();
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            comboCat.Items.Add(dr[0].ToString());
                        }
                    }
                }
            }

        }

        private void PicBoxClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /*private void BtnSavePM_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand("INSERT INTO tbProduct(pname,pqty,pprice,pdescription,pcategory)VALUES(@pname,@pqty,@pprice,@pdescription,@pcategory)", connection))
                        {
                            cm.Parameters.AddWithValue("@pname", txtPName.Text);
                            cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPQTY.Text));
                            cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtPprice.Text));
                            cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                            cm.Parameters.AddWithValue("@pcategory", comboCat.Text);

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
        }*/

        private void BtnSavePM_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand("INSERT INTO tbProduct(pname, pqty, pprice, pdescription, pcategory,lowstockthreshold, expiredatee)VALUES(@pname, @pqty, @pprice, @pdescription, @pcategory,@lowstockthreshold, @expiredatee)", connection))
                        {
                            cm.Parameters.AddWithValue("@pname", txtPName.Text);
                            cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(txtPQTY.Text));
                            cm.Parameters.AddWithValue("@pprice", Convert.ToDecimal(txtPprice.Text));
                            cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                            cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                            cm.Parameters.AddWithValue("@lowstockthreshold", NudReorderLevel.Value);
                            cm.Parameters.AddWithValue("@expiredatee", DtExpiryDate.Value.Date);
                           

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


        private void BtnClearPM_Click(object sender, EventArgs e)
        {
            Clear();
            btnSavePM.Enabled = true;
            btnUpdatePM.Enabled = false;
           

        }

        /*private void BtnUpdatePM_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand("UPDATE tbProduct SET pname = @pname, pqty = @pqty, pprice = @pprice, pdescription = @pdescription, pcategory = @pcategory WHERE pid = @pid", connection))
                        {
                            cm.Parameters.AddWithValue("@pname", txtPName.Text);

                            // Ensure the quantity and price text can be converted to the correct types
                            decimal price;
                            bool qtyIsValid = int.TryParse(txtPQTY.Text, out int quantity);
                            bool priceIsValid = decimal.TryParse(txtPprice.Text, out price);

                            if (!qtyIsValid)
                            {
                                MessageBox.Show("Invalid format for quantity.");
                                return;
                            }

                            if (!priceIsValid)
                            {
                                MessageBox.Show("Invalid format for price.");
                                return;
                            }

                            cm.Parameters.AddWithValue("@pqty", quantity);
                            cm.Parameters.AddWithValue("@pprice", price);
                            cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                            cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                            cm.Parameters.AddWithValue("@pid", lblPid.Text);

                            connection.Open();
                            cm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Product has been successfully updated!");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

        private void BtnUpdatePM_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand("UPDATE tbProduct SET pname = @pname, pqty = @pqty, pprice = @pprice, pdescription = @pdescription, pcategory = @pcategory,lowstockthreshold = @lowstockthreshold, expiredatee = @expiredatee WHERE pid = @pid", connection))
                        {
                            cm.Parameters.AddWithValue("@pname", txtPName.Text);
                            cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(txtPQTY.Text));
                            cm.Parameters.AddWithValue("@pprice", Convert.ToDecimal(txtPprice.Text));
                            cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                            cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                            cm.Parameters.AddWithValue("@lowstockthreshold", NudReorderLevel.Value);
                            cm.Parameters.AddWithValue("@expiredatee", DtExpiryDate.Value.Date);
                            cm.Parameters.AddWithValue("@pid", lblPid.Text);

                            connection.Open();
                            cm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Product has been successfully updated!");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
