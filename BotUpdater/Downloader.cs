using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Net;

//TODO: Download .zip, unpack it and replace files.
//TODO: Update version.info file.

namespace BotUpdater
{
    class Downloader
    {
        public static async Task DownloadUpdate()
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
                client.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
                Uri download = new Uri(@"C:/Users/maiss/Desktop/Deploy.zip");
                //string fileID = ExtractFileID(Info.downloadURL);
                await client.DownloadFileTaskAsync(download, "update.zip");
            }
            ExtractZip();
            await Task.CompletedTask;
        }

        private static void ExtractZip()
        {
            Directory.CreateDirectory(Environment.CurrentDirectory + @"/Update");
            ZipFile.ExtractToDirectory("update.zip", Environment.CurrentDirectory + @"/Update");
            File.Delete("update.zip");
        }
    }
}
