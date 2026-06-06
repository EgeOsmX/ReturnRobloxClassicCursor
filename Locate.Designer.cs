
namespace Return_Roblox_Classic_Cursor
{
    partial class Locate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Locate));
            this.radio_auto = new System.Windows.Forms.RadioButton();
            this.label_locate = new System.Windows.Forms.Label();
            this.radio_manual = new System.Windows.Forms.RadioButton();
            this.label_status = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.textboxBrowse = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.checkboxBgMonitoring = new System.Windows.Forms.CheckBox();
            this.label_bgMonitoringInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radio_auto
            // 
            this.radio_auto.AutoSize = true;
            this.radio_auto.Location = new System.Drawing.Point(32, 41);
            this.radio_auto.Name = "radio_auto";
            this.radio_auto.Size = new System.Drawing.Size(84, 17);
            this.radio_auto.TabIndex = 0;
            this.radio_auto.TabStop = true;
            this.radio_auto.Text = "Auto Search";
            this.radio_auto.UseVisualStyleBackColor = true;
            this.radio_auto.CheckedChanged += new System.EventHandler(this.radio_auto_CheckedChanged);
            // 
            // label_locate
            // 
            this.label_locate.AutoSize = true;
            this.label_locate.Location = new System.Drawing.Point(22, 19);
            this.label_locate.Name = "label_locate";
            this.label_locate.Size = new System.Drawing.Size(157, 13);
            this.label_locate.TabIndex = 1;
            this.label_locate.Text = "Locate \"RobloxPlayerBeta.exe\"";
            this.label_locate.Click += new System.EventHandler(this.label_locate_Click);
            // 
            // radio_manual
            // 
            this.radio_manual.AutoSize = true;
            this.radio_manual.Location = new System.Drawing.Point(32, 61);
            this.radio_manual.Name = "radio_manual";
            this.radio_manual.Size = new System.Drawing.Size(100, 17);
            this.radio_manual.TabIndex = 2;
            this.radio_manual.TabStop = true;
            this.radio_manual.Text = "Select Manually";
            this.radio_manual.UseVisualStyleBackColor = true;
            this.radio_manual.CheckedChanged += new System.EventHandler(this.radio_manual_CheckedChanged);
            // 
            // label_status
            // 
            this.label_status.Location = new System.Drawing.Point(-1, 137);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(356, 17);
            this.label_status.TabIndex = 3;
            this.label_status.Text = "status";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_status.Click += new System.EventHandler(this.label_status_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(139, 98);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // textboxBrowse
            // 
            this.textboxBrowse.Location = new System.Drawing.Point(25, 161);
            this.textboxBrowse.Name = "textboxBrowse";
            this.textboxBrowse.Size = new System.Drawing.Size(223, 20);
            this.textboxBrowse.TabIndex = 5;
            this.textboxBrowse.TextChanged += new System.EventHandler(this.textboxBrowse_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(254, 159);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(139, 187);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 7;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // checkboxBgMonitoring
            // 
            this.checkboxBgMonitoring.AutoSize = true;
            this.checkboxBgMonitoring.Location = new System.Drawing.Point(193, 42);
            this.checkboxBgMonitoring.Name = "checkboxBgMonitoring";
            this.checkboxBgMonitoring.Size = new System.Drawing.Size(136, 17);
            this.checkboxBgMonitoring.TabIndex = 8;
            this.checkboxBgMonitoring.Text = "Background Monitoring";
            this.checkboxBgMonitoring.UseVisualStyleBackColor = true;
            this.checkboxBgMonitoring.CheckedChanged += new System.EventHandler(this.checkboxBgMonitoring_CheckedChanged);
            // 
            // label_bgMonitoringInfo
            // 
            this.label_bgMonitoringInfo.AutoSize = true;
            this.label_bgMonitoringInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bgMonitoringInfo.Location = new System.Drawing.Point(210, 57);
            this.label_bgMonitoringInfo.Name = "label_bgMonitoringInfo";
            this.label_bgMonitoringInfo.Size = new System.Drawing.Size(99, 12);
            this.label_bgMonitoringInfo.TabIndex = 9;
            this.label_bgMonitoringInfo.Text = "label_bgMonitoringInfo";
            this.label_bgMonitoringInfo.Click += new System.EventHandler(this.label_bgMonitoringInfo_Click);
            // 
            // Locate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 135);
            this.Controls.Add(this.label_bgMonitoringInfo);
            this.Controls.Add(this.checkboxBgMonitoring);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.textboxBrowse);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.radio_manual);
            this.Controls.Add(this.label_locate);
            this.Controls.Add(this.radio_auto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Locate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locate Game Files";
            this.Load += new System.EventHandler(this.Locate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radio_auto;
        private System.Windows.Forms.Label label_locate;
        private System.Windows.Forms.RadioButton radio_manual;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.TextBox textboxBrowse;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.CheckBox checkboxBgMonitoring;
        private System.Windows.Forms.Label label_bgMonitoringInfo;
    }
}