using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Commands.Abstract
{
    public interface ICommand
    {
        Task Execute();
    }
}
