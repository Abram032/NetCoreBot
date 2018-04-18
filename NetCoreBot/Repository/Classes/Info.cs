using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Repository.Classes
{
    static class Info
    {
        public static string GitVersion { get; set; } = string.Empty;
        public static string DownloadLink { get; set; } = string.Empty;
        public static string version = "2.1.0"; 
        public const string author = "Maissae";
        public const string gitProjectSite = "https://github.com/Maissae/DiscordBotTemplate";
        public const string gitProjectReadmeLink = "https://github.com/Maissae/DiscordBotTemplate/blob/master/README.md";
    }
}
