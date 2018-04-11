using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace BotUpdater
{
    class Updater
    {
        private static string dirDeploy = Environment.CurrentDirectory + @"/Deploy/";
        //private static string dirUpdate = Environment.CurrentDirectory + @"/Update/";
        private static string dirBackup = Environment.CurrentDirectory + @"/Backup/";
        private static string dirMain = Environment.CurrentDirectory + @"/";

        public static async Task UpdateFiles()
        {
            Console.WriteLine("Updating...");
            string[] files = Directory.GetFiles(dirDeploy, "*.*", SearchOption.AllDirectories);
            Directory.CreateDirectory(Environment.CurrentDirectory + @"/Backup");
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!fileInfo.Name.Contains("Launch"))
                {
                    if (File.Exists(dirMain + fileInfo.Name))
                        File.Replace(dirDeploy + fileInfo.Name, dirMain + fileInfo.Name, dirBackup + fileInfo.Name);
                    else
                        File.Move(dirDeploy + fileInfo.Name, dirMain + fileInfo.Name);
                }
            }
            Console.WriteLine("Update complete.");
            await Task.CompletedTask;
        }
    }
}
