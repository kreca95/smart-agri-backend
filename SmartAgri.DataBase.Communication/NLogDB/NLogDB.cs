using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAgri.DataBase.Communication.NLogDb
{
    public class NLogDB
    {
        private readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private const string error = "Error.txt";
        private const string info = "Info.txt";
        private const string path = "C:/SmartAgriLogs/DB/";
        public NLogDB()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = path + info };
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = path + info };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            var errorfile = new NLog.Targets.FileTarget("errorlogfile") { FileName = path + error };

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            config.AddRule(LogLevel.Error, LogLevel.Fatal, errorfile);
            // Apply config           
            NLog.LogManager.Configuration = config;
        }

        public NLog.Logger GetLogger()
        {
            if (Logger != null)
                return Logger;

            return NLog.LogManager.GetCurrentClassLogger();
        }

    }
}
