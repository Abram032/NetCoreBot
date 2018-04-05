using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

//TODO: Allow for admin-only commands in console.

namespace DiscordTestBot
{
    class CLI
    {
        public void Main()
        {
            while(true)
            {
                string command = Console.ReadLine();
                Console.WriteLine(command);
            }
        }
    }
}
