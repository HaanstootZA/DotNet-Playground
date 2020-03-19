using System;
using System.Windows.Forms;

namespace MusicRenamer
{
    public partial class frmSettings : Form
    {
        private void InitProperties()
        {
            rbAlbum.Enabled = false;
            rbTrack.Enabled = false;
            //
            //Check the correct Radio Button
            //
            switch (Settings.StringCase)
            {
                case Case.ALLCAPS:
                    rbUpper.Checked = true;
                    break;
                case Case.nocaps:
                    rbLower.Checked = true;
                    break;
                case Case.CamelCase:
                    rbCamel.Checked = true;
                    break;
                case Case.FirstLetterInitial:
                    rbFirst.Checked = true;
                    break;
                case Case.None:
                    rbNone.Checked = true;
                    break;
                default:
                    rbNone.Checked = true;
                    break;
            }
            //
            //Check the correct Radio Button
            //
            switch (Settings.TreeOrder)
            {
                case OrderBy.Artist:
                    rbArtist.Checked = true;
                    break;
                case OrderBy.Title:
                    rbTitle.Checked = true;
                    break;
                case OrderBy.Album:
                    rbAlbum.Checked = true;
                    break;
                case OrderBy.Track:
                    rbTrack.Checked = true;
                    break;
                default:
                    rbArtist.Checked = true;
                    break;
            }
            this.chkClearComments.Checked = Settings.RemoveComments;
            this.chkAlbumKey.Checked = Settings.UseAlbumInKey;
            this.chkTrackKey.Checked = Settings.UseTrackInKey;
        }

        public frmSettings()
        {
            InitializeComponent();
            Settings.Backup();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Settings.Confirm();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Settings.Abort();
            this.Close();
        }

        #region EventHandlers
        private void rbCamel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCamel.Checked)
                Settings.StringCase = Case.CamelCase;
        }
        private void rbUpper_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUpper.Checked)
                Settings.StringCase = Case.ALLCAPS;
        }
        private void rbFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFirst.Checked)
                Settings.StringCase = Case.FirstLetterInitial;
        }
        private void rbLower_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLower.Checked)
                Settings.StringCase = Case.nocaps;
        }
        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNone.Checked)
                Settings.StringCase = Case.None;
        }
        private void chkClearComments_CheckedChanged(object sender, EventArgs e)
        {
            Settings.RemoveComments = chkClearComments.Checked;
        }
        private void chkAlbumKey_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAlbum.Checked && !chkAlbumKey.Checked)
            {
                chkAlbumKey.Checked = !chkAlbumKey.Checked;
                MessageBox.Show("Can not change the key when the selected key is still used within the Order");
            }
            else
            {
                Settings.UseAlbumInKey = chkAlbumKey.Checked;
                if (chkAlbumKey.Checked)
                    rbAlbum.Enabled = true;
                else
                    rbAlbum.Enabled = false;
            }
        }
        private void chkTrackKey_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTrack.Checked && !chkTrackKey.Checked)
            {
                chkTrackKey.Checked = !chkTrackKey.Checked;
                MessageBox.Show("Can not change the key when the selected key is still used within the Order");
            }
            else
            {
                Settings.UseTrackInKey = chkTrackKey.Checked;
                if (chkTrackKey.Checked)
                    rbTrack.Enabled = true;
                else
                    rbTrack.Enabled = false;
            }
        }
        private void rbArtist_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArtist.Checked)
                Settings.TreeOrder = OrderBy.Artist;
        }
        private void rbTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTitle.Checked)
                Settings.TreeOrder = OrderBy.Title;
        }
        private void rbAlbum_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAlbum.Checked)
                Settings.TreeOrder = OrderBy.Album;
        }
        private void rbTrack_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTrack.Checked)
                Settings.TreeOrder = OrderBy.Track;
        }
        #endregion
    }
}
