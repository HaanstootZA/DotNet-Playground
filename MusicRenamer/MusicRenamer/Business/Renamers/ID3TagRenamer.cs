using System.Text.RegularExpressions;

namespace MusicRenamer
{
    class ID3TagRenamer : MusicRenamer_Base
    {
        #region Constructors
        public ID3TagRenamer(string Folder, string RegexPattern) : base(Folder, RegexPattern) { }
        #endregion

        public void ID3RegexReplace(string SelectPattern, string newValue)
        {
            for (int i = 0; i < files.Length; i++)
            {
                RFile currentFile = files[i];
                TagLib.File TagFile = currentFile.Tag.File;
                TagLib.File NewTagFile = null;
                if (TagFile.Tag != null)
                {
                    TagFile.Tag.Album = Regex.Replace(TagFile.Tag.Album, SelectPattern, newValue);
                    TagFile.Tag.Performers[0] = Regex.Replace(TagFile.Tag.Performers[0], SelectPattern, newValue);
                    TagFile.Tag.Title = Regex.Replace(TagFile.Tag.Title, SelectPattern, newValue);
                    NewTagFile = TagFile;
                }
                RenamerTag NewTag = new RenamerTag(NewTagFile);
                currentFile.SaveTag(NewTag);
                TagFile.Dispose();
                NewTagFile.Dispose();
            }
        }

        public void ID3RegexReplace(string SelectPattern, string newValue, Music_Tag ToUpdate)
        {
            if (Music_Tag.Empty == ToUpdate)
            {
                ID3RegexReplace(SelectPattern, newValue);
            }
            else
            {
                RFile currentFile;
                TagLib.File TagFile;
                TagLib.File NewTagFile;
                for (int i = 0; i < files.Length; i++)
                {
                    currentFile = files[i];
                    TagFile = currentFile.Tag.File;
                    NewTagFile = null;
                    if (TagFile.Tag != null)
                    {
                        switch (ToUpdate)
                        {
                            case Music_Tag.Album:
                                TagFile.Tag.Album = Regex.Replace(TagFile.Tag.Album, SelectPattern, newValue);
                                break;
                            case Music_Tag.Artist:
                                TagFile.Tag.Performers[0] = Regex.Replace(TagFile.Tag.Performers[0], SelectPattern, newValue);
                                break;
                            case Music_Tag.Title:
                                TagFile.Tag.Title = Regex.Replace(TagFile.Tag.Title, SelectPattern, newValue);
                                break;
                        }
                        NewTagFile = TagFile;
                    }
                    RenamerTag NewTag = new RenamerTag(NewTagFile);
                    currentFile.SaveTag(NewTag);
                    TagFile.Dispose();
                    NewTagFile.Dispose();
                }
            }
        }
    }
}
