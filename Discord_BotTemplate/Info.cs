using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Discord_BotTemplate
{
    class Info
    {
        private static string version = "v0.8a";
        private static string site = "https://github.com/Maissae/Discord_BotTemplate";
        private static string filePath = Environment.CurrentDirectory + @"/version.info";
        private static string author = "Maissae";

        public static void CreateInfoFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("version: " + version);
                sw.WriteLine("Author: " + author);
                sw.WriteLine("Site: " + site);
            }
        }
    }
}
