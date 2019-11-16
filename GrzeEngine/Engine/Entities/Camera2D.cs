using GrzeEngine.Engine.Shaders;
using GrzeEngine.Engine.Utils;
using OpenGL;

namespace GrzeEngine.Engine.Entities
{
    public class Camera2D : Camera
    {
        public Vector2 position = Vector2.Zero;
        public float roll, scale, speed = 0.05f;

        public Camera2D()
        {
            this.position = Vector2.Zero;
        }

        public override void Update(float delta)
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

        public override Matrix4 GetViewMatrix()
        {
            return Maths.Create2DViewMatrix(this);
        }
    }
}
