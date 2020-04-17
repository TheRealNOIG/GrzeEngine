
namespace GrzeEngine.Engine.Logging
{
    public enum LogLevel
    {
        NONE = 0,
        INFO = 1,
        DEBUG = 2,
        WARNING = 4,
        ERROR = 8,
        ALL = 15
    }

    public abstract class Logger
    {
        protected LogLevel levelMask;
        protected Logger nextLogger;

        public Logger(LogLevel mask)
        {
            this.levelMask = mask;
        }

        public Logger setNext(Logger nextLoggerInChain)
        {
            this.nextLogger = nextLoggerInChain;
            return this.nextLogger;
        }

        public void Message<T>(T msg, LogLevel level)
        {
            if ((level & this.levelMask) != 0)
            {
                this.WriteMessage(msg);
            }
            if (nextLogger != null)
            {
                nextLogger.Message(msg, level);
            }
        }

        abstract protected void WriteMessage<T>(T msg);
    }
}
