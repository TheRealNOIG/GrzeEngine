using GrzeEngine.Engine.Utils;
using GrzeEngine.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrzeEngine.Engine.Shaders
{
    public class Static2DShader : StaticShader
    {
        //No idea why static2DFragmentShader is an empty string and the file was saved to static2DFragmentShader1
        public Static2DShader()
            : base(Resources.static2DVertexShader,
                Resources.static2DFragmentShader1)
        {
        }

        public void Load2DProjectionMatrix(int width, int height)
        {
            //TODO get fov from active camera
            this["projection_matrix"].SetValue(OpenGL.Matrix4.CreateOrthographic(256, 144, 0.1f, 1000.0f));
        }
    }
}
