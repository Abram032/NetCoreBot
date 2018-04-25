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
    public class InfoCommand : ICommand
    {
        ISettings _settings;

        private List<string> _parameters;
        private object _messageDetails;

        Random random = new Random();

        public InfoCommand(List<string> parameters, object messageDetails)
        {
            _parameters = parameters;
            _messageDetails = messageDetails;
            _settings = Settings.Instance;
        }

        public async Task Execute()
        {
            IMessageWriter _writer = new MessageWriter(_messageDetails);
            string error = "Invalid use of command!";
            string message = "Project Site - " + Info.gitProjectSite + "\n";
            message += "Version - " + Info.version;
            if(AreValid(_parameters))
                await _writer.ReturnStatus(message);
            else
                await _writer.ReturnStatus(error);
            await Task.CompletedTask;
        }

        public string Help()
        {
            string help = "Usage:\n"
                + _settings.GetValue(SettingKeys.CommandPrefix) + " help - Shows info about bot.";
            return help;
        }

        private bool AreValid(List<string> parameters)
        {
            if(parameters.Count > 0)
                return false;
            else
                return true;
        }
    }
}
