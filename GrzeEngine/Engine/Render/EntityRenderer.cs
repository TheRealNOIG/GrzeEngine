using System.Collections.Generic;
using GrzeEngine.Engine.Entities;
using GrzeEngine.Engine.Entities._3D;
using GrzeEngine.Engine.Shaders;
using GrzeEngine.Engine.Utils;
using OpenGL;

namespace GrzeEngine.Engine.Render
{
    public class EntityRenderer : Renderer<VAO, Entity>
    {
        public StaticShader shader;
        private Camera3D camera;

        public EntityRenderer(int width, int height, Camera3D camera)
        {
            this.camera = camera;
            shader = new StaticShader();
            shader.LoadProjectionMatrix(width, height); 
            shader.LoadViewMatrix(Maths.CreateViewMatrix(this.camera));;
        }

        public override void Render(Dictionary<VAO, List<Entity>> entities)
        {
            shader.Use();
            shader.LoadViewMatrix(Maths.CreateViewMatrix(this.camera));

            Gl.Enable(EnableCap.CullFace);
            Gl.CullFace(CullFaceMode.Back);

            foreach (KeyValuePair<VAO, List<Entity>> item in entities)
            {
                VAO model = item.Key;
                PrepareModel(model);
                foreach (Entity entity in item.Value)
                {
                    SetEntityTransform(entity);
                    Gl.DrawElements(model.DrawMode, model.VertexCount, model.elementType, model.offsetInBytes);
                }
                UnBindModel();
            }
        }

        public void SetEntityTransform(Entity entity)
        {
            shader.LoadTransformationMatrix(Maths.CreateTransformationMatrix(entity));
        }

        public override void Cleanup()
        {
            shader.Dispose();
        }
    }
}
