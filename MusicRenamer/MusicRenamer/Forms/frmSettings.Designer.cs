namespace MusicRenamer
{
    partial class frmSettings
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbFirst = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbUpper = new System.Windows.Forms.RadioButton();
            this.rbLower = new System.Windows.Forms.RadioButton();
            this.rbCamel = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkClearComments = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAlbumKey = new System.Windows.Forms.CheckBox();
            this.chkTrackKey = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbArtist = new System.Windows.Forms.RadioButton();
            this.rbTitle = new System.Windows.Forms.RadioButton();
            this.rbAlbum = new System.Windows.Forms.RadioButton();
            this.rbTrack = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbFirst);
            this.groupBox1.Controls.Add(this.rbNone);
            this.groupBox1.Controls.Add(this.rbUpper);
            this.groupBox1.Controls.Add(this.rbLower);
            this.groupBox1.Controls.Add(this.rbCamel);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Naming Case";
            // 
            // rbFirst
            // 
            this.rbFirst.AutoSize = true;
            this.rbFirst.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbFirst.Location = new System.Drawing.Point(6, 86);
            this.rbFirst.Name = "rbFirst";
            this.rbFirst.Size = new System.Drawing.Size(192, 18);
            this.rbFirst.TabIndex = 4;
            this.rbFirst.TabStop = true;
            this.rbFirst.Text = "First LEttEr UPper CaSe Per Word";
            this.rbFirst.UseVisualStyleBackColor = true;
            this.rbFirst.CheckedChanged += new System.EventHandler(this.rbFirst_CheckedChanged);
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbNone.Location = new System.Drawing.Point(263, 54);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(57, 18);
            this.rbNone.TabIndex = 3;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rbNone_CheckedChanged);
            // 
            // rbUpper
            // 
            this.rbUpper.AutoSize = true;
            this.rbUpper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbUpper.Location = new System.Drawing.Point(6, 54);
            this.rbUpper.Name = "rbUpper";
            this.rbUpper.Size = new System.Drawing.Size(90, 18);
            this.rbUpper.TabIndex = 2;
            this.rbUpper.TabStop = true;
            this.rbUpper.Text = "ALL UPPER";
            this.rbUpper.UseVisualStyleBackColor = true;
            this.rbUpper.CheckedChanged += new System.EventHandler(this.rbUpper_CheckedChanged);
            // 
            // rbLower
            // 
            this.rbLower.AutoSize = true;
            this.rbLower.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbLower.Location = new System.Drawing.Point(263, 19);
            this.rbLower.Name = "rbLower";
            this.rbLower.Size = new System.Drawing.Size(69, 18);
            this.rbLower.TabIndex = 1;
            this.rbLower.TabStop = true;
            this.rbLower.Text = "all lower";
            this.rbLower.UseVisualStyleBackColor = true;
            this.rbLower.CheckedChanged += new System.EventHandler(this.rbLower_CheckedChanged);
            // 
            // rbCamel
            // 
            this.rbCamel.AutoSize = true;
            this.rbCamel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbCamel.Location = new System.Drawing.Point(6, 19);
            this.rbCamel.Name = "rbCamel";
            this.rbCamel.Size = new System.Drawing.Size(87, 18);
            this.rbCamel.TabIndex = 0;
            this.rbCamel.TabStop = true;
            this.rbCamel.Text = "Camel Case";
            this.rbCamel.UseVisualStyleBackColor = true;
            this.rbCamel.CheckedChanged += new System.EventHandler(this.rbCamel_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(275, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Location = new System.Drawing.Point(194, 252);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Accept";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkClearComments
            // 
            this.chkClearComments.AutoSize = true;
            this.chkClearComments.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkClearComments.Location = new System.Drawing.Point(12, 12);
            this.chkClearComments.Name = "chkClearComments";
            this.chkClearComments.Size = new System.Drawing.Size(130, 18);
            this.chkClearComments.TabIndex = 3;
            this.chkClearComments.Text = "Clear Comments Tag";
            this.chkClearComments.UseVisualStyleBackColor = true;
            this.chkClearComments.CheckedChanged += new System.EventHandler(this.chkClearComments_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkTrackKey);
            this.groupBox2.Controls.Add(this.chkAlbumKey);
            this.groupBox2.Location = new System.Drawing.Point(12, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 77);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced";
            // 
            // chkAlbumKey
            // 
            this.chkAlbumKey.AutoSize = true;
            this.chkAlbumKey.Location = new System.Drawing.Point(7, 20);
            this.chkAlbumKey.Name = "chkAlbumKey";
            this.chkAlbumKey.Size = new System.Drawing.Size(141, 17);
            this.chkAlbumKey.TabIndex = 0;
            this.chkAlbumKey.Text = "Use Album Name In Key";
            this.toolTip1.SetToolTip(this.chkAlbumKey, "This value is used to determine wether the album should be included when determin" +
                    "ing whether a track is a duplicate");
            this.chkAlbumKey.UseVisualStyleBackColor = true;
            this.chkAlbumKey.CheckedChanged += new System.EventHandler(this.chkAlbumKey_CheckedChanged);
            // 
            // chkTrackKey
            // 
            this.chkTrackKey.AutoSize = true;
            this.chkTrackKey.Location = new System.Drawing.Point(7, 50);
            this.chkTrackKey.Name = "chkTrackKey";
            this.chkTrackKey.Size = new System.Drawing.Size(140, 17);
            this.chkTrackKey.TabIndex = 1;
            this.chkTrackKey.Text = "Use Track Name In Key";
            this.toolTip1.SetToolTip(this.chkTrackKey, "Used in determining duplicates");
            this.chkTrackKey.UseVisualStyleBackColor = true;
            this.chkTrackKey.CheckedChanged += new System.EventHandler(this.chkTrackKey_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbTrack);
            this.groupBox3.Controls.Add(this.rbAlbum);
            this.groupBox3.Controls.Add(this.rbTitle);
            this.groupBox3.Controls.Add(this.rbArtist);
            this.groupBox3.Location = new System.Drawing.Point(169, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(198, 77);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ordering";
            // 
            // rbArtist
            // 
            this.rbArtist.AutoSize = true;
            this.rbArtist.Location = new System.Drawing.Point(7, 20);
            this.rbArtist.Name = "rbArtist";
            this.rbArtist.Size = new System.Drawing.Size(48, 17);
            this.rbArtist.TabIndex = 0;
            this.rbArtist.TabStop = true;
            this.rbArtist.Text = "Artist";
            this.rbArtist.UseVisualStyleBackColor = true;
            this.rbArtist.CheckedChanged += new System.EventHandler(this.rbArtist_CheckedChanged);
            // 
            // rbTitle
            // 
            this.rbTitle.AutoSize = true;
            this.rbTitle.Location = new System.Drawing.Point(7, 50);
            this.rbTitle.Name = "rbTitle";
            this.rbTitle.Size = new System.Drawing.Size(45, 17);
            this.rbTitle.TabIndex = 1;
            this.rbTitle.TabStop = true;
            this.rbTitle.Text = "Title";
            this.rbTitle.UseVisualStyleBackColor = true;
            this.rbTitle.CheckedChanged += new System.EventHandler(this.rbTitle_CheckedChanged);
            // 
            // rbAlbum
            // 
            this.rbAlbum.AutoSize = true;
            this.rbAlbum.Location = new System.Drawing.Point(99, 20);
            this.rbAlbum.Name = "rbAlbum";
            this.rbAlbum.Size = new System.Drawing.Size(54, 17);
            this.rbAlbum.TabIndex = 2;
            this.rbAlbum.TabStop = true;
            this.rbAlbum.Text = "Album";
            this.rbAlbum.UseVisualStyleBackColor = true;
            this.rbAlbum.CheckedChanged += new System.EventHandler(this.rbAlbum_CheckedChanged);
            // 
            // rbTrack
            // 
            this.rbTrack.AutoSize = true;
            this.rbTrack.Location = new System.Drawing.Point(99, 50);
            this.rbTrack.Name = "rbTrack";
            this.rbTrack.Size = new System.Drawing.Size(60, 17);
            this.rbTrack.TabIndex = 3;
            this.rbTrack.TabStop = true;
            this.rbTrack.Text = "Track#";
            this.rbTrack.UseVisualStyleBackColor = true;
            this.rbTrack.CheckedChanged += new System.EventHandler(this.rbTrack_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(372, 281);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkClearComments);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.InitProperties();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbUpper;
        private System.Windows.Forms.RadioButton rbLower;
        private System.Windows.Forms.RadioButton rbCamel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton rbFirst;
        private System.Windows.Forms.CheckBox chkClearComments;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkTrackKey;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkAlbumKey;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbTrack;
        private System.Windows.Forms.RadioButton rbAlbum;
        private System.Windows.Forms.RadioButton rbTitle;
        private System.Windows.Forms.RadioButton rbArtist;

    }
}