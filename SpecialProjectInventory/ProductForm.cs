using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class ProductForm : Form
    {
        
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public ProductForm()
        {
            InitializeComponent();
            LoadProduct();
        }
        // Populates the data grid with data from the system
        public void LoadProduct()  
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            string searchQuery = "%" + txtSearch.Text + "%";
            try
            {
                using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                {
                    cm = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE @search", connection);
                    cm.Parameters.AddWithValue("@search", searchQuery);
                    connection.Open();
                    dr = cm.ExecuteReader();    
                    while(dr.Read())
                    {
                        i++;
                        dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());

                    }
                    dr.Close();
                }

             }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while connecting to the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

    }

        private void BtnCatAdd_Click(object sender, EventArgs e)
        {
            ProductModuleForm formModule = new ProductModuleForm();
            formModule.btnSavePM.Enabled = true;
            formModule.btnUpdatePM.Enabled = false;
            formModule.ShowDialog();
            LoadProduct();


        }

        private void DgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            bool isEmployee = CheckUserRole("Employee");
            if (colName == "Edit")
            {
                ProductModuleForm productModule = new ProductModuleForm();
                int productId = Convert.ToInt32(dgvProduct.Rows[e.RowIndex].Cells[1].Value);
                productModule.EditingProductId = productId;
                productModule.LblPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.txtPQTY.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.txtPprice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.txtPDes.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.CmbCatCategory.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();


                productModule.btnSavePM.Enabled = false;
                productModule.btnUpdatePM.Enabled = true;
                productModule.ShowDialog();

            }
            if (colName == "Delete" && !isEmployee)
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
                        {
                            connection.Open();
                            cm = new SqlCommand("DELETE FROM tbProduct WHERE pid = @pid", connection);
                            cm.Parameters.AddWithValue("@pid", dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString());
                            cm.ExecuteNonQuery();
                        }
                        MessageBox.Show("Record has been successfully deleted!");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("An error occurred while connecting to the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
               if (colName == "Delete") MessageBox.Show("You do not have permission to delete products.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            LoadProduct();

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();

        }

        private bool CheckUserRole(string roleName)
        {
            
            return MainForm.UserRole == roleName;
        }
    }
}
