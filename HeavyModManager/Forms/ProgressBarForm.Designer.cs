namespace HeavyModManager.Forms
{
    partial class ProgressBarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressBarForm));
            progressBar1 = new ProgressBar();
            labelPercentage = new Label();
            labelDetails = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Name = "progressBar1";
            progressBar1.Step = 1;
            progressBar1.Style = ProgressBarStyle.Marquee;
            // 
            // labelPercentage
            // 
            resources.ApplyResources(labelPercentage, "labelPercentage");
            labelPercentage.Name = "labelPercentage";
            // 
            // labelDetails
            // 
            resources.ApplyResources(labelDetails, "labelDetails");
            labelDetails.Name = "labelDetails";
            // 
            // ProgressBarForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(labelDetails);
            Controls.Add(labelPercentage);
            Controls.Add(progressBar1);
            Cursor = Cursors.WaitCursor;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProgressBarForm";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private Label labelPercentage;
        private Label labelDetails;
    }
}