using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum TextureName { Snake}
    internal class Contents
    {

        private Texture2D _snakeTexture;
        public Dictionary<TextureName, Texture2D> TextureDict { get; private set; } = new Dictionary<TextureName, Texture2D>();
        
        public Contents()
        {
            _snakeTexture = Globals.Content.Load<Texture2D>("Art/Snake/snake");
            TextureDict.Add(TextureName.Snake, _snakeTexture);
            
        }
    }
}
