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
    public partial class UserformForm : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-78II3F3\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True");
        
        public UserformForm()
        {
            InitializeComponent();
            LoadUser();
        }

        /* ORIGINAL*/
        /*public void LoadUser()  //allows data in the system to show in the data grid view here
        {
            int i = 0;
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
                            dgvUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                            i++;
                        }
                    }
                }
            }

        }*/

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
                                             dr["password"]?.ToString() ?? string.Empty,
                                             dr["phone"]?.ToString() ?? string.Empty,
                                             null,  // Placeholder for Edit image column
                                             null); // Placeholder for Delete image column
                        }
                    }
                }
            }
        }


        private void btncusAdd_Click(object sender, EventArgs e)  //user add button 
        {//these are related to the plus special button and its features
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdateUM.Enabled = false;
            userModule.ShowDialog();
            LoadUser();

        }
        /*ORIGINAL*/
        /*private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {//allows the pencil icon which is named "Edit" to edit user info also trash can to delete 
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if(colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm();
                userModule.txtUserNameUM.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtFullnameUM.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtPasswordUM.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtPhoneUM.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                userModule.btnSave.Enabled=false;
                userModule.btnUpdateUM.Enabled=true;
                userModule.txtUserNameUM.Enabled = false;  //when userModule form comes up the username is not highlighted
                userModule.ShowDialog();

            }
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand("DELETE FROM tbUser WHERE username LIKE @username", con))
                        {
                            cm.Parameters.AddWithValue("@username", dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString());
                            con.Open();
                            cm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Record has been successfully deleted!");
                }

            }
            LoadUser();

        }*/

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm();

                userModule.lblUserID.Text = dgvUser.Rows[e.RowIndex].Cells["userID"].Value.ToString(); // NEW
                userModule.txtUserNameUM.Text = dgvUser.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                userModule.txtFullnameUM.Text = dgvUser.Rows[e.RowIndex].Cells["fullName"].Value.ToString();
                userModule.txtPasswordUM.Text = dgvUser.Rows[e.RowIndex].Cells["password"].Value.ToString();
                userModule.txtPhoneUM.Text = dgvUser.Rows[e.RowIndex].Cells["phoneNum"].Value.ToString();

                userModule.btnSave.Enabled = false;
                userModule.btnUpdateUM.Enabled = true;
                userModule.txtUserNameUM.Enabled = false;
                userModule.ShowDialog();
            }
            if (colName == "Delete")
            {
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
                    LoadUser();
                }
            }
        }



    }
}
