using System;
using System.Collections.Generic;
using System.Text;

//TODO: Allow for admin-only commands in console.

namespace NetCoreBot
{
    class Terminal
    {
        public Terminal()
        {

        }

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
