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
        CommandService _commandService;

        public Terminal()
        {
            
        }

        public void Main()
        {
            while(true)
            {
                string command = Console.ReadLine();
                //_commandService = new CommandService();
                //_commandService.ReadCommand(command);
            }
        }
    }
}
