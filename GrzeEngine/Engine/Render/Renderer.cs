using GrzeEngine.Engine.Entities;
using GrzeEngine.Engine.Entities._3D;
using GrzeEngine.Engine.Shaders;
using GrzeEngine.Engine.Utils;
using OpenGL;
using System.Collections.Generic;

namespace GrzeEngine.Engine.Render
{
    public class Renderer
    {
        protected Camera camera;
        protected StaticShader shader;
        protected List<ModelEntity> entityList = new List<ModelEntity>();
        protected Dictionary<GenericVAO, List<ModelEntity>> entityDictionary = new Dictionary<GenericVAO, List<ModelEntity>>();

        public Renderer(int width, int height, Camera camera, StaticShader shader)
        {
            this.camera = camera;
            this.shader = shader;
            this.shader.LoadProjectionMatrix(width, height);
        }

        public virtual void Render()
        {
            shader.Use();
            shader.LoadViewMatrix(camera.GetViewMatrix());

            Gl.Enable(EnableCap.CullFace);
            Gl.CullFace(CullFaceMode.Back);

            foreach (KeyValuePair<GenericVAO, List<ModelEntity>> item in entityDictionary)
            {
                GenericVAO model = item.Key;
                PrepareModel(model);
                foreach (Entity entity in item.Value)
                {
                    shader.LoadTransformationMatrix(Maths.CreateTransformationMatrix(entity));
                    Gl.DrawElements(model.DrawMode, model.VertexCount, model.elementType, model.offsetInBytes);
                }
                UnBindModel();
            }
        }
        public virtual void Update(float delta)
        {
            foreach (ModelEntity entity in entityList)
            {
                entity.Update(delta);
            }
            camera.Update(delta);
        }
        public virtual void Cleanup()
        {
            shader.Dispose();
        }

        public virtual void PrepareModel<T1>(T1 model) where T1 : GenericVAO
        {
            Gl.BindVertexArray(model.ID);
        }

        public virtual void UnBindModel()
        {
            Gl.BindVertexArray(0);
        }

        public virtual StaticShader GetShader()
        {
            return shader;
        }

        public virtual void AddEntity(ModelEntity entity)
        {
            entityList.Add(entity);
        }

        public void ProcessAllEntities()
        {
            foreach (ModelEntity entity in entityList)
            {
                ProcessEntity(entity);
            }
        }

        public virtual void ProcessEntity(ModelEntity entity)
        {
            GenericVAO model = entity.model;

            if (entityDictionary.ContainsKey(model))
            {
                List<ModelEntity> result;
                if (entityDictionary.TryGetValue(model, out result))
                {
                    if (!result.Contains(entity))
                    {
                        result.Add(entity);
                    }
                }
            }
            else
            {
                List<ModelEntity> newList = new List<ModelEntity>();
                newList.Add(entity);
                entityDictionary.Add(model, newList);
            }
        }
    }
}
