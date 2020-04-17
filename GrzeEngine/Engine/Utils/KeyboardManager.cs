using System.Collections.Generic;

namespace GrzeEngine.Engine.Utils
{
    public static class KeyboardManager
    {
        private static List<char> keysDown = new List<char>();
        private static List<char> keysPressed = new List<char>();

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
                if (keysPressed.Contains(key))
                    keysPressed.Remove(key);
            }
        }

        public static bool IsKeyDown(char key)
        {
            if (keysDown.Contains(key))
                return true;
            else
                return false;
        }

        public static bool IsKeyPressed(char key)
        {
            if (keysDown.Contains(key) && !keysPressed.Contains(key))
            {
                keysPressed.Add(key);
                return true;
            }
            else
                return false;
        }
    }
}
