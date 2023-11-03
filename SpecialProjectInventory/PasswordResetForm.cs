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
    public partial class PasswordResetForm : Form
    {
        private string _username;

        public PasswordResetForm(int userID, string username)
        {
            InitializeComponent();

            _username = username;
            TxtUserName.Text = _username;
            this.lblUserID.Text = userID.ToString();
        }


        public PasswordResetForm()
        {
            InitializeComponent();
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            int userId; // Declares an integer to hold the parsed userID
            if (!int.TryParse(lblUserID.Text.Trim(), out userId)) // Trys to parse the userID from the label text
            {
                MessageBox.Show("Invalid userID format.");
                return;  // Shows an error message and exit the method if parsing fails
            }

            using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
            {
                con.Open();

                // Checks the current password
                using (SqlCommand cmd = new SqlCommand("SELECT password FROM tbUser WHERE userID = @userID", con))
                {
                    cmd.Parameters.AddWithValue("@userID", userId);  // Use the parsed integer value here
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string currentPasswordFromDB = result.ToString();
                        if (TxtCurrentPassword.Text != currentPasswordFromDB)
                        {
                            MessageBox.Show("Current password is incorrect.");
                            return;
                        }
                    }
                }

                // Checks whether the current password is correct
                if (TxtNewPassword.Text != TxtConfirmPassword.Text)
                {
                    MessageBox.Show("New password and re-entered password do not match.");
                    return;
                }

                // Updates password in database
                using (SqlCommand cmd = new SqlCommand("UPDATE tbUser SET isPasswordReset = 0 WHERE userID = @userID", con))
                {
                    cmd.Parameters.AddWithValue("@newPassword", TxtNewPassword.Text);
                    cmd.Parameters.AddWithValue("@userID", userId); // Use the parsed integer value here as well
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Password changed successfully!");
                this.Hide();
                MainForm main = new MainForm();
                this.Hide();
                main.ShowDialog();
            }
        }

        private void BtnClearPassword_Click(object sender, EventArgs e)
        {
            ClearResetForm();
        }

        public void ClearResetForm()
        {
            TxtNewPassword.Clear();
            TxtConfirmPassword.Clear();

        }
    }
}
