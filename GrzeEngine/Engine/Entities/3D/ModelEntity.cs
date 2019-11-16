using OpenGL;

namespace GrzeEngine.Engine.Entities._3D
{
    public class ModelEntity : Entity
    {
        public VAO model;

        public ModelEntity(VAO model, Vector3 position, Vector3 rotation)
        {
            this.model = model;
            this.position = position;
            this.rotation = rotation;
        }

        public void CleanUp()
        {
            model.Dispose();
        }

        public override void Update(float delat)
        {
        }
    }
}