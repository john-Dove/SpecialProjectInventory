using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class OrderModuleForm : Form
    {
        SqlConnection con = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString);
        SqlCommand cm = new SqlCommand();
  
        SqlDataReader dr;
        int qty = 0;            //ensures that amount ordering doesnt goes over what is in stock con't

        public OrderModuleForm()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }

        private void picBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            

        }

        public void LoadCustomer()  //allows data in the system to show in the data grid view here on the order form page when some thing is types in the search box
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT cid, cname FROM tbCustomer WHERE CONCAT(cid,cname) LIKE '%"+txtSearchCust.Text+"%'", con);  // should be tbCustomer <--- recheck back this
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();


        }

        public void LoadProduct()  //allows data in the system to show in the data grid view here
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%"+txtSearchProd.Text+"%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();


        }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();     //find items stored in the customer table when type
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();       //find items stored in the products table when type
        }
   
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetQty();

            if (UDQty.Value > qty) // Ensures that the ordering amount doesn't go over what is in stock
            {
                MessageBox.Show("In-stock quantity is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UDQty.Value = UDQty.Value - 1;
                return;
            }

            if (UDQty.Value > 0)
            {
                // Use decimal for price to handle money values correctly
                decimal total = Convert.ToDecimal(txtPrice.Text) * UDQty.Value;
                txtTotal.Text = total.ToString();
            }



        }

        private void DgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCld.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCname.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();


        }

        private void DgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
           // qty = Convert.ToInt16(dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString());        //ensures that amount ordering doesnt goes over what is in stock con't


        }

        /* private void BtnInsert_Click(object sender, EventArgs e)
         {
             try
             {
                 if (txtCld.Text == "")
                 {
                     MessageBox.Show("Please select a customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
                 if (txtPid.Text == "")
                 {
                     MessageBox.Show("Please select a product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }

                 if (MessageBox.Show("Are you sure you want to Insert this order?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     cm = new SqlCommand("INSERT INTO tbOrder(odate, pid, cid, qty, price, total) VALUES (@odate, @pid, @cid, @qty, @price, @total)", con);
                     cm.Parameters.AddWithValue("@odate", dtOrder.Value);
                     cm.Parameters.AddWithValue("@pid", Convert.ToInt32(txtPid.Text));
                     cm.Parameters.AddWithValue("@cid", Convert.ToInt32(txtCld.Text));
                     cm.Parameters.AddWithValue("@qty", Convert.ToInt32(UDQty.Value));
                     cm.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                     cm.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotal.Text));
                     con.Open();
                     cm.ExecuteNonQuery();
                     con.Close();
                     MessageBox.Show("Order has been successfully Inserted.");
                     //Clear();

                     cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty-@pqty) WHERE pid LIKE '"+ txtPid.Text +"' ", con);     // as a part with quantity not going over what is in stock
                     cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(UDQty.Value));

                     con.Open();
                     cm.ExecuteNonQuery();
                     con.Close();
                     Clear();
                     LoadProduct();      //loads new product list after and order has been made

                 }


             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }


         }*/

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCld.Text == "")
                {
                    MessageBox.Show("Please select a customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPid.Text == "")
                {
                    MessageBox.Show("Please select a product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to Insert this order?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Inserts the order into tbOrder
                    cm = new SqlCommand("INSERT INTO tbOrder(odate, pid, cid, qty, price, total) VALUES (@odate, @pid, @cid, @qty, @price, @total)", con);
                    cm.Parameters.AddWithValue("@odate", dtOrder.Value);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt32(txtPid.Text));
                    cm.Parameters.AddWithValue("@cid", Convert.ToInt32(txtCld.Text));
                    cm.Parameters.AddWithValue("@qty", Convert.ToInt32(UDQty.Value));
                    cm.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                    cm.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotal.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Order has been successfully Inserted.");

                    // Deducts the quantity from tbProduct
                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty-@pqty) WHERE pid LIKE '" + txtPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(UDQty.Value));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    Clear();
                    LoadProduct(); //loads new product list after and order has been made

                    // Record the sale for analytics
                    SalesUtility.RecordSale(
                        productId: Convert.ToInt32(txtPid.Text),
                        quantitySold: Convert.ToInt32(UDQty.Value),
                        totalAmount: Convert.ToDecimal(txtTotal.Text),
                        saleDate: dtOrder.Value,
                        customerId: Convert.ToInt32(txtCld.Text)
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void Clear() 
        {
            txtCld.Clear();
            txtCname.Clear();
            
            txtPid.Clear();
            txtPName.Clear();
            
            txtPrice.Clear();
            UDQty.Value = 0;
            txtTotal.Clear();
            dtOrder.Value = DateTime.Now;


        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
            //btnInsert.Enabled = true;
            //btnOUpdate.Enabled = false;

        }

        public void GetQty()
        {                                                       //THIS EQUAL SYMBOL MIGHT BE WRONG 2:23:54
            cm = new SqlCommand("SELECT pqty FROM tbProduct WHERE pid = @pid", con);
            cm.Parameters.AddWithValue("@pid", txtPid.Text);    //this code was written for this "Instock quantity is not enough!"
            con.Open();                                                                                 //error message when attemting to update or delete an order
            dr = cm.ExecuteReader();
            if (dr.Read())
            {
                qty = Convert.ToInt32(dr["pqty"].ToString());
            }
            dr.Close();
            con.Close();
        }
        
    }
}
