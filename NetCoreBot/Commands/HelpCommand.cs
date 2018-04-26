using NetCoreBot.Commands.Concrete;
using NetCoreBot.Commands.Abstract;
using NetCoreBot.Common.Abstract;
using NetCoreBot.Common.Concrete;
using NetCoreBot.Repository.Abstract;
using NetCoreBot.Repository.Concrete;
using NetCoreBot.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Commands
{
    public class HelpCommand : ICommand
    {
        ISettings _settings;

        private List<string> _parameters;
        private object _messageDetails;

        public HelpCommand(List<string> parameters, object messageDetails)
        {
            _parameters = parameters;
            _messageDetails = messageDetails;
            _settings = Settings.Instance;
        }

        public async Task Execute()
        {
            IMessageWriter _writer = new MessageWriter(_messageDetails);
            string error = "Invalid use of command!";
            string message = string.Empty;
            if(AreValid(_parameters))
            {
                if(_parameters.Count == 0)
                    message = ShowCommands();
                if(_parameters.Count == 1)
                    message = ShowCommandHelp();
                await _writer.ReturnStatus(message);
            }
            else
            {
                 await _writer.ReturnStatus(error);
            }
            await Task.CompletedTask;
        }

        public string Help()
        {
            string help = "Why would you even do that? ._. \nUsage:\n"
                + _settings.GetValue(SettingKeys.CommandPrefix) + " help - Shows available commands.\n"
                + _settings.GetValue(SettingKeys.CommandPrefix) + " help <command> - Shows help for specific command.";
            return help;
        }

        private string ShowCommands()
        {
            string message = "Available commands:\n";
            string availableCommands = string.Empty;
            string lastCommand = CommandNames.commands[CommandNames.commands.Count - 1];
            foreach(string command in CommandNames.commands)
            {
                availableCommands += command;
                if(command != lastCommand)
                    availableCommands += ", ";
                else
                    availableCommands += ".";
            }
            message += availableCommands;
            message += "\nFor more help you can use " + _settings.GetValue(SettingKeys.CommandPrefix) + " help <command>.";
            return message;
        }

        private string ShowCommandHelp()
        {
            string message = string.Empty;
            string parameter = _parameters[0];
            ICommandBuilder commandBuilder = new CommandBuilder();
            ICommand command = commandBuilder.BuildCommand(parameter, new List<string>());
            if(command != null)
                message = command.Help();
            else
                message = "Unknown command.";
            return message;
        }

        private bool AreValid(List<string> parameters)
        {
            if(parameters.Count <= 1)
                return true;
            else
                return false;
        }
    }
}
