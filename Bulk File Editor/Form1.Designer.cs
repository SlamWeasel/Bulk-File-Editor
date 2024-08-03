namespace Bulk_File_Editor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            NextButton = new Button();
            panel1 = new Panel();
            CommentField = new TextBox();
            label2 = new Label();
            NameField = new TextBox();
            label1 = new Label();
            MediaPlaceholder = new Label();
            MediaHolder = new Panel();
            RadioV = new RadioButton();
            RadioI = new RadioButton();
            LoadDisplay = new ProgressBar();
            StopButton = new Button();
            ReplayButton = new Button();
            SkipButton = new Button();
            TipStop = new ToolTip(components);
            TipReload = new ToolTip(components);
            TipApply = new ToolTip(components);
            TipSkip = new ToolTip(components);
            OpenButton = new Button();
            TipOpen = new ToolTip(components);
            VolumeBar = new TrackBar();
            TipVolumne = new ToolTip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeBar).BeginInit();
            SuspendLayout();
            // 
            // NextButton
            // 
            NextButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NextButton.Font = new Font("Wingdings", 36F, FontStyle.Regular, GraphicsUnit.Point, 2);
            NextButton.Location = new Point(12, 375);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(67, 59);
            NextButton.TabIndex = 0;
            NextButton.Text = "Ø";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(CommentField);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(NameField);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(563, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(225, 452);
            panel1.TabIndex = 1;
            // 
            // CommentField
            // 
            CommentField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CommentField.Location = new Point(3, 88);
            CommentField.Name = "CommentField";
            CommentField.Size = new Size(217, 23);
            CommentField.TabIndex = 3;
            CommentField.KeyPress += CommentField_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 70);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 2;
            label2.Text = "Comment";
            // 
            // NameField
            // 
            NameField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NameField.Location = new Point(3, 27);
            NameField.Name = "NameField";
            NameField.Size = new Size(217, 23);
            NameField.TabIndex = 1;
            NameField.KeyPress += CommentField_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // MediaPlaceholder
            // 
            MediaPlaceholder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MediaPlaceholder.BackColor = SystemColors.AppWorkspace;
            MediaPlaceholder.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MediaPlaceholder.Location = new Point(193, 145);
            MediaPlaceholder.Name = "MediaPlaceholder";
            MediaPlaceholder.Size = new Size(210, 97);
            MediaPlaceholder.TabIndex = 2;
            MediaPlaceholder.Text = "No Media Folder Selected";
            MediaPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
            MediaPlaceholder.Click += MediaPlaceholder_Click;
            // 
            // MediaHolder
            // 
            MediaHolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MediaHolder.BorderStyle = BorderStyle.FixedSingle;
            MediaHolder.Location = new Point(12, 12);
            MediaHolder.Name = "MediaHolder";
            MediaHolder.Size = new Size(534, 357);
            MediaHolder.TabIndex = 3;
            // 
            // RadioV
            // 
            RadioV.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RadioV.AutoSize = true;
            RadioV.Checked = true;
            RadioV.Location = new Point(193, 415);
            RadioV.Name = "RadioV";
            RadioV.Size = new Size(60, 19);
            RadioV.TabIndex = 4;
            RadioV.TabStop = true;
            RadioV.Text = "Videos";
            RadioV.UseVisualStyleBackColor = true;
            // 
            // RadioI
            // 
            RadioI.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RadioI.AutoSize = true;
            RadioI.Location = new Point(293, 415);
            RadioI.Name = "RadioI";
            RadioI.Size = new Size(63, 19);
            RadioI.TabIndex = 5;
            RadioI.Text = "Images";
            RadioI.UseVisualStyleBackColor = true;
            // 
            // LoadDisplay
            // 
            LoadDisplay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LoadDisplay.Location = new Point(193, 375);
            LoadDisplay.Name = "LoadDisplay";
            LoadDisplay.Size = new Size(353, 23);
            LoadDisplay.TabIndex = 6;
            // 
            // StopButton
            // 
            StopButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StopButton.Font = new Font("Wingdings", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 2);
            StopButton.Location = new Point(85, 375);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(43, 42);
            StopButton.TabIndex = 7;
            StopButton.Text = "n";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // ReplayButton
            // 
            ReplayButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ReplayButton.Font = new Font("Wingdings 3", 24F, FontStyle.Regular, GraphicsUnit.Point, 2);
            ReplayButton.Location = new Point(134, 375);
            ReplayButton.Name = "ReplayButton";
            ReplayButton.Size = new Size(43, 42);
            ReplayButton.TabIndex = 8;
            ReplayButton.Text = "P";
            ReplayButton.UseVisualStyleBackColor = true;
            ReplayButton.Click += ReplayButton_Click;
            // 
            // SkipButton
            // 
            SkipButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SkipButton.Font = new Font("Wingdings 3", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 2);
            SkipButton.Location = new Point(85, 423);
            SkipButton.Name = "SkipButton";
            SkipButton.Size = new Size(43, 42);
            SkipButton.TabIndex = 9;
            SkipButton.Text = "A";
            SkipButton.UseVisualStyleBackColor = true;
            SkipButton.Click += SkipButton_Click;
            // 
            // TipStop
            // 
            TipStop.ToolTipIcon = ToolTipIcon.Info;
            TipStop.ToolTipTitle = "Stop";
            // 
            // TipReload
            // 
            TipReload.ToolTipIcon = ToolTipIcon.Info;
            TipReload.ToolTipTitle = "Restart";
            // 
            // TipApply
            // 
            TipApply.ToolTipIcon = ToolTipIcon.Warning;
            TipApply.ToolTipTitle = "Apply";
            // 
            // TipSkip
            // 
            TipSkip.ToolTipIcon = ToolTipIcon.Warning;
            TipSkip.ToolTipTitle = "Skip";
            // 
            // OpenButton
            // 
            OpenButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            OpenButton.Font = new Font("Wingdings", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 2);
            OpenButton.Location = new Point(134, 425);
            OpenButton.Name = "OpenButton";
            OpenButton.Size = new Size(43, 42);
            OpenButton.TabIndex = 10;
            OpenButton.Text = "1";
            OpenButton.UseVisualStyleBackColor = true;
            OpenButton.Click += OpenButton_Click;
            // 
            // TipOpen
            // 
            TipOpen.ToolTipIcon = ToolTipIcon.Warning;
            TipOpen.ToolTipTitle = "Open";
            // 
            // VolumeBar
            // 
            VolumeBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VolumeBar.Location = new Point(193, 440);
            VolumeBar.Maximum = 50;
            VolumeBar.Name = "VolumeBar";
            VolumeBar.Size = new Size(353, 45);
            VolumeBar.TabIndex = 11;
            VolumeBar.Value = 50;
            VolumeBar.Scroll += VolumeBar_Scroll;
            // 
            // TipVolumne
            // 
            TipVolumne.ToolTipIcon = ToolTipIcon.Info;
            TipVolumne.ToolTipTitle = "Volume";
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 476);
            Controls.Add(VolumeBar);
            Controls.Add(OpenButton);
            Controls.Add(SkipButton);
            Controls.Add(ReplayButton);
            Controls.Add(StopButton);
            Controls.Add(LoadDisplay);
            Controls.Add(RadioI);
            Controls.Add(RadioV);
            Controls.Add(MediaPlaceholder);
            Controls.Add(panel1);
            Controls.Add(NextButton);
            Controls.Add(MediaHolder);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "File Scrubber";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button NextButton;
        private Panel panel1;
        private TextBox NameField;
        private Label label1;
        private TextBox CommentField;
        private Label label2;
        private Label MediaPlaceholder;
        private Panel MediaHolder;
        private RadioButton RadioV;
        private RadioButton RadioI;
        private ProgressBar LoadDisplay;
        private Button StopButton;
        private Button ReplayButton;
        private Button SkipButton;
        private ToolTip TipStop;
        private ToolTip TipReload;
        private ToolTip TipApply;
        private ToolTip TipSkip;
        private Button OpenButton;
        private ToolTip TipOpen;
        private TrackBar VolumeBar;
        private ToolTip TipVolumne;
    }
}
