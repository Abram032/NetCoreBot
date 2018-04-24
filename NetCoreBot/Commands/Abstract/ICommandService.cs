using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Commands.Abstract
{
    public interface ICommandService
    {
        Task ExecuteCommand(string message, object details = null);
    }
}
