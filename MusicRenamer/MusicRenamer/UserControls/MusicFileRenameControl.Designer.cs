namespace MusicRenamer
{
    partial class MusicFileRenameControl
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
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtSearchPattern = new System.Windows.Forms.TextBox();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.lstFileList = new System.Windows.Forms.ListBox();
            this.lstFileListPreview = new System.Windows.Forms.ListBox();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.label5);
            this.splitContainer4.Panel1.Controls.Add(this.label4);
            this.splitContainer4.Panel1.Controls.Add(this.label3);
            this.splitContainer4.Panel1.Controls.Add(this.btnPreview);
            this.splitContainer4.Panel1.Controls.Add(this.btnConfirm);
            this.splitContainer4.Panel1.Controls.Add(this.txtSearchPattern);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer4.Size = new System.Drawing.Size(958, 472);
            this.splitContainer4.SplitterDistance = 67;
            this.splitContainer4.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Preview";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Original File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "New File Structure\\Name";
            // 
            // btnGenerate
            // 
            this.btnPreview.Location = new System.Drawing.Point(271, 21);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(878, 20);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtSearchPattern
            // 
            this.txtSearchPattern.Location = new System.Drawing.Point(13, 23);
            this.txtSearchPattern.Name = "txtSearchPattern";
            this.txtSearchPattern.Size = new System.Drawing.Size(252, 20);
            this.txtSearchPattern.TabIndex = 5;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.lstFileList);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.lstFileListPreview);
            this.splitContainer6.Size = new System.Drawing.Size(958, 401);
            this.splitContainer6.SplitterDistance = 414;
            this.splitContainer6.TabIndex = 0;
            // 
            // lstFileList
            // 
            this.lstFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFileList.FormattingEnabled = true;
            this.lstFileList.HorizontalScrollbar = true;
            this.lstFileList.Location = new System.Drawing.Point(0, 0);
            this.lstFileList.Name = "lstFileList";
            this.lstFileList.Size = new System.Drawing.Size(414, 401);
            this.lstFileList.TabIndex = 0;
            this.lstFileList.ContextMenuStrip = fileDet;
            this.lstFileList.KeyDown += new System.Windows.Forms.KeyEventHandler(base.ListBox_KeyDown);
            this.lstFileList.MouseDown += new System.Windows.Forms.MouseEventHandler(base.ListBox_MouseDown);
            this.lstFileList.SelectedIndexChanged += new System.EventHandler(this.lstFileList_IndexChanged);
            // 
            // lstFileListPreview
            // 
            this.lstFileListPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFileListPreview.FormattingEnabled = true;
            this.lstFileListPreview.HorizontalScrollbar = true;
            this.lstFileListPreview.Location = new System.Drawing.Point(0, 0);
            this.lstFileListPreview.Name = "lstFileListPreview";
            this.lstFileListPreview.Size = new System.Drawing.Size(540, 401);
            this.lstFileListPreview.TabIndex = 0;
            this.lstFileListPreview.ContextMenuStrip = fileDet;
            this.lstFileListPreview.KeyDown += new System.Windows.Forms.KeyEventHandler(base.ListBox_KeyDown);
            this.lstFileListPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(base.ListBox_MouseDown);
            this.lstFileListPreview.SelectedIndexChanged += new System.EventHandler(this.lstFileListPreview_IndexChanged);
            // 
            // FileRenaming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer4);
            this.Name = "FileRenaming";
            this.Size = new System.Drawing.Size(958, 472);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtSearchPattern;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.ListBox lstFileList;
        private System.Windows.Forms.ListBox lstFileListPreview;

    }
}
