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
       
        public LoginForm()
        {
            InitializeComponent();
        }

        
        private void BtnLogin_Click(object sender, EventArgs e)  // login query instructions
        {
            string sql = "SELECT tbUser.*, tbRole.roleName FROM tbUser INNER JOIN tbRole ON tbUser.roleID = tbRole.roleID WHERE username=@username AND password=@password";

            try
            {
                using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@username", TxtUserName.Text);
                        command.Parameters.AddWithValue("@password", TxtPassword.Text);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            MainForm.UserRole = reader["roleName"].ToString();
                            int userID = (int)reader["userID"];
                            // Checks whether a password reset is required
                            if (IsPasswordResetRequired(TxtUserName.Text))
                            {
                                // Informs the user and then redirect to the Change Password form it is
                                MessageBox.Show("You are required to reset your password before proceeding.", "PASSWORD RESET REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ShowChangePasswordForm(userID, TxtUserName.Text);
                                this.Hide();

                            }
                            else
                            {
                                MessageBox.Show("Welcome " + reader["fullname"].ToString() + " | ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainForm main = new MainForm();
                                this.Hide();
                                main.ShowDialog();
                            }
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
                TxtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = false;
            }
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            TxtUserName.Clear();
            TxtPassword.Clear();
        }

        private void picBoxClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private bool IsPasswordResetRequired(string username)
        {
            using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
            {
                string query = "SELECT isPasswordReset FROM tbUser WHERE username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    bool resetRequired = (bool)command.ExecuteScalar();

                    return resetRequired;
                }
            }
        }

        private void ShowChangePasswordForm(int userID, string username)
        {
            PasswordResetForm changePasswordForm = new PasswordResetForm(userID, username);
            changePasswordForm.ShowDialog();
        }





    }
}
