using System.Collections.Generic;
using GrzeEngine.Engine._2DEntities;
using GrzeEngine.Engine.Entities;
using GrzeEngine.Engine.Logging;
using GrzeEngine.Engine.Shaders;
using GrzeEngine.Engine.Utils;
using OpenGL;

namespace GrzeEngine.Engine.Render
{
    
    class MasterRenderer
    {
        private EntityRenderer entityRenderer;
        private SpriteRenderer spriteRenderer;
        private List<Entity> entityList = new List<Entity>();
        private List<Sprite> spriteList = new List<Sprite>();
        private Dictionary<VAO, List<Entity>> entityDictionary = new Dictionary<VAO, List<Entity>>();
        private Dictionary<SpriteVAO, List<Sprite>> spriteDictionary = new Dictionary<SpriteVAO, List<Sprite>>();

        public MasterRenderer(int width, int height, Camera camera)
        {
            entityRenderer = new EntityRenderer(width, height, camera);
        }

        public MasterRenderer(int width, int height, Camera2D camera)
        {
            spriteRenderer = new SpriteRenderer(width, height, camera);
        }

        public void AddEntity(Entity entity)
        {
            entityList.Add(entity);
        }

        public void AddSprite(Sprite sprite)
        {
            spriteList.Add(sprite);
        }

        public void ProcessEntities()
        {
            foreach (Entity entity in entityList)
            {
                ProcessEntity(entity);
            }
        }

        public void ProcessSprite()
        {
            foreach (Sprite sprite in spriteList)
            {
                ProcessSprite(sprite);
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

        private void ProcessSprite(Sprite sprite)
        {
            SpriteVAO model = sprite.model;

            if (spriteDictionary.ContainsKey(model))
            {
                List<Sprite> result;
                if (spriteDictionary.TryGetValue(model, out result))
                {
                    result.Add(sprite);
                }
            }
            else
            {
                List<Sprite> newList = new List<Sprite>();
                newList.Add(sprite);
                spriteDictionary.Add(model, newList);
            }
        }

        public void Render()
        {
            /*
            entityRenderer.Render(entityDictionary);
            entityDictionary.Clear();
            */

            spriteRenderer.Render(spriteDictionary);
            spriteDictionary.Clear();
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
            /*
            entityRenderer.Cleanup();
            entityList.Clear();
            entityDictionary.Clear();
            */
            spriteRenderer.Cleanup();
            spriteList.Clear();
            spriteDictionary.Clear();
        }

        public StaticShader GetEntityShader()
        {
            return entityRenderer.shader;
        }

        public StaticShader GetSpriteShader()
        {
            return spriteRenderer.shader;
        }
    }
}
