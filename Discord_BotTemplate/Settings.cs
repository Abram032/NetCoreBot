using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//TODO: Default settings file.
//TODO: Add comments to the settings file for easier use.
//TODO: Make StreamReader skip comments "#" in settings file.
//TODO: Add more settings for the bot.

namespace Discord_BotTemplate
{
    public sealed class Settings
    {
        private string enviroPath;
        private string filePath;
        private Dictionary<string, string> settings;
        private Dictionary<string, string> defaultSettings;
        private static Settings instance = null;
        private static readonly object syncRoot = new object();

        private Settings()
        {
            enviroPath = Environment.CurrentDirectory;
            filePath = Environment.CurrentDirectory + @"/Settings/settings.settings";
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
            DefaultKeys(defaultSettings);
            DefaultKeys(settings);
            if (File.Exists(filePath))
                await LoadAll();
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
            Directory.CreateDirectory(enviroPath + @"/Settings");
            var keys = defaultSettings.Keys;
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (string key in keys)
                    await sw.WriteLineAsync(key + ": " + defaultSettings[key]);
            }
            Console.WriteLine("Please exit and go edit settings file so your bot can connect.");
            await Task.CompletedTask;
        }

        private async Task LoadAll()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    string[] pair = SplitLine(line);
                    settings[pair[0]] = pair[1];
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

        private void DefaultKeys(Dictionary<string,string> settings)
        {
            settings.Add("Token", string.Empty);
            settings.Add("AdminID", string.Empty);
            settings.Add("SaveMessages", "false");
            settings.Add("SaveLogs", "false");
        }
    }
}
