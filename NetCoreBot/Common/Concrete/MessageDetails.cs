using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Common.Concrete
{
    public class MessageDetails
    {
        public MessageSource Source { get; private set; } = 0;
        public ISocketMessageChannel Channel { get; set; } = null;
        public SocketUser Author { get; private set; } = null;

        public MessageDetails(SocketMessage message)
        {
            Source = message.Source;
            Channel = message.Channel;
            Author = message.Author;
        }
    }
}
