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
            shader.LoadViewMatrix(Maths.CreateViewMatrix(this.camera));;
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
                SetEntityTransform(entity);
                entity.model.Program.Use();
                entity.model.Draw();
            }
        }

        public void Update(float delta)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(delta);
            }
        }

        public void SetEntityTransform(Entity entity)
        {
            shader.LoadTransformationMatrix(Maths.CreateTransformationMatrix(entity));
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
