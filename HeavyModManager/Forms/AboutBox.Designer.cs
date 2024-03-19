namespace HeavyModManager.Forms
{
    partial class AboutBox
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            tableLayoutPanel = new TableLayoutPanel();
            labelProductName = new Label();
            labelCopyright = new Label();
            textBoxDescription = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonClose = new Button();
            buttonSource = new Button();
            buttonDiscord = new Button();
            buttonWiki = new Button();
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(tableLayoutPanel, "tableLayoutPanel");
            tableLayoutPanel.Controls.Add(labelProductName, 0, 0);
            tableLayoutPanel.Controls.Add(labelCopyright, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxDescription, 0, 2);
            tableLayoutPanel.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // labelProductName
            // 
            resources.ApplyResources(labelProductName, "labelProductName");
            labelProductName.Name = "labelProductName";
            // 
            // labelCopyright
            // 
            resources.ApplyResources(labelCopyright, "labelCopyright");
            labelCopyright.Name = "labelCopyright";
            // 
            // textBoxDescription
            // 
            textBoxDescription.BorderStyle = BorderStyle.None;
            resources.ApplyResources(textBoxDescription, "textBoxDescription");
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.ReadOnly = true;
            textBoxDescription.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonClose);
            flowLayoutPanel1.Controls.Add(buttonSource);
            flowLayoutPanel1.Controls.Add(buttonDiscord);
            flowLayoutPanel1.Controls.Add(buttonWiki);
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // buttonClose
            // 
            resources.ApplyResources(buttonClose, "buttonClose");
            buttonClose.DialogResult = DialogResult.Cancel;
            buttonClose.Name = "buttonClose";
            buttonClose.Click += button3_Click;
            // 
            // buttonSource
            // 
            resources.ApplyResources(buttonSource, "buttonSource");
            buttonSource.Name = "buttonSource";
            buttonSource.Click += button1_Click;
            // 
            // buttonDiscord
            // 
            resources.ApplyResources(buttonDiscord, "buttonDiscord");
            buttonDiscord.Name = "buttonDiscord";
            buttonDiscord.Click += button2_Click;
            // 
            // buttonWiki
            // 
            resources.ApplyResources(buttonWiki, "buttonWiki");
            buttonWiki.Name = "buttonWiki";
            buttonWiki.Click += button4_Click;
            // 
            // AboutBox
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonClose;
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AboutBox";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label labelProductName;
        private Label labelCopyright;
        private TextBox textBoxDescription;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonSource;
        private Button buttonDiscord;
        private Button buttonClose;
        private Button buttonWiki;
    }
}
