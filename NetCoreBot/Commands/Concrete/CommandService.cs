using Discord.WebSocket;
using NetCoreBot.Commands.Abstract;
using NetCoreBot.Resources;
using NetCoreBot.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NetCoreBot.Common.Abstract;
using NetCoreBot.Common.Concrete;

namespace NetCoreBot.Commands.Concrete
{
    public class CommandService : ICommandService
    {
        ISettings _settings;

        public CommandService(ISettings settings)
        {
            _settings = settings;
        }

        public async Task ExecuteCommand(string message, object messageDetails = null)
        {
            ICommand command = CreateCommand(message, messageDetails);
            if(command != null)
                await command.Execute();
            else
            {
                string _message = "Unknown command.";
                IMessageWriter writer = new MessageWriter(messageDetails);
                if(messageDetails != null)
                    await writer.ReturnStatus(_message);
                else
                    await writer.ReturnStatus(_message, true);
            }    
            await Task.CompletedTask;
        }

        private ICommand CreateCommand(string message, object messageDetails)
        {
            string _message = RemovePrefix(message);
            _message = ConvertToLowercase(_message);
            List<string> parameters = GetParameters(_message);
            _message = GetCommand(_message);

            ICommandBuilder commandBuilder = new CommandBuilder();
            ICommand command = commandBuilder.BuildCommand(_message, parameters, messageDetails);
            return command;
        }

        private string RemovePrefix(string message)
        {
            message = message.Replace(_settings.GetValue(SettingKeys.CommandPrefix), string.Empty);
            message = message.Trim();
            return message;
        }

        private List<string> GetParameters(string message)
        {
            string[] array = message.Split(' ');
            List<string> parameters = new List<string>(array);
            parameters.RemoveAt(0);
            return parameters;
        }

        private string GetCommand(string message)
        {
            string[] array = message.Split(' ');
            List<string> parameters = new List<string>(array);
            return parameters[0];
        }

        private string ConvertToLowercase(string message)
        {
            message = message.ToLower();
            return message;
        }
    }
}
