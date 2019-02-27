using GrzeEngine.Engine.Entities;
using GrzeEngine.Engine.Logging;
using GrzeEngine.Engine.Render;
using GrzeEngine.Engine.Utils;
using OpenGL;

namespace GrzeEngine.Engine.Core
{
    class Window
    {
        public static int WIDTH = 1280, HEIGHT = 720;

        private EntityRenderer entityRenderer;
        private Camera camera;

        public Window()
        {

            OpenGL.Platform.Window.CreateWindow("OpenGL", WIDTH, HEIGHT, false);

            Initialize();

            while (OpenGL.Platform.Window.Open)
            {
                OpenGL.Platform.Window.HandleEvents();
                OpenGL.Platform.Input.Subscribe((char)27, OpenGL.Platform.Window.OnClose);
                OpenGL.Platform.Input.SubscribeAll(new OpenGL.Platform.Event(HandleInput));

                OnUpdate();
                OnRender(); 
            }

            CleanUp();
        }

        void Initialize()
        {
            //Setup renderer
            camera = new Camera();
            entityRenderer = new EntityRenderer(WIDTH, HEIGHT, camera);

            //Create a cube
            //entityRenderer.AddEntity((Geometry.CreateCube(entityRenderer.shader, new Vector3(-1, -1, -1), new Vector3(1, 1, 1));
            entityRenderer.AddEntity(new Entity(
                Geometry.CreateCube(entityRenderer.shader, new Vector3(-1, -1, -1), new Vector3(1, 1, 1)), Vector3.Zero, Vector3.Zero));
        }

        void CleanUp()
        {
            entityRenderer.Cleanup();
        }

        void OnUpdate()
        {
            camera.Update();
        }

        void HandleInput(char c, bool state)
        {
            MasterLogger.Message(c.ToString() + " " + state.ToString());
            KeyboardManager.HandleInput(c, state);
        }

        void OnRender()
        {
            //SetupGL and Clear screen
            Gl.Viewport(0, 0, WIDTH, HEIGHT);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Gl.Enable(EnableCap.DepthTest);

            //Rendercode
            entityRenderer.Render();

            OpenGL.Platform.Window.SwapBuffers();
        }
    }
}
