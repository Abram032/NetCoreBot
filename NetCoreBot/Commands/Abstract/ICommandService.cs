using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Commands.Abstract
{
    interface ICommandService
    {
        void ExecuteCommand(string message);
        void ExecuteCommand(object message);
    }
}
