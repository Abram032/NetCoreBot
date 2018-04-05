using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DiscordTestBot
{
    public class LogHandler
    {
        private string enviroPath;
        private string msgFilePath;
        private string logFilePath;
        
        public LogHandler()
        {
            enviroPath = Environment.CurrentDirectory;
            msgFilePath = Environment.CurrentDirectory + @"/Logs/Messages/" + DateTime.Today.ToShortDateString() + @".log";
            logFilePath = Environment.CurrentDirectory + @"/Logs/Bot/" + DateTime.Today.ToShortDateString() + @".log";
        }

        public async Task Handle(object obj, bool SaveLogs = true, bool SaveMessages = true)
        {
            if(!File.Exists(msgFilePath) || !File.Exists(logFilePath))
                CreateDirectories();
            if (obj is SocketMessage && SaveMessages)
                await LogMessage((SocketMessage)obj);
            if (obj is LogMessage && SaveLogs)
                await LogMessage((LogMessage)obj);
            await Task.CompletedTask;
        }

        private async Task LogMessage(SocketMessage message)
        {
            DateTime dateTime = DateTime.Now;
            string _message = dateTime.ToLongTimeString();
            _message += " { " + message.Channel + " } ( " + message.Author + " ) : " + message.Content;
            //Console.WriteLine(_message);
            using (StreamWriter sw = new StreamWriter(msgFilePath, true))
                await sw.WriteLineAsync(_message);
            await Task.CompletedTask;
        }

        private async Task LogMessage(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
                await sw.WriteLineAsync(message.ToString());
            await Task.CompletedTask;
        }

        private void CreateDirectories()
        {
            Directory.CreateDirectory(enviroPath + @"/Logs");
            Directory.CreateDirectory(enviroPath + @"/Logs/Messages");
            Directory.CreateDirectory(enviroPath + @"/Logs/Bot");
        }
    }
}
