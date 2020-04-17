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

            clock = new Clock();

            //setup logging system
            Log.CreateLoggers();
        }

        public virtual void StartLoop()
        {
            while (OpenGL.Platform.Window.Open)
            {
                HandleEvents();

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

        #region Event Handling
        private SDL.SDL_Event sdlEvent;
        private byte[] mouseState = new byte[256];

        private void HandleEvents()
        {
            while (SDL.SDL_PollEvent(out sdlEvent) != 0 && OpenGL.Platform.Window.window != System.IntPtr.Zero)
            {
                switch (sdlEvent.type)
                {
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        KeyboardManager.HandleInput((char)sdlEvent.key.keysym.sym, true);
                        break;
                    case SDL.SDL_EventType.SDL_KEYUP:
                        KeyboardManager.HandleInput((char)sdlEvent.key.keysym.sym, false);
                        break;
                    case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                    case SDL.SDL_EventType.SDL_MOUSEBUTTONUP:
                        // keep track of mouse state internally due to a bug in SDL
                        // https://bugzilla.libsdl.org/show_bug.cgi?id=2195
                        if (mouseState[sdlEvent.button.button] == sdlEvent.button.state) break;
                        mouseState[sdlEvent.button.button] = sdlEvent.button.state;
                        if (sdlEvent.button.y == 0 || sdlEvent.button.x == 0) mouseState[sdlEvent.button.button] = 0;

                        OpenGL.Platform.Window.OnMouse(sdlEvent.button.button, sdlEvent.button.state, sdlEvent.button.x, sdlEvent.button.y);
                        break;
                    case SDL.SDL_EventType.SDL_MOUSEMOTION:
                        OpenGL.Platform.Window.OnMovePassive(sdlEvent.motion.x, sdlEvent.motion.y);
                        break;
                    case SDL.SDL_EventType.SDL_MOUSEWHEEL:
                        OpenGL.Platform.Window.OnMouseWheel?.Invoke(sdlEvent.wheel.which, sdlEvent.wheel.y, 0, 0);
                        break;
                    case SDL.SDL_EventType.SDL_WINDOWEVENT:
                        switch (sdlEvent.window.windowEvent)
                        {
                            case SDL.SDL_WindowEventID.SDL_WINDOWEVENT_RESIZED:
                                OpenGL.Platform.Window.OnReshape(sdlEvent.window.data1, sdlEvent.window.data2);
                                break;
                            case SDL.SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE:
                                OpenGL.Platform.Window.OnClose();
                                break;
                            case SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MINIMIZED:
                                // stop rendering the scene
                                break;
                            case SDL.SDL_WindowEventID.SDL_WINDOWEVENT_RESTORED:
                            case SDL.SDL_WindowEventID.SDL_WINDOWEVENT_EXPOSED:
                                // stop rendering the scene
                                break;
                        }
                        break;
                }
            }
        }
        #endregion
    }
}
