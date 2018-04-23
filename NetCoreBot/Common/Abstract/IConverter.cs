using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Common.Abstract
{
    interface IConverter
    {
        bool StringToBool(string input);
    }
}
