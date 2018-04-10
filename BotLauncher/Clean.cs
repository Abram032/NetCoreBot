using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace BotLauncher
{
    class Clean
    {
        private static string dirDeploy = Environment.CurrentDirectory + @"/Update/Deploy/";
        private static string dirUpdate = Environment.CurrentDirectory + @"/Update/";
        private static string dirBackup = Environment.CurrentDirectory + @"/Backup/";
        private static string dirMain = Environment.CurrentDirectory + @"/";

        public static async Task CleanUp()
        {
            string[] filesDeploy = null;
            string[] filesBackup = null;
            if(Directory.Exists(dirDeploy))
                filesDeploy = Directory.GetFiles(dirDeploy, "*.*", SearchOption.AllDirectories);
            if(Directory.Exists(dirBackup))
                filesBackup = Directory.GetFiles(dirBackup, "*.*", SearchOption.AllDirectories);

            if(filesDeploy != null)
                foreach(string file in filesDeploy)
                    File.Delete(file);
            if(filesBackup != null)
                foreach(string file in filesBackup)
                    File.Delete(file);
            if(Directory.Exists(dirDeploy))
                Directory.Delete(Environment.CurrentDirectory + @"/Update/Deploy");
            if(Directory.Exists(dirUpdate))
                Directory.Delete(Environment.CurrentDirectory + @"/Update");
            if(Directory.Exists(dirBackup))
                Directory.Delete(Environment.CurrentDirectory + @"/Backup");
            await Task.CompletedTask;
        }
    }
}
