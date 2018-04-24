using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Common.Abstract
{
    public interface IMessageWriter
    {
        void ReturnStatus(string message, bool isCli = false);
    }
}
