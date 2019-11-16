using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrzeEngine.Engine.Entities
{
    public abstract class Entity
    {
        public Vector3 position, rotation, size;

        public abstract void Update(float delat);

        public void IncreasePosition(float x, float y, float z)
        {
            this.position.X += x;
            this.position.Y += y;
            this.position.Z += z;
        }

        public void IncreasePosition(int x, int y, int z)
        {
            this.position.X += x;
            this.position.Y += y;
            this.position.Z += z;
        }

        public void IncreasePosition(int x, int y)
        {
            this.position.X += x;
            this.position.Y += y;
        }

        public void IncreaseRotation(float x, float y, float z)
        {
            this.rotation.X += x;
            this.rotation.Y += y;
            this.rotation.Z = z;
        }

        public void IncreaseRotation(float x, float y)
        {
            this.rotation.X += x;
            this.rotation.Y += y;
        }
    }
}
