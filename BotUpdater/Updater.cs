using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace BotUpdater
{
    class Updater
    {
        private static string dirDeploy = Environment.CurrentDirectory + @"/Update/Deploy/";
        private static string dirUpdate = Environment.CurrentDirectory + @"/Update/";
        private static string dirBackup = Environment.CurrentDirectory + @"/Backup/";
        private static string dirMain = Environment.CurrentDirectory + @"/";

        public static async Task UpdateFiles()
        {
            string[] files = Directory.GetFiles(dirDeploy, "*.*", SearchOption.AllDirectories);
            Directory.CreateDirectory(Environment.CurrentDirectory + @"/Backup");
            foreach(string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if(File.Exists(dirMain + fileInfo.Name))
                    File.Replace(dirDeploy + fileInfo.Name, dirMain + fileInfo.Name, dirBackup + fileInfo.Name);
                else
                    File.Move(dirDeploy + fileInfo.Name, dirMain + fileInfo.Name);
                //fileInfo.Replace(Environment.CurrentDirectory, Environment.CurrentDirectory + @"/Backup", true);
            }
            await RemoveBackup();
            await Task.CompletedTask;
        }

        private static async Task RemoveBackup()
        {
            string[] filesDeploy = Directory.GetFiles(dirDeploy, "*.*", SearchOption.AllDirectories);
            string[] filesBackup = Directory.GetFiles(dirBackup, "*.*", SearchOption.AllDirectories);

            foreach(string file in filesDeploy)
                File.Delete(file);
            foreach(string file in filesBackup)
                File.Delete(file);

            Directory.Delete(Environment.CurrentDirectory + @"/Update/Deploy");
            Directory.Delete(Environment.CurrentDirectory + @"/Update");
            Directory.Delete(Environment.CurrentDirectory + @"/Backup");
            await Task.CompletedTask;
        }
    }
}
