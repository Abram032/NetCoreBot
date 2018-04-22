using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Common.Abstract
{
    public interface IConnectionManager
    {
        Task ClientConnect();
        object GetClient();
    }
}
