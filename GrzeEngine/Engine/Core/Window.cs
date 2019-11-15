using System;
using System.Collections.Generic;
using GrzeEngine.Engine._2DEntities;
using GrzeEngine.Engine.Entities;
using GrzeEngine.Engine.Logging;
using GrzeEngine.Engine.Render;
using GrzeEngine.Engine.Utils;
using GrzeEngine.Properties;
using OpenGL;

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

            clock = new Clock();
        }

        public virtual void StartLoop()
        {
            while (OpenGL.Platform.Window.Open)
            {
                OpenGL.Platform.Window.HandleEvents();
                OpenGL.Platform.Input.Subscribe((char)27, OnExit);
                //TODO Add non normal keys
                OpenGL.Platform.Input.SubscribeAll(new OpenGL.Platform.Event(HandleInput));

                OnUpdate();
                OnRender();
            }
        }

        public abstract void CleanUp();

        public abstract void OnUpdate();

        public virtual void HandleInput(char c, bool state)
        {
            //Log.Message(((int)c).ToString() + " " + state.ToString());
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
            OpenGL.Platform.Window.OnClose();
        }
    }
}
