using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Common.Abstract
{
    public interface ILogHandler
    {
        Task Handle(object obj);
    }
}
