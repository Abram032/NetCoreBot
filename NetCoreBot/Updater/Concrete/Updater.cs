using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Updater.Concrete
{
    class Updater
    {
        private readonly string dirDeploy = Environment.CurrentDirectory + @"/Deploy/";
        private readonly string dirBackup = Environment.CurrentDirectory + @"/Backup/";
        private readonly string dirMain = Environment.CurrentDirectory + @"/";

        public async Task UpdateFiles()
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
            Console.WriteLine("Update complete. Please restart application.");
            Console.ReadKey();
            Environment.Exit(0);
            await Task.CompletedTask;
        }
    }
}
