using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

//TODO: Allow for admin-only commands in console.

namespace Discord_BotTemplate
{
    public class CLI
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
