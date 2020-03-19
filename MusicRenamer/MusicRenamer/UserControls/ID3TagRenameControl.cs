using System;

namespace MusicRenamer
{
    partial class ID3TagRenameControl : UserControl_Base
    {
        //SELECT  REGEX Filter [a-zA-Z \-]*(([0-9][0-9][0-9][0-9][0-9])|([0-9][0-9][0-9][0-9])|([0-9][0-9][0-9]))\.[m|M|w|W][p|P|4|m|M][3|a|A]$
        //GET File LIKE Sultans Of Swing904
        //REPLACE REGEX Remove [0-9]*$, ""
        //Get 904, and remove 904

        public ID3TagRenameControl(string FolderName)
            : base(FolderName)
        {
            InitializeComponent();
        }

        private void btnID3Rename_Click(object sender, EventArgs e)
        {
            if (Renamer.Files != null)
            {
                Music_Tag tagToUse;
                if (rbID3Album.Checked)
                    tagToUse = Music_Tag.Album;
                else if (rbID3Artist.Checked)
                    tagToUse = Music_Tag.Artist;
                else if (rbID3Title.Checked)
                    tagToUse = Music_Tag.Title;
                else
                    tagToUse = Music_Tag.Empty;
                string StringSpecificationPattern = txtID3StringSpecificationPattern.Text;
                string ReplacementValue = txtID3ReplacementValue.Text;
                if (StringSpecificationPattern != "")
                {
                    ((ID3TagRenamer)Renamer).ID3RegexReplace(StringSpecificationPattern, ReplacementValue, tagToUse);
                }
            }
        }

        private void btnID3Search_Click(object sender, EventArgs e)
        {
            lstID3List.Items.Clear();
            Renamer = new ID3TagRenamer(FolderName, txtID3SearchPattern.Text);
            lstID3List.Items.AddRange(Renamer.Files);
        }

        protected override void ChangeDirectory()
        {
            lstID3List.Items.Clear();
            if (Renamer != null)
                Renamer.Clear();
            ThreadHelper.Thread_Busy = false;
        }
    }
}
