using GrzeEngine.Engine.Entities;
using GrzeEngine.Engine.Entities._2D;
using OpenGL;
using System.Collections.Generic;

namespace GrzeEngine.Engine.Render
{
    public abstract class Renderer<T1, T> where T : IEntity where T1 : GenericVAO 
    {
        public abstract void Render(Dictionary<T1, List<T>> data);
        public abstract void Cleanup();

        public virtual void UnBindModel() { Gl.BindVertexArray(0); }
        public virtual void PrepareModel(T1 model) { Gl.BindVertexArray(model.ID); } 
    }
}
