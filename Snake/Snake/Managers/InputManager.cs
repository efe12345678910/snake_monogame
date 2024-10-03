using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal static class InputManager
    {
        private static KeyboardState _lastKeyboardState;
        public static bool IsRightArrowPressed { get; private set; }
        public static bool IsLeftArrowPressed { get; private set; }
        public static Action RightArrowPressed { get;  set; }
        public static Action LeftArrowPressed { get;  set; }
        public static void Update()
        {
            IsRightArrowPressed = Keyboard.GetState().IsKeyDown(Keys.Right) && _lastKeyboardState.IsKeyUp(Keys.Right);
            if(IsRightArrowPressed)
            {
                RightArrowPressed?.Invoke();
            }
            IsLeftArrowPressed = Keyboard.GetState().IsKeyDown(Keys.Left) && _lastKeyboardState.IsKeyUp(Keys.Left);
            if(IsLeftArrowPressed)
            {
                LeftArrowPressed?.Invoke();
            }
            _lastKeyboardState = Keyboard.GetState();
        }
    }
}
