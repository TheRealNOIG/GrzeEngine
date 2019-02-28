using System;
using GrzeEngine.Engine.Logging;
using GrzeEngine.Engine.Utils;
using OpenGL;

namespace GrzeEngine.Engine.Entities
{
    public class Camera
    {
        public  Vector3 position = Vector3.Zero;
        public float pitch, yaw, roll;
        float speed = 0.05f;

        public Camera() {
            position = new Vector3(2, 2, -10);
        }

        public void Update()
        {
            var dx = (float) (speed * Math.Cos(Maths.toRadinas(yaw)));
            var dz = (float) (speed * Math.Sin(Maths.toRadinas(yaw)));
            var rdx = (float) (speed * Math.Cos(Maths.toRadinas(yaw + 90)));
            var rdz = (float) (speed * Math.Sin(Maths.toRadinas(yaw + 90)));
            
            if (KeyboardManager.IsKeyDown('w'))
                IncreasePosition(rdx, rdz);
            if (KeyboardManager.IsKeyDown('s'))
                IncreasePosition(-rdx, -rdz);;
            if (KeyboardManager.IsKeyDown('a'))
                IncreasePosition(dx, dz);
            if (KeyboardManager.IsKeyDown('d'))
                IncreasePosition(-dx, -dz);;
            if (KeyboardManager.IsKeyDown(' '))
                position.Y -= speed;
            if (KeyboardManager.IsKeyDown('t'))
                position.Y += speed;

            if (KeyboardManager.IsKeyDown('q'))
                yaw -= 1f;
            if (KeyboardManager.IsKeyDown('e'))
                yaw += 1f;
        }

        public void IncreasePosition(float x, float z, float y)
        {
            this.position.x += x;
            this.position.y += y;
            this.position.z += z;
        }

        public void IncreasePosition(float x, float z)
        {
            this.position.x += x;
            this.position.z += z;
        }
    }
}
