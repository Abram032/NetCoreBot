using Discord;
using Discord.WebSocket;
using NetCoreBot.Common.Interfaces;
using NetCoreBot.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Common.Classes
{
    class LogHandler : ILogHandler
    {
        private ISettings _settings;
        private string enviroPath = Environment.CurrentDirectory;
        private string msgFilePath = Environment.CurrentDirectory 
            + @"/Logs/Messages/" + DateTime.Today.ToShortDateString() + @".log";
        private string logFilePath = Environment.CurrentDirectory 
            + @"/Logs/Bot/" + DateTime.Today.ToShortDateString() + @".log";

        public LogHandler(ISettings settings)
        {
            _settings = settings;
        }

        public async Task Handle(object obj)
        {
            if (obj is SocketMessage && ExceptionHandler.StrToBool(SettingKeys.SaveMessages))
            {
                if(!File.Exists(msgFilePath))
                    CreateMessagesDirectory();
                await LogMessage((SocketMessage)obj);
            }       
            if (obj is LogMessage && ExceptionHandler.StrToBool(SettingKeys.SaveLogs))
            {
                if(!File.Exists(logFilePath))
                    CreateLogsDirectories();
                await LogMessage((LogMessage)obj);
            }
            if (obj is LogMessage)
            {
                await ConsoleLogOutput((LogMessage)obj);
            }
            await Task.CompletedTask;
        }

        private async Task LogMessage(SocketMessage message)
        {
            DateTime dateTime = DateTime.Now;
            string _message = dateTime.ToLongTimeString();
            _message += " { " + message.Channel + " } ( " + message.Author + " ) : " + message.Content;
            using (StreamWriter sw = new StreamWriter(msgFilePath, true))
                await sw.WriteLineAsync(_message);
            await Task.CompletedTask;
        }

        private async Task LogMessage(LogMessage message)
        {
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
                await sw.WriteLineAsync(message.ToString());
            await Task.CompletedTask;
        }

        private async Task ConsoleLogOutput(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            await Task.CompletedTask;
        }

        private void CreateLogsDirectories()
        {
            Directory.CreateDirectory(enviroPath + @"/Logs");
            Directory.CreateDirectory(enviroPath + @"/Logs/Bot");
        }

        private void CreateMessagesDirectory()
        {
            Directory.CreateDirectory(enviroPath + @"/Logs");
            Directory.CreateDirectory(enviroPath + @"/Logs/Messages");
        }
    }
}
