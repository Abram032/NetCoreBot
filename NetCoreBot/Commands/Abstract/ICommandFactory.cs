using NetCoreBot.Commands.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Commands.Abstract
{
    public interface ICommandFactory
    {
        ICommand BuildCommand(string message, List<string> parameters, MessageDetails _messageDetails = null);
    }
}
