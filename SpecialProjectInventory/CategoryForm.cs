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
    public partial class CategoryForm : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-78II3F3\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public CategoryForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()  //allows data in the system to show in the data grid view here
        {
            int i = 0;
            dgvCategory.Rows.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                {
                    cm = new SqlCommand("Select * from tbCategory", connection);
                    connection.Open();
                    dr = cm.ExecuteReader();

                    while(dr.Read())
                    {
                        i++;
                        dgvCategory.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while connecting to the database: " + ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncatAdd_Click(object sender, EventArgs e)
        {
            CategoryModuleForm formModule = new CategoryModuleForm();
            formModule.btnSaveCM.Enabled = true;
            formModule.btnUpdateCM.Enabled = false;
            formModule.ShowDialog();
            LoadCategory();


        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CategoryModuleForm formModule = new CategoryModuleForm();
                formModule.lblCatld.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                formModule.txtCatName.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();

                formModule.btnSaveCM.Enabled = false;
                formModule.btnUpdateCM.Enabled = true;
                formModule.ShowDialog();

            }
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                        {
                            connection.Open();
                            cm = new SqlCommand("DELETE FROM tbCategory WHERE catid =@catid", connection);
                            cm.Parameters.AddWithValue("@catid", dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString());
                            cm.ExecuteNonQuery();
                        }
                        MessageBox.Show("Record has been successfully deleted!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while connecting to the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
            LoadCategory(); 

        }
    }
}
