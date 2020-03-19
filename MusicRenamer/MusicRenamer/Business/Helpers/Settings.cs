using System;

namespace MusicRenamer
{
    class Setting_Inst
    {
        public Case StringCase = Case.CamelCase;
        public bool RemoveComments = false;
        public string FileNamingConvention = "";

        public OrderBy TreeOrder = OrderBy.Artist;
        public bool UseAlbumInKey;
        public bool UseTrackInKey;
    }

    public enum OrderBy
    {
        Artist, Title, Album, Track
    }

    static class Settings
    {
        private static Setting_Inst tempSettings;

        private static OrderBy _TreeOrder = OrderBy.Artist;
        private static bool _UseAlbumInKey = false;
        private static bool _UseTrackInKey = false;
        private static int _UknownCounter = 0;

        public static Case StringCase = Case.CamelCase;
        public static bool RemoveComments = false;

        private static string _FileNamingConvention = "\\[ARTIST]\\[ALBUM]\\[ARTIST] - [TITLE]";

        public static string Artist { get { return "[ARTIST]"; } }
        public static string Title { get { return "[TITLE]"; } }
        public static string Album { get { return "[ALBUM]"; } }
        public static string Track { get { return "[TRACK]"; } }
        public static string FileNamingConvention
        {
            get
            {
                return _FileNamingConvention;
            }
            set
            {
                if (value.Contains(Artist) || value.Contains(Track) || value.Contains(Title) || value.Contains(Album))
                    _FileNamingConvention = value;
                else
                    throw new Naming_Exception();
            }
        }


        public static bool UseAlbumInKey
        {
            get { return _UseAlbumInKey; }
            set
            {
                if (value)
                    _UseAlbumInKey = value;
                else if (_TreeOrder == OrderBy.Album)
                    throw new Exception("Can not change the key when the selected key is still used within the Order");
            }
        }
        public static bool UseTrackInKey
        {
            get { return _UseTrackInKey; }
            set
            {
                if (value)
                    _UseTrackInKey = value;
                else if (_TreeOrder == OrderBy.Track)
                    throw new Exception("Can not change the key when the selected key is still used within the Order");
            }
        }
        public static OrderBy TreeOrder
        {
            get { return _TreeOrder; }
            set
            {
                if (value == OrderBy.Album && !UseAlbumInKey)
                    throw new Exception("Can not set the order by to album if the album is not included in the key");
                if (value == OrderBy.Track && !UseTrackInKey)
                    throw new Exception("Can not set the order by to track if the track is not included in the key");
                _TreeOrder = value;
            }
        }
        public static int UnknownCounter
        {
            get
            {
                int temp = _UknownCounter;
                _UknownCounter = _UknownCounter + 1;
                return temp;
            }
            set
            {
                if (value >= 0)
                    _UknownCounter = value;
                else
                    _UknownCounter = 0;
            }
        }

        public static void Abort()
        {
            RemoveComments = tempSettings.RemoveComments;
            UseAlbumInKey = tempSettings.UseAlbumInKey;
            UseTrackInKey = tempSettings.UseTrackInKey;
            StringCase = tempSettings.StringCase;
            _TreeOrder = tempSettings.TreeOrder;
        }

        public static void Confirm()
        {
            tempSettings = null;
        }

        public static void Backup()
        {
            tempSettings = new Setting_Inst();
            tempSettings.RemoveComments = (RemoveComments == true);
            tempSettings.UseAlbumInKey = (UseAlbumInKey == true);
            tempSettings.UseTrackInKey = (UseTrackInKey == true);
            tempSettings.StringCase = CopyCase();
            tempSettings.TreeOrder = CopyOrder();
        }

        private static Case CopyCase()
        {
            switch (StringCase)
            {
                case Case.ALLCAPS:
                    return Case.ALLCAPS;
                case Case.nocaps:
                    return Case.nocaps;
                case Case.CamelCase:
                    return Case.CamelCase;
                case Case.FirstLetterInitial:
                    return Case.FirstLetterInitial;
                case Case.None:
                    return Case.None;
                default:
                    return Case.None;
            }
        }

        private static OrderBy CopyOrder()
        {
            switch (_TreeOrder)
            {
                case OrderBy.Artist:
                    return OrderBy.Artist;
                case OrderBy.Title:
                    return OrderBy.Title;
                case OrderBy.Album:
                    return OrderBy.Album;
                case OrderBy.Track:
                    return OrderBy.Track;
                default:
                    return OrderBy.Artist;
            }
        }
    }
}
