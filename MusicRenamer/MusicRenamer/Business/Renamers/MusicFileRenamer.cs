using System;
using System.IO;

namespace MusicRenamer
{
    class MusicFileRenamer : MusicRenamer_Base
    {
        private int RootSlashCount = 0;

        #region Constructors
        public MusicFileRenamer(string Folder)
            : base(Folder)
        {
            RootSlashCount = Folder.Split(new char[] { '\\' }).Length;
        }
        #endregion

        public string[] SetPreviewFiles(int PreviewSize)
        {
            string[] newFileNames = new string[(files.Length < PreviewSize ? files.Length : PreviewSize)];
            for (int i = 0; (i < files.Length && i < PreviewSize); i++)
            {
                RFile currentFile = Files[i];
                RenamerTag NewTag = currentFile.GetNewTag();
                newFileNames[i] = currentFile.GetNewFileName(rootFolder, NewTag);
            }
            return newFileNames;
        }

        private bool CheckDirectory(string FolderName)
        {
            bool ret = true;
            int FolderSlashCount = FolderName.Split(new char[] { '\\' }).Length;
            if (RootSlashCount >= FolderSlashCount)
                ret = false;
            return ret;
        }

        private int CountFiles(string FolderName)
        {
            int count = 0;
			count += Directory.GetFiles(FolderName, "*.mp3", SearchOption.AllDirectories).Length;
			count += Directory.GetFiles(FolderName, "*.mp4", SearchOption.AllDirectories).Length;
            count += Directory.GetFiles(FolderName, "*.m4a", SearchOption.AllDirectories).Length;
            count += Directory.GetFiles(FolderName, "*.wma", SearchOption.AllDirectories).Length;
            return count;
        }

        private string CleanFolder(string FolderName)
        {
            if (FolderName.ToUpper().Equals(RootFolder.ToUpper()) || (CountFiles(FolderName) > 0))
                return "";
            string ret = CleanFolder(Directory.GetParent(FolderName).FullName);
            if (ret.Equals(""))
                return FolderName;
            else
                return ret;
        }

        private void CleanFolders(string[] Folders)
        {
            foreach (string s in Folders)
            {
                if (Directory.Exists(s))
                {
                    string ToDelete = CleanFolder(s);
                    if (!ToDelete.Equals(""))
                    {
                        if (Directory.Exists(ToDelete) && CheckDirectory(ToDelete))
                            Directory.Delete(ToDelete, true);
                    }
                }
            }
        }

        public void CommitFileNameChanges()
        {
            if (files.Length > 0)
            {
                string[] OldFolders = new string[files.Length];

                RenamerTag NewTag;
                string NewName;

                TagTree Tree = base.BuildFileTree(true);
                while(Tree.Size > 0)
                {
                    RFile currentFile = Tree.Pop();
                    string oldFile = currentFile.FileName;
                    try
                    {
                        OldFolders[OldFolders.Length - Tree.Size - 1] = oldFile.Substring(0, oldFile.LastIndexOf("\\"));

                        NewTag = currentFile.GetNewTag();
                        NewName = (currentFile.GetNewFileName(rootFolder, NewTag) + oldFile.Substring(oldFile.LastIndexOf("."))).Replace("?", "");

                        currentFile.Save(rootFolder + "\\DUPLICATES", NewName, NewTag);
                    }
                    catch (Exception ex)
                    {
                        //errors.Append(errors.Equals("") ? "General_Exception: " : "\r\n General_Exception: ");
                        //errors.Append(ex.Message);
                    }
                }
                CleanFolders(OldFolders);
            }
        }
    }
}
