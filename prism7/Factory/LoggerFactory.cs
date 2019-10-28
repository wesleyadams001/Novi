using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prism7.Services;
using XModule.Interfaces;

namespace prism7.Factory
{
    public class LoggerFactory : ILoggerFactory
    {
        public XModule.Interfaces.ILogger Create<T>() where T : class
        {
            return new Services.Logger(typeof(T));
        }

    }
}
