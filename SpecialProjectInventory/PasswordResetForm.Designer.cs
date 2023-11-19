namespace SpecialProjectInventory
{
    partial class PasswordResetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LblUserName = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.LblCurrentPassword = new System.Windows.Forms.Label();
            this.TxtCurrentPassword = new System.Windows.Forms.TextBox();
            this.LblConfirmPassword = new System.Windows.Forms.Label();
            this.TxtConfirmPassword = new System.Windows.Forms.TextBox();
            this.BtnChangePassword = new System.Windows.Forms.Button();
            this.LblNewPassword = new System.Windows.Forms.Label();
            this.TxtNewPassword = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.BtnClearPassword = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 54);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Change Password";
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUserName.Location = new System.Drawing.Point(120, 107);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(85, 17);
            this.LblUserName.TabIndex = 18;
            this.LblUserName.Text = "User Name :";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Enabled = false;
            this.TxtUserName.Location = new System.Drawing.Point(211, 107);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(299, 20);
            this.TxtUserName.TabIndex = 19;
            // 
            // LblCurrentPassword
            // 
            this.LblCurrentPassword.AutoSize = true;
            this.LblCurrentPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrentPassword.Location = new System.Drawing.Point(76, 161);
            this.LblCurrentPassword.Name = "LblCurrentPassword";
            this.LblCurrentPassword.Size = new System.Drawing.Size(129, 17);
            this.LblCurrentPassword.TabIndex = 22;
            this.LblCurrentPassword.Text = "Current Password :";
            // 
            // TxtCurrentPassword
            // 
            this.TxtCurrentPassword.Location = new System.Drawing.Point(211, 161);
            this.TxtCurrentPassword.Name = "TxtCurrentPassword";
            this.TxtCurrentPassword.Size = new System.Drawing.Size(299, 20);
            this.TxtCurrentPassword.TabIndex = 23;
            this.TxtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // LblConfirmPassword
            // 
            this.LblConfirmPassword.AutoSize = true;
            this.LblConfirmPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblConfirmPassword.Location = new System.Drawing.Point(75, 269);
            this.LblConfirmPassword.Name = "LblConfirmPassword";
            this.LblConfirmPassword.Size = new System.Drawing.Size(130, 17);
            this.LblConfirmPassword.TabIndex = 24;
            this.LblConfirmPassword.Text = "Re-enter Password:";
            // 
            // TxtConfirmPassword
            // 
            this.TxtConfirmPassword.Location = new System.Drawing.Point(211, 269);
            this.TxtConfirmPassword.Name = "TxtConfirmPassword";
            this.TxtConfirmPassword.Size = new System.Drawing.Size(299, 20);
            this.TxtConfirmPassword.TabIndex = 25;
            this.TxtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // BtnChangePassword
            // 
            this.BtnChangePassword.BackColor = System.Drawing.Color.Green;
            this.BtnChangePassword.FlatAppearance.BorderSize = 0;
            this.BtnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnChangePassword.ForeColor = System.Drawing.Color.White;
            this.BtnChangePassword.Location = new System.Drawing.Point(212, 325);
            this.BtnChangePassword.Name = "BtnChangePassword";
            this.BtnChangePassword.Size = new System.Drawing.Size(140, 38);
            this.BtnChangePassword.TabIndex = 26;
            this.BtnChangePassword.Text = "Change Password";
            this.BtnChangePassword.UseVisualStyleBackColor = false;
            this.BtnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // LblNewPassword
            // 
            this.LblNewPassword.AutoSize = true;
            this.LblNewPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNewPassword.Location = new System.Drawing.Point(98, 215);
            this.LblNewPassword.Name = "LblNewPassword";
            this.LblNewPassword.Size = new System.Drawing.Size(107, 17);
            this.LblNewPassword.TabIndex = 29;
            this.LblNewPassword.Text = "New Password:";
            // 
            // TxtNewPassword
            // 
            this.TxtNewPassword.Location = new System.Drawing.Point(211, 215);
            this.TxtNewPassword.Name = "TxtNewPassword";
            this.TxtNewPassword.Size = new System.Drawing.Size(299, 20);
            this.TxtNewPassword.TabIndex = 30;
            this.TxtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(167, 77);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(38, 13);
            this.lblUserID.TabIndex = 31;
            this.lblUserID.Text = "userID";
            this.lblUserID.Visible = false;
            // 
            // BtnClearPassword
            // 
            this.BtnClearPassword.BackColor = System.Drawing.Color.Red;
            this.BtnClearPassword.FlatAppearance.BorderSize = 0;
            this.BtnClearPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearPassword.ForeColor = System.Drawing.Color.White;
            this.BtnClearPassword.Location = new System.Drawing.Point(370, 325);
            this.BtnClearPassword.Name = "BtnClearPassword";
            this.BtnClearPassword.Size = new System.Drawing.Size(140, 38);
            this.BtnClearPassword.TabIndex = 28;
            this.BtnClearPassword.Text = "Clear";
            this.BtnClearPassword.UseVisualStyleBackColor = false;
            this.BtnClearPassword.Click += new System.EventHandler(this.BtnClearPassword_Click);
            // 
            // PasswordResetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 406);
            this.ControlBox = false;
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.TxtNewPassword);
            this.Controls.Add(this.LblNewPassword);
            this.Controls.Add(this.BtnClearPassword);
            this.Controls.Add(this.BtnChangePassword);
            this.Controls.Add(this.TxtConfirmPassword);
            this.Controls.Add(this.LblConfirmPassword);
            this.Controls.Add(this.TxtCurrentPassword);
            this.Controls.Add(this.LblCurrentPassword);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordResetForm";
            this.Text = "PasswordResetForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblUserName;
        public System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label LblCurrentPassword;
        public System.Windows.Forms.TextBox TxtCurrentPassword;
        private System.Windows.Forms.Label LblConfirmPassword;
        public System.Windows.Forms.TextBox TxtConfirmPassword;
        public System.Windows.Forms.Button BtnChangePassword;
        private System.Windows.Forms.Label LblNewPassword;
        public System.Windows.Forms.TextBox TxtNewPassword;
        public System.Windows.Forms.Label lblUserID;
        public System.Windows.Forms.Button BtnClearPassword;
    }
}