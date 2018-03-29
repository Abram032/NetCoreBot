using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot
{
    public class Settings
    {
        //TODO: Figrure out how to store settings and information secure
        private string token;
        private string admin;

        //TODO: Implement loading settings from file.
        public async Task LoadSettings()
        {
            await Task.CompletedTask;
        }
    }
}
