using System;
using System.Collections.Generic;
using Xunit;

namespace NetCoreBotTests
{
    public class TestList
    {
        [Fact]
        public void TestEmptyList()
        {
            Assert.Empty(new List<int>());
        }
    }
}
