using System;
using System.Collections.Generic;
using System.Text;
using NetCoreBot.Repository.Interfaces;
using System.Threading.Tasks;
using System.IO;

namespace NetCoreBot.Repository.Classes
{
    class Settings : ISettings
    {
        private Dictionary<string, string> settings;
        private Dictionary<string, string> defaultSettings;
        private string filePath = Environment.CurrentDirectory + @"/Settings/config.ini";
        private string directoryPath = Environment.CurrentDirectory + @"/Settings";

        public Settings()
        {
            settings = new Dictionary<string, string>();
            defaultSettings = new Dictionary<string, string>();
            if (!File.Exists(filePath))
                CreateSettings().Wait();
            InitSettings(defaultSettings);
            InitSettings(settings);
        }

        private async Task CreateSettings()
        {
            Console.WriteLine("Config file not found, creating...");
            CreateDirectory();
            await CreateSettingsFile();
            Console.WriteLine("Please exit and edit config file so your bot can connect.");
            await Task.CompletedTask;
        }

        public async Task LoadSettings()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    if (!line.StartsWith('#') || !line.StartsWith(string.Empty))
                    {
                        string key = SplitKeyAndValue(line, 0);
                        string value = SplitKeyAndValue(line, 1);
                        settings[key] = value;
                    }
                }
            }
            await Task.CompletedTask;
        }

        public string GetValue(string key, bool defaultSetting = false)
        {
            if (defaultSetting)
                return defaultSettings[key];
            else
                return settings[key];
        }

        public async Task SaveSettings()
        {
            throw new NotImplementedException();
        }

        private void CreateDirectory()
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }

        private string SplitKeyAndValue(string line, int index)
        {
            line = line.Trim();
            line = line.Replace(" ", string.Empty);
            string[] pairs = line.Split(':');
            if(pairs.Length > index)
                return pairs[index];
            else
                return string.Empty;
        }

        private void InitSettings(Dictionary<string, string> settings)
        {
            settings.Add("Token", string.Empty);
            settings.Add("OwnerID", string.Empty);
            settings.Add("SaveMessages", "false");
            settings.Add("SaveLogs", "false");
            settings.Add("CommandPrefix", "!t");
            settings.Add("DeleteMessages", "false");
            settings.Add("DeleteCommandMessages", "false");
        }

        private async Task CreateSettingsFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                await sw.WriteLineAsync("# I highly suggest editing this file using other programs than notepad, line notepad++ or sublime.");
                await sw.WriteLineAsync("# Those programs color the syntax so it's easier for you to read the file.");
                await sw.WriteLineAsync("# Put your token here so your bot can connect.");
                await sw.WriteLineAsync("# You can get your app token from here https://discordapp.com/developers/applications/me");
                await sw.WriteLineAsync("# Example: Token: 123456789xyzabc");
                await sw.WriteLineAsync("Token: ");
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Your owner ID, gives you privileges to use owner only commands from chat.");
                await sw.WriteLineAsync("# To get your ID, right click on yourself in the chat and Copy ID.");
                await sw.WriteLineAsync("# Example: 1234567890");
                await sw.WriteLineAsync("OwnerID: ");
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Saves all incomming messages to a file.");
                await sw.WriteLineAsync("# <true, false>, Default: false");
                await sw.WriteLineAsync("SaveMessages: false");
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Saves all incomming console logs to a file.");
                await sw.WriteLineAsync("# <true, false>, Default: false");
                await sw.WriteLineAsync("SaveLogs: false");
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Command prefix for all your bot commands.");
                await sw.WriteLineAsync("# Can be any you like for example: '!', '*', ';' etc.");
                await sw.WriteLineAsync("# It can also be a string of characters like: \"!t\", \"!test\" etc.");
                await sw.WriteLineAsync("# Default: !t");
                await sw.WriteLineAsync("CommandPrefix: !t");
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Deletes messages that bot sends after a while.");
                await sw.WriteLineAsync("# <true, false>, Default: false");
                await sw.WriteLineAsync("DeleteMessages: false");
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Deletes messages that are command calls after a while.");
                await sw.WriteLineAsync("# <true, false>, Default: false");
                await sw.WriteLineAsync("DeleteCommandMessages: false");
            }
            await Task.CompletedTask;
        }
    }
}
