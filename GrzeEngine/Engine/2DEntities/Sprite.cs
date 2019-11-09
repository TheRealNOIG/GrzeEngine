using GrzeEngine.Engine.Render;
using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrzeEngine.Engine._2DEntities
{
    public class Sprite
    {
        public Vector2 position, rotation, size;
        public SpriteVAO model;

        public Sprite(Vector2 position, Vector2 size, Vector2 rotation, ShaderProgram shader)
        {
            this.position = position;
            this.size = size;
            this.rotation = rotation;
            this.model = CreateQuad(shader, this.position, this.size);
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

        private SpriteVAO CreateQuad(ShaderProgram program, Vector2 location, Vector2 size)
        {
            Vector2[] vertices = new Vector2[] { new Vector2(location.X, location.Y), new Vector2(location.X + size.X, location.Y),
                new Vector2(location.X + size.X, location.Y + size.Y), new Vector2(location.X, location.Y + size.Y) };
            uint[] indices = new uint[] { 0, 1, 2, 2, 3, 0 };

            return new SpriteVAO(program, new VBO<Vector2>(vertices), new VBO<uint>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }
    }
}
