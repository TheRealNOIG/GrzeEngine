using OpenGL;

namespace GrzeEngine.Engine.Shaders
{
    class StaticShader : ShaderProgram
    {
        private static readonly string VERTEX_FILE = "Vertex";
        private static readonly string FRAGMENT_FILE = "Fragment";

        public StaticShader()
            : base(System.IO.File.ReadAllText(@"D:\" + VERTEX_FILE + ".txt"),
                  System.IO.File.ReadAllText(@"D:\" + FRAGMENT_FILE + ".txt"))
        { }

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
            this["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.75f, (float)width / height, 0.1f, 1000.0f));
        }
    }
}
