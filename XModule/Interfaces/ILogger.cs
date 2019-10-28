using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Interfaces
{
    public interface ILogger
    {
        string Name { get; }
        void Debug(string message);
        void Error(string message);
    }
}
