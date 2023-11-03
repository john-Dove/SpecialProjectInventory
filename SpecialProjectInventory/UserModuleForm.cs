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
    public partial class UserModuleForm : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-78II3F3\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True");
        SqlCommand cm = new SqlCommand();


        public UserModuleForm()
        {
            InitializeComponent();
            //InitializePhoneMaskedTextBox();
        }

      /*  private void InitializePhoneMaskedTextBox()
        {
            txtPhoneUM = ProjectUtility.CreatePhoneNumberMaskedTextBox();
            txtPhoneUM.Location = new System.Drawing.Point(*//* your X coordinate *//*, *//* your Y coordinate *//*);
            txtPhoneUM.Name = "txtPhoneUM";
            txtPhoneUM.Size = new System.Drawing.Size(100, 20); // Replace with your dimensions
            this.Controls.Add(txtPhoneUM); // Add it to the form's Controls collection
        }*/

        private void picBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               /* if (txtPasswordUM.Text != txtRepass.Text)
                {
                    MessageBox.Show("Password did not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/


                if (MessageBox.Show("Are you sure you want to save this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand("INSERT INTO tbUser(username, fullname, password, phone, roleID) VALUES (@username, @fullname, @password, @phone, (SELECT roleID FROM tbRole WHERE roleName = @roleName))", con))
                        {
                            cm.Parameters.AddWithValue("@username", txtUserNameUM.Text);
                            cm.Parameters.AddWithValue("@fullname", txtFullnameUM.Text);
                            cm.Parameters.AddWithValue("@password", txtPasswordUM.Text);
                            cm.Parameters.AddWithValue("@phone", txtPhoneUM.Text);
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
            txtUserNameUM.Clear();
            txtFullnameUM.Clear();
            txtPasswordUM.Clear();
            txtPhoneUM.Clear();
        }


        /* private void BtnUpdateUM_Click(object sender, EventArgs e)
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
                         using (SqlCommand cm = new SqlCommand("UPDATE tbUser SET fullname = @fullname, password=@password, phone=@phone, roleID = (SELECT roleID FROM tbRole WHERE roleName = @roleName) WHERE userID = @userID", con))
                         {
                             cm.Parameters.AddWithValue("@username", txtUserNameUM.Text);
                             cm.Parameters.AddWithValue("@fullname", txtFullnameUM.Text);
                             cm.Parameters.AddWithValue("@password", txtPasswordUM.Text);
                             cm.Parameters.AddWithValue("@phone", txtPhoneUM.Text);
                             cm.Parameters.AddWithValue("@roleName", cmbUserRole.SelectedItem.ToString());
                             cm.Parameters.AddWithValue("@userID", lblUserID.Text);
                             con.Open();
                             cm.ExecuteNonQuery();
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
         }*/


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
                        StringBuilder query = new StringBuilder("UPDATE tbUser SET ");


                        // Checking each checkbox and adding to the SQL query
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
                            cm.Parameters.AddWithValue("@phone", txtPhoneUM.Text);
                        }  

                        // Removing the trailing comma and space from our query
                        if (query.ToString().EndsWith(", "))
                            query.Length -= 2;

                        query.Append(" WHERE userID = @userID");
                        cm.Parameters.AddWithValue("@userID", lblUserID.Text);

                        using (SqlCommand cm = new SqlCommand(query.ToString(), con))
                        {
                            con.Open();
                            cm.ExecuteNonQuery();
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

        private void UserModuleForm_Load(object sender, EventArgs e)
        {
            List<string> roles = GetRolesFromDatabase();
            cmbUserRole.Items.Clear();
            cmbUserRole.Items.AddRange(roles.ToArray());

            if (cmbUserRole.Items.Count > 0)
            {
                cmbUserRole.SelectedIndex = 0; // Sets the third item as default
            }

        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the password for this user?", "Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand cm = new SqlCommand("UPDATE tbUser SET password = @defaultPassword, IsPasswordReset = 1 WHERE userID = @userID", con))
                    {
                        cm.Parameters.AddWithValue("@defaultPassword", "password123"); // Default password
                        cm.Parameters.AddWithValue("@userID", lblUserID.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Password has been reset!");
            }

        }

        private void ChkBxEditRole_CheckedChanged(object sender, EventArgs e)
        {
            cmbUserRole.Enabled = ChkBxEditRole.Checked;
        }

        private void ChkBxEditUserName_CheckedChanged(object sender, EventArgs e)
        {
            txtUserNameUM.Enabled = ChkBxEditUserName.Checked;
        }

        private void ChkBxEditName_CheckedChanged(object sender, EventArgs e)
        {
            txtFullnameUM.Enabled = ChkBxEditName.Checked;
        }

        private void ChkBxEditPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswordUM.Enabled = ChkBxEditPassword.Checked;
            BtnResetPassword.Enabled = ChkBxEditPassword.Checked;
        }

        private void ChkBxEditPhone_CheckedChanged(object sender, EventArgs e)
        {
            txtPhoneUM.Enabled = ChkBxEditPhone.Checked;
        }
    }
}
