namespace MusicRenamer
{
    partial class ID3TagRenameControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID3ReplacementValue = new System.Windows.Forms.TextBox();
            this.txtID3StringSpecificationPattern = new System.Windows.Forms.TextBox();
            this.btnID3Rename = new System.Windows.Forms.Button();
            this.rbID3Title = new System.Windows.Forms.RadioButton();
            this.rbID3Album = new System.Windows.Forms.RadioButton();
            this.rbID3Artist = new System.Windows.Forms.RadioButton();
            this.btnID3Search = new System.Windows.Forms.Button();
            this.txtID3SearchPattern = new System.Windows.Forms.TextBox();
            this.lstID3List = new System.Windows.Forms.ListBox();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer7.IsSplitterFixed = true;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.label2);
            this.splitContainer7.Panel1.Controls.Add(this.label1);
            this.splitContainer7.Panel1.Controls.Add(this.txtID3ReplacementValue);
            this.splitContainer7.Panel1.Controls.Add(this.txtID3StringSpecificationPattern);
            this.splitContainer7.Panel1.Controls.Add(this.btnID3Rename);
            this.splitContainer7.Panel1.Controls.Add(this.rbID3Title);
            this.splitContainer7.Panel1.Controls.Add(this.rbID3Album);
            this.splitContainer7.Panel1.Controls.Add(this.rbID3Artist);
            this.splitContainer7.Panel1.Controls.Add(this.btnID3Search);
            this.splitContainer7.Panel1.Controls.Add(this.txtID3SearchPattern);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.lstID3List);
            this.splitContainer7.Size = new System.Drawing.Size(958, 377);
            this.splitContainer7.SplitterDistance = 77;
            this.splitContainer7.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Replacement Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "String Specification Pattern";
            // 
            // txtID3ReplacementValue
            // 
            this.txtID3ReplacementValue.Location = new System.Drawing.Point(666, 35);
            this.txtID3ReplacementValue.Name = "txtID3ReplacementValue";
            this.txtID3ReplacementValue.Size = new System.Drawing.Size(287, 20);
            this.txtID3ReplacementValue.TabIndex = 15;
            // 
            // txtID3StringSpecificationPattern
            // 
            this.txtID3StringSpecificationPattern.Location = new System.Drawing.Point(666, 3);
            this.txtID3StringSpecificationPattern.Name = "txtID3StringSpecificationPattern";
            this.txtID3StringSpecificationPattern.Size = new System.Drawing.Size(287, 20);
            this.txtID3StringSpecificationPattern.TabIndex = 14;
            // 
            // btnID3Rename
            // 
            this.btnID3Rename.Location = new System.Drawing.Point(666, 55);
            this.btnID3Rename.Name = "btnID3Rename";
            this.btnID3Rename.Size = new System.Drawing.Size(75, 23);
            this.btnID3Rename.TabIndex = 13;
            this.btnID3Rename.Text = "Replace";
            this.btnID3Rename.UseVisualStyleBackColor = true;
            this.btnID3Rename.Click += new System.EventHandler(this.btnID3Rename_Click);
            // 
            // rbID3Title
            // 
            this.rbID3Title.AutoSize = true;
            this.rbID3Title.Location = new System.Drawing.Point(446, 52);
            this.rbID3Title.Name = "rbID3Title";
            this.rbID3Title.Size = new System.Drawing.Size(45, 17);
            this.rbID3Title.TabIndex = 12;
            this.rbID3Title.TabStop = true;
            this.rbID3Title.Text = "Title";
            this.rbID3Title.UseVisualStyleBackColor = true;
            // 
            // rbID3Album
            // 
            this.rbID3Album.AutoSize = true;
            this.rbID3Album.Location = new System.Drawing.Point(446, 29);
            this.rbID3Album.Name = "rbID3Album";
            this.rbID3Album.Size = new System.Drawing.Size(54, 17);
            this.rbID3Album.TabIndex = 11;
            this.rbID3Album.TabStop = true;
            this.rbID3Album.Text = "Album";
            this.rbID3Album.UseVisualStyleBackColor = true;
            // 
            // rbID3Artist
            // 
            this.rbID3Artist.AutoSize = true;
            this.rbID3Artist.Location = new System.Drawing.Point(446, 6);
            this.rbID3Artist.Name = "rbID3Artist";
            this.rbID3Artist.Size = new System.Drawing.Size(48, 17);
            this.rbID3Artist.TabIndex = 10;
            this.rbID3Artist.TabStop = true;
            this.rbID3Artist.Text = "Artist";
            this.rbID3Artist.UseVisualStyleBackColor = true;
            // 
            // btnID3Search
            // 
            this.btnID3Search.Location = new System.Drawing.Point(182, 26);
            this.btnID3Search.Name = "btnID3Search";
            this.btnID3Search.Size = new System.Drawing.Size(75, 23);
            this.btnID3Search.TabIndex = 9;
            this.btnID3Search.Text = "Search";
            this.btnID3Search.UseVisualStyleBackColor = true;
            this.btnID3Search.Click += new System.EventHandler(this.btnID3Search_Click);
            // 
            // txtID3SearchPattern
            // 
            this.txtID3SearchPattern.Location = new System.Drawing.Point(5, 3);
            this.txtID3SearchPattern.Name = "txtID3SearchPattern";
            this.txtID3SearchPattern.Size = new System.Drawing.Size(252, 20);
            this.txtID3SearchPattern.TabIndex = 8;
            // 
            // lstID3List
            // 
            this.lstID3List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstID3List.ContextMenuStrip = base.fileDet;
            this.lstID3List.FormattingEnabled = true;
            this.lstID3List.HorizontalScrollbar = true;
            this.lstID3List.Location = new System.Drawing.Point(0, 0);
            this.lstID3List.Name = "lstID3List";
            this.lstID3List.Size = new System.Drawing.Size(958, 289);
            this.lstID3List.TabIndex = 0;
            this.lstID3List.KeyDown += new System.Windows.Forms.KeyEventHandler(base.ListBox_KeyDown);
            this.lstID3List.MouseDown += new System.Windows.Forms.MouseEventHandler(base.ListBox_MouseDown);
            // 
            // ID3TagRenaming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer7);
            this.Name = "ID3TagRenaming";
            this.Size = new System.Drawing.Size(958, 377);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel1.PerformLayout();
            this.splitContainer7.Panel2.ResumeLayout(false);
            this.splitContainer7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID3ReplacementValue;
        private System.Windows.Forms.TextBox txtID3StringSpecificationPattern;
        private System.Windows.Forms.Button btnID3Rename;
        private System.Windows.Forms.RadioButton rbID3Title;
        private System.Windows.Forms.RadioButton rbID3Album;
        private System.Windows.Forms.RadioButton rbID3Artist;
        private System.Windows.Forms.Button btnID3Search;
        private System.Windows.Forms.TextBox txtID3SearchPattern;
        private System.Windows.Forms.ListBox lstID3List;
    }
}
