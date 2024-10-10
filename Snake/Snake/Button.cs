using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Button
    {
        private Texture2D _buttonTexture;
        public Vector2 Position { get; private set; }
        private Rectangle _rectangle;
        public Button()
        {
            Position = new Vector2(400, 100);
            _buttonTexture = Contents.TextureDict[TextureName.Button];
            _rectangle = new Rectangle((int)Position.X,(int)Position.Y, _buttonTexture.Bounds.Width,_buttonTexture.Bounds.Height); 
            InputManager.LMBClicked += onLMBClicked;
        }
        public void Update()
        {
            
        }
        public void onLMBClicked()
        {
            if (_rectangle.Contains(Mouse.GetState().Position))
            {
                Globals.Game.GameManager.ChangeState(GameStateManager.GameStateEnum.Play);
            }
        }
        public void Draw()
        {
            Globals.SpriteBatch.Draw(_buttonTexture, Position, Microsoft.Xna.Framework.Color.White);
        }
    }
}
