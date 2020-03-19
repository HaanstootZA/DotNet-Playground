using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace MusicRenamer
{
    abstract class UserControl_Base : UserControl
    {
        private string folderName = "";
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

        protected System.Windows.Forms.ContextMenuStrip fileDet;
        protected System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;

        protected MusicRenamer_Base Renamer;
        private ListBox toUse;

        public string FolderName {
            get { return folderName; }
            protected set { folderName = value; }
        }

        protected UserControl_Base(string FolderName)
        {
            folderName = FolderName;
            InitializeComponent();
        }

        protected void propertiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (toUse != null)
            {
                frmDetail FilePropertiesView;
                FilePropertiesView = new frmDetail(Renamer.Files[toUse.SelectedIndex]);
                FilePropertiesView.ShowDialog();
            }
        }

        protected void fileDet_Opening(object sender, CancelEventArgs e)
        {
            if (toUse.SelectedIndex < 0)
                e.Cancel = true;
        }

        protected void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(ListBox))
            {
                if (e.Button == MouseButtons.Right)
                {
                    toUse = (ListBox)sender;
                    int index = toUse.IndexFromPoint(e.X, e.Y);
                    toUse.SetSelected(index, true);
                }
            }
        }

        protected void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender.GetType() == typeof(ListBox))
            {
                toUse = (ListBox)sender;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fileDet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileDet.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserControl_Base
            // 
            this.Name = "UserControl_Base";
            this.Size = new System.Drawing.Size(10, 10);
            this.ResumeLayout(false);
            // 
            // fileDet
            // 
            this.fileDet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem});
            this.fileDet.Name = "fileDet";
            this.fileDet.Size = new System.Drawing.Size(170, 26);
            this.fileDet.Opening += new CancelEventHandler(fileDet_Opening);
            // 
            // propertiesToolStripMenuItem1
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new EventHandler(propertiesToolStripMenuItem1_Click);

            this.fileDet.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        protected abstract void ChangeDirectory();

        public void ChangeDirectory(string newDirectory)
        {
            this.folderName = newDirectory;
            Thread t1 = new Thread(new ThreadStart(ChangeDirectory));
            t1.Start();
        }
    }
}
