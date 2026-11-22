using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HeavyModManager.Forms
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm()
        {
            InitializeComponent();
        }

        public void SetDetails(string details)
        {
            labelDetails.Text = details;
        }

        public void SetProgress(int percent)
        {
            if (InvokeRequired)
            {
                Invoke(() => SetProgress(percent));
                return;
            }

            if (progressBar1.Style != ProgressBarStyle.Continuous)
                progressBar1.Style = ProgressBarStyle.Continuous;

            progressBar1.Value = Math.Clamp(percent, 0, 100);
            labelPercentage.Text = $"{percent}%";
        }

        public void SetIndeterminate(bool indeterminate)
        {
            if (InvokeRequired)
            {
                Invoke(() => SetIndeterminate(indeterminate));
                return;
            }

            progressBar1.Style = indeterminate
                ? ProgressBarStyle.Marquee
                : ProgressBarStyle.Continuous;

            labelPercentage.Text = "Processing...";
        }
    }
}
