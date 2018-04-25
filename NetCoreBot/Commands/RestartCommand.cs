using NetCoreBot.Commands.Abstract;
using NetCoreBot.Common.Abstract;
using NetCoreBot.Common.Concrete;
using NetCoreBot.Repository.Abstract;
using NetCoreBot.Repository.Concrete;
using NetCoreBot.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Commands
{
    public class RestartCommand : ICommand
    {
        ISettings _settings;

        private List<string> _parameters;
        private object _messageDetails;

        public RestartCommand(List<string> parameters, object messageDetails)
        {
            _parameters = parameters;
            _messageDetails = messageDetails;
            _settings = Settings.Instance;
        }

        public async Task Execute()
        {
            IMessageWriter _writer = new MessageWriter(_messageDetails);
            string error = "Invalid use of command!";
            string notAuthorized = "You're not the owner!";
            string message = "Brb!";
            if (AreValid(_parameters))
            {
                if(IsAdmin())
                {
                    await _writer.ReturnStatus(message);
                    Process.Start("Run.bat", "-n");
                    Environment.Exit(0);
                }
                else
                    await _writer.ReturnStatus(notAuthorized);
            }
            else
                await _writer.ReturnStatus(error);
            await Task.CompletedTask;
        }

        public string Help()
        {
            string message = "Usage:\n"
                + _settings.GetValue(SettingKeys.CommandPrefix) + " restart - restarts bot process.";
            return message;
        }

        private bool AreValid(List<string> parameters)
        {
            if (parameters.Count > 0)
                return false;
            else
                return true;
        }

        private bool IsAdmin()
        {
            if (_messageDetails == null)
                return true;
            var details = _messageDetails as MessageDetails;
            if (details != null)
            {
                var author = details.Author.Id;
                var owner = _settings.GetValue(SettingKeys.OwnerID);
                ulong? ownerid = null;
                try
                {
                    ownerid = Convert.ToUInt64(owner);
                }
                catch
                {
                    return false;
                }
                if (author == ownerid)
                    return true;
            }
            return false;
        }
    }
}
