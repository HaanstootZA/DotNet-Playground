using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System;

namespace MusicRenamer
{
	enum Music_Tag
	{
		Artist = 0,
		Title = 1,
		Album = 2,
		Empty = 3
	}

	class MusicRenamer_Base
	{
		#region Variables
		protected RFile[] files;
		protected string rootFolder = "";
		#endregion

		#region Attributes
		public RFile[] Files { get { return files; } }
		public string RootFolder { get { return rootFolder; } }
		#endregion

		private string[] SetFile(string Folder)
		{
			string[] ret;

			string[] filesMP3 = Directory.GetFiles(Folder, "*.mp3", SearchOption.AllDirectories);
			string[] filesMP4 = Directory.GetFiles(Folder, "*.mp4", SearchOption.AllDirectories);
			string[] filesM4A = Directory.GetFiles(Folder, "*.m4a", SearchOption.AllDirectories);
			string[] filesWMA = Directory.GetFiles(Folder, "*.wma", SearchOption.AllDirectories);
			int mp3l = filesMP3.Length;
			int mp4l = filesMP4.Length;
			int m4al = filesM4A.Length;
			int wmal = filesWMA.Length;
			ret = new string[mp3l + mp4l + m4al + wmal];
			for(int i = 0; i < ret.Length; i++)
			{
				string s;
				if(i < mp3l)
					s = filesMP3[i];
				else if(i < mp3l + mp4l)
					s = filesMP4[i - mp3l];
				else if(i < mp3l + mp4l + m4al)
					s = filesM4A[i - mp3l - mp4l];
				else
					s = filesWMA[i - mp3l - mp4l - m4al];
				ret[i] = s;
			}
			return ret;
		}

		#region Constructors
		public MusicRenamer_Base(string Folder)
		{
			rootFolder = Folder;
			string[] fileNames = SetFile(Folder);
			AddFileRange(ref fileNames);
		}

		public MusicRenamer_Base(string Folder, string RegexPattern)
		{
			rootFolder = Folder;
			string[] fileNames = SetFile(Folder);
			AddFileRange(ref fileNames, RegexPattern);
		}
		#endregion

		#region AddFiles
		//Add byref
		private void AddFileRange(ref string[] FilesToAdd)
		{
			files = new RFile[FilesToAdd.Length];
			for(int i = 0; i < FilesToAdd.Length; i++)
			{
				string file = FilesToAdd[i];
				RFile newFile = new RFile(rootFolder, file);
				FilesToAdd[i] = null;
				files[i] = newFile;
			}
		}

		private void AddFileRange(ref string[] FilesToAdd, string RegexPattern)
		{
			Regex Regex = new Regex(RegexPattern);
			for(int i = 0; i < FilesToAdd.Length; i++)
			{
				string file = FilesToAdd[i];
				MatchCollection mc = Regex.Matches(file);
				if(mc.Count > 0)
				{
					RFile newFile = new RFile(rootFolder, file);
					files[i] = newFile;
				}
			}
		}

		public TagTree BuildFileTree(bool CleanUp)
		{
			TagTree Tree = new TagTree();
			for(int i = 0; i < files.Length; i++)
			{
				RFile s = files[i];
				try
				{
					Tree.Push(s);
				}
				catch(Exception ez)
				{
					ExceptionHelper.ErrorFiles.Enqueue(s);
				}
				if(CleanUp)
					files[i] = null;
			}
			if(CleanUp)
				files = null;
			return Tree;
		}
		#endregion

		public void Clear()
		{
			files = null;
			rootFolder = "";
		}

		public void Reset()
		{
			files = null;
			Settings.UnknownCounter = 0;
		}
	}
}
