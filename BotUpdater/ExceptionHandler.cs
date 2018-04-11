using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace BotUpdater
{
    class ExceptionHandler
    {
        public static bool CheckConnection()
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
