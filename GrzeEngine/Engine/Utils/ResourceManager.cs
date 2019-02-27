using System.IO;
using System.Reflection;
using GrzeEngine.Engine.Logging;

namespace GrzeEngine.Engine.Utils
{
    public static class ResourceManager
    {

        public static string getSourceFile(string path)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}