using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Interfaces
{
    public interface ILoggerFactory
    {
        ILogger Create<T>() where T : class;
    }
}
