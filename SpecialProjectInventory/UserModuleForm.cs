using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace SpecialProjectInventory
{
    public partial class UserModuleForm : Form
    {
        public bool IsAddButtonClicked { get; set; } = false;

        public void DisableUpdateButtonIfAddClicked()
        {
            // Disables btnUpdateUM if AddButtonClicked is true
            btnUpdateUM.Enabled = !IsAddButtonClicked;
        }

        public void EnableAllCheckBoxes()
        {
            ChkBxEditRole.Checked = true;
            ChkBxEditUserName.Checked = true;
            ChkBxEditName.Checked = true;
            ChkBxEditPassword.Checked = true;
            ChkBxEditPhone.Checked = true;

            UpdateButtonStates();
        }

        public UserModuleForm()
        {
            InitializeComponent();
            InitializePhoneMaskedTextBox();
        }

        private void InitializePhoneMaskedTextBox()
        {
            // Creates a MaskedTextBox for phone numbers using your utility function.
            var MskTxtPhoneUM = ProjectUtility.CreatePhoneNumberMaskedTextBox();
            // Adds the control to the form's Controls collection.
            this.Controls.Add(MskTxtPhoneUM);
        }


        private void PicBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand("INSERT INTO tbUser(username, fullname, password, phone, roleID) VALUES (@username, @fullname, @password, @phone, (SELECT roleID FROM tbRole WHERE roleName = @roleName))", con))
                        {
                            cm.Parameters.AddWithValue("@username", txtUserNameUM.Text);
                            cm.Parameters.AddWithValue("@fullname", txtFullnameUM.Text);
                            cm.Parameters.AddWithValue("@password", txtPasswordUM.Text);
                            cm.Parameters.AddWithValue("@phone", MskTxtPhoneUM.Text);
                            cm.Parameters.AddWithValue("@roleName", cmbUserRole.SelectedItem.ToString());
                            con.Open();
                            cm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("User has been successfully saved.");
                    Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void BtnClearUM_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdateUM.Enabled = false;

        }

        
        public void Clear()
        {
            if (ChkBxEditUserName.Checked)
            {
                txtUserNameUM.Clear();
                ChkBxEditUserName.Checked = false;
            }
            if (ChkBxEditName.Checked)
            {
                txtFullnameUM.Clear();
                ChkBxEditName.Checked = false;
            }
            if (ChkBxEditPassword.Checked)
            {
                txtPasswordUM.Clear();
                ChkBxEditPassword.Checked = false;
            }
            if (ChkBxEditPhone.Checked)
            {
                MskTxtPhoneUM.Clear();
                ChkBxEditPhone.Checked = false;
            }

            // Updates the state of buttons after clearing the fields and unchecking the checkboxes.
            UpdateButtonStates();
        }


        private void BtnUpdateUM_Click(object sender, EventArgs e)
        {
            try
            {
                // Checks if a role is selected from the combo box
                if (cmbUserRole.SelectedItem == null)
                {
                    MessageBox.Show("Please select a user role!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to update this user?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        con.Open(); // Opens the connection first

                        StringBuilder query = new StringBuilder("UPDATE tbUser SET ");

                        using (SqlCommand cm = new SqlCommand())
                        {
                            cm.Connection = con; // Assigns the connection to the SqlCommand object

                            // Checks each checkbox and appends parameters as necessary
                            if (ChkBxEditRole.Checked)
                            {
                                query.Append("roleID = (SELECT roleID FROM tbRole WHERE roleName = @roleName), ");
                                cm.Parameters.AddWithValue("@roleName", cmbUserRole.SelectedItem.ToString());
                            }

                            if (ChkBxEditUserName.Checked)
                            {
                                query.Append("username = @username, ");
                                cm.Parameters.AddWithValue("@username", txtUserNameUM.Text);
                            }

                            if (ChkBxEditName.Checked)
                            {
                                query.Append("fullname = @fullname, ");
                                cm.Parameters.AddWithValue("@fullname", txtFullnameUM.Text);
                            }

                            if (ChkBxEditPassword.Checked)
                            {
                                query.Append("password = @password, ");
                                cm.Parameters.AddWithValue("@password", txtPasswordUM.Text);
                            }

                            if (ChkBxEditPhone.Checked)
                            {
                                query.Append("phone = @phone, ");
                                cm.Parameters.AddWithValue("@phone", MskTxtPhoneUM.Text);
                            }

                            // Remove the last comma and space if we've added parameters
                            if (query.ToString().EndsWith(", "))
                            {
                                query.Length -= 2;
                            }

                            query.Append(" WHERE userID = @userID");
                            cm.Parameters.AddWithValue("@userID", lblUserID.Text);

                            // Now we set the command text to the query we've built
                            cm.CommandText = query.ToString();

                            cm.ExecuteNonQuery(); // Execute the non-query command
                        }
                    }
                    MessageBox.Show("User has been successfully updated!");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public List<string> GetRolesFromDatabase()
        {
            List<string> roles = new List<string>();
            string sql = "SELECT roleName FROM tbRole";
            using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
            {
                using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            roles.Add(reader["roleName"].ToString());
                        }
                    }
                }
            }
            return roles;
        }
        // Generates user roles from the database
        private void UserModuleForm_Load(object sender, EventArgs e)
        {
            List<string> roles = GetRolesFromDatabase();
            cmbUserRole.Items.Clear();
            cmbUserRole.Items.AddRange(roles.ToArray());

            if (cmbUserRole.Items.Count > 0)
            {
                cmbUserRole.SelectedIndex = 2; // Sets the third item as default
            }

            // Hides user role checkbox if user is manager
            if(RoleHelper.IsManager())
            {
                ChkBxEditRole.Visible = false;
            }
            else
            {
                ChkBxEditRole.Visible = true;

            }

            btnUpdateUM.Enabled = !IsAddButtonClicked;

            UpdateButtonStates();

        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the password for this user?", "Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand cm = new SqlCommand("UPDATE tbUser SET password = @newPassword, IsPasswordReset = 1 WHERE userID = @userID", con))
                    {
                        // Sets default password the hashes it 
                        var newPassword = "password123";
                        var hashedNewPassword = ProjectUtility.HashPassword(newPassword);


                        // Adds parameters to SqlCommand
                        cm.Parameters.AddWithValue("@newPassword", hashedNewPassword); // Sets the new password
                        cm.Parameters.AddWithValue("@userID", lblUserID.Text); 

                        // Opens connection, execute command, and closes connection
                        con.Open();
                        int rowsAffected = cm.ExecuteNonQuery(); // Executes the command and gets the number of affected rows
                        con.Close();

                        // Checks whether the password update was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Password has been reset to {newPassword}!");
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("No user was found with the given ID, or no changes were needed.");
                        }
                    }
                }
            }
        }

        private void UpdateButtonStates()
        {
            bool anyBoxChecked = ChkBxEditRole.Checked || ChkBxEditUserName.Checked 
                               || ChkBxEditName.Checked || ChkBxEditPhone.Checked;
            
            btnUpdateUM.Enabled = anyBoxChecked && !IsAddButtonClicked;
            BtnClearUM.Enabled = anyBoxChecked;
           
        }


        private void ChkBxEditRole_CheckedChanged(object sender, EventArgs e)
        {
            cmbUserRole.Enabled = ChkBxEditRole.Checked;
            UpdateButtonStates();
        }

        private void ChkBxEditUserName_CheckedChanged(object sender, EventArgs e)
        {
            txtUserNameUM.Enabled = ChkBxEditUserName.Checked;
            UpdateButtonStates();
        }

        private void ChkBxEditName_CheckedChanged(object sender, EventArgs e)
        {
            txtFullnameUM.Enabled = ChkBxEditName.Checked;
            UpdateButtonStates();
        }

        private void ChkBxEditPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswordUM.Enabled = ChkBxEditPassword.Checked;
            BtnResetPassword.Enabled = ChkBxEditPassword.Checked;
            UpdateButtonStates();
        }

        private void ChkBxEditPhone_CheckedChanged(object sender, EventArgs e)
        {
            MskTxtPhoneUM.Enabled = ChkBxEditPhone.Checked;
            UpdateButtonStates();
        }

        


    }
}
