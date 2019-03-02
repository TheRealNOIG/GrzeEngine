using System.Collections.Generic;
using GrzeEngine.Engine.Entities;
using GrzeEngine.Engine.Logging;
using GrzeEngine.Engine.Shaders;
using GrzeEngine.Engine.Utils;
using OpenGL;

namespace GrzeEngine.Engine.Render
{
    //TODO create instance renderer for trees and testBox https://learnopengl.com/Advanced-OpenGL/Instancing
    
    class MasterRenderer
    {
        private EntityRenderer entityRenderer;
        
        private List<Entity> entityList = new List<Entity>();
        private Dictionary<VAO, List<Entity>> entityDictionary = new Dictionary<VAO, List<Entity>>();

        public MasterRenderer(int width, int height, Camera camera)
        {
            entityRenderer = new EntityRenderer(width, height, camera);
        }
        
        public void AddEntity(Entity entity)
        {
            entityList.Add(entity);
        }

        public void ProcessEntities()
        {
            foreach (Entity entity in entityList)
            {
                ProcessEntity(entity);
            }
        }

        private void ProcessEntity(Entity entity)
        {
            VAO model = entity.model;

            if (entityDictionary.ContainsKey(model))
            {
                List<Entity> result;
                if (entityDictionary.TryGetValue(model, out result))
                {
                    result.Add(entity);
                }
            }
            else
            {
                List<Entity> newList = new List<Entity>();
                newList.Add(entity);
                entityDictionary.Add(model, newList);
            }
        }

        public void Render()
        {
            entityRenderer.Render(entityDictionary);
            entityDictionary.Clear();
        }

        public void Update(float delta)
        {
            foreach (Entity entity in entityList)
            {
                entity.Update(delta);
            }
        }

        public void Cleanup()
        {
            entityRenderer.Cleanup();
            entityList.Clear();
            entityDictionary.Clear();
        }

        public StaticShader GetEntityShader()
        {
            return entityRenderer.shader;
        }
    }
}
