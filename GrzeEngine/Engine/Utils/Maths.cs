using GrzeEngine.Engine.Entities;
using OpenGL;

namespace GrzeEngine.Engine.Utils
{
    public static class Maths
    {

        public static Matrix4 CreateViewMatrix(Camera camera)
        {
            var rotationX = Matrix4.CreateRotationX(camera.pitch);
            var rotationY = Matrix4.CreateRotationY(camera.yaw);
            var rotationZ = Matrix4.CreateRotationZ(camera.roll);
            var finalRotation = rotationX * rotationY * rotationZ;
            return Matrix4.CreateTranslation(finalRotation * camera.position);
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
