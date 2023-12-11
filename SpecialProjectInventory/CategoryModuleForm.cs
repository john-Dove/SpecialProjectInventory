using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class CategoryModuleForm : Form
    {

        public CategoryModuleForm()
        {
            InitializeComponent();
        }

        private void BtnSaveCM_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this category?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string connectionString = SpecialProjectInventory.DatabaseConfig.ConnectionString;
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // The SqlCommand is now declared inside the using block
                        using (SqlCommand cm = new SqlCommand("INSERT INTO tbCategory(catname)VALUES(@catname)", con))
                        {
                            cm.Parameters.AddWithValue("@catname", txtCatName.Text);
                            con.Open();
                            cm.ExecuteNonQuery();
                        } // The SqlCommand object is disposed here
                        MessageBox.Show("Category has been successfully saved.");
                        Clear();
                    } // The SqlConnection object is disposed here
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void Clear()
        {
            txtCatName.Clear();
        }

        private void BtnClearCM_Click(object sender, EventArgs e)
        {
            Clear();
            btnSaveCM.Enabled = true;
            btnUpdateCM.Enabled = false;


        }

        private void PicBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnUpdateCM_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Category?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string connectionString = SpecialProjectInventory.DatabaseConfig.ConnectionString;
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // The SqlCommand is now declared inside the using block
                        using (SqlCommand cm = new SqlCommand("UPDATE tbCategory SET catname = @catname WHERE catid LIKE '" + lblCatld.Text + "' ", con))
                        {
                            cm.Parameters.AddWithValue("@catname", txtCatName.Text);
                            con.Open();
                            cm.ExecuteNonQuery();
                        } // The SqlCommand object is disposed here

                        MessageBox.Show("Category has been successfully updated!");
                        Dispose();
                    } // The SqlConnection object is disposed here
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
