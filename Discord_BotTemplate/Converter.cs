using System;
using System.Collections.Generic;
using System.Text;

namespace Discord_BotTemplate
{
    class Converter
    {
        public static bool SettingsStrToBool(string key)
        {
            return ExceptionHandler.StrToBool(key);
        }
    }
}
