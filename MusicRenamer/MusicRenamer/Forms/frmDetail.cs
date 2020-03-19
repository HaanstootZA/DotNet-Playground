using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MusicRenamer
{
    public partial class frmDetail : Form
    {
        public RFile CurrentSong;
        private string checkIntRegex = @"[0-9]*\s";
        RenamerTag NewTag;

        #region Attributes
        private string Filename { get { return CurrentSong.FileName; } }
        private string Artist { get { return CurrentSong.Tag.Artist; } }
        private string Album { get { return CurrentSong.Tag.Album; } }
        private string Title { get { return CurrentSong.Tag.Title; } }
        private uint Track { get { return CurrentSong.Tag.Track; } }
        private uint Year { get { return CurrentSong.Tag.Year; } }
        private string Genre { get { return CurrentSong.Tag.Genre; } }
        private string Comment { get { return CurrentSong.Tag.Comment; } }
        #endregion

        public frmDetail(RFile Song)
        {
            CurrentSong = Song;

            if (CurrentSong.Tag == null && CurrentSong.Tag != null)
                NewTag = CurrentSong.CopyTagFile();

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CurrentSong.SaveTag(NewTag);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnSave_Click(sender, e);
        }

        //#region Property_Events
        //private void txtArtist_TextChanged(object sender, EventArgs e)
        //{
        //    Artist = txtArtist.Text;
        //}
        //private void txtAlbum_TextChanged(object sender, EventArgs e)
        //{
        //    Album = txtAlbum.Text;
        //}
        //private void txtTitle_TextChanged(object sender, EventArgs e)
        //{
        //    Title = txtTitle.Text;
        //}
        //private void txtTrack_TextChanged(object sender, EventArgs e)
        //{
        //    if (Regex.IsMatch(txtTrack.Text, checkIntRegex))
        //        Track = Convert.ToUInt32(txtTrack.Text);
        //    else
        //    {
        //        Track = 0;
        //        txtTrack.Text = "";
        //    }
        //}
        //private void txtYear_TextChanged(object sender, EventArgs e)
        //{
        //    if (Regex.IsMatch(txtYear.Text, checkIntRegex))
        //        Year = Convert.ToUInt32(txtYear.Text);
        //    else
        //    {
        //        Year = 0;
        //        txtYear.Text = "";
        //    }
        //}
        //private void txtGenre_TextChanged(object sender, EventArgs e)
        //{
        //    Genre = txtGenre.Text;
        //}
        //private void txtComments_TextChanged(object sender, EventArgs e)
        //{
        //    Comment = txtComments.Text;
        //}
        //#endregion
    }
}
