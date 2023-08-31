using HeavyModManager.Classes;

namespace HeavyModManager.Forms
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
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
            System.Diagnostics.Process.Start("https://github.com/igorseabra4/HeavyModManager");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/9eAE6UB");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(WikiLink);
        }

        public static string WikiLink => "https://heavyironmodding.org/wiki/";

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
