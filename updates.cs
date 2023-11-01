public partial class ProductForm : Form
{
    SqlCommand cm = new SqlCommand();
    SqlDataReader dr;

    public ProductForm()
    {
        InitializeComponent();
        LoadProduct();
    }

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
                while (dr.Read())
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

    private void btncatAdd_Click(object sender, EventArgs e)
    {
        ProductModuleForm formModule = new ProductModuleForm();
        formModule.btnSavePM.Enabled = true;
        formModule.btnUpdatePM.Enabled = false;
        formModule.ShowDialog();
        LoadProduct();
    }

    private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        string colName = dgvProduct.Columns[e.ColumnIndex].Name;
        if (colName == "Edit")
        {
            // ... (your existing code unchanged)
        }
        else if (colName == "Delete")
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
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while connecting to the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        LoadProduct();
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        LoadProduct();
    }
}
