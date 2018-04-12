using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Common.Interfaces
{
    public interface IConnect
    {
        Task ClientConnect(string token);
    }
}
