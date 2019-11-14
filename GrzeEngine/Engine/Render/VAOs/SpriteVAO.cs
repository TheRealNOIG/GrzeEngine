using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static SpriteVAO CreateQuad(ShaderProgram program, Vector2 location, Vector2 size)
        {
            Vector2[] vertices = new Vector2[] { new Vector2(location.X, location.Y), new Vector2(location.X + size.X, location.Y),
                new Vector2(location.X + size.X, location.Y + size.Y), new Vector2(location.X, location.Y + size.Y) };
            uint[] indices = new uint[] { 0, 1, 2, 2, 3, 0 };

            return new SpriteVAO(program, new VBO<Vector2>(vertices), new VBO<uint>(indices, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead));
        }
    }
}
