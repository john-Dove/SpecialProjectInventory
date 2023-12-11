using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace SpecialProjectInventory
{
    public partial class PasswordResetForm : Form
    {
        private readonly string _username;

        public PasswordResetForm(int userID, string username)
        {
            InitializeComponent();

            _username = username;
            TxtUserName.Text = _username;
            lblUserID.Text = userID.ToString();
        }


        public PasswordResetForm()
        {
            InitializeComponent();
        }

        // Evaluates and resets password where applicable
        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            // Checks whether the new password meets complexity requirements
            if (!ProjectUtility.IsPasswordComplex(TxtNewPassword.Text))
            {
                MessageBox.Show("The password does not meet complexity requirements.");
                return;
            }

            // Declares an integer to hold the parsed userID
            if (!int.TryParse(lblUserID.Text.Trim(), out int userId))
            {
                MessageBox.Show("Invalid userID format.");
                return;
            }

            using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
            {
                con.Open();

                // Starts a transaction to ensure both operations (password update and reset flag update) are atomic
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Checks the current password
                        using (SqlCommand cmd = new SqlCommand("SELECT password FROM tbUser WHERE userID = @userID", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userID", userId);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                string currentPasswordFromDB = result.ToString();
                                // Hashes the input current password and compare with the hashed password from the database
                                string inputCurrentPasswordHashed = ProjectUtility.HashPassword(TxtCurrentPassword.Text);

                                if (inputCurrentPasswordHashed != currentPasswordFromDB)
                                {
                                    MessageBox.Show("Current password is incorrect.");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("User not found.");
                                return;
                            }
                        }

                        // Checks whether the new password and confirmation match
                        if (TxtNewPassword.Text != TxtConfirmPassword.Text)
                        {
                            MessageBox.Show("New password and confirmation password do not match.");
                            return;
                        }

                        // Updates password in database
                        using (SqlCommand cmd = new SqlCommand("UPDATE tbUser SET password = @newPassword WHERE userID = @userID", con, transaction))
                        {
                            // Hashes the new password before storing it in the database
                            string newHashedPassword = ProjectUtility.HashPassword(TxtNewPassword.Text);
                            cmd.Parameters.AddWithValue("@newPassword", newHashedPassword);
                            cmd.Parameters.AddWithValue("@userID", userId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Checks whether password was updated
                            if (rowsAffected > 0)
                            {
                                // If password update was successful, reset the isPasswordReset flag
                                using (SqlCommand resetCmd = new SqlCommand("UPDATE tbUser SET isPasswordReset = 0 WHERE userID = @userID", con, transaction))
                                {
                                    resetCmd.Parameters.AddWithValue("@userID", userId);
                                    resetCmd.ExecuteNonQuery();
                                }

                                // Commits the transaction if both operations are successful
                                transaction.Commit();

                                Hide();
                                MessageBox.Show("Password changed successfully!");
                                MainForm main = new MainForm();
                                main.ShowDialog();
                            }
                            else
                            {
                                // Rolls back the transaction if the password update was unsuccessful
                                transaction.Rollback();
                                MessageBox.Show("Password update failed. Please try again.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // If any exception occurs, roll back the transaction and show the error message
                        transaction.Rollback();
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        // Invokes the clear method on form fields
        private void BtnClearPassword_Click(object sender, EventArgs e)
        {
            ClearResetForm();
        }

        public void ClearResetForm()
        {
            TxtCurrentPassword.Clear();
            TxtNewPassword.Clear();
            TxtConfirmPassword.Clear();


        }

        private void ChkBxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBxShowPassword.Checked == false)
            {
                TxtCurrentPassword.UseSystemPasswordChar = true;
                TxtNewPassword.UseSystemPasswordChar = true;
                TxtConfirmPassword.UseSystemPasswordChar = true;
            }
            else
            {
                TxtCurrentPassword.UseSystemPasswordChar = false;
                TxtNewPassword.UseSystemPasswordChar = false;
                TxtConfirmPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
