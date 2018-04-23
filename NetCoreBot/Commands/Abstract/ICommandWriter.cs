using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Commands.Abstract
{
    public interface ICommandWriter
    {
        void ReturnStatus(string message, bool isCli = false);
    }
}
