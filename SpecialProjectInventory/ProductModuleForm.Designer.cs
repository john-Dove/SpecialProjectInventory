namespace SpecialProjectInventory
{
    partial class ProductModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductModuleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPDes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnClearPM = new System.Windows.Forms.Button();
            this.btnUpdatePM = new System.Windows.Forms.Button();
            this.btnSavePM = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPprice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPQTY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbCatCategory = new System.Windows.Forms.ComboBox();
            this.LblPid = new System.Windows.Forms.Label();
            this.NudReorderLevel = new System.Windows.Forms.NumericUpDown();
            this.LblReorderLevel = new System.Windows.Forms.Label();
            this.DtExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.LblExpiryDate = new System.Windows.Forms.Label();
            this.LblThresholdDate = new System.Windows.Forms.Label();
            this.DtpThresholdDate = new System.Windows.Forms.DateTimePicker();
            this.RdBtnPerishable = new System.Windows.Forms.RadioButton();
            this.LblPerishable = new System.Windows.Forms.Label();
            this.RdBtnNonPerishable = new System.Windows.Forms.RadioButton();
            this.LblProductID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudReorderLevel)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(686, 54);
            this.panel1.TabIndex = 14;
            // 
            // picBoxClose
            // 
            this.picBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("picBoxClose.Image")));
            this.picBoxClose.Location = new System.Drawing.Point(630, 3);
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
            this.label1.Size = new System.Drawing.Size(131, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product Module";
            // 
            // txtPDes
            // 
            this.txtPDes.Location = new System.Drawing.Point(203, 247);
            this.txtPDes.Name = "txtPDes";
            this.txtPDes.Size = new System.Drawing.Size(409, 23);
            this.txtPDes.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(85, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Description :";
            // 
            // BtnClearPM
            // 
            this.BtnClearPM.BackColor = System.Drawing.Color.Red;
            this.BtnClearPM.FlatAppearance.BorderSize = 0;
            this.BtnClearPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearPM.ForeColor = System.Drawing.Color.White;
            this.BtnClearPM.Location = new System.Drawing.Point(447, 544);
            this.BtnClearPM.Name = "BtnClearPM";
            this.BtnClearPM.Size = new System.Drawing.Size(93, 38);
            this.BtnClearPM.TabIndex = 25;
            this.BtnClearPM.Text = "Clear";
            this.BtnClearPM.UseVisualStyleBackColor = false;
            this.BtnClearPM.Click += new System.EventHandler(this.BtnClearPM_Click);
            // 
            // btnUpdatePM
            // 
            this.btnUpdatePM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdatePM.FlatAppearance.BorderSize = 0;
            this.btnUpdatePM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePM.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePM.Location = new System.Drawing.Point(325, 544);
            this.btnUpdatePM.Name = "btnUpdatePM";
            this.btnUpdatePM.Size = new System.Drawing.Size(93, 38);
            this.btnUpdatePM.TabIndex = 24;
            this.btnUpdatePM.Text = "Update";
            this.btnUpdatePM.UseVisualStyleBackColor = false;
            this.btnUpdatePM.Click += new System.EventHandler(this.BtnUpdatePM_Click);
            // 
            // btnSavePM
            // 
            this.btnSavePM.BackColor = System.Drawing.Color.Green;
            this.btnSavePM.FlatAppearance.BorderSize = 0;
            this.btnSavePM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePM.ForeColor = System.Drawing.Color.White;
            this.btnSavePM.Location = new System.Drawing.Point(203, 544);
            this.btnSavePM.Name = "btnSavePM";
            this.btnSavePM.Size = new System.Drawing.Size(93, 38);
            this.btnSavePM.TabIndex = 23;
            this.btnSavePM.Text = "Save";
            this.btnSavePM.UseVisualStyleBackColor = false;
            this.btnSavePM.Click += new System.EventHandler(this.BtnSavePM_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(96, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Category :";
            // 
            // txtPprice
            // 
            this.txtPprice.Location = new System.Drawing.Point(203, 202);
            this.txtPprice.Name = "txtPprice";
            this.txtPprice.Size = new System.Drawing.Size(409, 23);
            this.txtPprice.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Price :";
            // 
            // txtPQTY
            // 
            this.txtPQTY.Location = new System.Drawing.Point(203, 157);
            this.txtPQTY.Name = "txtPQTY";
            this.txtPQTY.Size = new System.Drawing.Size(409, 23);
            this.txtPQTY.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(102, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Quantity :";
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(203, 112);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(409, 23);
            this.txtPName.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Product Name :";
            // 
            // CmbCatCategory
            // 
            this.CmbCatCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCatCategory.FormattingEnabled = true;
            this.CmbCatCategory.Location = new System.Drawing.Point(203, 292);
            this.CmbCatCategory.Name = "CmbCatCategory";
            this.CmbCatCategory.Size = new System.Drawing.Size(409, 25);
            this.CmbCatCategory.TabIndex = 28;
            this.CmbCatCategory.SelectedIndexChanged += new System.EventHandler(this.CmbCatCategory_SelectedIndexChanged);
            // 
            // LblPid
            // 
            this.LblPid.AutoSize = true;
            this.LblPid.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPid.Location = new System.Drawing.Point(200, 83);
            this.LblPid.Name = "LblPid";
            this.LblPid.Size = new System.Drawing.Size(75, 17);
            this.LblPid.TabIndex = 29;
            this.LblPid.Text = "Product id";
            // 
            // NudReorderLevel
            // 
            this.NudReorderLevel.Location = new System.Drawing.Point(203, 429);
            this.NudReorderLevel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NudReorderLevel.Name = "NudReorderLevel";
            this.NudReorderLevel.Size = new System.Drawing.Size(138, 23);
            this.NudReorderLevel.TabIndex = 30;
            // 
            // LblReorderLevel
            // 
            this.LblReorderLevel.AutoSize = true;
            this.LblReorderLevel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReorderLevel.Location = new System.Drawing.Point(44, 433);
            this.LblReorderLevel.Name = "LblReorderLevel";
            this.LblReorderLevel.Size = new System.Drawing.Size(129, 17);
            this.LblReorderLevel.TabIndex = 31;
            this.LblReorderLevel.Text = "Re-order Threshold:";
            // 
            // DtExpiryDate
            // 
            this.DtExpiryDate.CustomFormat = "dd/MM/yyyy";
            this.DtExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtExpiryDate.Location = new System.Drawing.Point(203, 339);
            this.DtExpiryDate.Name = "DtExpiryDate";
            this.DtExpiryDate.Size = new System.Drawing.Size(242, 23);
            this.DtExpiryDate.TabIndex = 32;
            // 
            // LblExpiryDate
            // 
            this.LblExpiryDate.AutoSize = true;
            this.LblExpiryDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblExpiryDate.Location = new System.Drawing.Point(96, 343);
            this.LblExpiryDate.Name = "LblExpiryDate";
            this.LblExpiryDate.Size = new System.Drawing.Size(83, 17);
            this.LblExpiryDate.TabIndex = 33;
            this.LblExpiryDate.Text = "Expiry Date:";
            // 
            // LblThresholdDate
            // 
            this.LblThresholdDate.AutoSize = true;
            this.LblThresholdDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblThresholdDate.Location = new System.Drawing.Point(72, 388);
            this.LblThresholdDate.Name = "LblThresholdDate";
            this.LblThresholdDate.Size = new System.Drawing.Size(107, 17);
            this.LblThresholdDate.TabIndex = 35;
            this.LblThresholdDate.Text = "Threshold Date:";
            // 
            // DtpThresholdDate
            // 
            this.DtpThresholdDate.CustomFormat = "dd/MM/yyyy";
            this.DtpThresholdDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpThresholdDate.Location = new System.Drawing.Point(203, 384);
            this.DtpThresholdDate.Name = "DtpThresholdDate";
            this.DtpThresholdDate.Size = new System.Drawing.Size(242, 23);
            this.DtpThresholdDate.TabIndex = 34;
            // 
            // RdBtnPerishable
            // 
            this.RdBtnPerishable.AutoSize = true;
            this.RdBtnPerishable.Location = new System.Drawing.Point(203, 473);
            this.RdBtnPerishable.Name = "RdBtnPerishable";
            this.RdBtnPerishable.Size = new System.Drawing.Size(91, 21);
            this.RdBtnPerishable.TabIndex = 36;
            this.RdBtnPerishable.TabStop = true;
            this.RdBtnPerishable.Text = "Perishable";
            this.RdBtnPerishable.UseVisualStyleBackColor = true;
            // 
            // LblPerishable
            // 
            this.LblPerishable.AutoSize = true;
            this.LblPerishable.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPerishable.Location = new System.Drawing.Point(126, 473);
            this.LblPerishable.Name = "LblPerishable";
            this.LblPerishable.Size = new System.Drawing.Size(40, 17);
            this.LblPerishable.TabIndex = 37;
            this.LblPerishable.Text = "Type:";
            // 
            // RdBtnNonPerishable
            // 
            this.RdBtnNonPerishable.AutoSize = true;
            this.RdBtnNonPerishable.Location = new System.Drawing.Point(323, 473);
            this.RdBtnNonPerishable.Name = "RdBtnNonPerishable";
            this.RdBtnNonPerishable.Size = new System.Drawing.Size(122, 21);
            this.RdBtnNonPerishable.TabIndex = 38;
            this.RdBtnNonPerishable.TabStop = true;
            this.RdBtnNonPerishable.Text = "Non-Perishable";
            this.RdBtnNonPerishable.UseVisualStyleBackColor = true;
            // 
            // LblProductID
            // 
            this.LblProductID.AutoSize = true;
            this.LblProductID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProductID.Location = new System.Drawing.Point(93, 83);
            this.LblProductID.Name = "LblProductID";
            this.LblProductID.Size = new System.Drawing.Size(80, 17);
            this.LblProductID.TabIndex = 39;
            this.LblProductID.Text = "Product ID:";
            // 
            // ProductModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 629);
            this.Controls.Add(this.LblProductID);
            this.Controls.Add(this.RdBtnNonPerishable);
            this.Controls.Add(this.LblPerishable);
            this.Controls.Add(this.RdBtnPerishable);
            this.Controls.Add(this.LblThresholdDate);
            this.Controls.Add(this.DtpThresholdDate);
            this.Controls.Add(this.LblExpiryDate);
            this.Controls.Add(this.DtExpiryDate);
            this.Controls.Add(this.LblReorderLevel);
            this.Controls.Add(this.NudReorderLevel);
            this.Controls.Add(this.LblPid);
            this.Controls.Add(this.CmbCatCategory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPDes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnClearPM);
            this.Controls.Add(this.btnUpdatePM);
            this.Controls.Add(this.btnSavePM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPprice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPQTY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductModuleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudReorderLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picBoxClose;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtPDes;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button BtnClearPM;
        public System.Windows.Forms.Button btnUpdatePM;
        public System.Windows.Forms.Button btnSavePM;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtPprice;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtPQTY;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox CmbCatCategory;
        public System.Windows.Forms.Label LblPid;
        public System.Windows.Forms.NumericUpDown NudReorderLevel;
        private System.Windows.Forms.Label LblReorderLevel;
        public System.Windows.Forms.DateTimePicker DtExpiryDate;
        private System.Windows.Forms.Label LblExpiryDate;
        private System.Windows.Forms.Label LblThresholdDate;
        public System.Windows.Forms.DateTimePicker DtpThresholdDate;
        private System.Windows.Forms.RadioButton RdBtnPerishable;
        private System.Windows.Forms.Label LblPerishable;
        private System.Windows.Forms.RadioButton RdBtnNonPerishable;
        public System.Windows.Forms.Label LblProductID;
    }
}