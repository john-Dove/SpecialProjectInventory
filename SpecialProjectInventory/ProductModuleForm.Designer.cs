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
            this.comboCat = new System.Windows.Forms.ComboBox();
            this.lblPid = new System.Windows.Forms.Label();
            this.NudReorderLevel = new System.Windows.Forms.NumericUpDown();
            this.LblReorderLevel = new System.Windows.Forms.Label();
            this.DtExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.LblExpiryDate = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(688, 54);
            this.panel1.TabIndex = 14;
            // 
            // picBoxClose
            // 
            this.picBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("picBoxClose.Image")));
            this.picBoxClose.Location = new System.Drawing.Point(633, 7);
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
            this.txtPDes.Location = new System.Drawing.Point(203, 253);
            this.txtPDes.Name = "txtPDes";
            this.txtPDes.Size = new System.Drawing.Size(409, 23);
            this.txtPDes.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(85, 259);
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
            this.BtnClearPM.Location = new System.Drawing.Point(447, 475);
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
            this.btnUpdatePM.Location = new System.Drawing.Point(325, 475);
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
            this.btnSavePM.Location = new System.Drawing.Point(203, 475);
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
            this.label5.Location = new System.Drawing.Point(96, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Category :";
            // 
            // txtPprice
            // 
            this.txtPprice.Location = new System.Drawing.Point(203, 206);
            this.txtPprice.Name = "txtPprice";
            this.txtPprice.Size = new System.Drawing.Size(409, 23);
            this.txtPprice.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Price :";
            // 
            // txtPQTY
            // 
            this.txtPQTY.Location = new System.Drawing.Point(203, 159);
            this.txtPQTY.Name = "txtPQTY";
            this.txtPQTY.Size = new System.Drawing.Size(409, 23);
            this.txtPQTY.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(102, 165);
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
            // comboCat
            // 
            this.comboCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCat.FormattingEnabled = true;
            this.comboCat.Location = new System.Drawing.Point(203, 300);
            this.comboCat.Name = "comboCat";
            this.comboCat.Size = new System.Drawing.Size(409, 25);
            this.comboCat.TabIndex = 28;
            // 
            // lblPid
            // 
            this.lblPid.AutoSize = true;
            this.lblPid.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPid.Location = new System.Drawing.Point(12, 57);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(75, 17);
            this.lblPid.TabIndex = 29;
            this.lblPid.Text = "Product id";
            // 
            // NudReorderLevel
            // 
            this.NudReorderLevel.Location = new System.Drawing.Point(203, 396);
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
            this.LblReorderLevel.Location = new System.Drawing.Point(44, 400);
            this.LblReorderLevel.Name = "LblReorderLevel";
            this.LblReorderLevel.Size = new System.Drawing.Size(129, 17);
            this.LblReorderLevel.TabIndex = 31;
            this.LblReorderLevel.Text = "Re-order Threshold:";
            // 
            // DtExpiryDate
            // 
            this.DtExpiryDate.CustomFormat = "dd/MM/yyyy";
            this.DtExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtExpiryDate.Location = new System.Drawing.Point(203, 349);
            this.DtExpiryDate.Name = "DtExpiryDate";
            this.DtExpiryDate.Size = new System.Drawing.Size(242, 23);
            this.DtExpiryDate.TabIndex = 32;
            // 
            // LblExpiryDate
            // 
            this.LblExpiryDate.AutoSize = true;
            this.LblExpiryDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblExpiryDate.Location = new System.Drawing.Point(96, 353);
            this.LblExpiryDate.Name = "LblExpiryDate";
            this.LblExpiryDate.Size = new System.Drawing.Size(83, 17);
            this.LblExpiryDate.TabIndex = 33;
            this.LblExpiryDate.Text = "Expiry Date:";
            // 
            // ProductModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 540);
            this.Controls.Add(this.LblExpiryDate);
            this.Controls.Add(this.DtExpiryDate);
            this.Controls.Add(this.LblReorderLevel);
            this.Controls.Add(this.NudReorderLevel);
            this.Controls.Add(this.lblPid);
            this.Controls.Add(this.comboCat);
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
        public System.Windows.Forms.ComboBox comboCat;
        public System.Windows.Forms.Label lblPid;
        public System.Windows.Forms.NumericUpDown NudReorderLevel;
        private System.Windows.Forms.Label LblReorderLevel;
        public System.Windows.Forms.DateTimePicker DtExpiryDate;
        private System.Windows.Forms.Label LblExpiryDate;
    }
}