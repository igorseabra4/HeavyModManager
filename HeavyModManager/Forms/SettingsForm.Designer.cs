namespace HeavyModManager.Forms
{
    partial class SettingsForm
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
            buttonSave = new Button();
            buttonCancel = new Button();
            groupBox1 = new GroupBox();
            linkLabelXemuArgsRef = new LinkLabel();
            buttonPickXemuPath = new Button();
            textBoxXemuArgs = new TextBox();
            label3 = new Label();
            textBoxXemuPath = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            button1 = new Button();
            label7 = new Label();
            textBox1 = new TextBox();
            linkLabelDolphinArgsRef = new LinkLabel();
            buttonPickDolphinPath = new Button();
            textBoxDolphinArgs = new TextBox();
            label2 = new Label();
            textBoxDolphinPath = new TextBox();
            label4 = new Label();
            groupBox3 = new GroupBox();
            linkLabelPCSX2ArgsRef = new LinkLabel();
            buttonPickPCSX2Path = new Button();
            textBoxPCSX2Args = new TextBox();
            label5 = new Label();
            textBoxPCSX2Path = new TextBox();
            label6 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(297, 298);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(114, 23);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save Settings";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(417, 298);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(106, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(linkLabelXemuArgsRef);
            groupBox1.Controls.Add(buttonPickXemuPath);
            groupBox1.Controls.Add(textBoxXemuArgs);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxXemuPath);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 132);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(511, 77);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Microsoft Xbox";
            // 
            // linkLabelXemuArgsRef
            // 
            linkLabelXemuArgsRef.AutoSize = true;
            linkLabelXemuArgsRef.Location = new Point(106, 48);
            linkLabelXemuArgsRef.Name = "linkLabelXemuArgsRef";
            linkLabelXemuArgsRef.Size = new Size(59, 15);
            linkLabelXemuArgsRef.TabIndex = 8;
            linkLabelXemuArgsRef.TabStop = true;
            linkLabelXemuArgsRef.Text = "Reference";
            linkLabelXemuArgsRef.LinkClicked += linkLabelXemuArgsRef_LinkClicked;
            // 
            // buttonPickXemuPath
            // 
            buttonPickXemuPath.Location = new Point(465, 15);
            buttonPickXemuPath.Name = "buttonPickXemuPath";
            buttonPickXemuPath.Size = new Size(40, 23);
            buttonPickXemuPath.TabIndex = 7;
            buttonPickXemuPath.Text = "...";
            buttonPickXemuPath.UseVisualStyleBackColor = true;
            buttonPickXemuPath.Click += buttonPickXemuPath_Click;
            // 
            // textBoxXemuArgs
            // 
            textBoxXemuArgs.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxXemuArgs.Location = new Point(171, 45);
            textBoxXemuArgs.Name = "textBoxXemuArgs";
            textBoxXemuArgs.Size = new Size(334, 23);
            textBoxXemuArgs.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 48);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 4;
            label3.Text = "Arguments";
            // 
            // textBoxXemuPath
            // 
            textBoxXemuPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxXemuPath.Location = new Point(171, 16);
            textBoxXemuPath.Name = "textBoxXemuPath";
            textBoxXemuPath.Size = new Size(289, 23);
            textBoxXemuPath.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 2;
            label1.Text = "Xemu Executable Path";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(linkLabelDolphinArgsRef);
            groupBox2.Controls.Add(buttonPickDolphinPath);
            groupBox2.Controls.Add(textBoxDolphinArgs);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBoxDolphinPath);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(511, 114);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nintendo GameCube";
            // 
            // button1
            // 
            button1.Location = new Point(465, 45);
            button1.Name = "button1";
            button1.Size = new Size(40, 23);
            button1.TabIndex = 9;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 48);
            label7.Name = "label7";
            label7.Size = new Size(138, 15);
            label7.TabIndex = 8;
            label7.Text = "Dolphin User Folder Path";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(171, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(289, 23);
            textBox1.TabIndex = 7;
            // 
            // linkLabelDolphinArgsRef
            // 
            linkLabelDolphinArgsRef.AutoSize = true;
            linkLabelDolphinArgsRef.Location = new Point(106, 77);
            linkLabelDolphinArgsRef.Name = "linkLabelDolphinArgsRef";
            linkLabelDolphinArgsRef.Size = new Size(59, 15);
            linkLabelDolphinArgsRef.TabIndex = 7;
            linkLabelDolphinArgsRef.TabStop = true;
            linkLabelDolphinArgsRef.Text = "Reference";
            linkLabelDolphinArgsRef.LinkClicked += linkLabelDolphinArgsRef_LinkClicked;
            // 
            // buttonPickDolphinPath
            // 
            buttonPickDolphinPath.Location = new Point(465, 16);
            buttonPickDolphinPath.Name = "buttonPickDolphinPath";
            buttonPickDolphinPath.Size = new Size(40, 23);
            buttonPickDolphinPath.TabIndex = 6;
            buttonPickDolphinPath.Text = "...";
            buttonPickDolphinPath.UseVisualStyleBackColor = true;
            buttonPickDolphinPath.Click += buttonPickDolphinPath_Click;
            // 
            // textBoxDolphinArgs
            // 
            textBoxDolphinArgs.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDolphinArgs.Location = new Point(171, 74);
            textBoxDolphinArgs.Name = "textBoxDolphinArgs";
            textBoxDolphinArgs.Size = new Size(334, 23);
            textBoxDolphinArgs.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 77);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 4;
            label2.Text = "Arguments";
            // 
            // textBoxDolphinPath
            // 
            textBoxDolphinPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDolphinPath.Location = new Point(171, 16);
            textBoxDolphinPath.Name = "textBoxDolphinPath";
            textBoxDolphinPath.Size = new Size(288, 23);
            textBoxDolphinPath.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 19);
            label4.Name = "label4";
            label4.Size = new Size(135, 15);
            label4.TabIndex = 2;
            label4.Text = "Dolphin Executable Path";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(linkLabelPCSX2ArgsRef);
            groupBox3.Controls.Add(buttonPickPCSX2Path);
            groupBox3.Controls.Add(textBoxPCSX2Args);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(textBoxPCSX2Path);
            groupBox3.Controls.Add(label6);
            groupBox3.Location = new Point(12, 215);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(511, 77);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Sony PlayStation 2";
            // 
            // linkLabelPCSX2ArgsRef
            // 
            linkLabelPCSX2ArgsRef.AutoSize = true;
            linkLabelPCSX2ArgsRef.Location = new Point(106, 48);
            linkLabelPCSX2ArgsRef.Name = "linkLabelPCSX2ArgsRef";
            linkLabelPCSX2ArgsRef.Size = new Size(59, 15);
            linkLabelPCSX2ArgsRef.TabIndex = 8;
            linkLabelPCSX2ArgsRef.TabStop = true;
            linkLabelPCSX2ArgsRef.Text = "Reference";
            linkLabelPCSX2ArgsRef.LinkClicked += linkLabelPCSX2ArgsRef_LinkClicked;
            // 
            // buttonPickPCSX2Path
            // 
            buttonPickPCSX2Path.Location = new Point(465, 16);
            buttonPickPCSX2Path.Name = "buttonPickPCSX2Path";
            buttonPickPCSX2Path.Size = new Size(40, 23);
            buttonPickPCSX2Path.TabIndex = 8;
            buttonPickPCSX2Path.Text = "...";
            buttonPickPCSX2Path.UseVisualStyleBackColor = true;
            buttonPickPCSX2Path.Click += buttonPickPCSX2Path_Click;
            // 
            // textBoxPCSX2Args
            // 
            textBoxPCSX2Args.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPCSX2Args.Location = new Point(171, 45);
            textBoxPCSX2Args.Name = "textBoxPCSX2Args";
            textBoxPCSX2Args.Size = new Size(334, 23);
            textBoxPCSX2Args.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 48);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 4;
            label5.Text = "Arguments";
            // 
            // textBoxPCSX2Path
            // 
            textBoxPCSX2Path.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPCSX2Path.Location = new Point(171, 16);
            textBoxPCSX2Path.Name = "textBoxPCSX2Path";
            textBoxPCSX2Path.Size = new Size(289, 23);
            textBoxPCSX2Path.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 19);
            label6.Name = "label6";
            label6.Size = new Size(127, 15);
            label6.TabIndex = 2;
            label6.Text = "PCSX2 Executable Path";
            // 
            // SettingsForm
            // 
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(535, 333);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Emulator Settings";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
        private GroupBox groupBox1;
        private TextBox textBoxXemuPath;
        private Label label1;
        private TextBox textBoxXemuArgs;
        private Label label3;
        private GroupBox groupBox2;
        private TextBox textBoxDolphinArgs;
        private Label label2;
        private TextBox textBoxDolphinPath;
        private Label label4;
        private GroupBox groupBox3;
        private TextBox textBoxPCSX2Args;
        private Label label5;
        private TextBox textBoxPCSX2Path;
        private Label label6;
        private Button buttonPickDolphinPath;
        private Button buttonPickXemuPath;
        private Button buttonPickPCSX2Path;
        private LinkLabel linkLabelDolphinArgsRef;
        private LinkLabel linkLabelXemuArgsRef;
        private LinkLabel linkLabelPCSX2ArgsRef;
        private Label label7;
        private TextBox textBox1;
        private Button button1;
    }
}