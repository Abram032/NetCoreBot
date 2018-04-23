using NetCoreBot.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

//TODO: Remove ExceptionHandler and move converting into local class.

namespace NetCoreBot.Common.Concrete
{
    class Converter : IConverter
    {
        public bool StringToBool(string input)
        {
            return ExceptionHandler.StrToBool(input);
        }
    }
}
