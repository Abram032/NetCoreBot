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
        private static string filePath = Environment.CurrentDirectory + @"/version.info";

        public static string GetValue(string key)
        {
            return info[key];
        }

        private static Dictionary<string, string> FillDictionary()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("version", "1.4a");
            info.Add("author", "Maissae");
            info.Add("site", "https://github.com/Maissae/Discord_BotTemplate");
            return info;
        }

        public static async Task LoadInfo()
        {
            if(!File.Exists(filePath))
                CreateInfoFile();
            else
                await LoadInfoFile();
            await Task.CompletedTask;
        }

        private static async Task LoadInfoFile()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    if(!line.StartsWith('#') || !line.StartsWith(string.Empty))
                    {
                        string[] pair = SplitLine(line);
                        if(pair.Length > 1)
                            info[pair[0]] = pair[1];
                    }
                }
            }
            await Task.CompletedTask;
        }

        private static void CreateInfoFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("version: " + info["version"]);
                sw.WriteLine("Author: " + info["author"]);
                sw.WriteLine("Site: " + info["site"]);
            }
        }

        public static void RebuildInfoFile()
        {
            info["version"] = gitVersion;
            File.Delete(filePath);
            CreateInfoFile();
        }

        private static string[] SplitLine(string line)
        {
            line = line.Trim();
            line = line.Replace(" ", string.Empty);
            string[] pair = line.Split(':');
            return pair;
        }
    }
}
