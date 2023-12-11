using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpecialProjectInventory
{// all these codes went towards building a special type of picture box place in top panel of main form
    public partial class CustomerButton : PictureBox //this was changes to picture box from usercontrol
    {
        public CustomerButton()
        {
            InitializeComponent();
        }

        private Image NormalImage;
        private Image HoverImage;


        public Image ImageNormal
        {
            get { return NormalImage; }
            set { NormalImage = value; }
        }


        public Image ImageHover
        {
            get { return HoverImage; }
            set { HoverImage = value; }
        }

        private void CustomerBotton_MouseHover(object sender, EventArgs e)
        {
            this.Image = HoverImage;
        }

        private void CustomerButton_MouseLeave(object sender, EventArgs e)
        {
            this.Image = NormalImage;
        }
    }
}
