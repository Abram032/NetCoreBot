using NetCoreBot.Resources;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Updater.Concrete
{
    class UpdateChecker
    {
        private string gitVersion = string.Empty; 
        private string downloadLink = string.Empty; 

        public async Task CheckVersion()
        {
            if(CheckConnection() == false)
            {
                Console.WriteLine("Connection could not be established.");
                Console.WriteLine("Please check your internet connection and try again.");
                return;
            }
            using (WebClient client = new WebClient())
            {
                string[] htmlCode = client.DownloadString
                    (Info.gitProjectReadmeLink).Split('\n');
                foreach(string line in htmlCode)
                {
                    if(line.Contains("Current version"))
                        gitVersion = line;
                    if(line.Contains("Download"))
                        downloadLink = line;
                }
            }
            Info.GitVersion = ExtractVersion(gitVersion);
            Info.DownloadLink = ExtractURL(downloadLink);
            await Task.CompletedTask;
        }

        private string Split(string line)
        {
            string[] info = line.Split(':');
            return info[info.Length-1];
        }

        private string ExtractVersion(string version)
        {
            version = version.Trim();
            version = version.Replace(" ", string.Empty);
            version = version.Replace("</p>", string.Empty);
            version = Split(version);
            return version;
        }

        private string ExtractURL(string URL)
        {
            URL = URL.Trim();
            URL = URL.Replace(" ", string.Empty);
            string[] split = URL.Split('"');
            if(split.Length < 2)
                return string.Empty;
            URL = split[1];
            return URL;
        }

        private bool CheckConnection()
        {
            WebClient client = new WebClient();
            try
            {
                string htmlCode = client.DownloadString
                    ("https://github.com/Maissae/Discord_BotTemplate/blob/master/README.md");
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
