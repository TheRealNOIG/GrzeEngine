using System;

namespace GrzeEngine.Engine.Logging
{
    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(LogLevel mask) : base(mask)
        {
        }

        protected override void WriteMessage<T>(T msg)
        {
            Console.WriteLine(msg.ToString());
        }
    }
}
