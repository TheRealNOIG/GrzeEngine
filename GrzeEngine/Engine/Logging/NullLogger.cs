

namespace GrzeEngine.Engine.Logging
{
    class NullLogger : Logger
    {
        public NullLogger(LogLevel mask) : base(mask)
        {
        }

        protected override void WriteMessage(string msg)
        {
            //NULLLOGGER useg for Singleton logger
        }
    }
}
