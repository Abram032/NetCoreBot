using NetCoreBot.Commands.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Commands.Concrete
{
    public class CommandReciever : ICommandReciever
    {
        private MessageDetails _messageDetails;

        public CommandReciever(MessageDetails messageDetails)
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

        private async Task SendMessageAsync(string _message)
        {
            await _messageDetails.Channel.SendMessageAsync(_message);
        }
    }
}
