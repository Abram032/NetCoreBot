using NetCoreBot.Resources;
using NetCoreBot.Updater.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;

//TODO: Change download URI.

namespace NetCoreBot.Updater.Concrete
{
    public class Downloader : IDownloader
    {
        private const string updateZipName = "update.zip";
        private readonly string deployPath = Environment.CurrentDirectory;

        public async Task DownloadUpdate()
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
                client.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
                Uri download = new Uri(@"C:/Users/maiss/Desktop/Deploy.zip");
                //Uri download = new Uri(Info.DownloadLink);
                await client.DownloadFileTaskAsync(download, updateZipName);
            }
            ExtractZip();
            await Task.CompletedTask;
        }
        
        private void ExtractZip()
        {
            ZipFile.ExtractToDirectory(updateZipName, Environment.CurrentDirectory);
            File.Delete(updateZipName);
        }
    }
}
