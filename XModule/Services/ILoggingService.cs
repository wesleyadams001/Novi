using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Services
{
    /// <summary>
    /// an ILoggingService interface, so as to decouple consumers from the actual logging framework
    /// </summary>
    public interface ILoggingService
    {
        void Log(string msg);
        void Log(string msgType, string msg);
        void Log(int loggerIds, string msg);
        void Log(int loggerIds, string msgType, string msg);
        void InitLogSession();
        void EndLogSession();
        int getLoggerId();
    }
}
