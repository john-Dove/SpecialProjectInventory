namespace SpecialProjectInventory
{
    partial class ReportModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportModule));
            this.DtReportStart = new System.Windows.Forms.DateTimePicker();
            this.CmbCategory = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PicBoxCloseReport = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveReport = new System.Windows.Forms.Button();
            this.LblReportCategory = new System.Windows.Forms.Label();
            this.LblStartDate = new System.Windows.Forms.Label();
            this.DtReportEnd = new System.Windows.Forms.DateTimePicker();
            this.LblEndDate = new System.Windows.Forms.Label();
            this.DgvReport = new System.Windows.Forms.DataGridView();
            this.BtnGenerateReport = new System.Windows.Forms.Button();
            this.CmbCriteria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxCloseReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // DtReportStart
            // 
            this.DtReportStart.CustomFormat = "dd/MM/yyyy";
            this.DtReportStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtReportStart.Location = new System.Drawing.Point(247, 97);
            this.DtReportStart.Name = "DtReportStart";
            this.DtReportStart.Size = new System.Drawing.Size(242, 20);
            this.DtReportStart.TabIndex = 57;
            // 
            // CmbCategory
            // 
            this.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategory.FormattingEnabled = true;
            this.CmbCategory.Location = new System.Drawing.Point(247, 171);
            this.CmbCategory.Name = "CmbCategory";
            this.CmbCategory.Size = new System.Drawing.Size(242, 21);
            this.CmbCategory.TabIndex = 53;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.PicBoxCloseReport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 54);
            this.panel1.TabIndex = 40;
            // 
            // PicBoxCloseReport
            // 
            this.PicBoxCloseReport.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxCloseReport.Image")));
            this.PicBoxCloseReport.Location = new System.Drawing.Point(1015, 7);
            this.PicBoxCloseReport.Name = "PicBoxCloseReport";
            this.PicBoxCloseReport.Size = new System.Drawing.Size(43, 47);
            this.PicBoxCloseReport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxCloseReport.TabIndex = 12;
            this.PicBoxCloseReport.TabStop = false;
            this.PicBoxCloseReport.Click += new System.EventHandler(this.PicBoxCloseReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Report Module";
            // 
            // btnSaveReport
            // 
            this.btnSaveReport.BackColor = System.Drawing.Color.Green;
            this.btnSaveReport.FlatAppearance.BorderSize = 0;
            this.btnSaveReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveReport.ForeColor = System.Drawing.Color.White;
            this.btnSaveReport.Location = new System.Drawing.Point(383, 257);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(93, 38);
            this.btnSaveReport.TabIndex = 48;
            this.btnSaveReport.Text = "Save";
            this.btnSaveReport.UseVisualStyleBackColor = false;
            this.btnSaveReport.Click += new System.EventHandler(this.BtnSaveReport_Click);
            // 
            // LblReportCategory
            // 
            this.LblReportCategory.AutoSize = true;
            this.LblReportCategory.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReportCategory.Location = new System.Drawing.Point(97, 175);
            this.LblReportCategory.Name = "LblReportCategory";
            this.LblReportCategory.Size = new System.Drawing.Size(77, 17);
            this.LblReportCategory.TabIndex = 47;
            this.LblReportCategory.Text = "Category :";
            // 
            // LblStartDate
            // 
            this.LblStartDate.AutoSize = true;
            this.LblStartDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStartDate.Location = new System.Drawing.Point(102, 100);
            this.LblStartDate.Name = "LblStartDate";
            this.LblStartDate.Size = new System.Drawing.Size(77, 17);
            this.LblStartDate.TabIndex = 43;
            this.LblStartDate.Text = "Start Date:";
            // 
            // DtReportEnd
            // 
            this.DtReportEnd.CustomFormat = "dd/MM/yyyy";
            this.DtReportEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtReportEnd.Location = new System.Drawing.Point(247, 134);
            this.DtReportEnd.Name = "DtReportEnd";
            this.DtReportEnd.Size = new System.Drawing.Size(242, 20);
            this.DtReportEnd.TabIndex = 59;
            // 
            // LblEndDate
            // 
            this.LblEndDate.AutoSize = true;
            this.LblEndDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEndDate.Location = new System.Drawing.Point(102, 137);
            this.LblEndDate.Name = "LblEndDate";
            this.LblEndDate.Size = new System.Drawing.Size(72, 17);
            this.LblEndDate.TabIndex = 58;
            this.LblEndDate.Text = "End Date:";
            // 
            // DgvReport
            // 
            this.DgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReport.Location = new System.Drawing.Point(100, 321);
            this.DgvReport.Name = "DgvReport";
            this.DgvReport.Size = new System.Drawing.Size(940, 243);
            this.DgvReport.TabIndex = 60;
            // 
            // BtnGenerateReport
            // 
            this.BtnGenerateReport.BackColor = System.Drawing.Color.Teal;
            this.BtnGenerateReport.FlatAppearance.BorderSize = 0;
            this.BtnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.BtnGenerateReport.Location = new System.Drawing.Point(247, 257);
            this.BtnGenerateReport.Name = "BtnGenerateReport";
            this.BtnGenerateReport.Size = new System.Drawing.Size(93, 38);
            this.BtnGenerateReport.TabIndex = 61;
            this.BtnGenerateReport.Text = "Generate Report";
            this.BtnGenerateReport.UseVisualStyleBackColor = false;
            this.BtnGenerateReport.Click += new System.EventHandler(this.BtnGenerateReport_Click);
            // 
            // CmbCriteria
            // 
            this.CmbCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCriteria.FormattingEnabled = true;
            this.CmbCriteria.Location = new System.Drawing.Point(247, 209);
            this.CmbCriteria.Name = "CmbCriteria";
            this.CmbCriteria.Size = new System.Drawing.Size(242, 21);
            this.CmbCriteria.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 62;
            this.label2.Text = "Criteria";
            // 
            // ReportModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 576);
            this.Controls.Add(this.CmbCriteria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnGenerateReport);
            this.Controls.Add(this.DgvReport);
            this.Controls.Add(this.DtReportEnd);
            this.Controls.Add(this.LblEndDate);
            this.Controls.Add(this.DtReportStart);
            this.Controls.Add(this.CmbCategory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSaveReport);
            this.Controls.Add(this.LblReportCategory);
            this.Controls.Add(this.LblStartDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportModule";
            this.Text = "ReportModule";
            this.Load += new System.EventHandler(this.ReportModule_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxCloseReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DateTimePicker DtReportStart;
        public System.Windows.Forms.ComboBox CmbCategory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PicBoxCloseReport;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnSaveReport;
        private System.Windows.Forms.Label LblReportCategory;
        private System.Windows.Forms.Label LblStartDate;
        public System.Windows.Forms.DateTimePicker DtReportEnd;
        private System.Windows.Forms.Label LblEndDate;
        private System.Windows.Forms.DataGridView DgvReport;
        public System.Windows.Forms.Button BtnGenerateReport;
        public System.Windows.Forms.ComboBox CmbCriteria;
        private System.Windows.Forms.Label label2;
    }
}