using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class ProductModuleForm : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-78II3F3\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        //SqlDataReader dr;

        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
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

        private void picBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSavePM_Click(object sender, EventArgs e)
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
        }


        public void Clear()
        {
            txtPName.Clear();
            txtPQTY.Clear();
            txtPprice.Clear();
            txtPDes.Clear();
            comboCat.Text = "";

        }

        private void BtnClearPM_Click(object sender, EventArgs e)
        {
            Clear();
            btnSavePM.Enabled = true;
            btnUpdatePM.Enabled = false;
           

        }

        private void btnUpdatePM_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand("UPDATE tbProduct SET pname = @pname, pqty=@pqty, pprice=@pprice, pdescription=@pdescription, pcategory=@pcategory WHERE pid LIKE '" + lblPid.Text + "' ", connection))
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
