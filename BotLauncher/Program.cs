using System;
using System.Threading.Tasks;

namespace BotLauncher
{
    class Program
    {
        public static void StartUp() => new Launch().Main();
        static Task launch = new Task(StartUp);

        static void Main(string[] args)
        {
           launch.Start();
           launch.Wait();
        }
    }
}
