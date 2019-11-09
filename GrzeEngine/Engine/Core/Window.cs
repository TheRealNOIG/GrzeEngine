using System;
using System.Collections.Generic;
using GrzeEngine.Engine._2DEntities;
using GrzeEngine.Engine.Entities;
using GrzeEngine.Engine.Logging;
using GrzeEngine.Engine.Render;
using GrzeEngine.Engine.Utils;
using OpenGL;

namespace GrzeEngine.Engine.Core
{
    internal class Window
    {
        public static int WIDTH = 1280, HEIGHT = 720;

        private MasterRenderer masterRenderer;
        //private Camera camera;
        private Camera2D camera2D;
        private Clock clock;

        public Window()
        {
            Initialize();

            while (OpenGL.Platform.Window.Open)
            {
                OpenGL.Platform.Window.HandleEvents();
                OpenGL.Platform.Input.Subscribe((char)27, OnExit);
                //TODO Add non normal keys
                OpenGL.Platform.Input.SubscribeAll(new OpenGL.Platform.Event(HandleInput));

                OnUpdate();
                OnRender(); 
            }

            CleanUp();
        }

        void Initialize()
        {
            //Setup opengl and window
            OpenGL.Platform.Window.CreateWindow("OpenGL", WIDTH, HEIGHT, false);
            Gl.Enable(EnableCap.DepthTest);
            Gl.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            clock = new Clock();
            
            //Setup renderer
            camera2D = new Camera2D();
            masterRenderer = new MasterRenderer(WIDTH, HEIGHT, camera2D);

            //2D TEST
            masterRenderer.AddSprite(new Sprite(Vector2.Zero, new Vector2(10, 10), Vector2.Zero, masterRenderer.GetSpriteShader()));

            /*OLD 3D code
            Random rnd = new Random();
            VAO box = Geometry.CreateCube( masterRenderer.GetEntityShader(), new Vector3(-1, -1, -1), new Vector3(1, 1, 1));
            
            masterRenderer.AddEntity(new TestBox(box, Vector3.Zero, Vector3.Zero));
            for (int i = 0; i < 1000; i++)
            {
                masterRenderer.AddEntity(new TestBox(box, new Vector3(-rnd.Next(300), -rnd.Next(300), -rnd.Next(300)), Vector3.Zero));
            }
            */

        }

        void CleanUp()
        {
            masterRenderer.Cleanup();
        }

        void OnUpdate()
        {
            var delta = clock.delta();
            
            camera2D.Update(delta);
            masterRenderer.Update(delta);
        }

        void HandleInput(char c, bool state)
        {
            //Log.Message(((int)c).ToString() + " " + state.ToString());
            KeyboardManager.HandleInput(c, state);
        }

        void OnRender()
        {
            //SetupGL and Clear screen
            Gl.Viewport(0, 0, WIDTH, HEIGHT);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Rendercode
            masterRenderer.ProcessEntities();
            masterRenderer.ProcessSprite();
            masterRenderer.Render();

            OpenGL.Platform.Window.SwapBuffers();
        }

        void OnExit()
        {
            //TODO need to close the console when the window exit button is pressed
            OpenGL.Platform.Window.OnClose();
            Environment.Exit(0);
        }
    }
}
