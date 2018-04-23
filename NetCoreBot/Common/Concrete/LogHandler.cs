using Discord;
using Discord.WebSocket;
using NetCoreBot.Common.Abstract;
using NetCoreBot.Repository.Abstract;
using NetCoreBot.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Common.Concrete
{
    class LogHandler : ILogHandler
    {
        private ISettings _settings;
        private IConverter converter;
        private string enviroPath = Environment.CurrentDirectory;
        private string logFilePath = Environment.CurrentDirectory 
            + @"/Logs/" + DateTime.Today.ToShortDateString() + @".log";

        public LogHandler(ISettings settings)
        {
            _settings = settings;
            converter = new Converter();
        }

        public async Task Handle(object log)
        {
            var _log = (LogMessage)log;
            if (converter.StringToBool(SettingKeys.SaveLogs))
            {
                if(!File.Exists(logFilePath))
                    CreateLogsDirectories();
                await LogMessage(_log);
            }
            await ConsoleLogOutput(_log);
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
        }
    }
}
