using HeavyModManager.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HeavyModManager.Forms
{
    public partial class SettingsForm : Form
    {
        private string xemuDocsUrl = "https://xemu.app/docs/cli/";

        private string dolphinDocsUrl = "https://github.com/dolphin-emu/dolphin/blob/master/Readme.md#command-line-usage";

        private string pcsx2DocsUrl = "https://pcsx2.net/docs/advanced/cli/";

        public SettingsForm()
        {
            InitializeComponent();

            // Update UI with current settings
            textBoxDolphinPath.Text = ModManager.DolphinPath;
            textBoxXemuPath.Text = ModManager.XemuPath;
            textBoxPCSX2Path.Text = ModManager.PCSX2Path;

            textBoxDolphinArgs.Text = ModManager.DolphinCommandLineArgs;
            textBoxXemuArgs.Text = ModManager.XemuCommandLineArgs;
            textBoxPCSX2Args.Text = ModManager.PCSX2CommandLineArgs;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveEmulatorSettings();
            Close();
        }

        private void SaveEmulatorSettings()
        {
            ModManager.DolphinPath = textBoxDolphinPath.Text;
            ModManager.XemuPath = textBoxXemuPath.Text;
            ModManager.PCSX2Path = textBoxPCSX2Path.Text;

            ModManager.DolphinCommandLineArgs = textBoxDolphinArgs.Text;
            ModManager.XemuCommandLineArgs = textBoxXemuArgs.Text;
            ModManager.PCSX2CommandLineArgs = textBoxPCSX2Args.Text;
        }

        private void linkLabelDolphinArgsRef_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenReferenceLink(dolphinDocsUrl);
        }

        private void linkLabelXemuArgsRef_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenReferenceLink(xemuDocsUrl);
        }

        private void linkLabelPCSX2ArgsRef_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenReferenceLink(pcsx2DocsUrl);
        }

        private void OpenReferenceLink(string url)
        {
            var psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void buttonPickDolphinPath_Click(object sender, EventArgs e)
        {
            PromptUserToPickEmulatorPath("Select Dolphin Executable", "Dolphin Executable|dolphin.exe", textBoxDolphinPath);
        }

        private void buttonPickXemuPath_Click(object sender, EventArgs e)
        {
            PromptUserToPickEmulatorPath("Select Xemu Executable", "Xemu Executable|xemu.exe", textBoxXemuPath);
        }

        private void buttonPickPCSX2Path_Click(object sender, EventArgs e)
        {
            PromptUserToPickEmulatorPath("Select PCSX2 Executable", "PCSX2 Executable|pcsx2-qt.exe", textBoxPCSX2Path);
        }

        private void PromptUserToPickEmulatorPath(string title, string filter, TextBox targetTextBox)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = title;
                ofd.Filter = filter + "|All Executables|*.exe|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    targetTextBox.Text = ofd.FileName;
                }
            }
        }
    }
}
