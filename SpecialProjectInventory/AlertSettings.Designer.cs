namespace SpecialProjectInventory
{
    partial class AlertSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertSettings));
            this.lblPid = new System.Windows.Forms.Label();
            this.PanAlertSettings = new System.Windows.Forms.Panel();
            this.PcBxCloseAlert = new System.Windows.Forms.PictureBox();
            this.LblAlertSettings = new System.Windows.Forms.Label();
            this.BtnClearAlert = new System.Windows.Forms.Button();
            this.btnUpdateAlert = new System.Windows.Forms.Button();
            this.btnSaveAlert = new System.Windows.Forms.Button();
            this.LblEnable = new System.Windows.Forms.Label();
            this.LblThreshold = new System.Windows.Forms.Label();
            this.TxtBxAlertType = new System.Windows.Forms.TextBox();
            this.LblAlertType = new System.Windows.Forms.Label();
            this.TxtBxAlertID = new System.Windows.Forms.TextBox();
            this.RdBtnYes = new System.Windows.Forms.RadioButton();
            this.RdBtnNo = new System.Windows.Forms.RadioButton();
            this.DgvAlertSettings = new System.Windows.Forms.DataGridView();
            this.alertID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alertType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.threshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbAlertSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specialProjectDBsDataSet = new SpecialProjectInventory.SpecialProjectDBsDataSet();
            this.tbAlertSettingsTableAdapter = new SpecialProjectInventory.SpecialProjectDBsDataSetTableAdapters.tbAlertSettingsTableAdapter();
            this.UdAlertThreshold = new System.Windows.Forms.NumericUpDown();
            this.BtnDeleteAlertSettings = new System.Windows.Forms.Button();
            this.PanAlertSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxCloseAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlertSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAlertSettingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialProjectDBsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdAlertThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPid
            // 
            this.lblPid.AutoSize = true;
            this.lblPid.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPid.Location = new System.Drawing.Point(129, 102);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(58, 17);
            this.lblPid.TabIndex = 50;
            this.lblPid.Text = "Alert ID:";
            // 
            // PanAlertSettings
            // 
            this.PanAlertSettings.BackColor = System.Drawing.Color.Red;
            this.PanAlertSettings.Controls.Add(this.PcBxCloseAlert);
            this.PanAlertSettings.Controls.Add(this.LblAlertSettings);
            this.PanAlertSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanAlertSettings.Location = new System.Drawing.Point(0, 0);
            this.PanAlertSettings.Name = "PanAlertSettings";
            this.PanAlertSettings.Size = new System.Drawing.Size(1122, 54);
            this.PanAlertSettings.TabIndex = 36;
            // 
            // PcBxCloseAlert
            // 
            this.PcBxCloseAlert.Image = ((System.Drawing.Image)(resources.GetObject("PcBxCloseAlert.Image")));
            this.PcBxCloseAlert.Location = new System.Drawing.Point(1067, 0);
            this.PcBxCloseAlert.Name = "PcBxCloseAlert";
            this.PcBxCloseAlert.Size = new System.Drawing.Size(43, 47);
            this.PcBxCloseAlert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PcBxCloseAlert.TabIndex = 12;
            this.PcBxCloseAlert.TabStop = false;
            this.PcBxCloseAlert.Click += new System.EventHandler(this.PcBxCloseAlert_Click);
            // 
            // LblAlertSettings
            // 
            this.LblAlertSettings.AutoSize = true;
            this.LblAlertSettings.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAlertSettings.ForeColor = System.Drawing.Color.White;
            this.LblAlertSettings.Location = new System.Drawing.Point(12, 9);
            this.LblAlertSettings.Name = "LblAlertSettings";
            this.LblAlertSettings.Size = new System.Drawing.Size(105, 19);
            this.LblAlertSettings.TabIndex = 1;
            this.LblAlertSettings.Text = "Alert Settings";
            // 
            // BtnClearAlert
            // 
            this.BtnClearAlert.BackColor = System.Drawing.Color.Red;
            this.BtnClearAlert.FlatAppearance.BorderSize = 0;
            this.BtnClearAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearAlert.ForeColor = System.Drawing.Color.White;
            this.BtnClearAlert.Location = new System.Drawing.Point(499, 273);
            this.BtnClearAlert.Name = "BtnClearAlert";
            this.BtnClearAlert.Size = new System.Drawing.Size(93, 38);
            this.BtnClearAlert.TabIndex = 46;
            this.BtnClearAlert.Text = "Clear";
            this.BtnClearAlert.UseVisualStyleBackColor = false;
            this.BtnClearAlert.Click += new System.EventHandler(this.BtnClearAlert_Click);
            // 
            // btnUpdateAlert
            // 
            this.btnUpdateAlert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdateAlert.FlatAppearance.BorderSize = 0;
            this.btnUpdateAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateAlert.ForeColor = System.Drawing.Color.White;
            this.btnUpdateAlert.Location = new System.Drawing.Point(255, 273);
            this.btnUpdateAlert.Name = "btnUpdateAlert";
            this.btnUpdateAlert.Size = new System.Drawing.Size(93, 38);
            this.btnUpdateAlert.TabIndex = 45;
            this.btnUpdateAlert.Text = "Update";
            this.btnUpdateAlert.UseVisualStyleBackColor = false;
            this.btnUpdateAlert.Click += new System.EventHandler(this.BtnUpdateAlert_Click);
            // 
            // btnSaveAlert
            // 
            this.btnSaveAlert.BackColor = System.Drawing.Color.Green;
            this.btnSaveAlert.FlatAppearance.BorderSize = 0;
            this.btnSaveAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAlert.ForeColor = System.Drawing.Color.White;
            this.btnSaveAlert.Location = new System.Drawing.Point(133, 273);
            this.btnSaveAlert.Name = "btnSaveAlert";
            this.btnSaveAlert.Size = new System.Drawing.Size(93, 38);
            this.btnSaveAlert.TabIndex = 44;
            this.btnSaveAlert.Text = "Save";
            this.btnSaveAlert.UseVisualStyleBackColor = false;
            this.btnSaveAlert.Click += new System.EventHandler(this.BtnSaveAlert_Click);
            // 
            // LblEnable
            // 
            this.LblEnable.AutoSize = true;
            this.LblEnable.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEnable.Location = new System.Drawing.Point(131, 225);
            this.LblEnable.Name = "LblEnable";
            this.LblEnable.Size = new System.Drawing.Size(56, 17);
            this.LblEnable.TabIndex = 41;
            this.LblEnable.Text = "Enable:";
            // 
            // LblThreshold
            // 
            this.LblThreshold.AutoSize = true;
            this.LblThreshold.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblThreshold.Location = new System.Drawing.Point(116, 184);
            this.LblThreshold.Name = "LblThreshold";
            this.LblThreshold.Size = new System.Drawing.Size(71, 17);
            this.LblThreshold.TabIndex = 39;
            this.LblThreshold.Text = "Threshold:";
            // 
            // TxtBxAlertType
            // 
            this.TxtBxAlertType.Location = new System.Drawing.Point(217, 137);
            this.TxtBxAlertType.Name = "TxtBxAlertType";
            this.TxtBxAlertType.Size = new System.Drawing.Size(409, 20);
            this.TxtBxAlertType.TabIndex = 38;
            // 
            // LblAlertType
            // 
            this.LblAlertType.AutoSize = true;
            this.LblAlertType.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAlertType.Location = new System.Drawing.Point(114, 143);
            this.LblAlertType.Name = "LblAlertType";
            this.LblAlertType.Size = new System.Drawing.Size(73, 17);
            this.LblAlertType.TabIndex = 37;
            this.LblAlertType.Text = "Alert Type:";
            // 
            // TxtBxAlertID
            // 
            this.TxtBxAlertID.Location = new System.Drawing.Point(217, 99);
            this.TxtBxAlertID.Name = "TxtBxAlertID";
            this.TxtBxAlertID.Size = new System.Drawing.Size(43, 20);
            this.TxtBxAlertID.TabIndex = 57;
            // 
            // RdBtnYes
            // 
            this.RdBtnYes.AutoSize = true;
            this.RdBtnYes.Location = new System.Drawing.Point(217, 227);
            this.RdBtnYes.Name = "RdBtnYes";
            this.RdBtnYes.Size = new System.Drawing.Size(43, 17);
            this.RdBtnYes.TabIndex = 58;
            this.RdBtnYes.TabStop = true;
            this.RdBtnYes.Text = "Yes";
            this.RdBtnYes.UseVisualStyleBackColor = true;
            // 
            // RdBtnNo
            // 
            this.RdBtnNo.AutoSize = true;
            this.RdBtnNo.Location = new System.Drawing.Point(307, 227);
            this.RdBtnNo.Name = "RdBtnNo";
            this.RdBtnNo.Size = new System.Drawing.Size(39, 17);
            this.RdBtnNo.TabIndex = 59;
            this.RdBtnNo.TabStop = true;
            this.RdBtnNo.Text = "No";
            this.RdBtnNo.UseVisualStyleBackColor = true;
            // 
            // DgvAlertSettings
            // 
            this.DgvAlertSettings.AutoGenerateColumns = false;
            this.DgvAlertSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAlertSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alertID,
            this.alertType,
            this.threshold,
            this.isEnabled});
            this.DgvAlertSettings.DataSource = this.tbAlertSettingsBindingSource;
            this.DgvAlertSettings.Location = new System.Drawing.Point(669, 71);
            this.DgvAlertSettings.Name = "DgvAlertSettings";
            this.DgvAlertSettings.Size = new System.Drawing.Size(441, 374);
            this.DgvAlertSettings.TabIndex = 60;
            this.DgvAlertSettings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAlertSettings_CellContentClick);
            // 
            // alertID
            // 
            this.alertID.DataPropertyName = "alertID";
            this.alertID.HeaderText = "alertID";
            this.alertID.Name = "alertID";
            this.alertID.ReadOnly = true;
            // 
            // alertType
            // 
            this.alertType.DataPropertyName = "alertType";
            this.alertType.HeaderText = "alertType";
            this.alertType.Name = "alertType";
            // 
            // threshold
            // 
            this.threshold.DataPropertyName = "threshold";
            this.threshold.HeaderText = "threshold";
            this.threshold.Name = "threshold";
            // 
            // isEnabled
            // 
            this.isEnabled.DataPropertyName = "isEnabled";
            this.isEnabled.HeaderText = "isEnabled";
            this.isEnabled.Name = "isEnabled";
            // 
            // tbAlertSettingsBindingSource
            // 
            this.tbAlertSettingsBindingSource.DataMember = "tbAlertSettings";
            this.tbAlertSettingsBindingSource.DataSource = this.specialProjectDBsDataSet;
            // 
            // specialProjectDBsDataSet
            // 
            this.specialProjectDBsDataSet.DataSetName = "SpecialProjectDBsDataSet";
            this.specialProjectDBsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbAlertSettingsTableAdapter
            // 
            this.tbAlertSettingsTableAdapter.ClearBeforeFill = true;
            // 
            // UdAlertThreshold
            // 
            this.UdAlertThreshold.Location = new System.Drawing.Point(217, 181);
            this.UdAlertThreshold.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.UdAlertThreshold.Name = "UdAlertThreshold";
            this.UdAlertThreshold.Size = new System.Drawing.Size(138, 20);
            this.UdAlertThreshold.TabIndex = 61;
            // 
            // BtnDeleteAlertSettings
            // 
            this.BtnDeleteAlertSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BtnDeleteAlertSettings.FlatAppearance.BorderSize = 0;
            this.BtnDeleteAlertSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeleteAlertSettings.ForeColor = System.Drawing.Color.White;
            this.BtnDeleteAlertSettings.Location = new System.Drawing.Point(377, 273);
            this.BtnDeleteAlertSettings.Name = "BtnDeleteAlertSettings";
            this.BtnDeleteAlertSettings.Size = new System.Drawing.Size(93, 38);
            this.BtnDeleteAlertSettings.TabIndex = 62;
            this.BtnDeleteAlertSettings.Text = "Delete Alert Settings";
            this.BtnDeleteAlertSettings.UseVisualStyleBackColor = false;
            this.BtnDeleteAlertSettings.Click += new System.EventHandler(this.BtnDeleteAlertSettings_Click);
            // 
            // AlertSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 517);
            this.Controls.Add(this.BtnDeleteAlertSettings);
            this.Controls.Add(this.UdAlertThreshold);
            this.Controls.Add(this.DgvAlertSettings);
            this.Controls.Add(this.RdBtnNo);
            this.Controls.Add(this.RdBtnYes);
            this.Controls.Add(this.TxtBxAlertID);
            this.Controls.Add(this.lblPid);
            this.Controls.Add(this.PanAlertSettings);
            this.Controls.Add(this.BtnClearAlert);
            this.Controls.Add(this.btnUpdateAlert);
            this.Controls.Add(this.btnSaveAlert);
            this.Controls.Add(this.LblEnable);
            this.Controls.Add(this.LblThreshold);
            this.Controls.Add(this.TxtBxAlertType);
            this.Controls.Add(this.LblAlertType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlertSettings";
            this.Text = "AlertSettings";
            this.Load += new System.EventHandler(this.AlertSettings_Load);
            this.PanAlertSettings.ResumeLayout(false);
            this.PanAlertSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxCloseAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlertSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAlertSettingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialProjectDBsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdAlertThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.Panel PanAlertSettings;
        private System.Windows.Forms.PictureBox PcBxCloseAlert;
        private System.Windows.Forms.Label LblAlertSettings;
        public System.Windows.Forms.Button BtnClearAlert;
        public System.Windows.Forms.Button btnUpdateAlert;
        public System.Windows.Forms.Button btnSaveAlert;
        private System.Windows.Forms.Label LblEnable;
        private System.Windows.Forms.Label LblThreshold;
        public System.Windows.Forms.TextBox TxtBxAlertType;
        private System.Windows.Forms.Label LblAlertType;
        public System.Windows.Forms.TextBox TxtBxAlertID;
        private System.Windows.Forms.RadioButton RdBtnYes;
        private System.Windows.Forms.RadioButton RdBtnNo;
        private System.Windows.Forms.DataGridView DgvAlertSettings;
        private SpecialProjectDBsDataSet specialProjectDBsDataSet;
        private System.Windows.Forms.BindingSource tbAlertSettingsBindingSource;
        private SpecialProjectDBsDataSetTableAdapters.tbAlertSettingsTableAdapter tbAlertSettingsTableAdapter;
        public System.Windows.Forms.NumericUpDown UdAlertThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn alertID;
        private System.Windows.Forms.DataGridViewTextBoxColumn alertType;
        private System.Windows.Forms.DataGridViewTextBoxColumn threshold;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEnabled;
        public System.Windows.Forms.Button BtnDeleteAlertSettings;
    }
}