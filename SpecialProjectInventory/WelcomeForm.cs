using System;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
            timer1.Start();

        }

        int startPoint = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 2;
            progressBar1.Value = startPoint;
            if(progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                LoginForm login = new LoginForm();
                Hide();
                login.ShowDialog();

            }


        }
    }
}
