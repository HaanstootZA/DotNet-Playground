using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagLib;

namespace MusicRenamer
{
    public class RenamerTag
    {
        private string _FileName;
        private string _Artist;
        private string _Album;
        private string _Title;
        private uint _Track;
        private uint _Year;
        private string _Comment;
        private string _Genre;
        private int _Bitrate;
        private TimeSpan _Duration;

        public string FileName { get { return _FileName; } }
        public string Artist { get { return _Artist; } }
        public string Album { get { return _Album; } }
        public string Title { get { return _Title; } }
        public uint Track { get { return _Track; } }
        public uint Year { get { return _Year; } }
        public string Comment { get { return _Comment; } }
        public string Genre { get { return _Genre; } }
        public int Bitrate { get { return _Bitrate; } }
        public TimeSpan Duration { get { return _Duration; } }
        public TagLib.File File
        {
            get
            {
                TagLib.File ret = TagLib.File.Create(_FileName);
                this.SetTagLibTag(ref ret);
                return ret;
            }
        }

        public RenamerTag()
        {
            _FileName = "";
            _Artist = "";
            _Album = "";
            _Title = "";
            _Track = 0;
            _Year = 0;
            _Comment = "";
            _Genre = "";
            _Bitrate = 0;
            _Duration = default(TimeSpan);
        }

        public RenamerTag(string FileName)
        {
            _FileName = FileName;
            TagLib.File temp = TagLib.File.Create(FileName);
            SetTag(temp);
            temp.Dispose();
        }

        public RenamerTag(TagLib.File File)
        {
            _FileName = File.Name;
            SetTag(File);
        }

        public RenamerTag GetCleanTag()
        {
            RenamerTag NewTag = new RenamerTag(FileName);
            if (this._Artist == null || this._Artist.Equals(""))
            {
                NewTag._Artist = "Unknown";
            }
            if (this._Title == null || this._Title.Equals(""))
            {
                NewTag._Title = string.Format("Unknown_Track_{0:000}", Settings.UnknownCounter);
            }
            if (this._Album == null || this._Album == "")
            {
                NewTag._Album = "Unknown";
            }

            NewTag._Artist = String_Cleaner.CleanString(String_Cleaner.ChangeCase(NewTag._Artist)).Trim();
            NewTag._Album = String_Cleaner.CleanString(String_Cleaner.ChangeCase(NewTag._Album)).Trim();
            NewTag._Title = String_Cleaner.CleanString(String_Cleaner.ChangeCase(NewTag._Title)).Trim();
            if (Settings.RemoveComments)
                NewTag._Comment = "";
            return NewTag;
        }

        public void Save()
        {
            TagLib.File save = File;
            save.Save();
            save.Dispose();
        }

        public void Move(string NewFile)
        {
            System.IO.File.Move(FileName, NewFile);
            _FileName = string.Copy(NewFile);
        }

        public override string ToString()
        {
            return _FileName;
        }

        public bool Compare(RenamerTag NewTag)
        {
            if (this == NewTag)
                return true;
            if (this._Title != NewTag._Title)
                return false;
            if (this._Album != NewTag._Album)
                return false;
            if (this._Track != NewTag._Track)
                return false;
            if (this._Year != NewTag._Year)
                return false;
            if (this._Comment != NewTag._Comment)
                return false;
            if (this._Artist != NewTag._Artist)
                return false;
            if (this._Genre != NewTag._Genre)
                return false;
            if (this._Duration != NewTag._Duration)
                return false;
            if (this._Bitrate != NewTag._Bitrate)
                return false;
            return true;
        }

        private void SetTag(TagLib.File File)
        {
            TagLib.Tag Tag = File.Tag;
            if (Tag != null)
            {
                this._Artist = ConcatenateStrings(Tag.Performers);
                this._Album = Tag.Album;
                this._Title = Tag.Title;
                this._Track = Tag.Track;
                this._Year = Tag.Year;
                this._Comment = Tag.Comment;
                this._Genre = ConcatenateStrings(Tag.Genres);
                this._Bitrate = File.Properties.AudioBitrate;
                this._Duration = File.Properties.Duration;
            }
        }

        private void SetTagLibTag(ref TagLib.File CurrentFile)
        {
            CurrentFile.Tag.Performers = new string[1] { this._Artist };
            CurrentFile.Tag.Album = this._Album;
            CurrentFile.Tag.Title = this._Title;
            CurrentFile.Tag.Track = this._Track;
            CurrentFile.Tag.Year = this._Year;
            CurrentFile.Tag.Comment = this._Comment;
            CurrentFile.Tag.Genres = new string[1] { this._Genre };
        }

        private string ConcatenateStrings(string[] Source)
        {
            for (int i = 0; i < Source.Length; i++)
                String_Cleaner.StringBuilder = (i > 0 ? " " : "") + Source[i];
            return String_Cleaner.StringBuilder;
        }
    }

}
