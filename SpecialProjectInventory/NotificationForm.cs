using System;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class NotificationForm : Form
    {
        public NotificationForm(string message)
        {
            InitializeComponent();
            LblNotification.Text = message;
        }

        private void BtnCloseNote_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnShowAlerts_Click(object sender, EventArgs e)
        {
            /* AlertsForm alertsForm = new AlertsForm();
             alertsForm.ShowDialog();*/
            //OpenChildForm(new AlertsForm());
        }
    }
}
