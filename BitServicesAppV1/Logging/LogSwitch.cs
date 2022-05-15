using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServicesDesktopApp.Logging
{
    public enum LogType
    {
        File, Database, EventLog
    }
    public static class LogSwitch
        {
            /* When the class is a static class to use the methods of that class you will not need an object
             * LogHelper.<MethodName>();
             * static class will accept static methods and data members only
             * 
             */
          
            // is an intangible concept that's why we defined it as abstract
            private static LogBase logger = null;
            public static void Log(LogType target, string message)
            {
                switch (target)
                {
                    case LogType.File:
                        logger = new FileLogger();
                        logger.Log(message);
                        break;
                    case LogType.Database:
                        logger = new DBLogger();
                        logger.Log(message);
                        break;
                    case LogType.EventLog:
                        logger = new EventLogger();
                        logger.Log(message);
                        break;
                }
            }
        }
    }

