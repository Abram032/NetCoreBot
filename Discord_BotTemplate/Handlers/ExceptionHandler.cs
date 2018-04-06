using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Discord_BotTemplate
{
    class ExceptionHandler
    {
        public static bool CheckToken(DiscordSocketClient client, string token)
        {
            try 
            {
                client.LoginAsync(TokenType.Bot, token).Wait();
            }
            catch
            {
                Console.WriteLine("Invalid Token!");
                return false;
            }
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
                return Convert.ToBoolean(Settings.Instance.GetDefaultValue(key)); 
            }
            return Convert.ToBoolean(Settings.Instance.GetValue(key));
        }
    }
}
