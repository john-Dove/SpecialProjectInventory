namespace SpecialProjectInventory
{
    partial class CustomerModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerModuleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClearUM = new System.Windows.Forms.Button();
            this.btnUpdateUM = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCld = new System.Windows.Forms.Label();
            this.MskTxtCPhone = new System.Windows.Forms.MaskedTextBox();
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
            this.panel1.Size = new System.Drawing.Size(630, 54);
            this.panel1.TabIndex = 14;
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
            this.picBoxClose.Click += new System.EventHandler(this.PicBoxClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Module";
            // 
            // BtnClearUM
            // 
            this.BtnClearUM.BackColor = System.Drawing.Color.Red;
            this.BtnClearUM.FlatAppearance.BorderSize = 0;
            this.BtnClearUM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearUM.ForeColor = System.Drawing.Color.White;
            this.BtnClearUM.Location = new System.Drawing.Point(471, 189);
            this.BtnClearUM.Name = "BtnClearUM";
            this.BtnClearUM.Size = new System.Drawing.Size(93, 38);
            this.BtnClearUM.TabIndex = 4;
            this.BtnClearUM.Text = "Clear";
            this.BtnClearUM.UseVisualStyleBackColor = false;
            this.BtnClearUM.Click += new System.EventHandler(this.BtnClearUM_Click);
            // 
            // btnUpdateUM
            // 
            this.btnUpdateUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdateUM.FlatAppearance.BorderSize = 0;
            this.btnUpdateUM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateUM.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUM.Location = new System.Drawing.Point(349, 189);
            this.btnUpdateUM.Name = "btnUpdateUM";
            this.btnUpdateUM.Size = new System.Drawing.Size(93, 38);
            this.btnUpdateUM.TabIndex = 3;
            this.btnUpdateUM.Text = "Update";
            this.btnUpdateUM.UseVisualStyleBackColor = false;
            this.btnUpdateUM.Click += new System.EventHandler(this.BtnUpdateUM_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(227, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 38);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Phone :";
            // 
            // txtCName
            // 
            this.txtCName.Location = new System.Drawing.Point(155, 94);
            this.txtCName.Name = "txtCName";
            this.txtCName.Size = new System.Drawing.Size(409, 23);
            this.txtCName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Name :";
            // 
            // lblCld
            // 
            this.lblCld.AutoSize = true;
            this.lblCld.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCld.Location = new System.Drawing.Point(48, 210);
            this.lblCld.Name = "lblCld";
            this.lblCld.Size = new System.Drawing.Size(87, 17);
            this.lblCld.TabIndex = 26;
            this.lblCld.Text = "Customer Id";
            this.lblCld.Visible = false;
            // 
            // MskTxtCPhone
            // 
            this.MskTxtCPhone.Location = new System.Drawing.Point(155, 143);
            this.MskTxtCPhone.Mask = "(999) 999-9999";
            this.MskTxtCPhone.Name = "MskTxtCPhone";
            this.MskTxtCPhone.Size = new System.Drawing.Size(409, 23);
            this.MskTxtCPhone.TabIndex = 1;
            // 
            // CustomerModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 268);
            this.Controls.Add(this.MskTxtCPhone);
            this.Controls.Add(this.lblCld);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnClearUM);
            this.Controls.Add(this.btnUpdateUM);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCName);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CustomerModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerModuleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picBoxClose;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button BtnClearUM;
        public System.Windows.Forms.Button btnUpdateUM;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblCld;
        public System.Windows.Forms.MaskedTextBox MskTxtCPhone;
    }
}