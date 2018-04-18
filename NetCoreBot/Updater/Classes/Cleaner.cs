using NetCoreBot.Updater.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Loader;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreBot.Updater.Classes
{
    class Cleaner : ICleaner
    {
        string UpdateDirPath { get; set; }
        string BackupDirPath { get; set; }

        public Cleaner()
        {
            UpdateDirPath = Environment.CurrentDirectory + @"/Deploy/";
            BackupDirPath = Environment.CurrentDirectory + @"/Backup/";
        }

        public async Task CleanUp()
        {
            string[] filesDeploy = GetFiles(UpdateDirPath);
            string[] filesBackup = GetFiles(BackupDirPath);
            DeleteFiles(filesDeploy);
            DeleteFiles(filesBackup);
            DeleteDirectory(UpdateDirPath);
            DeleteDirectory(BackupDirPath);
            await Task.CompletedTask;
        }

        private string[] GetFiles(string path)
        {
            if(Directory.Exists(path))
                return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            else
                return null;
        }

        private void DeleteFiles(string[] files)
        {
            if(files != null)
                foreach(string file in files)
                    File.Delete(file);
        }

        private void DeleteDirectory(string path)
        {
            if(Directory.Exists(path))
                Directory.Delete(path);
        }
    }
}
