using System;
using Xunit;
using Discord_BotTemplate;

namespace Discord_BotTests
{
    public class CLI_Test
    {
        [Fact]
        public void Test()
        {
            Assert.Equal("CLI", CreateInstance());
        }

        string CreateInstance()
        {
            CLI cli = new CLI();
            return cli.GetType().Name;
        }
    }
}
