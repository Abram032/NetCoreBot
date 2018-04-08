using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

//TODO: Download .zip, unpack it and replace files.
//TODO: Update version.info file.

namespace BotUpdater
{
    class DownloadUpdates
    {
        public static async Task DownloadUpdate()
        {
            WebClient client = new WebClient();
            
        }

        private static string GetDownloadURL()
        {
            string URL = string.Empty;
            return URL;
        }
    }
}
