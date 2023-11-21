using System;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class NotificationForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly string _userRole; // Adds this to store the user role

        // Updates the constructor to accept the user role
        public NotificationForm(MainForm mainForm, string message, string userRole)
        {
            InitializeComponent();
            _mainForm = mainForm;
            LblNotification.Text = message;
            _userRole = userRole; // Stores the user role
        }

        private void BtnShowAlerts_Click(object sender, EventArgs e)
        {
            // Passes the user role to the AlertsForm
            AlertsForm alertsForm = new AlertsForm(_userRole);
            alertsForm.LoadAlerts(); // Ensures that the AlertsForm loads its data.
            _mainForm.OpenChildForm(alertsForm);
        }

        private void BtnCloseNote_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
