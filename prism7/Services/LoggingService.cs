using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Services;
using XModule.Interfaces;

namespace AclProcessor.Services
{
    public class Logger : XModule.Interfaces.ILogger
    {
        private readonly NLog.Logger _logger;
        public Logger(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            _logger = LogManager.GetCurrentClassLogger();
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var debuglogfile = new NLog.Targets.FileTarget("debuglog") { FileName = "DebugLog.txt" };
            var fatallogfile = new NLog.Targets.FileTarget("fatallog") { FileName = "FatalLog.txt" };

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, fatallogfile);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, debuglogfile);
            
            // Apply config           
            NLog.LogManager.Configuration = config;
        }

        public string Name
        {
            get { return _logger.Name; }
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }
    }
}
