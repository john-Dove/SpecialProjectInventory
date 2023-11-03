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
        public static string UserRole { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        // Shows subform form in mainform
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
            {
                activeForm.Close();

            }
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
            // Sets all buttons to false initially
            btncusUsers.Visible = false;
            btncusCustomer.Visible = false;
            btncusCategories.Visible = false;
            btncusProduct.Visible = false;
            btncusOrders.Visible = false;

            // Checks for Admin privileges
            if (RoleHelper.IsAdmin())
            {
                btncusUsers.Visible = true;
                btncusCustomer.Visible = true;
                btncusCategories.Visible = true;
                btncusProduct.Visible = true;
                btncusOrders.Visible = true;
            }

            // Checks for Manager privileges
            if (RoleHelper.IsManager())
            {
                btncusUsers.Visible = true;
                btncusCustomer.Visible = true;
                btncusCategories.Visible = true;
                btncusProduct.Visible = true;
                btncusOrders.Visible = true;
            }

            // Checks for Employee privileges
            if (RoleHelper.IsEmployee())
            {
                btncusOrders.Visible = true;
            }

        }

        private void btncusProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm());
        }

        private void btncusOrders_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Hides the MainForm
            this.Hide();

            // Creates a new instance of the login form and show it
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

            // Closes the MainForm after logging out
            this.Close();

        }
    }
}
