using System;
using GrzeEngine.Engine.Core;
using GrzeEngine.Engine.Logging;

namespace GrzeEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.CreateLoggers();
            Log.Message("Creating OpenGL instance", LogLevel.INFO);
            Window window = new Window();
            Console.ReadKey();
        }
    }
}
