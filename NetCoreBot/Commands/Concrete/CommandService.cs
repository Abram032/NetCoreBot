using Discord.WebSocket;
using NetCoreBot.Commands.Abstract;
using NetCoreBot.Resources;
using NetCoreBot.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Commands.Concrete
{
    public class CommandService : ICommandService
    {
        ISettings _settings;

        public CommandService(ISettings settings)
        {
            _settings = settings;
        }

        public void ExecuteCommand(string message)
        {
            ICommand command = CreateCommand(message);
            command.Execute();
        }

        public void ExecuteCommand(object message)
        {
            var socketMessage = message as SocketMessage;
            if(socketMessage == null)
                return;
            ICommand command = CreateCommand(socketMessage);
            command.Execute();
        }

        private ICommand CreateCommand(string message)
        {
            string _message = RemovePrefix(message);
            _message = ConvertToLowercase(_message);
            List<string> _parameters = GetParameters(_message);
            _message = GetCommand(_message);

            ICommandFactory commandFactory = new CommandFactory();
            ICommand command = commandFactory.BuildCommand(_message, _parameters);
            return command;
        }

        private ICommand CreateCommand(SocketMessage socketMessage)
        {
            string _message = RemovePrefix(socketMessage.ToString());
            _message = ConvertToLowercase(_message);
            List<string> _parameters = GetParameters(_message);
            _message = GetCommand(_message);
            var _messageDetails = new MessageDetails(socketMessage);

            ICommandFactory commandFactory = new CommandFactory();
            ICommand command = commandFactory.BuildCommand(_message, _parameters, _messageDetails);
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
