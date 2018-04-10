using System;
using System.Collections.Generic;
using System.Text;
using Discord_BotTemplate;
using Xunit;
using static Discord_BotTemplate.Settings;

namespace Discord_BotTests
{
    public class Settings_Test
    {
        [Fact]
        public void Test()
        {
            Assert.Same(Settings.Instance, GetInstance());
        }

        private Settings GetInstance()
        {
            return Settings.Instance;
        }
    }
}
