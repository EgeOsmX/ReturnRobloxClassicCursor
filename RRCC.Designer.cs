
namespace Return_Roblox_Classic_Cursor
{
    partial class RRCC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RRCC));
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.label_rrcc1 = new System.Windows.Forms.Label();
            this.label_rrcc2 = new System.Windows.Forms.Label();
            this.label_rrcc3_ver = new System.Windows.Forms.Label();
            this.checkbox_winStartup = new System.Windows.Forms.CheckBox();
            this.checkbox_launchMinimized = new System.Windows.Forms.CheckBox();
            this.btnLocate = new System.Windows.Forms.Button();
            this.radio_newCursor = new System.Windows.Forms.RadioButton();
            this.radio_oldCursor = new System.Windows.Forms.RadioButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.stripMenuItem_selectedGameDir = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuItem_update = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(64, 29);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            this.pictureBoxLogo.Resize += new System.EventHandler(this.RRCC_Resize);
            // 
            // label_rrcc1
            // 
            this.label_rrcc1.AutoSize = true;
            this.label_rrcc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rrcc1.Location = new System.Drawing.Point(152, 53);
            this.label_rrcc1.Name = "label_rrcc1";
            this.label_rrcc1.Size = new System.Drawing.Size(41, 13);
            this.label_rrcc1.TabIndex = 2;
            this.label_rrcc1.Text = "RRCC";
            this.label_rrcc1.Click += new System.EventHandler(this.label_rrcc1_Click);
            // 
            // label_rrcc2
            // 
            this.label_rrcc2.AutoSize = true;
            this.label_rrcc2.Location = new System.Drawing.Point(152, 70);
            this.label_rrcc2.Name = "label_rrcc2";
            this.label_rrcc2.Size = new System.Drawing.Size(68, 13);
            this.label_rrcc2.TabIndex = 3;
            this.label_rrcc2.Text = "by EgeOsmX";
            this.label_rrcc2.Click += new System.EventHandler(this.label_rrcc2_Click);
            // 
            // label_rrcc3_ver
            // 
            this.label_rrcc3_ver.AutoSize = true;
            this.label_rrcc3_ver.Location = new System.Drawing.Point(153, 87);
            this.label_rrcc3_ver.Name = "label_rrcc3_ver";
            this.label_rrcc3_ver.Size = new System.Drawing.Size(28, 13);
            this.label_rrcc3_ver.TabIndex = 4;
            this.label_rrcc3_ver.Text = "v1.0";
            this.label_rrcc3_ver.Click += new System.EventHandler(this.label_rrcc3_ver_Click);
            // 
            // checkbox_winStartup
            // 
            this.checkbox_winStartup.AutoSize = true;
            this.checkbox_winStartup.Location = new System.Drawing.Point(12, 200);
            this.checkbox_winStartup.Name = "checkbox_winStartup";
            this.checkbox_winStartup.Size = new System.Drawing.Size(145, 17);
            this.checkbox_winStartup.TabIndex = 6;
            this.checkbox_winStartup.Text = "Run on Windows Startup";
            this.checkbox_winStartup.UseVisualStyleBackColor = true;
            this.checkbox_winStartup.CheckedChanged += new System.EventHandler(this.checkbox_winStartup_CheckedChanged);
            // 
            // checkbox_launchMinimized
            // 
            this.checkbox_launchMinimized.AutoSize = true;
            this.checkbox_launchMinimized.Location = new System.Drawing.Point(12, 219);
            this.checkbox_launchMinimized.Name = "checkbox_launchMinimized";
            this.checkbox_launchMinimized.Size = new System.Drawing.Size(111, 17);
            this.checkbox_launchMinimized.TabIndex = 7;
            this.checkbox_launchMinimized.Text = "Launch Minimized";
            this.checkbox_launchMinimized.UseVisualStyleBackColor = true;
            this.checkbox_launchMinimized.CheckedChanged += new System.EventHandler(this.checkbox_launchMinimized_CheckedChanged);
            // 
            // btnLocate
            // 
            this.btnLocate.Location = new System.Drawing.Point(166, 212);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(117, 26);
            this.btnLocate.TabIndex = 8;
            this.btnLocate.Text = "Locate Game Files";
            this.btnLocate.UseVisualStyleBackColor = true;
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
            // 
            // radio_newCursor
            // 
            this.radio_newCursor.AutoSize = true;
            this.radio_newCursor.Location = new System.Drawing.Point(12, 145);
            this.radio_newCursor.Name = "radio_newCursor";
            this.radio_newCursor.Size = new System.Drawing.Size(80, 17);
            this.radio_newCursor.TabIndex = 9;
            this.radio_newCursor.TabStop = true;
            this.radio_newCursor.Text = "New Cursor";
            this.radio_newCursor.UseVisualStyleBackColor = true;
            this.radio_newCursor.CheckedChanged += new System.EventHandler(this.radio_newCursor_CheckedChanged);
            // 
            // radio_oldCursor
            // 
            this.radio_oldCursor.AutoSize = true;
            this.radio_oldCursor.Location = new System.Drawing.Point(12, 164);
            this.radio_oldCursor.Name = "radio_oldCursor";
            this.radio_oldCursor.Size = new System.Drawing.Size(74, 17);
            this.radio_oldCursor.TabIndex = 10;
            this.radio_oldCursor.TabStop = true;
            this.radio_oldCursor.Text = "Old Cursor";
            this.radio_oldCursor.UseVisualStyleBackColor = true;
            this.radio_oldCursor.CheckedChanged += new System.EventHandler(this.radio_oldCursor_CheckedChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripMenuItem_selectedGameDir,
            this.stripMenuItem_update});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(288, 24);
            this.menuStrip.TabIndex = 11;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // stripMenuItem_selectedGameDir
            // 
            this.stripMenuItem_selectedGameDir.Name = "stripMenuItem_selectedGameDir";
            this.stripMenuItem_selectedGameDir.Size = new System.Drawing.Size(148, 20);
            this.stripMenuItem_selectedGameDir.Text = "Selected Game Directory";
            this.stripMenuItem_selectedGameDir.Click += new System.EventHandler(this.stripMenuItem_selectedGameDir_Click);
            // 
            // stripMenuItem_update
            // 
            this.stripMenuItem_update.Name = "stripMenuItem_update";
            this.stripMenuItem_update.Size = new System.Drawing.Size(57, 20);
            this.stripMenuItem_update.Text = "Update";
            this.stripMenuItem_update.Click += new System.EventHandler(this.stripMenuItem_update_Click);
            // 
            // RRCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 244);
            this.Controls.Add(this.radio_oldCursor);
            this.Controls.Add(this.radio_newCursor);
            this.Controls.Add(this.btnLocate);
            this.Controls.Add(this.checkbox_launchMinimized);
            this.Controls.Add(this.checkbox_winStartup);
            this.Controls.Add(this.label_rrcc3_ver);
            this.Controls.Add(this.label_rrcc2);
            this.Controls.Add(this.label_rrcc1);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "RRCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return Roblox Classic Cursor";
            this.Load += new System.EventHandler(this.RRCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label label_rrcc1;
        private System.Windows.Forms.Label label_rrcc2;
        private System.Windows.Forms.Label label_rrcc3_ver;
        private System.Windows.Forms.CheckBox checkbox_winStartup;
        private System.Windows.Forms.CheckBox checkbox_launchMinimized;
        private System.Windows.Forms.Button btnLocate;
        private System.Windows.Forms.RadioButton radio_newCursor;
        private System.Windows.Forms.RadioButton radio_oldCursor;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_selectedGameDir;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_update;
    }
}

