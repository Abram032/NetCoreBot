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

        public MessageWriter(object messageDetails = null)
        {
            _messageDetails = messageDetails as MessageDetails;
        }

        public async Task ReturnStatus(string message)
        {
            if(IsCLI())
                Console.WriteLine(message);
            else
                SendMessageAsync(message).Wait();
            await Task.CompletedTask;
        }

        private async Task SendMessageAsync(string message)
        {
            string _message = _messageDetails.Author.Mention + " " + message;
            await _messageDetails.Channel.SendMessageAsync(_message);
        }

        private bool IsCLI()
        {
            if(_messageDetails == null)
                return true;
            else
                return false;
        }
    }
}
