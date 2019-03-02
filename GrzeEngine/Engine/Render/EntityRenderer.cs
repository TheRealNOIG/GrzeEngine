using System.Collections.Generic;
using GrzeEngine.Engine.Entities;
using GrzeEngine.Engine.Shaders;
using GrzeEngine.Engine.Utils;
using OpenGL;

namespace GrzeEngine.Engine.Render
{
    class EntityRenderer
    {
        public StaticShader shader;
        private Camera camera;

        public EntityRenderer(int width, int height, Camera camera)
        {
            this.camera = camera;
            this.shader = new StaticShader();
            shader.LoadProjectionMatrix(width, height); 
            shader.LoadViewMatrix(Maths.CreateViewMatrix(this.camera));;
        }

        /*
        public void Render()
        {
            shader.LoadViewMatrix(Maths.CreateViewMatrix(this.camera));
            Gl.Enable(EnableCap.CullFace);
            Gl.CullFace(CullFaceMode.Back);
            
            foreach (Entity entity in entities)
            {
                VAO model = entity.model;
                SetEntityTransform(entity);
                Gl.BindVertexArray(model.ID);
                Gl.DrawElements(model.DrawMode, model.VertexCount, model.elementType, model.offsetInBytes);
                Gl.BindVertexArray(0);
                //entity.model.Program.Use();
                //entity.model.Draw();
            }
        }
        */

        public void Render(Dictionary<VAO, List<Entity>> entities)
        {
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
        
        public void PrepareModel(VAO model)
        {
            Gl.BindVertexArray(model.ID);
        }

        public void UnBindModel()
        {
            Gl.BindVertexArray(0);
        }

        public void SetEntityTransform(Entity entity)
        {
            shader.LoadTransformationMatrix(Maths.CreateTransformationMatrix(entity));
        }

        public void Cleanup()
        {
            shader.Dispose();
        }
    }
}
