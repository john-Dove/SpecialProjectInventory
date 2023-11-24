using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace SpecialProjectInventory
{
    public partial class CustomerModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-78II3F3\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True");
        SqlCommand cm = new SqlCommand();

        public CustomerModuleForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
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

        private void picBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdateUM_Click(object sender, EventArgs e)
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

