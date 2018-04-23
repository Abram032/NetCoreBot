using System;
using System.Collections.Generic;
using System.Text;

//TODO: Add help command.
//TODO: Add stop command.
//TODO: Add restart command.

namespace NetCoreBot.Resources
{
    public static class CommandNames
    {
        public static readonly List<string> commands = InitList();
        public const string random = "random";

        private static List<string> InitList()
        {
            List<string> commands = new List<string>();
            commands.Add(random);
            return commands;
        }
    }
}
