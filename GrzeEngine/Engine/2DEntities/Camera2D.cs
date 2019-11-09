using GrzeEngine.Engine.Utils;
using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrzeEngine.Engine._2DEntities
{
    public class Camera2D
    {
        public Vector2 position = Vector2.Zero;
        public float roll, scale, speed = 0.05f;

        public Camera2D()
        {
            this.position = Vector2.Zero;
        }

        public void Update(float delta)
        {
            float deltaSpeed = speed * delta;

            if (KeyboardManager.IsKeyDown('w'))
                IncreasePosition(0, -deltaSpeed);
            if (KeyboardManager.IsKeyDown('s'))
                IncreasePosition(0, deltaSpeed);
            if (KeyboardManager.IsKeyDown('d'))
                IncreasePosition(-deltaSpeed, 0);
            if (KeyboardManager.IsKeyDown('a'))
                IncreasePosition(deltaSpeed, 0);
        }

        public void IncreasePosition(float x, float y)
        {
            this.position.X += x;
            this.position.Y += y;
        }
    }
}
