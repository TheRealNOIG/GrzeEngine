using GrzeEngine.Engine.Utils;
using OpenGL;

namespace GrzeEngine.Engine.Shaders
{
    class StaticShader : ShaderProgram
    {
        private static readonly string VERTEX_FILE = "GrzeEngine.Engine.Shaders.staticVertexShader.txt";
        private static readonly string FRAGMENT_FILE = "GrzeEngine.Engine.Shaders.staticFragmentShader.txt";

        
        public StaticShader()
            : base(ResourceManager.getSourceFile(VERTEX_FILE),
                ResourceManager.getSourceFile(FRAGMENT_FILE))
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
            this["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.75f, (float)width / height, 0.1f, 1000.0f));
        }
    }
}
