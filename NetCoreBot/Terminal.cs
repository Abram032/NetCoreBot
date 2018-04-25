using NetCoreBot.Commands.Abstract;
using NetCoreBot.Commands.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

//TODO: Allow for admin-only commands in console.
//TODO: Implement commands into console.

namespace NetCoreBot
{
    class Terminal
    {
        ICommandService _commandService;

        public Terminal(ICommandService commandService)
        {
            _commandService = commandService;
        }

        public void Main()
        {
            while(true)
            {
                string command = Console.ReadLine();
                _commandService.ExecuteCommand(command);
            }
        }
    }
}
