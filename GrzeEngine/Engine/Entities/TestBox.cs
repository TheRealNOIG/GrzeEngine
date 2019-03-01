using OpenGL;

namespace GrzeEngine.Engine.Entities
{
    public class TestBox : Entity
    {
        public TestBox(VAO model, Vector3 position, float rotX, float rotY, float rotZ) : base(model, position, rotX, rotY, rotZ)
        {
        }

        public TestBox(VAO model, Vector3 position, Vector3 rotation) : base(model, position, rotation)
        {
        }

        public override void Update(float delta)
        {
            rotX += 0.001f * delta;
            rotY += 0.002f * delta;
            rotZ += 0.001f * delta;
        }
    }
}