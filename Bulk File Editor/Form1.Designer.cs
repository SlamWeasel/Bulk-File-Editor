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
            button1 = new Button();
            panel1 = new Panel();
            CommentField = new TextBox();
            label2 = new Label();
            NameField = new TextBox();
            label1 = new Label();
            MediaPlaceholder = new Label();
            MediaHolder = new Panel();
            RadioV = new RadioButton();
            RadioI = new RadioButton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Font = new Font("Wingdings", 36F, FontStyle.Regular, GraphicsUnit.Point, 2);
            button1.Location = new Point(12, 379);
            button1.Name = "button1";
            button1.Size = new Size(67, 59);
            button1.TabIndex = 0;
            button1.Text = "Ø";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            panel1.Size = new Size(225, 426);
            panel1.TabIndex = 1;
            // 
            // CommentField
            // 
            CommentField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CommentField.Location = new Point(3, 88);
            CommentField.Name = "CommentField";
            CommentField.Size = new Size(217, 23);
            CommentField.TabIndex = 3;
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
            MediaPlaceholder.Size = new Size(210, 71);
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
            MediaHolder.Size = new Size(534, 361);
            MediaHolder.TabIndex = 3;
            // 
            // RadioV
            // 
            RadioV.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RadioV.AutoSize = true;
            RadioV.Checked = true;
            RadioV.Location = new Point(167, 411);
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
            RadioI.Location = new Point(267, 411);
            RadioI.Name = "RadioI";
            RadioI.Size = new Size(63, 19);
            RadioI.TabIndex = 5;
            RadioI.Text = "Images";
            RadioI.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RadioI);
            Controls.Add(RadioV);
            Controls.Add(MediaPlaceholder);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(MediaHolder);
            Name = "MainForm";
            Text = "File Scrubber";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private TextBox NameField;
        private Label label1;
        private TextBox CommentField;
        private Label label2;
        private Label MediaPlaceholder;
        private Panel MediaHolder;
        private RadioButton RadioV;
        private RadioButton RadioI;
    }
}
