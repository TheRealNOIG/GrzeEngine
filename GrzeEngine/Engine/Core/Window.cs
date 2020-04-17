using GrzeEngine.Engine.Logging;
using GrzeEngine.Engine.Utils;
using OpenGL;
using SDL2;
using System.Runtime.InteropServices;

namespace GrzeEngine.Engine.Core
{
    public abstract class Window
    {
        protected int width, height;
        protected Clock clock;

        public Window(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public virtual void Initialize(int width, int height)
        {
            //Setup opengl and window
            OpenGL.Platform.Window.CreateWindow("OpenGL", this.width, this.height, false);
            Gl.Enable(EnableCap.DepthTest);
            Gl.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            //Setup InputHandling
            for (int i = 8; i < 223; i++)
                OpenGL.Platform.Input.Subscribe((char)i, new OpenGL.Platform.Event(HandleInput));
            OpenGL.Platform.Input.Subscribe((char)27, OnExit);

            clock = new Clock();

            //setup logging system
            Log.CreateLoggers();
        }

        public virtual void StartLoop()
        {
            while (OpenGL.Platform.Window.Open)
            {
                OpenGL.Platform.Window.HandleEvents();

                OnUpdate();
                OnRender();
            }
        }

        public abstract void CleanUp();

        public abstract void OnUpdate();

        public virtual void HandleInput(char c, bool state)
        {
            Log.Message(((int)c).ToString() + " " + state.ToString());
            KeyboardManager.HandleInput(c, state);
        }

        public virtual void OnRender()
        {
            //SetupGL and Clear screen
            Gl.Viewport(0, 0, this.width, this.height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public virtual void SwapBuffers()
        {
            OpenGL.Platform.Window.SwapBuffers();
        }

        public virtual void OnExit()
        {
            CleanUp();
            OpenGL.Platform.Window.OnClose();
        }

       
    }
}
