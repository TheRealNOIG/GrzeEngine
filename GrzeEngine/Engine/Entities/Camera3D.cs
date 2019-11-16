using System;
using GrzeEngine.Engine.Shaders;
using GrzeEngine.Engine.Utils;
using OpenGL;

namespace GrzeEngine.Engine.Entities
{
    public class Camera3D : Camera
    {
        public  Vector3 position = Vector3.Zero;
        public float pitch, yaw, roll, scale;
        readonly float speed = 0.05f;

        public Camera3D() {
            position = new Vector3(2, 2, -10);
        }

        public override void Update(float delta)
        {
            float deltaSpeed = speed * delta;
            var dx = (float) (deltaSpeed * Math.Cos(Maths.toRadinas(yaw)));
            var dz = (float) (deltaSpeed * Math.Sin(Maths.toRadinas(yaw)));
            var rdx = (float) (deltaSpeed * Math.Cos(Maths.toRadinas(yaw + 90)));
            var rdz = (float) (deltaSpeed * Math.Sin(Maths.toRadinas(yaw + 90)));
            
            if (KeyboardManager.IsKeyDown('w'))
                IncreasePosition(rdx, rdz);
            if (KeyboardManager.IsKeyDown('s'))
                IncreasePosition(-rdx, -rdz);;
            if (KeyboardManager.IsKeyDown('a'))
                IncreasePosition(dx, dz);
            if (KeyboardManager.IsKeyDown('d'))
                IncreasePosition(-dx, -dz);;
            if (KeyboardManager.IsKeyDown(' '))
                position.Y -= deltaSpeed;
            if (KeyboardManager.IsKeyDown('t'))
                position.Y += deltaSpeed;

            if (KeyboardManager.IsKeyDown('q'))
                yaw -= deltaSpeed;
            if (KeyboardManager.IsKeyDown('e'))
                yaw += deltaSpeed;
        }

        public void IncreasePosition(float x, float z, float y)
        {
            this.position.X += x;
            this.position.Y += y;
            this.position.Z += z;
        }

        public void IncreasePosition(float x, float z)
        {
            this.position.X += x;
            this.position.Z += z;
        }

        public override Matrix4 GetViewMatrix()
        {
            return Maths.CreateViewMatrix(this);
        }
    }
}
