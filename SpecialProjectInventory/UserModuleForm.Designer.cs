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
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserNameUM = new System.Windows.Forms.TextBox();
            this.txtFullnameUM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPasswordUM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhoneUM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdateUM = new System.Windows.Forms.Button();
            this.BtnClearUM = new System.Windows.Forms.Button();
            this.txtRepass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.cmbUserRole = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.picBoxClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 54);
            this.panel1.TabIndex = 0;
            // 
            // picBoxClose
            // 
            this.picBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("picBoxClose.Image")));
            this.picBoxClose.Location = new System.Drawing.Point(584, 0);
            this.picBoxClose.Name = "picBoxClose";
            this.picBoxClose.Size = new System.Drawing.Size(43, 47);
            this.picBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxClose.TabIndex = 12;
            this.picBoxClose.TabStop = false;
            this.picBoxClose.Click += new System.EventHandler(this.picBoxClose_Click);
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
            this.label2.Location = new System.Drawing.Point(49, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name :";
            // 
            // txtUserNameUM
            // 
            this.txtUserNameUM.Location = new System.Drawing.Point(155, 131);
            this.txtUserNameUM.Name = "txtUserNameUM";
            this.txtUserNameUM.Size = new System.Drawing.Size(408, 20);
            this.txtUserNameUM.TabIndex = 2;
            // 
            // txtFullnameUM
            // 
            this.txtFullnameUM.Location = new System.Drawing.Point(155, 171);
            this.txtFullnameUM.Name = "txtFullnameUM";
            this.txtFullnameUM.Size = new System.Drawing.Size(408, 20);
            this.txtFullnameUM.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Full Name :";
            // 
            // txtPasswordUM
            // 
            this.txtPasswordUM.Location = new System.Drawing.Point(155, 211);
            this.txtPasswordUM.Name = "txtPasswordUM";
            this.txtPasswordUM.Size = new System.Drawing.Size(408, 20);
            this.txtPasswordUM.TabIndex = 6;
            this.txtPasswordUM.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password :";
            // 
            // txtPhoneUM
            // 
            this.txtPhoneUM.Location = new System.Drawing.Point(155, 291);
            this.txtPhoneUM.Name = "txtPhoneUM";
            this.txtPhoneUM.Size = new System.Drawing.Size(408, 20);
            this.txtPhoneUM.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(77, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Phone :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(227, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 38);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdateUM
            // 
            this.btnUpdateUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdateUM.FlatAppearance.BorderSize = 0;
            this.btnUpdateUM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateUM.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUM.Location = new System.Drawing.Point(349, 344);
            this.btnUpdateUM.Name = "btnUpdateUM";
            this.btnUpdateUM.Size = new System.Drawing.Size(93, 38);
            this.btnUpdateUM.TabIndex = 10;
            this.btnUpdateUM.Text = "Update";
            this.btnUpdateUM.UseVisualStyleBackColor = false;
            this.btnUpdateUM.Click += new System.EventHandler(this.btnUpdateUM_Click);
            // 
            // BtnClearUM
            // 
            this.BtnClearUM.BackColor = System.Drawing.Color.Red;
            this.BtnClearUM.FlatAppearance.BorderSize = 0;
            this.BtnClearUM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearUM.ForeColor = System.Drawing.Color.White;
            this.BtnClearUM.Location = new System.Drawing.Point(471, 344);
            this.BtnClearUM.Name = "BtnClearUM";
            this.BtnClearUM.Size = new System.Drawing.Size(93, 38);
            this.BtnClearUM.TabIndex = 11;
            this.BtnClearUM.Text = "Clear";
            this.BtnClearUM.UseVisualStyleBackColor = false;
            this.BtnClearUM.Click += new System.EventHandler(this.BtnClearUM_Click);
            // 
            // txtRepass
            // 
            this.txtRepass.Location = new System.Drawing.Point(155, 251);
            this.txtRepass.Name = "txtRepass";
            this.txtRepass.Size = new System.Drawing.Size(408, 20);
            this.txtRepass.TabIndex = 13;
            this.txtRepass.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Re-Type Password :";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(68, 67);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(38, 13);
            this.lblUserID.TabIndex = 14;
            this.lblUserID.Text = "userID";
            this.lblUserID.Visible = false;
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
            this.cmbUserRole.FormattingEnabled = true;
            this.cmbUserRole.Location = new System.Drawing.Point(155, 90);
            this.cmbUserRole.Name = "cmbUserRole";
            this.cmbUserRole.Size = new System.Drawing.Size(408, 21);
            this.cmbUserRole.TabIndex = 16;
            this.cmbUserRole.Text = "Select A Role";
            // 
            // UserModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 425);
            this.Controls.Add(this.cmbUserRole);
            this.Controls.Add(this.lblUserRole);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.txtRepass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnClearUM);
            this.Controls.Add(this.btnUpdateUM);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPhoneUM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPasswordUM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFullnameUM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserNameUM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserModuleForm";
            this.Load += new System.EventHandler(this.UserModuleForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
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
        public System.Windows.Forms.TextBox txtPhoneUM;
        public System.Windows.Forms.TextBox txtRepass;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.ComboBox cmbUserRole;
    }
}