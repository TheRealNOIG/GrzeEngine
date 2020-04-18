using OpenGL;
using System.Collections.Generic;

namespace GrzeEngine.Engine.Render
{
    public class SpriteVAO : GenericVAO
    {
        public SpriteVAO(ShaderProgram program, VBO<Vector2> vertex, VBO<uint> element)
            : base(program)
        {
            List<IGenericVBO> vbos = new List<IGenericVBO>();
            vbos.Add(new GenericVBO<Vector2>(vertex, "in_position"));
            vbos.Add(new GenericVBO<uint>(element));
            Init(vbos.ToArray());
        }

        public static SpriteVAO CreateQuad(ShaderProgram program, Vector3 size)
        {
            Vector2[] vertices = new Vector2[] { Vector2.Zero, new Vector2(size.X, 0),
                new Vector2(size.X, size.Y), new Vector2(0, size.Y) };
            uint[] indices = new uint[] { 0, 1, 2, 2, 3, 0 };

            return new SpriteVAO(program, new VBO<Vector2>(vertices), new VBO<uint>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }
    }
}
