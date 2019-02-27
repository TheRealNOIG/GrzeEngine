using GrzeEngine.Engine.Utils;
using OpenGL;

namespace GrzeEngine.Engine.Entities
{
    public class Camera
    {
        public  Vector3 position = Vector3.Zero;
        public float pitch, yaw, roll;

        public Camera() {
            position = new Vector3(2, 2, -10);
        }

        public void Update()
        {
            //TODO sin and cos this 
            if (KeyboardManager.IsKeyDown('w'))
                position.Z += 0.005f;
            if (KeyboardManager.IsKeyDown('s'))
                position.Z -= 0.005f;
            if (KeyboardManager.IsKeyDown('a'))
                position.X += 0.005f;
            if (KeyboardManager.IsKeyDown('d'))
                position.X -= 0.005f;
            if (KeyboardManager.IsKeyDown(' '))
                position.Y -= 0.005f;
            if (KeyboardManager.IsKeyDown('t'))
                position.Y += 0.005f;

            if (KeyboardManager.IsKeyDown('q'))
                yaw += 0.001f;
            if (KeyboardManager.IsKeyDown('e'))
                yaw -= 0.001f;
        }
    }
}
