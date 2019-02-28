using System;
using GrzeEngine.Engine.Entities;
using OpenGL;

namespace GrzeEngine.Engine.Utils
{
    public static class Maths
    {

        public static float toRadinas(float angle)
        {
            return ((float)Math.PI / 180) * angle;
        }

        public static Matrix4 CreateViewMatrix(Camera camera)
        {
            var rotationX = Matrix4.CreateRotationX(toRadinas(camera.pitch));
            var rotationY = Matrix4.CreateRotationY(toRadinas(camera.yaw));
            var rotationZ = Matrix4.CreateRotationZ(toRadinas(camera.roll));
            Matrix4 translation =  Matrix4.CreateTranslation(camera.position);
            return (translation * rotationX * rotationY * rotationZ);
        }

        public static Matrix4 CreateTransformationMatrix(Entity entity)
        {
            Matrix4 x = Matrix4.CreateRotationX(entity.rotX);
            Matrix4 y = Matrix4.CreateRotationY(entity.rotY);
            Matrix4 z = Matrix4.CreateRotationZ(entity.rotZ);
            Matrix4 translation = Matrix4.CreateTranslation(entity.position);
            return (x * y * z * translation);
        }

        //public static Matrix4 Transform(Vector3 position, float )
    }
}
