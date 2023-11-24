namespace SpecialProjectInventory
{
    partial class UserModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserModuleForm));
            this.PnlUserModule = new System.Windows.Forms.Panel();
            this.picBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserNameUM = new System.Windows.Forms.TextBox();
            this.txtFullnameUM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPasswordUM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdateUM = new System.Windows.Forms.Button();
            this.BtnClearUM = new System.Windows.Forms.Button();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.cmbUserRole = new System.Windows.Forms.ComboBox();
            this.BtnResetPassword = new System.Windows.Forms.Button();
            this.ChkBxEditRole = new System.Windows.Forms.CheckBox();
            this.ChkBxEditUserName = new System.Windows.Forms.CheckBox();
            this.ChkBxEditName = new System.Windows.Forms.CheckBox();
            this.ChkBxEditPassword = new System.Windows.Forms.CheckBox();
            this.ChkBxEditPhone = new System.Windows.Forms.CheckBox();
            this.MskTxtPhoneUM = new System.Windows.Forms.MaskedTextBox();
            this.PnlUserModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlUserModule
            // 
            this.PnlUserModule.BackColor = System.Drawing.Color.Red;
            this.PnlUserModule.Controls.Add(this.picBoxClose);
            this.PnlUserModule.Controls.Add(this.label1);
            this.PnlUserModule.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlUserModule.Location = new System.Drawing.Point(0, 0);
            this.PnlUserModule.Name = "PnlUserModule";
            this.PnlUserModule.Size = new System.Drawing.Size(799, 54);
            this.PnlUserModule.TabIndex = 0;
            // 
            // picBoxClose
            // 
            this.picBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("picBoxClose.Image")));
            this.picBoxClose.Location = new System.Drawing.Point(744, 3);
            this.picBoxClose.Name = "picBoxClose";
            this.picBoxClose.Size = new System.Drawing.Size(43, 47);
            this.picBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxClose.TabIndex = 12;
            this.picBoxClose.TabStop = false;
            this.picBoxClose.Click += new System.EventHandler(this.PicBoxClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Module";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name :";
            // 
            // txtUserNameUM
            // 
            this.txtUserNameUM.Enabled = false;
            this.txtUserNameUM.Location = new System.Drawing.Point(155, 141);
            this.txtUserNameUM.Name = "txtUserNameUM";
            this.txtUserNameUM.Size = new System.Drawing.Size(560, 20);
            this.txtUserNameUM.TabIndex = 2;
            // 
            // txtFullnameUM
            // 
            this.txtFullnameUM.Enabled = false;
            this.txtFullnameUM.Location = new System.Drawing.Point(155, 191);
            this.txtFullnameUM.Name = "txtFullnameUM";
            this.txtFullnameUM.Size = new System.Drawing.Size(560, 20);
            this.txtFullnameUM.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Full Name :";
            // 
            // txtPasswordUM
            // 
            this.txtPasswordUM.Enabled = false;
            this.txtPasswordUM.Location = new System.Drawing.Point(155, 241);
            this.txtPasswordUM.Name = "txtPasswordUM";
            this.txtPasswordUM.Size = new System.Drawing.Size(560, 20);
            this.txtPasswordUM.TabIndex = 6;
            this.txtPasswordUM.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(77, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Phone :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(227, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 38);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnUpdateUM
            // 
            this.btnUpdateUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdateUM.Enabled = false;
            this.btnUpdateUM.FlatAppearance.BorderSize = 0;
            this.btnUpdateUM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateUM.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUM.Location = new System.Drawing.Point(358, 344);
            this.btnUpdateUM.Name = "btnUpdateUM";
            this.btnUpdateUM.Size = new System.Drawing.Size(93, 38);
            this.btnUpdateUM.TabIndex = 10;
            this.btnUpdateUM.Text = "Update";
            this.btnUpdateUM.UseVisualStyleBackColor = false;
            this.btnUpdateUM.Click += new System.EventHandler(this.BtnUpdateUM_Click);
            // 
            // BtnClearUM
            // 
            this.BtnClearUM.BackColor = System.Drawing.Color.Red;
            this.BtnClearUM.Enabled = false;
            this.BtnClearUM.FlatAppearance.BorderSize = 0;
            this.BtnClearUM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearUM.ForeColor = System.Drawing.Color.White;
            this.BtnClearUM.Location = new System.Drawing.Point(489, 344);
            this.BtnClearUM.Name = "BtnClearUM";
            this.BtnClearUM.Size = new System.Drawing.Size(93, 38);
            this.BtnClearUM.TabIndex = 11;
            this.BtnClearUM.Text = "Clear";
            this.BtnClearUM.UseVisualStyleBackColor = false;
            this.BtnClearUM.Click += new System.EventHandler(this.BtnClearUM_Click);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(10, 62);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(0, 13);
            this.lblUserID.TabIndex = 14;
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserRole.Location = new System.Drawing.Point(65, 91);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(69, 17);
            this.lblUserRole.TabIndex = 15;
            this.lblUserRole.Text = "User Role:";
            // 
            // cmbUserRole
            // 
            this.cmbUserRole.Enabled = false;
            this.cmbUserRole.FormattingEnabled = true;
            this.cmbUserRole.Items.AddRange(new object[] {
            "Select a role"});
            this.cmbUserRole.Location = new System.Drawing.Point(155, 90);
            this.cmbUserRole.Name = "cmbUserRole";
            this.cmbUserRole.Size = new System.Drawing.Size(560, 21);
            this.cmbUserRole.TabIndex = 16;
            // 
            // BtnResetPassword
            // 
            this.BtnResetPassword.BackColor = System.Drawing.Color.Sienna;
            this.BtnResetPassword.Enabled = false;
            this.BtnResetPassword.FlatAppearance.BorderSize = 0;
            this.BtnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnResetPassword.ForeColor = System.Drawing.Color.White;
            this.BtnResetPassword.Location = new System.Drawing.Point(620, 344);
            this.BtnResetPassword.Name = "BtnResetPassword";
            this.BtnResetPassword.Size = new System.Drawing.Size(93, 38);
            this.BtnResetPassword.TabIndex = 17;
            this.BtnResetPassword.Text = "Reset Password";
            this.BtnResetPassword.UseVisualStyleBackColor = false;
            this.BtnResetPassword.Click += new System.EventHandler(this.BtnResetPassword_Click);
            // 
            // ChkBxEditRole
            // 
            this.ChkBxEditRole.AutoSize = true;
            this.ChkBxEditRole.Location = new System.Drawing.Point(731, 97);
            this.ChkBxEditRole.Name = "ChkBxEditRole";
            this.ChkBxEditRole.Size = new System.Drawing.Size(15, 14);
            this.ChkBxEditRole.TabIndex = 18;
            this.ChkBxEditRole.UseVisualStyleBackColor = true;
            this.ChkBxEditRole.CheckedChanged += new System.EventHandler(this.ChkBxEditRole_CheckedChanged);
            // 
            // ChkBxEditUserName
            // 
            this.ChkBxEditUserName.AutoSize = true;
            this.ChkBxEditUserName.Location = new System.Drawing.Point(731, 147);
            this.ChkBxEditUserName.Name = "ChkBxEditUserName";
            this.ChkBxEditUserName.Size = new System.Drawing.Size(15, 14);
            this.ChkBxEditUserName.TabIndex = 19;
            this.ChkBxEditUserName.UseVisualStyleBackColor = true;
            this.ChkBxEditUserName.CheckedChanged += new System.EventHandler(this.ChkBxEditUserName_CheckedChanged);
            // 
            // ChkBxEditName
            // 
            this.ChkBxEditName.AutoSize = true;
            this.ChkBxEditName.Location = new System.Drawing.Point(731, 197);
            this.ChkBxEditName.Name = "ChkBxEditName";
            this.ChkBxEditName.Size = new System.Drawing.Size(15, 14);
            this.ChkBxEditName.TabIndex = 20;
            this.ChkBxEditName.UseVisualStyleBackColor = true;
            this.ChkBxEditName.CheckedChanged += new System.EventHandler(this.ChkBxEditName_CheckedChanged);
            // 
            // ChkBxEditPassword
            // 
            this.ChkBxEditPassword.AutoSize = true;
            this.ChkBxEditPassword.Location = new System.Drawing.Point(731, 247);
            this.ChkBxEditPassword.Name = "ChkBxEditPassword";
            this.ChkBxEditPassword.Size = new System.Drawing.Size(15, 14);
            this.ChkBxEditPassword.TabIndex = 21;
            this.ChkBxEditPassword.UseVisualStyleBackColor = true;
            this.ChkBxEditPassword.CheckedChanged += new System.EventHandler(this.ChkBxEditPassword_CheckedChanged);
            // 
            // ChkBxEditPhone
            // 
            this.ChkBxEditPhone.AutoSize = true;
            this.ChkBxEditPhone.Location = new System.Drawing.Point(731, 297);
            this.ChkBxEditPhone.Name = "ChkBxEditPhone";
            this.ChkBxEditPhone.Size = new System.Drawing.Size(15, 14);
            this.ChkBxEditPhone.TabIndex = 22;
            this.ChkBxEditPhone.UseVisualStyleBackColor = true;
            this.ChkBxEditPhone.CheckedChanged += new System.EventHandler(this.ChkBxEditPhone_CheckedChanged);
            // 
            // MskTxtPhoneUM
            // 
            this.MskTxtPhoneUM.Enabled = false;
            this.MskTxtPhoneUM.Location = new System.Drawing.Point(155, 288);
            this.MskTxtPhoneUM.Mask = "(999) 999-9999";
            this.MskTxtPhoneUM.Name = "MskTxtPhoneUM";
            this.MskTxtPhoneUM.Size = new System.Drawing.Size(560, 20);
            this.MskTxtPhoneUM.TabIndex = 23;
            // 
            // UserModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 416);
            this.Controls.Add(this.MskTxtPhoneUM);
            this.Controls.Add(this.ChkBxEditPhone);
            this.Controls.Add(this.ChkBxEditPassword);
            this.Controls.Add(this.ChkBxEditName);
            this.Controls.Add(this.ChkBxEditUserName);
            this.Controls.Add(this.ChkBxEditRole);
            this.Controls.Add(this.BtnResetPassword);
            this.Controls.Add(this.cmbUserRole);
            this.Controls.Add(this.lblUserRole);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.BtnClearUM);
            this.Controls.Add(this.btnUpdateUM);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPasswordUM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFullnameUM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserNameUM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PnlUserModule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserModuleForm";
            this.Load += new System.EventHandler(this.UserModuleForm_Load);
            this.PnlUserModule.ResumeLayout(false);
            this.PnlUserModule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlUserModule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picBoxClose;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnUpdateUM;
        public System.Windows.Forms.Button BtnClearUM;
        public System.Windows.Forms.TextBox txtUserNameUM;
        public System.Windows.Forms.TextBox txtFullnameUM;
        public System.Windows.Forms.TextBox txtPasswordUM;
        public System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.ComboBox cmbUserRole;
        public System.Windows.Forms.Button BtnResetPassword;
        private System.Windows.Forms.CheckBox ChkBxEditRole;
        private System.Windows.Forms.CheckBox ChkBxEditUserName;
        private System.Windows.Forms.CheckBox ChkBxEditName;
        private System.Windows.Forms.CheckBox ChkBxEditPassword;
        private System.Windows.Forms.CheckBox ChkBxEditPhone;
        public System.Windows.Forms.MaskedTextBox MskTxtPhoneUM;
    }
}