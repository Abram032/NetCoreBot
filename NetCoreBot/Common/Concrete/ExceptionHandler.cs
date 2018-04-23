using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;
using NetCoreBot.Repository.Concrete;

//TODO: For removal biatch.

namespace NetCoreBot.Common.Concrete
{
    static class ExceptionHandler
    {
        public static bool CheckToken(DiscordSocketClient client, string token)
        {
            try 
            {
                client.LoginAsync(TokenType.Bot, token).Wait();
            }
            catch
            {          
                return false;
            }
            client.LogoutAsync().Wait();
            return true;
        }

        public static bool StrToBool(string key)
        {
            try 
            { 
                Convert.ToBoolean(Settings.Instance.GetValue(key)); 
            }
            catch 
            { 
                return Convert.ToBoolean(Settings.Instance.GetValue(key, true)); 
            }
            return Convert.ToBoolean(Settings.Instance.GetValue(key));
        }
    }
}
