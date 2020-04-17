using SDL2;
using System.Collections.Generic;
using static SDL2.SDL;

namespace GrzeEngine.Engine.Utils
{
    public static class KeyboardManager
    {
        private static List<SDL_Keycode> keysDown = new List<SDL_Keycode>();
        private static List<SDL_Keycode> keysPressed = new List<SDL_Keycode>();

        public static void HandleInput(SDL_Keycode key, bool state)
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

        public static bool IsKeyDown(SDL_Keycode key)
        {
            if (keysDown.Contains(key))
                return true;
            else
                return false;
        }
        public static bool IsKeyDown(char key)
        {
            if (keysDown.Contains((SDL_Keycode)key))
                return true;
            else
                return false;
        }

        public static bool IsKeyPressed(SDL_Keycode key)
        {
            if (keysDown.Contains(key) && !keysPressed.Contains(key))
            {
                keysPressed.Add(key);
                return true;
            }
            else
                return false;
        }
        public static bool IsKeyPressed(char key)
        {
            SDL_Keycode sym = (SDL_Keycode)key;
            if (keysDown.Contains(sym) && !keysPressed.Contains(sym))
            {
                keysPressed.Add(sym);
                return true;
            }
            else
                return false;
        }
    }
}
