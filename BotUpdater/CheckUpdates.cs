using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

//TODO: Change link from /dev/ tree to /master/ tree after tests.

namespace BotUpdater
{
    class CheckUpdates
    {
        public static async Task CheckVersion()
        {
            string version = string.Empty;
            string downloadURL = string.Empty;
            if(!CheckConnection())
            {
                Console.WriteLine("Connection could not be established.");
                Console.WriteLine("Please check your internet connection and try again.");
                return;
            }
            using (WebClient client = new WebClient())
            {
                string[] htmlCode = client.DownloadString
                    ("https://github.com/Maissae/Discord_BotTemplate/blob/dev/README.md").Split('\n');
                foreach(string line in htmlCode)
                {
                    if(line.Contains("Current version"))
                        version = line;
                    if(line.Contains("Download"))
                        downloadURL = line;
                }
            }
            Info.gitVersion = ExtractVersion(version);
            Info.downloadURL = ExtractURL(downloadURL);
            await Task.CompletedTask;
        }

        private static string Split(string line)
        {
            string[] info = line.Split(':');
            return info[info.Length-1];
        }

        private static string ExtractVersion(string version)
        {
            version = version.Trim();
            version = version.Replace(" ", string.Empty);
            version = version.Replace("</p>", string.Empty);
            version = Split(version);
            return version;
        }

        private static string ExtractURL(string URL)
        {
            URL = URL.Trim();
            URL = URL.Replace(" ", string.Empty);
            string[] split = URL.Split('"');
            if(split.Length < 2)
                return string.Empty;
            URL = split[1];
            return URL;
        }

        private static bool CheckConnection()
        {
            return ExceptionHandler.CheckConnection();
        }
    }
}
