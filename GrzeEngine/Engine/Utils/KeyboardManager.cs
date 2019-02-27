using System.Collections.Generic;

namespace GrzeEngine.Engine.Utils
{
    public static class KeyboardManager
    {
        private static List<char> keysDown = new List<char>();

        public static void HandleInput(char key, bool state)
        {
            if (state)
            {
                if (!keysDown.Contains(key))
                    keysDown.Add(key);
            }
            else
            {
                if (keysDown.Contains(key))
                    keysDown.Remove(key);
            }
        }

        public static bool IsKeyDown(char key)
        {
            if (keysDown.Contains(key))
                return true;
            else
                return false;
        }
    }
}
