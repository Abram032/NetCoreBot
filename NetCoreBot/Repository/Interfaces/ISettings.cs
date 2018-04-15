using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Repository.Interfaces
{
    public interface ISettings
    {
        //static ISettings GetInstance();
        Task LoadSettings();
        Task SaveSettings();
        string GetValue(string key, bool defaultSetting = false);
    }
}
