using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Common.Abstract
{
    interface IConverter
    {
        bool SettingsStringToBoolean(string key);
    }
}
