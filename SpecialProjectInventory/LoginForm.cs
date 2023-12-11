using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class LoginForm : Form
    {
        public static class UserSession
        {
            public static bool IsUserLoggedIn { get; set; } = false;
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        // Login query instructions
        private void BtnLogin_Click(object sender, EventArgs e)
        {

            string sql = "SELECT tbUser.*, tbRole.roleName FROM tbUser INNER JOIN tbRole ON tbUser.roleID = tbRole.roleID WHERE username=@username";

            try
            {
                using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Adds the username parameter to the command
                        command.Parameters.AddWithValue("@username", TxtUserName.Text);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string actualUsername = reader["username"].ToString();
                            string inputUsername = TxtUserName.Text;

                            // Perform a case-sensitive comparison of the usernames
                            if (!string.Equals(actualUsername, inputUsername, StringComparison.Ordinal))
                            {
                                MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            // Hashes the input password
                            string inputPasswordHashed = ProjectUtility.HashPassword(TxtPassword.Text);

                            // Gets the stored password hash from the database
                            string storedPasswordHash = reader["password"].ToString();

                            // Compares the hashed input password with the stored hashed password
                            if (inputPasswordHashed == storedPasswordHash)
                            {
                                // Continues with login success logic
                                MainForm.UserRole = reader["roleName"].ToString();
                                int userID = (int)reader["userID"];

                                // Checks whether a password reset is required 
                                if (IsPasswordResetRequired(TxtUserName.Text))
                                {
                                    MessageBox.Show("You are required to reset your password before proceeding.", "PASSWORD RESET REQUIRED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ShowChangePasswordForm(userID, TxtUserName.Text);
                                    Hide();
                                }
                                else
                                {
                                    UserSession.IsUserLoggedIn = true;
                                    string username = reader["username"].ToString();
                                    MessageBox.Show("Welcome " + reader["fullname"].ToString() + "!", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Hide();
                                    MainForm main = new MainForm();
                                    main.SetWelcomeMessage(username);
                                    main.ShowDialog();
                                    Dispose();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Toggles between masking and unmasking password
        private void ChkBxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPassword.Checked == false)
            {
                TxtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = false;
            }
        }

        private void LblClear_Click(object sender, EventArgs e)
        {
            TxtUserName.Clear();
            TxtPassword.Clear();
        }

        private void PicBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Checks the database for whether a password reset is needed
        private bool IsPasswordResetRequired(string username)
        {
            using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
            {
                string query = "SELECT isPasswordReset, password FROM tbUser WHERE username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool isPasswordReset = (bool)reader["isPasswordReset"];
                            string storedPasswordHash = reader["password"].ToString();
                            string defaultPasswordHashed = ProjectUtility.HashPassword("password123");

                            // The password reset is required if the isPasswordReset flag is true
                            // or if the user's password is still the default one.
                            return isPasswordReset || storedPasswordHash == defaultPasswordHashed;
                        }
                    }
                }
            }
            return false;
        }

        private void ShowChangePasswordForm(int userID, string username)
        {
            PasswordResetForm changePasswordForm = new PasswordResetForm(userID, username);
            changePasswordForm.ShowDialog();
        }
    }
}
