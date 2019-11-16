using OpenGL;

namespace GrzeEngine.Engine.Entities._3D
{
    public class TestBox : ModelEntity
    {
        public override void Update(float delta)
        {
            rotation.X += 0.001f * delta;
            rotation.Y += 0.002f * delta;
            rotation.Z += 0.001f * delta;
        }
    }
}