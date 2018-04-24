using NetCoreBot.Commands.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Commands.Abstract
{
    public interface ICommandBuilder
    {
        ICommand BuildCommand(string message, List<string> parameters, object messageDetails = null);
    }
}
