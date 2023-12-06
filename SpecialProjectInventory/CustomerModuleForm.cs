using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SpecialProjectInventory
{
    public partial class CustomerModuleForm : Form
    {
        public CustomerModuleForm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this customer?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand("INSERT INTO tbCustomer(cname,cphone)VALUES(@cname, @cphone)", con))
                        {
                            cm.Parameters.AddWithValue("@cname", txtCName.Text);
                            cm.Parameters.AddWithValue("@cphone", txtCPhone.Text);
                            con.Open();
                            cm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Customer has been successfully saved.");
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
            txtCName.Clear();
            txtCPhone.Clear();

        }

        private void BtnClearUM_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdateUM.Enabled = false;
        }

        private void PicBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnUpdateUM_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Customer?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand("UPDATE tbCustomer SET cname = @cname, cphone=@cphone WHERE cid LIKE '" + lblCld.Text + "' ", con))
                        {
                            cm.Parameters.AddWithValue("@cname", txtCName.Text);
                            cm.Parameters.AddWithValue("@cphone", txtCPhone.Text);
                            con.Open();
                            cm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Customer has been successfully updated!");
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

