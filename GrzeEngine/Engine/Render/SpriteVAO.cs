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
    }
}
