namespace SpecialProjectInventory
{
    partial class CategoryModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryModuleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCatld = new System.Windows.Forms.Label();
            this.BtnClearCM = new System.Windows.Forms.Button();
            this.btnUpdateCM = new System.Windows.Forms.Button();
            this.btnSaveCM = new System.Windows.Forms.Button();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panel1.TabIndex = 27;
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
            this.label1.Size = new System.Drawing.Size(144, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category Module";
            // 
            // lblCatld
            // 
            this.lblCatld.AutoSize = true;
            this.lblCatld.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatld.Location = new System.Drawing.Point(48, 160);
            this.lblCatld.Name = "lblCatld";
            this.lblCatld.Size = new System.Drawing.Size(85, 17);
            this.lblCatld.TabIndex = 35;
            this.lblCatld.Text = "Category Id";
            this.lblCatld.Visible = false;
            // 
            // BtnClearCM
            // 
            this.BtnClearCM.BackColor = System.Drawing.Color.Red;
            this.BtnClearCM.FlatAppearance.BorderSize = 0;
            this.BtnClearCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearCM.ForeColor = System.Drawing.Color.White;
            this.BtnClearCM.Location = new System.Drawing.Point(471, 139);
            this.BtnClearCM.Name = "BtnClearCM";
            this.BtnClearCM.Size = new System.Drawing.Size(93, 38);
            this.BtnClearCM.TabIndex = 34;
            this.BtnClearCM.Text = "Clear";
            this.BtnClearCM.UseVisualStyleBackColor = false;
            this.BtnClearCM.Click += new System.EventHandler(this.BtnClearCM_Click);
            // 
            // btnUpdateCM
            // 
            this.btnUpdateCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdateCM.FlatAppearance.BorderSize = 0;
            this.btnUpdateCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCM.ForeColor = System.Drawing.Color.White;
            this.btnUpdateCM.Location = new System.Drawing.Point(349, 139);
            this.btnUpdateCM.Name = "btnUpdateCM";
            this.btnUpdateCM.Size = new System.Drawing.Size(93, 38);
            this.btnUpdateCM.TabIndex = 33;
            this.btnUpdateCM.Text = "Update";
            this.btnUpdateCM.UseVisualStyleBackColor = false;
            this.btnUpdateCM.Click += new System.EventHandler(this.BtnUpdateCM_Click);
            // 
            // btnSaveCM
            // 
            this.btnSaveCM.BackColor = System.Drawing.Color.Green;
            this.btnSaveCM.FlatAppearance.BorderSize = 0;
            this.btnSaveCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCM.ForeColor = System.Drawing.Color.White;
            this.btnSaveCM.Location = new System.Drawing.Point(227, 139);
            this.btnSaveCM.Name = "btnSaveCM";
            this.btnSaveCM.Size = new System.Drawing.Size(93, 38);
            this.btnSaveCM.TabIndex = 32;
            this.btnSaveCM.Text = "Save";
            this.btnSaveCM.UseVisualStyleBackColor = false;
            this.btnSaveCM.Click += new System.EventHandler(this.BtnSaveCM_Click);
            // 
            // txtCatName
            // 
            this.txtCatName.Location = new System.Drawing.Point(155, 93);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(409, 23);
            this.txtCatName.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Category Name :";
            // 
            // CategoryModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 203);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCatld);
            this.Controls.Add(this.BtnClearCM);
            this.Controls.Add(this.btnUpdateCM);
            this.Controls.Add(this.btnSaveCM);
            this.Controls.Add(this.txtCatName);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CategoryModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryModuleForm";
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
        public System.Windows.Forms.Label lblCatld;
        public System.Windows.Forms.Button BtnClearCM;
        public System.Windows.Forms.Button btnUpdateCM;
        public System.Windows.Forms.Button btnSaveCM;
        public System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.Label label2;
    }
}