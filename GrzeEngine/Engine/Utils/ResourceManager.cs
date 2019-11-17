using OpenGL;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static OpenGL.GenericVAO;

namespace GrzeEngine.Engine.Utils
{
    public static class ResourceManager
    {

        public static VAO LoadOBJModel(string obj, ShaderProgram shader)
        {
            string[] lines = Regex.Split(obj, "\r\n|\r|\n");
            List<Vector3> vertices = new List<Vector3>();
            List<uint> indices = new List<uint>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                if (parts[0] == "v")
                {
                    vertices.Add(new Vector3(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3])));
                }
                else if (parts[0] == "f")
                {
                    string[] vertex1 = parts[1].Split('/');
                    string[] vertex2 = parts[2].Split('/');
                    string[] vertex3 = parts[3].Split('/');

                    indices.AddRange(processVertex(vertex1));
                    indices.AddRange(processVertex(vertex2));
                    indices.AddRange(processVertex(vertex3));
                }
            }
            List<IGenericVBO> vbos = new List<IGenericVBO>();
            vbos.Add(new GenericVBO<Vector3>(new VBO<Vector3>(vertices.ToArray()), "in_position"));
            vbos.Add(new GenericVBO<uint>(new VBO<uint>(indices.ToArray(), BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticRead)));
            VAO model = new VAO(shader, vbos.ToArray());
            return model;
        }

        private static List<uint> processVertex(string[] vertexData)
        {
            List<uint> indices = new List<uint>();
            //TODO implement noramls and texture
            indices.Add(uint.Parse(vertexData[0]) - 1);
            return indices;
        }
    }
}