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
    public partial class LoginForm : Form
    {

        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CAAM698\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True");
       // SqlCommand cm = new SqlCommand();
        //SqlDataReader dr;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //LOGIN BUTTON CLICK
        {
            //string sql = "SELECT * FROM tbUser WHERE username=@username AND password=@password";
            string sql = "SELECT tbUser.*, tbRole.roleName FROM tbUser INNER JOIN tbRole ON tbUser.roleID = tbRole.roleID WHERE username=@username AND password=@password";

            try
            {
                using (SqlConnection connection = new SqlConnection (SpecialProjectInventory.DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@username", txtUserName.Text);
                        command.Parameters.AddWithValue("@password", txtPassword.Text);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        /*if (reader.Read())
                        {
                            MessageBox.Show("Welcome " + reader["fullname"].ToString() + " | ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainForm main = new MainForm();
                            this.Hide();
                            main.ShowDialog();
                        }*/
                        if (reader.Read())
                        {
                            MainForm.UserRole = reader["roleName"].ToString();
                            MessageBox.Show("Welcome " + reader["fullname"].ToString() + " | ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainForm main = new MainForm();
                            this.Hide();
                            main.ShowDialog();
                        }

                        else
                        {
                            MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void cbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(cbPassword.Checked == false) 
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void picBoxClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



    }
}
