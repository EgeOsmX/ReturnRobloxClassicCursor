using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Return_Roblox_Classic_Cursor
{
    public partial class Locate : Form
    {
        private int collapsedHeight;
        private int autoHeight;
        private int manualHeight;

        public Locate()
        {
            InitializeComponent();
        }

        private void Locate_Load(object sender, EventArgs e)
        {
            collapsedHeight = this.Height;
            autoHeight = collapsedHeight + 39;
            manualHeight = collapsedHeight + 90;

            textboxBrowse.Visible = false;
            btnBrowse.Visible = false;
            btnCheck.Visible = false;

            label_status.Text = "";

            label_bgMonitoringInfo.Text =
                "🛈 Monitors Roblox in the\r\n" +
                "background and reapplies your\r\n" +
                "selected cursor when needed.";

            string iniPath = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
    "AppData",
    "LocalLow",
    "EgeOsmX",
    "Return Roblox Classic Cursor",
    "Preferences.ini"
);

            if (File.Exists(iniPath))
            {
                foreach (string line in File.ReadAllLines(iniPath))
                {
                    if (line.StartsWith("auto="))
                    {
                        checkboxBgMonitoring.Checked =
                            line.Substring(5).Trim() == "1";
                        break;
                    }
                }
            }

            UpdateBgMonitoringState();
        }

        private async Task AnimateHeight(int targetHeight)
        {
            while (this.Height != targetHeight)
            {
                if (this.Height < targetHeight)
                {
                    this.Height += 5;

                    if (this.Height > targetHeight)
                        this.Height = targetHeight;
                }
                else
                {
                    this.Height -= 5;

                    if (this.Height < targetHeight)
                        this.Height = targetHeight;
                }

                await Task.Delay(10);
            }
        }

        private async Task AutoSearch()
        {
            label_status.ForeColor = Color.Black;
            label_status.Text = "Searching for \"RobloxPlayerBeta.exe\"...";

            await Task.Delay(250);

            string robloxVersions = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Roblox",
                "Versions"
            );

            string foundPath = null;

            if (Directory.Exists(robloxVersions))
            {
                foreach (string dir in Directory.GetDirectories(robloxVersions))
                {
                    string exePath = Path.Combine(dir, "RobloxPlayerBeta.exe");

                    if (File.Exists(exePath))
                    {
                        foundPath = exePath;
                        break;
                    }
                }
            }

            if (foundPath != null)
            {
                SaveGameDir(foundPath);

                label_status.ForeColor = Color.Green;
                label_status.Text = "\"RobloxPlayerBeta.exe\" found. You can close this window now.";
            }
            else
            {
                label_status.ForeColor = Color.Red;
                label_status.Text = "\"RobloxPlayerBeta.exe\" not found.";
            }

            btnContinue.Enabled = true;
        }

        private void SaveGameDir(string path)
        {
            string iniPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "AppData",
                "LocalLow",
                "EgeOsmX",
                "Return Roblox Classic Cursor",
                "Preferences.ini"
            );

            if (!File.Exists(iniPath))
                return;

            string[] lines = File.ReadAllLines(iniPath);

            bool foundGameDir = false;
            bool foundCursor = false;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("gamedir="))
                {
                    lines[i] = "gamedir=" + path;
                    foundGameDir = true;
                }

                if (lines[i].StartsWith("cursor="))
                {
                    if (lines[i].Trim() == "cursor=0")
                        lines[i] = "cursor=1";

                    foundCursor = true;
                }
            }

            if (!foundGameDir)
            {
                Array.Resize(ref lines, lines.Length + 1);
                lines[lines.Length - 1] = "gamedir=" + path;
            }

            if (!foundCursor)
            {
                Array.Resize(ref lines, lines.Length + 1);
                lines[lines.Length - 1] = "cursor=1";
            }

            File.WriteAllLines(iniPath, lines);
        }
        private void UpdateBgMonitoringState()
        {
            checkboxBgMonitoring.Enabled = radio_auto.Checked;

            if (!radio_auto.Checked)
            {
                label_bgMonitoringInfo.ForeColor = SystemColors.GrayText;
            }
            else
            {
                label_bgMonitoringInfo.ForeColor = SystemColors.ControlText;
            }
        }

        private void SaveAutoSetting(bool enabled)
        {
            string iniPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "AppData",
                "LocalLow",
                "EgeOsmX",
                "Return Roblox Classic Cursor",
                "Preferences.ini"
            );

            if (!File.Exists(iniPath))
                return;

            string[] lines = File.ReadAllLines(iniPath);

            bool found = false;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("auto="))
                {
                    lines[i] = "auto=" + (enabled ? "1" : "0");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Array.Resize(ref lines, lines.Length + 1);
                lines[lines.Length - 1] = "auto=" + (enabled ? "1" : "0");
            }

            File.WriteAllLines(iniPath, lines);
        }

        private void label_locate_Click(object sender, EventArgs e)
        {
        }

        private void radio_auto_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBgMonitoringState();
        }

        private void radio_manual_CheckedChanged(object sender, EventArgs e)
        {
            checkboxBgMonitoring.Checked = false;
            checkboxBgMonitoring.Enabled = false;

            SaveAutoSetting(false);
        }

        private void label_status_Click(object sender, EventArgs e)
        {
        }

        private async void btnContinue_Click(object sender, EventArgs e)
        {
            btnContinue.Enabled = false;

            if (radio_auto.Checked)
            {
                textboxBrowse.Visible = false;
                btnBrowse.Visible = false;
                btnCheck.Visible = false;

                await AnimateHeight(collapsedHeight);
                await AnimateHeight(autoHeight);

                await AutoSearch();
            }
            else if (radio_manual.Checked)
            {
                await AnimateHeight(collapsedHeight);

                textboxBrowse.Visible = true;
                btnBrowse.Visible = true;
                btnCheck.Visible = true;

                await AnimateHeight(manualHeight);

                label_status.ForeColor = Color.Black;
                label_status.Text = "Select RobloxPlayerBeta.exe";

                btnContinue.Enabled = true;
            }
            else
            {
                label_status.ForeColor = Color.Red;
                label_status.Text = "Select an option.";

                btnContinue.Enabled = true;
            }
        }

        private void textboxBrowse_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "RobloxPlayerBeta.exe|RobloxPlayerBeta.exe";

            ofd.InitialDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Roblox",
                "Versions"
            );

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textboxBrowse.Text = ofd.FileName;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textboxBrowse.Text))
            {
                label_status.ForeColor = Color.Red;
                label_status.Text = "File not found.";
                return;
            }

            if (Path.GetFileName(textboxBrowse.Text) != "RobloxPlayerBeta.exe")
            {
                label_status.ForeColor = Color.Red;
                label_status.Text = "Invalid file selected.";
                return;
            }

            SaveGameDir(textboxBrowse.Text);

            label_status.ForeColor = Color.Green;
            label_status.Text = "Verified. You can close this window.";
        }

        private void checkboxBgMonitoring_CheckedChanged(object sender, EventArgs e)
        {
            SaveAutoSetting(checkboxBgMonitoring.Checked);
        }

        private void label_bgMonitoringInfo_Click(object sender, EventArgs e)
        {

        }
    }
}