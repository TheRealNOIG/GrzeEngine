using GrzeEngine.Engine.Entities._2D;
using GrzeEngine.Engine.Logging;
using GrzeEngine.Engine.Render;
using OpenGL;
using System;

namespace GrzeEngine.Engine.Utils
{
    public class Grid<T>
    {
        private int width, height;
        private float cellSize;
        private Vector2 location;
        private T[,] cells;

        public Grid(int width, int height, float cellSize, Vector2 gridLocation, Func<T> createCellObject)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.location = gridLocation;

            this.cells = new T[width, height];

            for (int w = 0; w < this.width; w++)
                for (int h = 0; h < this.height; h++)
                    this.cells[w, h] = createCellObject();
        }

        public T GetCellAtLocation(int x, int y)
        {
            return cells[x, y];
        }

        public Vector2 GetCellLocationInWorld(int x, int y)
        {
            return new Vector2(this.location.X + (x * cellSize), this.location.Y + (y * cellSize));
        }

        #region debug
        private Sprite[,] debugSprites;
        public void Debug(Renderer renderer)
        {
            ShaderProgram shader = renderer.GetShader();

            if (debugSprites == null)
            {
                debugSprites = new Sprite[this.width, this.height];
                for (int w = 0; w < this.width; w++)
                {
                    for (int h = 0; h < this.height; h++)
                    {
                        debugSprites[w, h] = new Sprite(GetCellLocationInWorld(w, h), new Vector2(cellSize - 0.2f), Vector2.Zero, shader);
                        renderer.AddEntity(debugSprites[w, h]);
                    }
                }
            }
        }
        #endregion
    }
}
