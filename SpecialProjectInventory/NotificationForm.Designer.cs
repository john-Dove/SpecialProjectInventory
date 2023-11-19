namespace SpecialProjectInventory
{
    partial class NotificationForm
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
            this.LblNotification = new System.Windows.Forms.Label();
            this.BtnCloseNote = new System.Windows.Forms.Button();
            this.BtnShowAlerts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblNotification
            // 
            this.LblNotification.AutoSize = true;
            this.LblNotification.Location = new System.Drawing.Point(12, 9);
            this.LblNotification.MaximumSize = new System.Drawing.Size(250, 0);
            this.LblNotification.Name = "LblNotification";
            this.LblNotification.Size = new System.Drawing.Size(35, 13);
            this.LblNotification.TabIndex = 0;
            this.LblNotification.Text = "label1";
            // 
            // BtnCloseNote
            // 
            this.BtnCloseNote.Location = new System.Drawing.Point(188, 62);
            this.BtnCloseNote.Name = "BtnCloseNote";
            this.BtnCloseNote.Size = new System.Drawing.Size(115, 23);
            this.BtnCloseNote.TabIndex = 1;
            this.BtnCloseNote.Text = "Close";
            this.BtnCloseNote.UseVisualStyleBackColor = true;
            this.BtnCloseNote.Click += new System.EventHandler(this.BtnCloseNote_Click);
            // 
            // BtnShowAlerts
            // 
            this.BtnShowAlerts.Location = new System.Drawing.Point(31, 62);
            this.BtnShowAlerts.Name = "BtnShowAlerts";
            this.BtnShowAlerts.Size = new System.Drawing.Size(115, 23);
            this.BtnShowAlerts.TabIndex = 2;
            this.BtnShowAlerts.Text = "Show Me Alerts";
            this.BtnShowAlerts.UseVisualStyleBackColor = true;
            this.BtnShowAlerts.Click += new System.EventHandler(this.BtnShowAlerts_Click);
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 97);
            this.Controls.Add(this.BtnShowAlerts);
            this.Controls.Add(this.BtnCloseNote);
            this.Controls.Add(this.LblNotification);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NotificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NotificationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblNotification;
        private System.Windows.Forms.Button BtnCloseNote;
        private System.Windows.Forms.Button BtnShowAlerts;
    }
}