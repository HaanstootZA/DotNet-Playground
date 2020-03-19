using System;
namespace MusicRenamer
{
    class TagKey
    {
        private UInt64 _Artist;
        private UInt64 _Album;
        private UInt64 _Title;
        private UInt64 _Track;

        public string Key
        {
            get
            {
                return _Artist
                    + (Settings.UseAlbumInKey ? "-" + _Album : "")
                    + "-" + _Title
                    + (Settings.UseTrackInKey ? "-" + _Track : "");
            }
        }

        public UInt64 iKey
        {
            get
            {
                switch (Settings.TreeOrder)
                {
                    case OrderBy.Artist:
                        return _Artist;
                    case OrderBy.Title:
                        return _Title;
                    case OrderBy.Album:
                        return _Album;
                    case OrderBy.Track:
                        return _Track;
                    default:
                        return _Artist;
                }
            }
        }

        public TagKey()
		{
			string Unknown = "Unknown";
			_Artist = ConvertString(Unknown);
			_Album = ConvertString(Unknown);
			_Title = ConvertString(Unknown);
            _Track = 0;
        }

        public TagKey(RenamerTag Tag)
        {
			string Unknown = "Unknown";
            if (Tag.Artist == null)
				_Artist = ConvertString(Unknown);
            else
                _Artist = ConvertString(Tag.Artist);
            if (Tag.Album == null)
				_Album = ConvertString(Unknown);
            else
                _Album = ConvertString(Tag.Album);
            if (Tag.Title == null)
				_Title = ConvertString(Unknown);
            else
                _Title = ConvertString(Tag.Title);

            _Track = (UInt64)Tag.Track;
        }

        private UInt64 ConvertString(string Value)
        {
            UInt64 ret = 0;
            Value = Value.ToUpper().Replace(" ", "");
            foreach (char c in Value)
            {
                int temp = c;
                while (temp > 0)
                {
                    ret = ret * 10;
                    temp = temp / 10;
                }
                ret += c;
            }
            return ret;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(TagKey))
                return (string.Compare(Key, ((TagKey)obj).Key) == 0);
            else
                return false;
        }
    }
}
