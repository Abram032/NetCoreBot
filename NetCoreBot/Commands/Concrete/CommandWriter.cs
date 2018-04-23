using NetCoreBot.Commands.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//TODO: Move CommandWriter to MessageWriter in Common, spearate Commands from API.

namespace NetCoreBot.Commands.Concrete
{
    public class CommandWriter : ICommandWriter
    {
        private MessageDetails _messageDetails;

        public CommandWriter(MessageDetails messageDetails)
        {
            _messageDetails = messageDetails;
        }

        public void ReturnStatus(string message, bool Cli = false)
        {
            if(Cli)
                Console.WriteLine(message);
            else
                SendMessageAsync(message).Wait();
        }

        private async Task SendMessageAsync(string message)
        {
            string _message = "@ " + _messageDetails.Author + " " + message;
            await _messageDetails.Channel.SendMessageAsync(message);
        }
    }
}
