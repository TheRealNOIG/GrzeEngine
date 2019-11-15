using GrzeEngine.Engine.Utils;
using GrzeEngine.Properties;
using OpenGL;

namespace GrzeEngine.Engine.Shaders
{
    public class StaticShader : ShaderProgram
    {
       
        public StaticShader()
            : base(Resources.staticVertexShader,
                Resources.staticFragmentShader)
        {
        }

        public StaticShader(string vertexFile, string fragmentFile)
            : base(vertexFile,
                fragmentFile)
        {
        }

        public void LoadViewMatrix(Matrix4 viewMatrix)
        {
            this["view_matrix"].SetValue(viewMatrix);
        }

        public void LoadTransformationMatrix(Matrix4 transform)
        {
            this["transformation_matrix"].SetValue(transform);
        }

        public void LoadProjectionMatrix(int width, int height)
        {
            //TODO get fov from active camera
            this["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(1f, (float)width / height, 0.1f, 1000.0f));
        }
    }
}
