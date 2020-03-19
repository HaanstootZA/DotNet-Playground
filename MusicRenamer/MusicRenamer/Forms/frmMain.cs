using System;
using System.Threading;
using System.Windows.Forms;

namespace MusicRenamer
{
    public partial class frmMain : Form
    {
        private string FolderName = "";

        public frmMain()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                FolderName = fbd.SelectedPath;
            }
            else
            {
                this.Dispose();
                GC.Collect();
                Environment.Exit(0);
            }

            InitializeComponent();
            InitTabPage(tc1.SelectedTab);
        }

        private void InitTabPage(TabPage tb)
        {
            if (tb.Controls.Count < 1)
            {
                UserControl_Base UserControl = null;
                if (tb == this.tbFileRename)
                {
                    WaitForm wf = new WaitForm();
                    //Thread t1 = new Thread(new ThreadStart(wf.ShowForm));
                    ThreadHelper.Thread_Busy = true;
                    //t1.Start();
                    UserControl = new MusicFileRenameControl(FolderName);
                    wf.ShowForm();
                }
                else if (tb == this.tbID3Renamer)
                {
                    UserControl = new ID3TagRenameControl(FolderName);
                }
                if (UserControl != null)
                {
                    UserControl.Dock = DockStyle.Fill;
                    tb.Controls.Add(UserControl);
                }
            }
        }

        private void ChangeFolderName(TabPage tb)
        {
            UserControl_Base UserControl = null;
            if ((tb.Controls.Count == 1) && (tb == this.tbFileRename || tb == this.tbID3Renamer))
            {
                UserControl = (UserControl_Base)tb.Controls[0];
                UserControl.ChangeDirectory(FolderName);
                UserControl.Dock = DockStyle.Fill;

                tb.Controls.Clear();
                tb.Controls.Add(UserControl);
            }
        }

        private void tc1_Selected(object sender, TabControlEventArgs e)
        {
            InitTabPage(e.TabPage);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings SettingForm = new frmSettings();
            SettingForm.ShowDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (!ThreadHelper.Thread_Busy)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult dr = fbd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    WaitForm wf = new WaitForm();
                    Thread t1 = new Thread(new ThreadStart(wf.ShowForm));
                    ThreadHelper.Thread_Busy = true;
                    t1.Start();
                    //wf.ShowForm();
                    FolderName = fbd.SelectedPath;
                    ChangeFolderName(tc1.TabPages[0]);
                    ChangeFolderName(tc1.TabPages[1]);
                    GC.Collect();

                    this.txtFolderName.Text = FolderName;
                    this.txtFolderName.Refresh();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
            Environment.Exit(0);
        }
    }
}
