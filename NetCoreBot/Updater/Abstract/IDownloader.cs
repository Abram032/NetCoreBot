using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Updater.Abstract
{
    public interface IDownloader
    {
        Task DownloadUpdate();
    }
}
