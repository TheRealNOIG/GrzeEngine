using OpenGL;

namespace GrzeEngine.Engine.Entities
{
    public abstract class Camera
    {
        public abstract void Update(float delta);

        public abstract Matrix4 GetViewMatrix();
    }
}
