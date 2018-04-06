using System;
using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discord_BotTemplate
{
    class TestBot
    {
        //TODO: Should I create and use only single instance of MessageHandler, Logger and CommandHandler?
        //TODO: Make constructors for each class in the project.
        MessageHandler msgHandler;
        LogHandler logger;
        Settings settings;
        
        Converter converter;
        ExceptionManager EM;

        public async Task MainAsync()
        {
            EM = new ExceptionManager();
            converter = new Converter();
            settings = new Settings();
            logger = new LogHandler();
            msgHandler = new MessageHandler();
            //await settings.LoadSettings();
            var client = InitClient();
            await Connect(client);
            await msgHandler.Handler(client);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage message)
        {
            await logger.Handle(message, 
                converter.StrToBoolT(settings.GetValue("SaveLogs")), 
                converter.StrToBoolT(settings.GetValue("SaveMessages")));
            //await logger.Handle(message);
            await Task.CompletedTask;
        }

        private async Task Connect(DiscordSocketClient client)
        {
            client.Log += Log;
            if (settings.GetValue("Token") != string.Empty &&
                EM.CheckToken(client, settings.GetValue("Token")))
            {
                await client.LoginAsync(TokenType.Bot, settings.GetValue("Token"));
                await client.StartAsync();
            }
            await Task.CompletedTask;
        }

        private DiscordSocketClient InitClient()
        {
            return new DiscordSocketClient(new DiscordSocketConfig { LogLevel = LogSeverity.Verbose });
        }
    }
}
