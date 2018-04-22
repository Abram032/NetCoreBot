using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Commands.Abstract
{
    public interface ICommandReciever
    {
        void ReturnStatus(string message, bool isCli = false);
    }
}
