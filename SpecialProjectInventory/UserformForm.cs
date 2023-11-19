using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class UserformForm : Form
    {        
        public UserformForm()
        {
            InitializeComponent();
            LoadUser();
        }
        
        public void LoadUser()
        {
            dgvUser.Rows.Clear();
            using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
            {
                using (SqlCommand cm = new SqlCommand("SELECT * FROM tbUser", con))
                {
                    con.Open();
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dgvUser.Rows.Add(dr["userID"]?.ToString() ?? string.Empty,
                                             dr["username"]?.ToString() ?? string.Empty,
                                             dr["fullname"]?.ToString() ?? string.Empty,
                                             //dr["password"]?.ToString() ?? string.Empty,
                                             "********", // Replaces the password field 
                                             dr["phone"]?.ToString() ?? string.Empty,
                                             null,  // Placeholder for edit image column
                                             null); // Placeholder for delete image column
                        }
                    }
                }
            }
        }

        // Invokes the LoadUser method if the correct role is established
        private void BtncusAdd_Click(object sender, EventArgs e)  
        {
            // Checks whether the user's role grants permission
            if (RoleHelper.IsManager())
            {
                MessageBox.Show("You do not have permission to add new users.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Prevents the manager from adding new users
            }
            // User related controls
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.IsAddButtonClicked = true;
            userModule.DisableUpdateButtonIfAddClicked();
            userModule.EnableAllCheckBoxes();

            userModule.ShowDialog();
            LoadUser();

        }
        // Manages the operations based on the control selected 
        private void DgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;

           
            if (colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm();

                userModule.lblUserID.Text = dgvUser.Rows[e.RowIndex].Cells["userID"].Value.ToString(); 
                userModule.txtUserNameUM.Text = dgvUser.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                userModule.txtFullnameUM.Text = dgvUser.Rows[e.RowIndex].Cells["fullName"].Value.ToString();
                userModule.txtPasswordUM.Text = dgvUser.Rows[e.RowIndex].Cells["password"].Value.ToString();
                userModule.MskTxtPhoneUM.Text = dgvUser.Rows[e.RowIndex].Cells["phoneNum"].Value.ToString();

                userModule.btnSave.Enabled = false;
                userModule.txtUserNameUM.Enabled = false;
                userModule.btnUpdateUM.Enabled = RoleHelper.IsManager();
                userModule.ShowDialog();

            }
            if (colName == "Delete")
            {

                if (RoleHelper.IsManager())
                {
                    MessageBox.Show("You do not have permission to delete users.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Prevents the manager from deleting users
                }

                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand("DELETE FROM tbUser WHERE userID = @userID", con))
                        {
                            cm.Parameters.AddWithValue("@userID", dgvUser.Rows[e.RowIndex].Cells["userID"].Value.ToString());
                            con.Open();
                            cm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Record has been successfully deleted!"); 
                }
            }
            LoadUser();
        }



    }
}
