using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Repository.Abstract
{
    public interface ISettings
    {
        Task LoadSettings();
        Task SaveSettings();
        string GetValue(string key, bool defaultSetting = false);
    }
}
