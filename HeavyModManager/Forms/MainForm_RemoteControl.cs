using HeavyModManager.Classes;
using HeavyModManager.Enum;
using HeavyModManager.Functions;
using System.Runtime.InteropServices;
using System.Text;

namespace HeavyModManager
{
    public partial class MainForm
    {
        private string MessageReceived = null;
        private const int WM_COPYDATA = 0x004A;

        [StructLayout(LayoutKind.Sequential)]
        private struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_COPYDATA)
            {
                var data = Marshal.PtrToStructure<COPYDATASTRUCT>(m.LParam);
                string message = Marshal.PtrToStringUni(data.lpData) ?? string.Empty;
                HandleMessage(message);
                m.Result = 1;
                return;
            }
            base.WndProc(ref m);
        }

        private void HandleMessage(string message)
        {
            MessageReceived = message;
            RemoteControlMessageReceived(message);
        }

        private bool _remoteMessageDisplayed = false;

        private void RemoteControlMessageReceived(string message)
        {
            var parse = message.Split(' ');
            if (parse.Length > 0)
            {
                if (parse[0] != "run")
                    return;
            }
            Game messageGame = Game.Null;
            if (parse.Length > 1)
            {
                switch (parse[1])
                {
                    case "Scooby":
                        messageGame = Game.Scooby;
                        break;
                    case "BFBB":
                        messageGame = Game.BFBB;
                        break;
                    case "Incredibles":
                        messageGame = ModManager.CurrentGame == Game.Incredibles ? Game.Incredibles : Game.Movie;
                        break;
                    case "ROTU":
                        messageGame = Game.Underminer;
                        break;
                    case "RatProto":
                        messageGame = Game.RatProto;
                        break;
                    default:
                        return;
                }
            }
            string? scene = null;
            if (parse.Length > 2 && parse[2].Length == 4)
                scene = parse[2];

            string? modId = null;
            if (parse.Length > 3)
                modId = parse[3];

            DialogResult dr;
            if (_remoteMessageDisplayed)
            {
                dr = DialogResult.OK;
            }
            else
            {
                var result = new StringBuilder();
                result.AppendLine($"Message received: {message}");
                if (!ModManager.DeveloperMode)
                    result.AppendLine("- Enable Developer Mode");
                if (messageGame != ModManager.CurrentGame)
                    result.AppendLine($"- Set game to {messageGame}");
                if (modId != null)
                    result.AppendLine($"- Enable mod {modId} if it exists");
                result.AppendLine($"- Apply mods");
                if (scene != null)
                    result.AppendLine($"- Set boot level to {scene}");
                result.AppendLine($"- Launch game");
                result.AppendLine("This message will not be displayed again this session.");
                dr = MessageBox.Show(result.ToString(), "Heavy Mod Manager: Message Received", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

            if (dr == DialogResult.OK)
            {
                _remoteMessageDisplayed = true;

                ModManager.DeveloperMode = true;
                developerModeToolStripMenuItem.Checked = true;

                comboBoxGame.SelectedItem = comboBoxGame.Items.Cast<ComboBoxGameItem>().First(item => item.Game == messageGame);

                if (ModManager.CurrentGameSettings.Mods.Contains(modId) && !ModManager.CurrentGameSettings.ActiveMods.Contains(modId))
                {
                    ModManager.CurrentGameSettings.ActivateMod(modId);
                    PopulateModList();
                }

                if (!CanApplyMods)
                {
                    MessageBox.Show("Error: cannot apply mods", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ModManager.Invalidate();
                Enabled = false;
                ModManager.CloseDolphin();
                ModManager.ApplyMods();

                var tempIniMod = new Mod() { INIReplacements = $"BOOT={scene}" };
                tempIniMod.ApplyIniPatches();

                Enabled = true;
                ModManager.RunGame();
            }

            UpdateDeveloperMode();
            UpdateDolphinLabel();
        }
    }
}
