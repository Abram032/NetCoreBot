using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BotUpdater
{
    class Info
    {
        public static string gitVersion = string.Empty;
        public static string downloadURL = string.Empty;
        private static Dictionary<string, string> info = FillDictionary();

        public static string GetValue(string key)
        {
            return info[key];
        }

        public static void SetValue(string key, string value)
        {
            info["version"] = value;
        }

        private static Dictionary<string, string> FillDictionary()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("version", "1.6a");
            info.Add("author", "Maissae");
            info.Add("site", "https://github.com/Maissae/Discord_BotTemplate");
            return info;
        }
    }
}
