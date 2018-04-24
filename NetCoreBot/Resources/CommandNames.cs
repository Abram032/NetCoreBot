using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Resources
{
    public static class CommandNames
    {
        public static readonly List<string> commands = InitList();
        public const string random = "random";
        public const string stop = "stop";
        public const string help = "help";
        public const string restart = "restart";

        private static List<string> InitList()
        {
            List<string> commands = new List<string>();
            commands.Add(random);
            commands.Add(stop);
            commands.Add(help);
            commands.Add(restart);
            commands.Sort();
            return commands;
        }
    }
}
