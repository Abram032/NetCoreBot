using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Discord_BotTemplate
{
    public class LogHandler
    {
        private static string enviroPath = Environment.CurrentDirectory;
        private static string msgFilePath = Environment.CurrentDirectory 
            + @"/Logs/Messages/" + DateTime.Today.ToShortDateString() + @".log";
        private static string logFilePath = Environment.CurrentDirectory 
            + @"/Logs/Bot/" + DateTime.Today.ToShortDateString() + @".log";

        public static async Task Handle(object obj)
        {
            if(!File.Exists(msgFilePath) || !File.Exists(logFilePath))
                CreateDirectories();
            if (obj is SocketMessage && Converter.SettingsStrToBool("SaveMessages"))
                await LogMessage((SocketMessage)obj);
            if (obj is LogMessage && Converter.SettingsStrToBool("SaveLogs"))
                await LogMessage((LogMessage)obj);
            await Task.CompletedTask;
        }

        private static async Task LogMessage(SocketMessage message)
        {
            DateTime dateTime = DateTime.Now;
            string _message = dateTime.ToLongTimeString();
            _message += " { " + message.Channel + " } ( " + message.Author + " ) : " + message.Content;
            using (StreamWriter sw = new StreamWriter(msgFilePath, true))
                await sw.WriteLineAsync(_message);
            await Task.CompletedTask;
        }

        private static async Task LogMessage(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
                await sw.WriteLineAsync(message.ToString());
            await Task.CompletedTask;
        }

        private static void CreateDirectories()
        {
            Directory.CreateDirectory(enviroPath + @"/Logs");
            Directory.CreateDirectory(enviroPath + @"/Logs/Messages");
            Directory.CreateDirectory(enviroPath + @"/Logs/Bot");
        }
    }
}
