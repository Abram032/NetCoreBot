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
    public class PurgeCommand : ICommand
    {
        ISettings _settings;

        private List<string> _parameters;
        private object _messageDetails;

        public PurgeCommand(List<string> parameters, object messageDetails)
        {
            _parameters = parameters;
            _messageDetails = messageDetails;
            _settings = Settings.Instance;
        }

        public async Task Execute()
        {
            IMessageWriter _writer = new MessageWriter(_messageDetails);
            string error = "Invalid use of command!";
            string message = "PURGE XENO SCUM!";
            if(AreValid(_parameters))
            {
                int amount = 100;
                if(_parameters.Count == 1)
                    amount = GetAmount();
                await PurgeMessages(amount);
                await _writer.ReturnStatus(message);
            }
            else
                await _writer.ReturnStatus(error);
            await Task.CompletedTask;
        }

        public string Help()
        {
            string help = "Usage:\n"
                + _settings.GetValue(SettingKeys.CommandPrefix) + " purge - Removes bot messages and command calls from chat.\n"
                + _settings.GetValue(SettingKeys.CommandPrefix) + " purge <amount> - Removes amount of last bot messages and command calls from chat.";
            return help;
        }

        private async Task PurgeMessages(int amount = 100)
        {
            var details = _messageDetails as MessageDetails;
            //var messages = details.Channel.GetMessagesAsync(amount, Discord.CacheMode.AllowDownload);
            //var _messages = details.Channel.GetMessagesAsync();
            //var _messages = new List<Discord.IMessage>(messages);
            //foreach(var message in _messages)
            //{
            //    if(message.ToString().Contains(_settings.GetValue(SettingKeys.CommandPrefix)) || message.Author.IsBot)
            //        await message.DeleteAsync();
            //}
            await Task.CompletedTask;
        }

        private int GetAmount()
        {
            return int.Parse(_parameters[0]);
        }

        private bool AreValid(List<string> parameters)
        {
            if(parameters.Count == 0)
                return true;
            if(parameters.Count == 1)
            {
                if(int.TryParse(parameters[0], out int result))
                    if(int.Parse(parameters[0]) < 100 && int.Parse(parameters[0]) > 0)
                        return true;
            }  
            return false;
        }
    }
}
