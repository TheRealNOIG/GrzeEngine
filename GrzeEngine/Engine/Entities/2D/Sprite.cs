using GrzeEngine.Engine.Render;
using OpenGL;

namespace GrzeEngine.Engine.Entities._2D
{
    public class Sprite : IEntity
    {
        public Vector2 position, rotation, size;
        public SpriteVAO model;

        public Sprite(Vector2 position, Vector2 size, Vector2 rotation, ShaderProgram shader)
        {
            this.position = position;
            this.size = size;
            this.rotation = rotation;
            this.model = SpriteVAO.CreateQuad(shader, this.position, this.size);
        }

        public void Update(float delta)
        {

        }

        public void CleanUp()
        {
            model.Dispose();
        }

        public void IncreasePosition(int x, int y)
        {
            this.position.X += x;
            this.position.Y += y;
        }
    }
}
