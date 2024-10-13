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
        public bool IsVisible { get; set; } = false;
        private Texture2D _buttonTexture;
        private SpriteFont _font;
        public Vector2 Position { get; private set; }
        private string _text;
        private Vector2 _textPosition;
        private Vector2 _buttonCenter;
        private Vector2 _textSize;
        private Rectangle _rectangle;
        private Vector2 _textOrigin;
        public Button(string text,Vector2 position)
        {
            _text = text;
            Position = position;
            _textPosition = Position;
            _buttonTexture = Contents.TextureDict[TextureName.Button];
            _buttonCenter = new Vector2(_textPosition.X + _buttonTexture.Width / 2, _textPosition.Y + _buttonTexture.Height / 2);
            _font = Contents.FontDict[FontName.Default];
            _textSize = _font.MeasureString(_text);
            _textOrigin = _textSize / 2;
            _rectangle = new Rectangle((int)Position.X,(int)Position.Y, _buttonTexture.Bounds.Width,_buttonTexture.Bounds.Height); 
            InputManager.LMBClicked += onLMBClicked;
            Debug.WriteLine(_buttonCenter);
            Debug.WriteLine(Position);

        }
        public void Update()
        {
        }
        public void onLMBClicked()
        {
            if (_rectangle.Contains(Mouse.GetState().Position) && IsVisible)
            {
                onButtonClicked();
            }
        }
        protected virtual void onButtonClicked()
        {
        }
        public void Draw()
        {
            if (IsVisible)
            {
                Globals.SpriteBatch.Draw(_buttonTexture, Position, Microsoft.Xna.Framework.Color.GreenYellow);
                Globals.SpriteBatch.DrawString(_font, _text, _buttonCenter, Microsoft.Xna.Framework.Color.Red, 0,
                   _textOrigin, 2, SpriteEffects.None, 0);
            }
        }
    }
}
