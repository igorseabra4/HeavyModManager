using HeavyModManager.Classes;
using HeavyModManager.Forms.Other;
using System.Diagnostics;

namespace HeavyModManager.Forms
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            IconManager.SetIcon(this);
            labelProductName.Text = $"Heavy Mod Manager {new ModManagerVersion().Version}";
            TopMost = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
                return;
            if (e.CloseReason == CloseReason.FormOwnerClosing)
                return;

            e.Cancel = true;
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/igorseabra4/HeavyModManager") { UseShellExecute = true });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://discord.gg/9eAE6UB") { UseShellExecute = true });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://heavyironmodding.org/wiki/Heavy_Mod_Manager") { UseShellExecute = true });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
