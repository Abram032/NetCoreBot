using System;
using System.Collections.Generic;
using System.Text;

namespace Discord_BotTemplate
{
    class Converter
    {
        public bool StrToBoolT(string value)
        {
            try { Convert.ToBoolean(value); }
            catch { return true; }
            return Convert.ToBoolean(value);
        }

        public bool StrToBoolF(string value)
        {
            try { Convert.ToBoolean(value); }
            catch { return false; }
            return Convert.ToBoolean(value);
        }
    }
}
