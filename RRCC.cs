using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Drawing.Imaging;
using System.Net;

namespace Return_Roblox_Classic_Cursor
{
    public partial class RRCC : Form
    {
        private string iniPath;

        private Timer iniTimer = new Timer();
        private NotifyIcon trayIcon = new NotifyIcon();

        private Timer robloxTimer = new Timer();

        private Timer monitorTimer = new Timer();

        private Timer countdownTimer = new Timer();

        private bool robloxRunning = false;
        private DateTime robloxStartTime;

        private ContextMenuStrip trayMenu = new ContextMenuStrip();

        private ToolStripMenuItem menuCountdown =
            new ToolStripMenuItem("Next check: --");

        private ToolStripMenuItem menuRestore =
            new ToolStripMenuItem("Show app");

        private ToolStripMenuItem menuExit =
            new ToolStripMenuItem("Quit");

        private DateTime nextCheckTime;

        private string cachedGameDir = "";

        private ToolStripMenuItem menuUpdatesEnabled =
    new ToolStripMenuItem("Updates");

        private ToolStripMenuItem menuUpdateStatus =
            new ToolStripMenuItem("Checking...");

        private ToolStripMenuItem menuCurrentVersion =
            new ToolStripMenuItem("Current version: ?");

        private bool loadingIni = false;

        private string updateInstallUrl = "";

        public RRCC()
        {
            InitializeComponent();

            this.Resize += RRCC_Resize;
            this.Icon = Properties.Resources.icon;
        }

        private async void RRCC_Load(object sender, EventArgs e)
        {
            string appDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "AppData",
                "LocalLow",
                "EgeOsmX",
                "Return Roblox Classic Cursor"
            );

            Directory.CreateDirectory(appDir);

            iniPath = Path.Combine(appDir, "Preferences.ini");

            pictureBoxLogo.Image = Properties.Resources.iconBig;
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;

            loadingIni = true;

            if (!File.Exists(iniPath) ||
    string.IsNullOrWhiteSpace(File.ReadAllText(iniPath)))
            {
                File.WriteAllText(iniPath,
            @"[RRCC]
ver=1.0
gamedir=
auto=0
cursor=0
startup=0
minimized=0
update=1
");
            }

            LoadIni();
            loadingIni = false;

            if (checkbox_launchMinimized.Checked)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    this.WindowState = FormWindowState.Minimized;
                });
            }

            iniTimer.Interval = 250;
            iniTimer.Tick += IniTimer_Tick;
            iniTimer.Start();

            trayIcon.Icon = Properties.Resources.icon;
            trayIcon.Text = "Return Roblox Classic Cursor";
            trayIcon.Visible = false;

            menuCountdown.Enabled = false;

            menuRestore.Click += (s, ev) =>
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                trayIcon.Visible = false;
                this.Activate();
            };

            menuExit.Click += (s, ev) =>
            {
                trayIcon.Visible = false;
                Application.Exit();
            };

            trayMenu.Items.Add(menuCountdown);
            trayMenu.Items.Add(new ToolStripSeparator());
            trayMenu.Items.Add(menuRestore);
            trayMenu.Items.Add(menuExit);

            trayIcon.ContextMenuStrip = trayMenu;

            trayIcon.MouseClick += (s, ev) =>
            {
                if (ev.Button == MouseButtons.Left)
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                    trayIcon.Visible = false;
                    this.Activate();
                }
            };

            trayIcon.DoubleClick += (s, ev) =>
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                trayIcon.Visible = false;
            };

            robloxTimer.Interval = 180000; // 3 min
            robloxTimer.Tick += RobloxTimer_Tick;
            robloxTimer.Start();

            nextCheckTime = DateTime.Now.AddMinutes(3);

            monitorTimer.Interval = 1000;
            monitorTimer.Tick += MonitorTimer_Tick;
            monitorTimer.Start();

            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();

            CheckRobloxCursor();

            UpdateGameDirMenu();

            menuUpdatesEnabled.CheckOnClick = true;

            menuUpdateStatus.Enabled = false;
            menuCurrentVersion.Enabled = false;

            stripMenuItem_update.DropDownItems.Add(menuUpdatesEnabled);
            stripMenuItem_update.DropDownItems.Add(menuUpdateStatus);
            stripMenuItem_update.DropDownItems.Add(menuCurrentVersion);

            menuUpdateStatus.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(updateInstallUrl))
                    return;

                System.Diagnostics.Process.Start(
                    "explorer.exe",
                    updateInstallUrl);
            };

            menuCurrentVersion.Text =
    "Current version: " +
    label_rrcc3_ver.Text.Replace("v", "");

            menuUpdatesEnabled.CheckedChanged += async (s, ev) =>
            {
                if (loadingIni)
                    return;

                SaveIni();

                UpdateUpdateMenu();

                if (menuUpdatesEnabled.Checked)
                    await CheckForUpdates();
            };

            UpdateUpdateMenu();

            loadingIni = false;

            if (menuUpdatesEnabled.Checked)
            {
                await CheckForUpdates();
            }
        }

        private void UpdateUpdateMenu()
        {
            bool enabled = menuUpdatesEnabled.Checked;

            menuUpdateStatus.Visible = enabled;
            menuCurrentVersion.Visible = enabled;

            if (!enabled)
            {
                menuUpdateStatus.Text = "";
                menuCurrentVersion.Text = "";
                stripMenuItem_update.Text = "Update";
            }
            else
            {
                menuCurrentVersion.Text =
                    "Current version: " +
                    label_rrcc3_ver.Text.Replace("v", "");

                if (string.IsNullOrWhiteSpace(menuUpdateStatus.Text))
                    menuUpdateStatus.Text = "Checking...";
            }
        }

        private async Task CheckForUpdates()
        {

            if (!menuUpdatesEnabled.Checked)
            {
                menuUpdateStatus.Text = "";
                menuCurrentVersion.Text = "";
                return;
            }

            if (!menuUpdatesEnabled.Checked)
            {
                menuUpdateStatus.Text = "Updates disabled";
                menuUpdateStatus.Enabled = false;
                return;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string ini =
                        await wc.DownloadStringTaskAsync(
                            "https://raw.githubusercontent.com/EgeOsmX/ReturnRobloxClassicCursor/refs/heads/main/version.ini");

                    string latestVersion = "";

                    string installUrl = "";

                    bool inLatest = false;

                    foreach (string line in ini.Split('\n'))
                    {
                        string l = line.Trim();

                        if (string.IsNullOrWhiteSpace(latestVersion))
                        {
                            stripMenuItem_update.Text = "Update";

                            menuUpdateStatus.Text =
                                "You are up to date";

                            menuUpdateStatus.Enabled = false;

                            return;
                        }

                        if (l == "[latest]")
                        {
                            inLatest = true;
                            continue;
                        }

                        if (l.StartsWith("[") && l != "[latest]")
                        {
                            inLatest = false;
                            continue;
                        }

                        if (!inLatest)
                            continue;

                        if (l.StartsWith("latestversion="))
                        {
                            latestVersion = l.Substring(14).Trim();
                        }
                        else if (l.StartsWith("install="))
                        {
                            installUrl = l.Substring(8).Trim();
                        }
                    }

                    updateInstallUrl = installUrl;

                    string currentVersion =
                        label_rrcc3_ver.Text
                        .Replace("v", "")
                        .Trim();

                    if (latestVersion != currentVersion)
                    {
                        updateInstallUrl = installUrl;

                        stripMenuItem_update.Text = "Update Available";

                        menuUpdateStatus.Text =
                            $"Update Available: {latestVersion} (click)";

                        menuUpdateStatus.Enabled = true;
                    }
                    else
                    {
                        stripMenuItem_update.Text = "Update";

                        menuUpdateStatus.Text =
                            "You are up to date";

                        menuUpdateStatus.Enabled = false;
                    }
                }
            }
            catch(Exception ex)
{
                MessageBox.Show(ex.ToString());

                menuUpdateStatus.Text =
                    "Update check failed";

                menuUpdateStatus.Enabled = false;
            }
        }

        private void UpdateGameDirMenu()
        {
            stripMenuItem_selectedGameDir.DropDownItems.Clear();

            ToolStripMenuItem gameDirItem = new ToolStripMenuItem();

            gameDirItem.Enabled = false;

            string gameDir = cachedGameDir;

            if (string.IsNullOrWhiteSpace(gameDir))
                gameDirItem.Text = "No game directory selected";
            else
                gameDirItem.Text = gameDir;

            stripMenuItem_selectedGameDir.DropDownItems.Add(gameDirItem);
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (GetIniValue("auto") != "1")
            {
                menuCountdown.Text = "Kontrol süresi: Devre dışı";
                return;
            }

            if (robloxRunning)
            {
                int fastRemaining =
                    60 - (int)(DateTime.Now - robloxStartTime).TotalSeconds;

                if (fastRemaining < 0)
                    fastRemaining = 0;

                menuCountdown.Text =
                    $"Checking for {fastRemaining}s";

                return;
            }

            TimeSpan remaining = nextCheckTime - DateTime.Now;

            if (remaining.TotalSeconds < 0)
                remaining = TimeSpan.Zero;

            menuCountdown.Text =
                $"Kontrol süresi: {remaining.Minutes}m {remaining.Seconds}s";
        }

        private void MonitorTimer_Tick(object sender, EventArgs e)
        {
            if (GetIniValue("auto") != "1")
                return;

            bool isRunning =
    System.Diagnostics.Process.GetProcesses()
    .Any(p =>
    {
        try
        {
            return p.ProcessName.Equals(
                "RobloxPlayerBeta",
                StringComparison.OrdinalIgnoreCase);
        }
        catch
        {
            return false;
        }
    });

            if (isRunning && !robloxRunning)
            {
                robloxRunning = true;
                robloxStartTime = DateTime.Now;

                robloxTimer.Interval = 1000;

                CheckRobloxCursor();
            }

            if (!isRunning && robloxRunning)
            {
                robloxRunning = false;
                robloxTimer.Interval = 180000;

                nextCheckTime = DateTime.Now.AddMinutes(3);
            }
        }

        private void RobloxTimer_Tick(object sender, EventArgs e)
        {
            CheckRobloxCursor();

            if (!robloxRunning)
            {
                nextCheckTime = DateTime.Now.AddMinutes(3);
            }
        }

        private void IniTimer_Tick(object sender, EventArgs e)
        {
            LoadIni();
        }

        private string GetIniValue(string key)
        {
            if (!File.Exists(iniPath))
                return "";

            foreach (string line in File.ReadAllLines(iniPath))
            {
                if (line.StartsWith(key + "="))
                    return line.Substring(key.Length + 1).Trim();
            }

            return "";
        }

        private string FindLatestRobloxExe()
        {
            string versionsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Roblox",
                "Versions"
            );

            if (!Directory.Exists(versionsPath))
                return null;

            string newestExe = null;
            DateTime newestTime = DateTime.MinValue;

            foreach (string dir in Directory.GetDirectories(versionsPath))
            {
                string exe = Path.Combine(dir, "RobloxPlayerBeta.exe");

                if (!File.Exists(exe))
                    continue;

                DateTime time = File.GetLastWriteTime(exe);

                if (time > newestTime)
                {
                    newestTime = time;
                    newestExe = exe;
                }
            }

            return newestExe;
        }

        private void CheckRobloxCursor()
        {
            if (GetIniValue("auto") != "1")
                return;

            string gameDir = FindLatestRobloxExe();

            if (string.IsNullOrEmpty(gameDir))
                return;

            string cursorMode = GetIniValue("cursor");

            ApplyCursorFiles(gameDir, cursorMode);

            if (robloxRunning)
            {
                if ((DateTime.Now - robloxStartTime).TotalSeconds >= 60)
                {
                    robloxRunning = false;
                    robloxTimer.Interval = 180000;
                }
            }
        }

        private void ApplyCursorFiles(string gameExe, string cursorMode)
        {
            string versionDir = Directory.GetParent(gameExe).FullName;

            string cursorDir = Path.Combine(
                versionDir,
                "content",
                "textures",
                "Cursors",
                "KeyboardMouse"
            );

            if (!Directory.Exists(cursorDir))
                return;

            try
            {
                if (cursorMode == "2")
                {
                    Properties.Resources.ArrowCursor.Save(
                        Path.Combine(cursorDir, "ArrowCursor.png"),
                        ImageFormat.Png);

                    Properties.Resources.ArrowFarCursor.Save(
                        Path.Combine(cursorDir, "ArrowFarCursor.png"),
                        ImageFormat.Png);

                    Properties.Resources.IBeamCursor.Save(
                        Path.Combine(cursorDir, "IBeamCursor.png"),
                        ImageFormat.Png);
                }
                else if (cursorMode == "1")
                {
                    Properties.Resources.ArrowCursor_new.Save(
                        Path.Combine(cursorDir, "ArrowCursor.png"),
                        ImageFormat.Png);

                    Properties.Resources.ArrowFarCursor_new.Save(
                        Path.Combine(cursorDir, "ArrowFarCursor.png"),
                        ImageFormat.Png);

                    Properties.Resources.IBeamCursor_new.Save(
                        Path.Combine(cursorDir, "IBeamCursor.png"),
                        ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveIni()
        {
            if (loadingIni)
                return;

            string version = label_rrcc3_ver.Text.Replace("v", "").Trim();

            string gamedir = "";

            string auto = "";

            if (File.Exists(iniPath))
            {
                foreach (string line in File.ReadAllLines(iniPath))
                {
                    if (line.StartsWith("gamedir="))
                        gamedir = line.Substring(8);

                    else if (line.StartsWith("auto="))
                        auto = line.Substring(5);
                }
            }

            int cursor = 0;

            if (radio_newCursor.Checked)
                cursor = 1;
            else if (radio_oldCursor.Checked)
                cursor = 2;


            string content =
$@"[RRCC]
ver={version}
gamedir={gamedir}
auto={auto}
cursor={cursor}
startup={(checkbox_winStartup.Checked ? 1 : 0)}
minimized={(checkbox_launchMinimized.Checked ? 1 : 0)}
update={(menuUpdatesEnabled.Checked ? 1 : 0)}";

            File.WriteAllText(iniPath, content);
        }


        private void LoadIni()
        {
            loadingIni = true;

            if (!File.Exists(iniPath))
                return;

            string[] lines = File.ReadAllLines(iniPath);

            foreach (string line in lines)
            {
                if (line.StartsWith("cursor="))
                {
                    string value = line.Substring(7).Trim();

                    switch (value)
                    {
                        case "0":
                            radio_newCursor.Checked = false;
                            radio_oldCursor.Checked = false;

                            radio_newCursor.Enabled = false;
                            radio_oldCursor.Enabled = false;
                            break;

                        case "1":
                            radio_newCursor.Enabled = true;
                            radio_oldCursor.Enabled = true;

                            radio_newCursor.Checked = true;
                            break;

                        case "2":
                            radio_newCursor.Enabled = true;
                            radio_oldCursor.Enabled = true;

                            radio_oldCursor.Checked = true;
                            break;
                    }
                }
                else if (line.StartsWith("startup="))
                {
                    checkbox_winStartup.Checked =
                        line.Substring(8) == "1";
                }
                else if (line.StartsWith("minimized="))
                {
                    checkbox_launchMinimized.Checked =
                        line.Substring(10) == "1";
                }

                else if (line.StartsWith("gamedir="))
                {
                    string newGameDir = line.Substring(8).Trim();

                    if (cachedGameDir != newGameDir)
                    {
                        cachedGameDir = newGameDir;

                        UpdateGameDirMenu();
                    }
                }
                else if (line.StartsWith("update="))
                {
                    menuUpdatesEnabled.Checked =
                        line.Substring(7).Trim() == "1";

                    UpdateUpdateMenu();
                }
            }

            loadingIni = false;
        }

        private void RRCC_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                trayIcon.Visible = true;
            }
        }


        private void label_rrcc1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void label_rrcc2_Click(object sender, EventArgs e)
        {

        }

        private void label_rrcc3_ver_Click(object sender, EventArgs e)
        {

        }

        private void checkbox_winStartup_CheckedChanged(object sender, EventArgs e)
        {
            string appName = "RRCC";

            using (Microsoft.Win32.RegistryKey key =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (checkbox_winStartup.Checked)
                {
                    key.SetValue(appName, Application.ExecutablePath);
                }
                else
                {
                    key.DeleteValue(appName, false);
                }
            }

            SaveIni();
        }

        private void checkbox_launchMinimized_CheckedChanged(object sender, EventArgs e)
        {
            SaveIni();
        }

        private void radio_newCursor_CheckedChanged(object sender, EventArgs e)
        {
            SaveIni();

            if (radio_newCursor.Checked)
                CheckRobloxCursor();
        }

        private void radio_oldCursor_CheckedChanged(object sender, EventArgs e)
        {
            SaveIni();

            if (radio_oldCursor.Checked)
                CheckRobloxCursor();
        }

        private void btnLocate_Click(object sender, EventArgs e)
        {
            Locate locate = new Locate();
            locate.ShowDialog();

            CheckRobloxCursor();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void stripMenuItem_selectedGameDir_Click(object sender, EventArgs e)
        {

        }

        private void stripMenuItem_update_Click(object sender, EventArgs e)
        {

        }
    }
}
