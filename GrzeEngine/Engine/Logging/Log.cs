namespace GrzeEngine.Engine.Logging
{
    public static class Log
    {
        private static readonly Logger logger = new NullLogger(LogLevel.NONE);

        public static Logger Logger
        {
            get
            {
                return logger;
            }
        }

        public static void Message(string message)
        {
            Logger.Message(message, LogLevel.DEBUG);
        }

        public static void Message(string message, LogLevel logLevel)
        {
            Logger.Message(message, logLevel);
        }

        public static void CreateLoggers()
        {
            /* How to implement new loggers
             * private Logger newLogger;
             * newLogger = *lastImplementedLogger.SetNext(new *LoggerType(LogLevel.First | LogLevel.Secound...));
            */
            Log.Logger.setNext(new ConsoleLogger(LogLevel.ALL));
        }
    }
}
