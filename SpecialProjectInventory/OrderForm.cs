using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class OrderForm : Form
    {


        public OrderForm()
        {
            InitializeComponent();
            LoadOrder();
        }

        public void LoadOrder()
        {
            double total = 0;
            int i = 0;
            dgvOrder.Rows.Clear();

            using (SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
            {
                using (SqlCommand cm = new SqlCommand("SELECT orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price, total  FROM tbOrder AS O JOIN tbCustomer AS C ON O.cid=C.cid JOIN tbProduct AS P ON O.pid=P.pid WHERE CONCAT (orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price) LIKE @search", con))
                {
                    cm.Parameters.AddWithValue("@search", "%" + txtSearchOF.Text + "%");

                    con.Open();
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            i++;
                            dgvOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1]).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                            total += Convert.ToDouble(dr[8]);
                        }
                    }
                }
            }

            lblQty.Text = i.ToString();
            lblTotal.Text = total.ToString("F2");


        }

        private void BtnCusAdd_Click(object sender, EventArgs e)
        {
            OrderModuleForm moduleForm = new OrderModuleForm();
            // moduleForm.btnInsert.Enabled = true;
            //moduleForm.btnOUpdate.Enabled = false;
            moduleForm.ShowDialog();
            LoadOrder();

        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this order?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(@"Your Connection String"))
                    {
                        string deleteQuery = "DELETE FROM tbOrder WHERE orderid LIKE @orderId";

                        using (SqlCommand cm = new SqlCommand(deleteQuery, con))
                        {
                            cm.Parameters.AddWithValue("@orderId", dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString());

                            con.Open();
                            cm.ExecuteNonQuery();
                        }

                        MessageBox.Show("Record has been successfully deleted!");

                        string updateQuery = "UPDATE tbProduct SET pqty = (pqty + @pqty) WHERE pid LIKE @pid";

                        using (SqlCommand cm = new SqlCommand(updateQuery, con))
                        {
                            cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));
                            cm.Parameters.AddWithValue("@pid", dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString());

                            con.Open();
                            cm.ExecuteNonQuery();
                        }
                    }
                }
            }
            LoadOrder();
        }


        private void txtSearchOF_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }
    }
}
