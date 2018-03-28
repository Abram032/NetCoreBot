using System;
using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//TODO: Create and use only single instance of MessageHandler, Logger and CommandHandler.
//TODO: Settings file and loading settings.

namespace DiscordTestBot
{
    class TestBot
    {

        MessageHandler mh;
        Logger logger;

        public async Task MainAsync()
        {
            var client = InitClient();
            logger = new Logger();
            await Connect(client);
            mh = new MessageHandler();
            await mh.HandleMessages(client);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage message)
        {
            await logger.LogHandler(message);
            await Task.CompletedTask;
        }

        private async Task Connect(DiscordSocketClient client)
        {    
            client.Log += Log;
            const string token = "MzIzNTUzNzY2MTIyOTc5MzMx.DZzUGA.ksQcoQr--binBYn-Y09_ZpsVjdQ";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
        }

        private DiscordSocketClient InitClient()
        {
            return new DiscordSocketClient( new DiscordSocketConfig { LogLevel = LogSeverity.Info } );
        }
    }
}
