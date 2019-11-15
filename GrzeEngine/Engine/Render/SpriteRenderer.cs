using System.Collections.Generic;
using GrzeEngine.Engine._2DEntities;
using GrzeEngine.Engine.Entities;
using GrzeEngine.Engine.Shaders;
using GrzeEngine.Engine.Utils;
using OpenGL;
namespace GrzeEngine.Engine.Render
{
    public class SpriteRenderer
    {
        public Static2DShader shader;
        private Camera2D camera;

        public SpriteRenderer(int width, int height, Camera2D camera)
        {
            this.camera = camera;
            shader = new Static2DShader();
            shader.Load2DProjectionMatrix(width, height);
            shader.LoadViewMatrix(Maths.Create2DViewMatrix(this.camera)); ;
        }

        public void Render(Dictionary<SpriteVAO, List<Sprite>> sprites)
        {
            shader.Use();
            shader.LoadViewMatrix(Maths.Create2DViewMatrix(this.camera));

            Gl.Enable(EnableCap.CullFace);
            Gl.CullFace(CullFaceMode.Back);

            foreach (KeyValuePair<SpriteVAO, List<Sprite>> item in sprites)
            {
                SpriteVAO model = item.Key;
                PrepareModel(model);
                foreach (Sprite sprite in item.Value)
                {
                    SetSpriteTransform(sprite);
                    Gl.DrawElements(model.DrawMode, model.VertexCount, model.elementType, model.offsetInBytes);
                }
                UnBindModel();
            }
        }

        public void PrepareModel(SpriteVAO model)
        {
            Gl.BindVertexArray(model.ID);
        }

        public void UnBindModel()
        {
            Gl.BindVertexArray(0);
        }

        public void SetSpriteTransform(Sprite sprite)
        {
            shader.LoadTransformationMatrix(Maths.CreateTransformationMatrix(sprite));
        }

        public void Cleanup()
        {
            shader.Dispose();
        }
    }
}
