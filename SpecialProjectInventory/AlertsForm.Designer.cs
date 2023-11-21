namespace SpecialProjectInventory
{
    partial class AlertsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertsForm));
            this.DgvAlerts = new System.Windows.Forms.DataGridView();
            this.logID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alertID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.triggeredOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resolve = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblManageAlerts = new System.Windows.Forms.Label();
            this.CbSettings = new SpecialProjectInventory.CustomerButton();
            this.BtnAlertConfig = new SpecialProjectInventory.CustomerButton();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlerts)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAlertConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvAlerts
            // 
            this.DgvAlerts.AllowUserToAddRows = false;
            this.DgvAlerts.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAlerts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvAlerts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.logID,
            this.alertID,
            this.triggeredOn,
            this.message,
            this.productID,
            this.resolve});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAlerts.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAlerts.EnableHeadersVisualStyles = false;
            this.DgvAlerts.Location = new System.Drawing.Point(0, 0);
            this.DgvAlerts.Name = "DgvAlerts";
            this.DgvAlerts.Size = new System.Drawing.Size(953, 523);
            this.DgvAlerts.TabIndex = 3;
            // 
            // logID
            // 
            this.logID.HeaderText = "Log ID";
            this.logID.Name = "logID";
            // 
            // alertID
            // 
            this.alertID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.alertID.HeaderText = "Alert ID";
            this.alertID.Name = "alertID";
            this.alertID.Width = 79;
            // 
            // triggeredOn
            // 
            this.triggeredOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.triggeredOn.HeaderText = "Triggered On";
            this.triggeredOn.Name = "triggeredOn";
            // 
            // message
            // 
            this.message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.message.HeaderText = "Message";
            this.message.Name = "message";
            this.message.Width = 88;
            // 
            // productID
            // 
            this.productID.HeaderText = "Product ID";
            this.productID.Name = "productID";
            // 
            // resolve
            // 
            this.resolve.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.resolve.HeaderText = "";
            this.resolve.Image = ((System.Drawing.Image)(resources.GetObject("resolve.Image")));
            this.resolve.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.resolve.Name = "resolve";
            this.resolve.Width = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel2.Controls.Add(this.CbSettings);
            this.panel2.Controls.Add(this.BtnAlertConfig);
            this.panel2.Controls.Add(this.LblManageAlerts);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 523);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(953, 49);
            this.panel2.TabIndex = 2;
            // 
            // LblManageAlerts
            // 
            this.LblManageAlerts.AutoSize = true;
            this.LblManageAlerts.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblManageAlerts.ForeColor = System.Drawing.Color.White;
            this.LblManageAlerts.Location = new System.Drawing.Point(12, 12);
            this.LblManageAlerts.Name = "LblManageAlerts";
            this.LblManageAlerts.Size = new System.Drawing.Size(121, 19);
            this.LblManageAlerts.TabIndex = 2;
            this.LblManageAlerts.Text = "Manage Alerts";
            // 
            // CbSettings
            // 
            this.CbSettings.Image = ((System.Drawing.Image)(resources.GetObject("CbSettings.Image")));
            this.CbSettings.ImageHover = ((System.Drawing.Image)(resources.GetObject("CbSettings.ImageHover")));
            this.CbSettings.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CbSettings.ImageNormal")));
            this.CbSettings.Location = new System.Drawing.Point(890, 6);
            this.CbSettings.Name = "CbSettings";
            this.CbSettings.Size = new System.Drawing.Size(51, 38);
            this.CbSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CbSettings.TabIndex = 3;
            this.CbSettings.TabStop = false;
            this.CbSettings.Click += new System.EventHandler(this.CBtnSettings_Click);
            // 
            // BtnAlertConfig
            // 
            this.BtnAlertConfig.Image = ((System.Drawing.Image)(resources.GetObject("BtnAlertConfig.Image")));
            this.BtnAlertConfig.ImageHover = ((System.Drawing.Image)(resources.GetObject("BtnAlertConfig.ImageHover")));
            this.BtnAlertConfig.ImageNormal = ((System.Drawing.Image)(resources.GetObject("BtnAlertConfig.ImageNormal")));
            this.BtnAlertConfig.Location = new System.Drawing.Point(682, 6);
            this.BtnAlertConfig.Name = "BtnAlertConfig";
            this.BtnAlertConfig.Size = new System.Drawing.Size(51, 38);
            this.BtnAlertConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAlertConfig.TabIndex = 2;
            this.BtnAlertConfig.TabStop = false;
            this.BtnAlertConfig.Click += new System.EventHandler(this.BtnAlertConfig_Click);
            // 
            // AlertsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 572);
            this.Controls.Add(this.DgvAlerts);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlertsForm";
            this.Text = "AlertsFrom";
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlerts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAlertConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvAlerts;
        private System.Windows.Forms.Panel panel2;
        private CustomerButton BtnAlertConfig;
        private System.Windows.Forms.Label LblManageAlerts;
        private System.Windows.Forms.DataGridViewTextBoxColumn logID;
        private System.Windows.Forms.DataGridViewTextBoxColumn alertID;
        private System.Windows.Forms.DataGridViewTextBoxColumn triggeredOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.DataGridViewTextBoxColumn productID;
        private System.Windows.Forms.DataGridViewImageColumn resolve;
        private CustomerButton CbSettings;
    }
}