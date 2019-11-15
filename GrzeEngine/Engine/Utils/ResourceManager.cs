using System.IO;
using System.Reflection;
using GrzeEngine.Engine.Logging;
using GrzeEngine.Properties;

namespace GrzeEngine.Engine.Utils
{
    public static class ResourceManager
    {

        public static string getSourceFile(string path)
        {
            return "This function has been removed";
            /*
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
            */
        }
    }
}