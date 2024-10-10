using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal static class InputManager
    {
        private static KeyboardState _lastKeyboardState;
        private static MouseState _lastMouseState;
        public static bool IsRightArrowPressed { get; private set; }
        public static bool IsLeftArrowPressed { get; private set; }
        public static Action RightArrowPressed { get;  set; }
        public static Action LeftArrowPressed { get;  set; }
        public static Action LMBClicked { get; set; }
        public static Action RKeyPressed { get; set; }
        public static Action PauseKeyPressed { get; set; }
        public static void Update()
        {
            if(Mouse.GetState().LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released)
            {
                LMBClicked?.Invoke();
            }
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
            if(Keyboard.GetState().IsKeyDown(Keys.R) && _lastKeyboardState.IsKeyUp(Keys.R))
            {
                RKeyPressed?.Invoke();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.P) && _lastKeyboardState.IsKeyUp(Keys.P))
            {
                PauseKeyPressed?.Invoke();
            }
            _lastKeyboardState = Keyboard.GetState();
            _lastMouseState = Mouse.GetState();
            
        }
        
    }
}
