using System.Collections.Generic;
using GrzeEngine.Engine.Entities._3D;
using GrzeEngine.Engine.Shaders;

namespace GrzeEngine.Engine.Render
{    
    public class MasterRenderer
    {
        private Dictionary<string, Renderer> renderers = new Dictionary<string, Renderer>();

        public void AddRenderer(string name, Renderer renderer)
        {
            renderers.Add(name, renderer);
        }

        public void AddEntity(string renderer, ModelEntity entity)
        {
            if (renderers.ContainsKey(renderer))
            {
                renderers[renderer].AddEntity(entity);
            }
        }
        public void RemoveEntity(string renderer, ModelEntity entity)
        {
            if (renderers.ContainsKey(renderer))
            {
                renderers[renderer].RemoveEntity(entity);
            }
        }
        public void RemoveAllEntity(string renderer, ModelEntity entity)
        {
            if (renderers.ContainsKey(renderer))
            {
                renderers[renderer].RemoveAllEntity(entity);
            }
        }

        public void ProcessEntities()
        {
            foreach (var item in renderers.Values)
            {
                item.ProcessAllEntities();
            }
        }
        public void ProcessEntities(string renderer)
        {
            if (renderers.ContainsKey(renderer))
            {
                renderers[renderer].ProcessAllEntities();
            }
        }

        public void Render()
        {
            foreach (var item in renderers.Values)
            {
                item.Render();
            }
        }
        public void Render(string renderer)
        {
            if (renderers.ContainsKey(renderer))
            {
                renderers[renderer].Render();
            }
        }

        public void Update(float delta)
        {
            foreach (var item in renderers.Values)
            {
                item.Update(delta);
            }
        }
        public void Update(string renderer, float delta)
        {
            if (renderers.ContainsKey(renderer))
            {
                renderers[renderer].Update(delta);
            }
        }

        public void Cleanup()
        {
            foreach (var item in renderers.Values)
            {
                item.Cleanup();
            }
        }
        public void Cleanup(string renderer)
        {
            if (renderers.ContainsKey(renderer))
            {
                renderers[renderer].Cleanup();
            }
        }

        public StaticShader GetShader(string renderer)
        {
            if (renderers.ContainsKey(renderer))
            {
                return renderers[renderer].GetShader();
            }
            return null;
        }
    }
}
