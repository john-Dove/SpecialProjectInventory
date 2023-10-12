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
    public partial class OrderForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-78II3F3\SQLEXPRESS;Initial Catalog=SpecialProjectDBs;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

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
            cm = new SqlCommand("SELECT orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price, total  FROM tbOrder AS O JOIN tbCustomer AS C ON O.cid=C.cid JOIN tbProduct AS P ON O.pid=P.pid WHERE CONCAT (orderid, odate, O.pid, P.pname, O.cid, C.cname, qty, price) LIKE '%"+ txtSearchOF.Text+"%' ", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(),Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                total += Convert.ToInt32(dr[8].ToString());
            }
            dr.Close();
            con.Close();

            lblQty.Text = i.ToString();
            lblTotal.Text = total.ToString();

        }

        private void btncusAdd_Click(object sender, EventArgs e)     //order add plus/button
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
           /* if (colName == "Edit")  the edit section on the order form
            {
                OrderModuleForm formModule = new OrderModuleForm();
                formModule.lblOid.Text = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                formModule.dtOrder.Text = dgvOrder.Rows[e.RowIndex].Cells[2].Value.ToString();
                formModule.txtPid.Text = dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString();
                formModule.txtCld.Text = dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString();
                formModule.UDQty.Value =Convert.ToInt32(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString());
                formModule.txtPrice.Text = dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString();

                formModule.btnInsert.Enabled = false;
                formModule.btnOUpdate.Enabled = true;
                formModule.ShowDialog();

            }*/
             if (colName == "Delete")
             {
                if (MessageBox.Show("Are you sure you want to delete this order?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbOrder WHERE orderid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");


                    //when am order has been deleted amount is added back into the system
                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty+@pqty) WHERE pid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);     // as a part with quantity not going over what is in stock
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

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
