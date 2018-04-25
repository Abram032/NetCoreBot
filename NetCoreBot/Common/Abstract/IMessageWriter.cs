using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Common.Abstract
{
    public interface IMessageWriter
    {
        Task ReturnStatus(string message, bool isCli = false);
    }
}
