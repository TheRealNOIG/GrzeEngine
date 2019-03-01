using System;
using System.Runtime.InteropServices;
using GrzeEngine.Engine.Logging;

namespace GrzeEngine.Engine.Utils
{
    public class Clock
    {
        private DateTime lastFramTime;
        private DateTime lastSecounTime;
        private int framesRendered;
        private int fps;
        
        public Clock()
        {
            lastFramTime = DateTime.Now;
            lastSecounTime = DateTime.Now;
        }

        public float delta()
        {
            float delta = (float)(DateTime.Now - lastFramTime).Ticks / 10000;
            framesRendered++;
            lastFramTime = DateTime.Now;
            
            if ((DateTime.Now - lastSecounTime).TotalSeconds >= 1)
            {
                fps = framesRendered;                     
                framesRendered = 0;            
                lastSecounTime = DateTime.Now;
                Log.Message(fps.ToString());
            }

            return delta;
        }
    }
}