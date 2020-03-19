using System;
using System.IO;
using System.Text;

namespace MusicRenamer
{
    public class RFile
    {
        private bool _Corrupt = false;
        public bool isDuplicate = false;
        public bool isOriginal = false;
        public int DuplicateCount;

        private RenamerTag tag;

        public bool Corrupt { get { return _Corrupt; } }
        public string FileName { get { return tag.FileName; } }
        public RenamerTag Tag { get { return tag; } }

		public RFile() {
			isDuplicate = false;
			isOriginal = false;
			_Corrupt = false;
			DuplicateCount = 0;
			tag = null;
		}

        public RFile(string RootFolder, string Filename)
        {
            try
            {
                tag = new RenamerTag(Filename);
                if (Filename.Substring(0, Filename.LastIndexOf(".")).Equals(GetNewFileName(RootFolder, tag)))
                {
                    isOriginal = true;
                }
            }
            catch (Exception)
            {
                tag = null;
                _Corrupt = true;
            }
        }

		public RFile(RFile rhs)
		{
			isDuplicate = rhs.isDuplicate;
			isOriginal = rhs.isOriginal;
			DuplicateCount = rhs.DuplicateCount;
			_Corrupt = rhs._Corrupt;
			tag = new RenamerTag();
			tag = rhs.tag;
		}

        public RenamerTag GetNewTag()
        {
            if (FileName.Equals("") || Tag == null)
                return null;
            return Tag.GetCleanTag();
        }

        public string GetNewFileName(string RootFolder, RenamerTag Tag)
        {
            string newName = "";
            try
            {
                if (Tag != null)
                {
                    if (isDuplicate)
                    {
                        int startIndex = Settings.FileNamingConvention.LastIndexOf("\\");
                        int endIndex = Settings.FileNamingConvention.Length - startIndex;
                        string newNamingConvention = Settings.FileNamingConvention.Substring(startIndex, endIndex);

                        newName = newNamingConvention.Replace(Settings.Artist, Tag.Artist)
                            .Replace(Settings.Title, Tag.Title)
                            .Replace(Settings.Album, Tag.Album)
                            .Replace(Settings.Track, Convert.ToString(Tag.Track));

                        newName = RootFolder + "\\DUPLICATES" + newName + "_" + DuplicateCount;
                    }
                    else
                    {
                        string name = Settings.FileNamingConvention.Replace(Settings.Artist, Tag.Artist)
                             .Replace(Settings.Title, Tag.Title).Replace(Settings.Album, Tag.Album)
                             .Replace(Settings.Track, Convert.ToString(Tag.Track));
                        newName = RootFolder + name;
                    }
                }
            }
            catch (Exception)
            {
                int ErrorStartIndex = FileName.LastIndexOf("\\") + 1;
                int ErrorEndIndex = FileName.LastIndexOf(".") - ErrorStartIndex;
                newName = RootFolder + @"\0_FAILED\" + FileName.Substring(ErrorStartIndex, ErrorEndIndex);
            }
            return newName;
        }

        private void CheckDirectoryForFile(string fileName)
        {
            string directory = fileName.Substring(0, fileName.LastIndexOf(Path.DirectorySeparatorChar));
            try
            {
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
            }
            catch { }
        }

        private int CheckFile(string NewName)
        {
            int ret = 1;

            string newDirectory = NewName.Substring(0, NewName.LastIndexOf("\\")).ToUpper();
            string oldDirectory = FileName.Substring(0, FileName.LastIndexOf("\\")).ToUpper();
            string newFile = NewName.Substring(NewName.LastIndexOf("\\") + 1);
            string oldFile = FileName.Substring(FileName.LastIndexOf("\\") + 1);
            if (newDirectory == oldDirectory && newFile == oldFile)
                return 2;

            string temp = NewName;
            if (!System.IO.File.Exists(temp))
                return 0;

            return ret;
        }

        private string SetErrorName(string RemoveFolder, string NewName, int Counter)
        {
            int startIndex = NewName.LastIndexOf("\\");
            int endIndex = NewName.LastIndexOf(".") - startIndex;
            int offset = 0;
            if (Counter > 1)
            {
                offset = 1 + (Counter - 1).ToString().Length;
            }

            String_Cleaner.StringBuilder = RemoveFolder;
            String_Cleaner.StringBuilder = NewName.Substring(startIndex, endIndex - offset);
            if (Counter > 0)
                String_Cleaner.StringBuilder = "_" + string.Format("{0:000}", Counter);
            String_Cleaner.StringBuilder = NewName.Substring(endIndex + startIndex);

            return String_Cleaner.StringBuilder;
        }

        private void SaveFile(string NewName, string RemoveFolder)
        {
            try
            {
                int counter = 0;
                bool busy = true;
                bool error = false;
                while (busy)
                {
                    if (NewName != string.Empty)
                    {
                        CheckDirectoryForFile(NewName);
                        int check = CheckFile(NewName);
                        if (check == 0)
                        {
                            try
                            {
                                tag.Move(NewName);
                                busy = false;
                            }
                            catch (IOException ioex)
                            {
                                error = ioex.Message.Contains("Cannot create a file when that file already exists.");
                            }
                        }
                        if (check == 1 || error)
                        {
                            NewName = SetErrorName(RemoveFolder, NewName, counter);
                            counter++;
                        }
                        if (check == 2)
                            busy = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(Renaming_Exception))
                    throw new Renaming_Exception(string.Format("Error Moving file: \r\n{0}\r\nTo:\r\n{1}", FileName, NewName));
            }
        }

        public void SaveTag(RenamerTag NewTag)
        {
            if (NewTag != null && !tag.Compare(NewTag))
            {
                NewTag.Save();
                tag = NewTag;
            }
        }

        public void Save(string RemoveFolder, string NewName, RenamerTag NewTag)
        {
            SaveTag(NewTag);
            SaveFile(NewName, RemoveFolder);
        }

        public override string ToString()
        {
            return FileName;
        }

        public RenamerTag CopyTagFile()
        {
            return new RenamerTag(FileName);
        }

        public bool CompareTags(RenamerTag NewTag)
        {
            return Tag.Compare(NewTag);
        }
    }
}
