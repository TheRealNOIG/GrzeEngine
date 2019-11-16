using GrzeEngine.Engine.Render;
using OpenGL;

namespace GrzeEngine.Engine.Entities._2D
{
    public class Sprite : Entity
    {
        public SpriteVAO model;

        public Sprite(Vector2 position, Vector2 size, Vector2 rotation, ShaderProgram shader)
        {
            this.position = new Vector3(position.X, position.Y, 0);
            this.size = new Vector3(size.X, size.Y, 0);
            this.rotation = new Vector3(rotation.X, rotation.Y, 0);
            model = SpriteVAO.CreateQuad(shader, this.position, this.size);
        }

        public override void Update(float delta)
        {

        }

        public void CleanUp()
        {
            model.Dispose();
        }
    }
}
