using Discord.WebSocket;
using NetCoreBot.Commands.Abstract;
using NetCoreBot.Resources;
using System;
using System.Collections.Generic;
using System.Text;

//TODO: Implement help command.
//TODO: Implement stop command.
//TODO: Implement restart command.

namespace NetCoreBot.Commands.Concrete
{
    public class CommandBuilder : ICommandBuilder
    {
        public ICommand BuildCommand(string message, List<string> parameters, object messageDetails = null)
        {
            ICommand command = null;
            switch (message)
            {
                case CommandNames.random:
                    command = new GenerateRandomNumberCommand(parameters, messageDetails);
                    break;
                default:
                    break;
            }
            return command;
        }
    }
}
