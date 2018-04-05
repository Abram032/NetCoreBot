using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot
{
    public class Settings
    {
        //TODO: Figrure out how to store settings and information secure
        private string enviroPath;
        private string filePath;
        public Dictionary<string, string> dict;

        public Settings()
        {
            enviroPath = Environment.CurrentDirectory;
            filePath = Environment.CurrentDirectory + @"/Settings/settings.settings";
            dict = new Dictionary<string, string>();
            DefaultKeys();
        }

        public async Task LoadSettings()
        {
            if (File.Exists(filePath))
                await LoadAll();
            else
                await CreateSettings();
            await Task.CompletedTask;
        }
        
        private async Task CreateSettings()
        {
            Console.WriteLine("Settings file does not exist... Creating.");
            Directory.CreateDirectory(enviroPath + @"/Settings");
            var keys = dict.Keys;
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach(string key in keys)
                    await sw.WriteLineAsync(key + ": " + dict[key]);
            }
            Console.WriteLine("Please exit and go edit settings file so your bot can connect.");
            await Task.CompletedTask;
        }
        
        private async Task LoadAll()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while(sr.Peek() >= 0) 
                {
                    string line = sr.ReadLine();
                    string[] pair = SplitLine(line);
                    dict[pair[0]] = pair[1];
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
        
        private void DefaultKeys()
        {
            dict.Add("Token", string.Empty);
            dict.Add("AdminID", string.Empty);
            dict.Add("SaveMessages", "true");
            dict.Add("SaveLogs", "true");
        }
    }
}
