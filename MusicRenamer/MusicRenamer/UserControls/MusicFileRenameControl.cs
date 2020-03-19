using System;
using System.Threading;

namespace MusicRenamer
{
    partial class MusicFileRenameControl : UserControl_Base
    {
        private const int FILE_PREVIEW_SIZE = 200;

        private void Restart()
        {
            Renamer.Reset();
            lstFileList.Items.Clear();
            lstFileListPreview.Items.Clear();
            if (Renamer.Files != null)
                for (int i = 0; (i < Renamer.Files.Length && i < FILE_PREVIEW_SIZE); i++)
                    this.lstFileList.Items.Add(Renamer.Files[i]);

            this.Refresh();
            GC.Collect();
        }

        private void Initialize()
        {
            Renamer = new MusicFileRenamer(FolderName);
            if (Renamer.Files != null)
                for (int i = 0; (i < Renamer.Files.Length && i < FILE_PREVIEW_SIZE); i++)
                    this.lstFileList.Items.Add(Renamer.Files[i].ToString());
            this.lstFileList.Refresh();
            ThreadHelper.Thread_Busy = false;
        }

        public MusicFileRenameControl(string FolderName)
            : base(FolderName)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            if (!ThreadHelper.Thread_Busy)
                ThreadHelper.Thread_Busy = true;
            Thread t1 = new Thread(new ThreadStart(Initialize));
            t1.Start();
        }

        private void Generate_Preview()
        {
            if (txtSearchPattern.Text != "")
                Settings.FileNamingConvention = txtSearchPattern.Text;
            lstFileListPreview.Items.AddRange(((MusicFileRenamer)Renamer).SetPreviewFiles(FILE_PREVIEW_SIZE));
            ThreadHelper.Thread_Busy = false;
            lstFileListPreview.Refresh();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!ThreadHelper.Thread_Busy)
            {
                lstFileListPreview.Items.Clear();
                WaitForm wf = new WaitForm();
                //Thread t1 = new Thread(new ThreadStart(wf.ShowForm));
                Thread t2 = new Thread(new ThreadStart(Generate_Preview));
                ThreadHelper.Thread_Busy = true;
                //t1.Start();
                t2.Start();
                wf.ShowForm();
            }
        }

        private void ConfirmFolderRename()
        {
            try
            {
                ((MusicFileRenamer)Renamer).CommitFileNameChanges();
            }
            catch (Exception ex)
            {
            }
            //if (!errors.Equals(""))
            //MessageBox.Show("The Following Error has occured:\r\n" + errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            Restart();
            ThreadHelper.Thread_Busy = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ThreadHelper.Thread_Busy)
            {
                ThreadHelper.Thread_Busy = true;

                WaitForm wf = new WaitForm();
                //Thread t1 = new Thread(new ThreadStart(wf.ShowForm));
                Thread t2 = new Thread(new ThreadStart(ConfirmFolderRename));
                //t1.Start();
                t2.Start();
                wf.ShowForm();
            }
        }

        protected override void ChangeDirectory()
        {
            this.lstFileList.Items.Clear();
            Renamer.Clear();
            this.lstFileListPreview.Items.Clear();

            Renamer = new MusicFileRenamer(FolderName);

            if (Renamer.Files != null)
                for (int i = 0; (i < Renamer.Files.Length && i < FILE_PREVIEW_SIZE); i++)
                    this.lstFileList.Items.Add(Renamer.Files[i]);

            ThreadHelper.Thread_Busy = false;
        }

        public void lstFileList_IndexChanged(object sender, EventArgs e)
        {
            if (this.lstFileList.Items.Count == this.lstFileListPreview.Items.Count)
            {
                this.lstFileListPreview.TopIndex = this.lstFileList.TopIndex;
                this.lstFileListPreview.SelectedIndex = this.lstFileList.SelectedIndex;
            }
        }

        public void lstFileListPreview_IndexChanged(object sender, EventArgs e)
        {
            if (this.lstFileList.Items.Count == this.lstFileListPreview.Items.Count)
            {
                this.lstFileList.TopIndex = this.lstFileListPreview.TopIndex;
                this.lstFileList.SelectedIndex = this.lstFileListPreview.SelectedIndex;
            }
        }
    }
}
