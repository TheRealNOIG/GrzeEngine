using OpenGL;

namespace GrzeEngine.Engine.Entities
{
    public abstract class Entity
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

        public abstract void Update(float delta);

        public void CleanUp()
        {
            model.Dispose();
        }

        public void IncreasePosition(float x, float y, float z)
        {
            this.position.x += x;
            this.position.y += y;
            this.position.z += z;
        }

        public void IncreasePosition(int x, int y, int z)
        {
            this.position.x += x;
            this.position.y += y;
            this.position.z += z;
        }

        public void IncreaseRotation(float x, float y, float z)
        {
            this.rotX += x;
            this.rotY += y;
            this.rotZ += z;
        }
    }
}