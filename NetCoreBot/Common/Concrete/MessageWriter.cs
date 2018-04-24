using NetCoreBot.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Common.Concrete
{
    public class MessageWriter : IMessageWriter
    {
        private MessageDetails _messageDetails;

        public MessageWriter(object messageDetails)
        {
            _messageDetails = messageDetails as MessageDetails;
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
