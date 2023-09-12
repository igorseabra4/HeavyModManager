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
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(labelProductName, 0, 0);
            tableLayoutPanel.Controls.Add(labelCopyright, 0, 1);
            tableLayoutPanel.Controls.Add(textBoxDescription, 0, 2);
            tableLayoutPanel.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(6, 6);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(332, 295);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelProductName
            // 
            labelProductName.Dock = DockStyle.Fill;
            labelProductName.Location = new Point(7, 0);
            labelProductName.Margin = new Padding(7, 0, 4, 0);
            labelProductName.MaximumSize = new Size(0, 20);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(321, 20);
            labelProductName.TabIndex = 1;
            labelProductName.Text = "Heavy Mod Manager";
            labelProductName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            labelCopyright.Dock = DockStyle.Fill;
            labelCopyright.Location = new Point(7, 22);
            labelCopyright.Margin = new Padding(7, 0, 4, 0);
            labelCopyright.MaximumSize = new Size(0, 20);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(321, 20);
            labelCopyright.TabIndex = 2;
            labelCopyright.Text = "© 2023 igorseabra4";
            labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            textBoxDescription.BorderStyle = BorderStyle.None;
            textBoxDescription.Dock = DockStyle.Fill;
            textBoxDescription.Location = new Point(7, 47);
            textBoxDescription.Margin = new Padding(7, 3, 4, 3);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.ReadOnly = true;
            textBoxDescription.Size = new Size(321, 213);
            textBoxDescription.TabIndex = 3;
            textBoxDescription.TabStop = false;
            textBoxDescription.Text = resources.GetString("textBoxDescription.Text");
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonClose);
            flowLayoutPanel1.Controls.Add(buttonSource);
            flowLayoutPanel1.Controls.Add(buttonDiscord);
            flowLayoutPanel1.Controls.Add(buttonWiki);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 263);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(332, 32);
            flowLayoutPanel1.TabIndex = 24;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose.DialogResult = DialogResult.Cancel;
            buttonClose.Location = new Point(268, 3);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(61, 25);
            buttonClose.TabIndex = 7;
            buttonClose.Text = "Close";
            buttonClose.Click += button3_Click;
            // 
            // buttonSource
            // 
            buttonSource.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSource.Location = new Point(200, 3);
            buttonSource.Name = "buttonSource";
            buttonSource.Size = new Size(62, 25);
            buttonSource.TabIndex = 6;
            buttonSource.Text = "Source";
            buttonSource.Click += button1_Click;
            // 
            // buttonDiscord
            // 
            buttonDiscord.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDiscord.Location = new Point(135, 3);
            buttonDiscord.Name = "buttonDiscord";
            buttonDiscord.Size = new Size(59, 25);
            buttonDiscord.TabIndex = 5;
            buttonDiscord.Text = "Discord";
            buttonDiscord.Click += button2_Click;
            // 
            // buttonWiki
            // 
            buttonWiki.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonWiki.Location = new Point(73, 3);
            buttonWiki.Name = "buttonWiki";
            buttonWiki.Size = new Size(56, 25);
            buttonWiki.TabIndex = 4;
            buttonWiki.Text = "Wiki";
            buttonWiki.Click += button4_Click;
            // 
            // AboutBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonClose;
            ClientSize = new Size(344, 307);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "AboutBox";
            Padding = new Padding(6);
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About Heavy Mod Manager";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
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
