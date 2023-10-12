using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /*private void customerButton1_Click(object sender, EventArgs e)
        {
            this was taken out and placed, then main forms stop showing, there a code in main from.cs add to commented out
        }*/

        //to show subform form in mainform
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null) 
               activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panMain.Controls.Add(childForm);
            panMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            

            
        }

        private void btncusUsers_Click(object sender, EventArgs e)
        {
            openChildForm(new UserformForm());
        }

        private void btncusCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerForm());
        }

        private void btncusCategories_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoryForm());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btncusProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm());
        }

        private void btncusOrders_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
        }
    }
}
