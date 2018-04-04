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
        //TODO: Use dictionaries to save and load information
        public string token;
        public string adminID;
        private string enviroPath = Environment.CurrentDirectory;
        private string filePath = Environment.CurrentDirectory + @"/Settings/settings.settings";
        Dictionary<string, string> settings = new Dictionary<string, string>();

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
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                await sw.WriteLineAsync("token:");
                await sw.WriteLineAsync("adminID:");
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
                    if(line.StartsWith("token:"))
                        GetToken(line);
                    if(line.StartsWith("adminID:"))
                        GetAdmin(line);
                }
            }
            await Task.CompletedTask;
        }

        private void GetToken(string line)
        {
            line = line.Trim();
            line = line.Replace(" ", string.Empty);
            line = line.Remove(0, 6);
            token = line;
        }

        private void GetAdmin(string line)
        {
            line = line.Trim();
            line = line.Replace(" ", string.Empty);
            line = line.Remove(0, 6);
            adminID = line;
        }
    }
}
