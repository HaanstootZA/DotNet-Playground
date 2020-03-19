using System.Text.RegularExpressions;
using System.Text;

namespace MusicRenamer
{
    enum Case
    {
        FirstLetterInitial = 0, ALLCAPS = 1, nocaps = 2, CamelCase = 3, None = 4
    }

    static class String_Cleaner
    {
		private static readonly string[] IllegalChars = new string[] { "[:]", "[*]", "[/<>|\"]", "^[Aa][Cc]?[Dd][Cc]", "^[Aa][Tt][Bb]", "^[Aa][Tt][Cc]", "^[Aa][Ff][Ii]" };
        private static readonly string[] ReplaceChars = new string[] { "-", "_", "", "ACDC", "ATB", "ATC", "AFI" };
        private static readonly string WordSearch = @"\b(\w|['])+\b";
        private static StringBuilder _StringBuilder = new StringBuilder();

        public static string StringBuilder
        {
            get
            {
                string ret = _StringBuilder.ToString();
                _StringBuilder.Remove(0, String_Cleaner._StringBuilder.Length);
                return ret;
            }
            set
            {
                _StringBuilder.Append(value);
            }
        }
        public static int BuilderLength { get { return _StringBuilder.Length; } }

        private static string FirstLetterEvaluator(Match m)
        {
            if (m.Value.ToUpper().Equals("FT"))
                return "ft";
            return m.Value[0].ToString().ToUpper() + m.Value.Substring(1);
        }

        public static string CleanString(string value)
        {
            string newValue = value;
            for (int i = 0; i < IllegalChars.Length; i++)
            {
                Regex Regex_Cleaner = new Regex(IllegalChars[i]);
                newValue = Regex_Cleaner.Replace(newValue, ReplaceChars[i]);
            }
            return newValue;
        }

        public static string InitialFirstLetter(string input)
        {
            string ret = input;
            MatchEvaluator myEvaluator = new MatchEvaluator(FirstLetterEvaluator);
            ret = Regex.Replace(input, WordSearch, myEvaluator, RegexOptions.None);
            return ret;
        }

        public static string ToCamelCase(string value)
        {
            string ret = value.ToLower();
            return InitialFirstLetter(ret);
        }

        public static string ChangeCase(string value, Case namingCase)
        {
            switch (namingCase)
            {
                case Case.ALLCAPS:
                    return value.ToUpper();
                case Case.nocaps:
                    return value.ToLower();
                case Case.CamelCase:
                    return ToCamelCase(value);
                case Case.FirstLetterInitial:
                    return InitialFirstLetter(value);
                case Case.None:
                    return value;
                default:
                    return value;
            }
        }

        public static string ChangeCase(string value)
        {
            switch (Settings.StringCase)
            {
                case Case.ALLCAPS:
                    return value.ToUpper();
                case Case.nocaps:
                    return value.ToLower();
                case Case.CamelCase:
                    return ToCamelCase(value);
                case Case.FirstLetterInitial:
                    return InitialFirstLetter(value);
                case Case.None:
                    return value;
                default:
                    return value;
            }
        }
    }
}
