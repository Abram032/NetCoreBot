using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discord_BotTemplate
{
    public sealed class Settings
    {
        private string directoryPath;
        private string filePath;
        private Dictionary<string, string> settings;
        private Dictionary<string, string> defaultSettings;
        private static Settings instance = null;
        private static readonly object syncRoot = new object();

        private Settings()
        {
            directoryPath = Environment.CurrentDirectory + @"/Settings";
            filePath = Environment.CurrentDirectory + @"/Settings/settings.ini";
            settings = new Dictionary<string, string>();
            defaultSettings = new Dictionary<string, string>();
        }

        public static Settings Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new Settings();
                }
                return instance;
            }
        }

        public async Task LoadSettings()
        {
            SetDefaultKeys(defaultSettings);
            SetDefaultKeys(settings);
            if (File.Exists(filePath))
                await LoadFile();
            else
                await CreateSettings();
            await Task.CompletedTask;
        }

        public string GetValue(string key)
        {
            return settings[key];
        }

        public string GetDefaultValue(string key)
        {
            return defaultSettings[key];
        }

        private async Task CreateSettings()
        {
            Console.WriteLine("Settings file does not exist... Creating.");
            Directory.CreateDirectory(directoryPath);
            await CreateSettingsFile();
            Console.WriteLine("Please exit and go edit settings file so your bot can connect.");
            await Task.CompletedTask;
        }

        private async Task LoadFile()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    if(!line.StartsWith('#') || !line.StartsWith(string.Empty))
                    {
                        string[] pair = SplitLine(line);
                        if(pair.Length > 1)
                            settings[pair[0]] = pair[1];
                    }
                }
            }
            await Task.CompletedTask;
        }

        private string[] SplitLine(string line)
        {
            line = line.Trim();
            line = line.Replace(" ", string.Empty);
            string[] pair = line.Split(':');
            return pair;
        }

        private void SetDefaultKeys(Dictionary<string,string> settings)
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
                await sw.WriteLineAsync("# Put your token here so your bot can connect.");
                await sw.WriteLineAsync("# You can get your app token from here https://discordapp.com/developers/applications/me");
                await sw.WriteLineAsync("# Example: Token: 123456789xyzabc");
                await sw.WriteLineAsync("Token: " + GetDefaultValue("Token"));
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Your owner ID, gives you privileges to use owner only commands from chat.");
                await sw.WriteLineAsync("# To get your ID, right click on yourself in the chat and Copy ID.");
                await sw.WriteLineAsync("# Example: 1234567890");
                await sw.WriteLineAsync("OwnerID: " + GetDefaultValue("OwnerID"));
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Saves all incomming messages to a file.");
                await sw.WriteLineAsync("# <true, false>, Default: false");
                await sw.WriteLineAsync("SaveMessages: " + GetDefaultValue("SaveMessages"));
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Saves all incomming console logs to a file.");
                await sw.WriteLineAsync("# <true, false>, Default: false");
                await sw.WriteLineAsync("SaveLogs: " + GetDefaultValue("SaveLogs"));
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Command prefix for all your bot commands.");
                await sw.WriteLineAsync("# Can be any you like for example: '!', '*', ';' etc.");
                await sw.WriteLineAsync("# It can also be a string of characters like: \"!t\", \"!test\" etc.");
                await sw.WriteLineAsync("# Default: !t");
                await sw.WriteLineAsync("CommandPrefix: " + GetDefaultValue("CommandPrefix"));
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Deletes messages that bot sends after a while.");
                await sw.WriteLineAsync("# <true, false>, Default: false");
                await sw.WriteLineAsync("DeleteMessages: " + GetDefaultValue("DeleteMessages"));
                await sw.WriteLineAsync();
                await sw.WriteLineAsync("# Deletes messages that are command calls after a while.");
                await sw.WriteLineAsync("# <true, false>, Default: false");
                await sw.WriteLineAsync("DeleteCommandMessages: " + GetDefaultValue("DeleteCommandMessages"));
            }
            await Task.CompletedTask;
        }
    }
}
