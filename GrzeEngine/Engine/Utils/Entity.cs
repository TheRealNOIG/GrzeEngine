using OpenGL;

namespace GrzeEngine.Engine.Utils
{
    public class Entity
    {
        public Vector3 position;
        public VAO model;
        public float rotX, rotY, rotZ, scale;

        public Entity(VAO model, Vector3 position, float rotX, float rotY, float rotZ)
        {
            this.model = model;
            this.position = position;
            this.rotX = rotX;
            this.rotY = rotY;
            this.rotZ = rotZ;
        }

        public Entity(VAO model, Vector3 position, Vector3 rotation)
        {
            this.model = model;
            this.position = position;
            this.rotX = rotation.X;
            this.rotY = rotation.Y;
            this.rotZ = rotation.Z;
        }

        public void CleanUp()
        {
            model.Dispose();
        }

        //TODO IncreasePosition(vec) IncreaseRotation(vec)
    }
}