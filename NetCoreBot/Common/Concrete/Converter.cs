using NetCoreBot.Common.Abstract;
using NetCoreBot.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Common.Concrete
{
    class Converter : IConverter
    {
        public bool SettingsStringToBoolean(string key)
        {
            try 
            { 
                Convert.ToBoolean(Settings.Instance.GetValue(key)); 
            }
            catch 
            { 
                return Convert.ToBoolean(Settings.Instance.GetValue(key, true)); 
            }
            return Convert.ToBoolean(Settings.Instance.GetValue(key));
        }
    }
}
