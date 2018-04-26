using Discord.WebSocket;
using NetCoreBot.Commands.Abstract;
using NetCoreBot.Resources;
using System;
using System.Collections.Generic;
using System.Text;

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
                case CommandNames.help:
                    command = new HelpCommand(parameters, messageDetails);
                    break;
                case CommandNames.restart:
                    command = new RestartCommand(parameters, messageDetails);
                    break;
                case CommandNames.exit:
                    command = new ExitCommand(parameters, messageDetails);
                    break;
                case CommandNames.info:
                    command = new InfoCommand(parameters, messageDetails);
                    break;
                case CommandNames.purge:
                    command = new PurgeCommand(parameters, messageDetails);
                    break;
                default:
                    break;
            }
            return command;
        }
    }
}
