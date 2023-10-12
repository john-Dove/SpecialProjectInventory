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
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-78II3F3\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;


        public UserformForm()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()  //allows data in the system to show in the data grid view here
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM  tbUser", con);
            con.Open();
            dr = cm.ExecuteReader();
            while(dr.Read()) 
            {
                i++;
                dgvUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();


        }

        private void btncusAdd_Click(object sender, EventArgs e)        //user add button 
        {//these are realted to the plus special button and its features
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdateUM.Enabled = false;
            userModule.ShowDialog();
            LoadUser();

        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            else if(colName == "Delete")
            {
                if(MessageBox.Show("Are you sure you want to delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbUser WHERE username LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");


                }
    

            }
            LoadUser();

        }
    }
}
