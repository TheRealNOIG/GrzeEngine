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
        private List<Entity> entities = new List<Entity>();
        private Camera camera;

        public EntityRenderer(int width, int height, Camera camera)
        {
            this.camera = camera;
            this.shader = new StaticShader();
            shader.LoadProjectionMatrix(width, height); 
            shader.LoadViewMatrix(Matrix4.CreateTranslation(new Vector3(2, 2, -10)) * Matrix4.CreateRotation(new Vector3(1, -2, 0), 0.2f));
        }

        public void AddEntity(Entity entity)
        {
            entities.Add(entity);
        }

        public void Render()
        {
            shader.LoadViewMatrix(Maths.CreateViewMatrix(this.camera));
            foreach (Entity entity in entities)
            {
                //TODO remove entity test
                entity.rotX += 0.001f;
                entity.rotY += 0.002f;
                entity.rotZ += 0.001f;

                SetEntityTransform(entity);
                entity.model.Program.Use();
                entity.model.Draw();
            }
        }

        public void SetEntityTransform(Entity entity)
        {
            shader["transformation_matrix"].SetValue(Maths.CreateTransformationMatrix(entity));
        }

        public void Cleanup()
        {
            shader.Dispose();
            foreach (Entity entity in entities)
            {
                entity.CleanUp();
            }
        }
    }
}
