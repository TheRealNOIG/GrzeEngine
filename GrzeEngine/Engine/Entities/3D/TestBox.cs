using OpenGL;

namespace GrzeEngine.Engine.Entities._3D
{
    public class TestBox : ModelEntity
    {
        public TestBox(VAO model, Vector3 position, float rotX, float rotY, float rotZ) : base(model, position, rotX, rotY, rotZ)
        {
        }

        public TestBox(VAO model, Vector3 position, Vector3 rotation) : base(model, position, rotation)
        {
        }

        public override void Update(float delta)
        {
            rotation.X += 0.001f * delta;
            rotation.Y += 0.002f * delta;
            rotation.Z += 0.001f * delta;
        }
    }
}