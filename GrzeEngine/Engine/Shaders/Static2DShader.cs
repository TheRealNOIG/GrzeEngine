using GrzeEngine.Engine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrzeEngine.Engine.Shaders
{
    class Static2DShader : StaticShader
    {
        private static readonly string VERTEX_FILE = "GrzeEngine.Engine.Shaders.static2DVertexShader.txt";
        private static readonly string FRAGMENT_FILE = "GrzeEngine.Engine.Shaders.static2DFragmentShader.txt";

        public Static2DShader()
            : base(VERTEX_FILE,
                FRAGMENT_FILE)
        {
        }

        public void Load2DProjectionMatrix(int width, int height)
        {
            //TODO get fov from active camera
            this["projection_matrix"].SetValue(OpenGL.Matrix4.CreateOrthographic(256, 144, 0.1f, 1000.0f));
        }
    }
}
