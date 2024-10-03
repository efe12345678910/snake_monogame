using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum TextureName { Snake}
    internal static class Contents
    {
        public static ContentManager Content { get; set; }

        private static Texture2D _snakeTexture;
        public static Dictionary<TextureName, Texture2D> TextureDict { get; private set; } = new Dictionary<TextureName, Texture2D>();
        
        static Contents()
        {
            
            
        }
        public static void Init()
        {
            _snakeTexture = Content.Load<Texture2D>("Art/Snake/snake_front");
            TextureDict.Add(TextureName.Snake, _snakeTexture);
        }
        public static Texture2D GetTexture2D(TextureName name)
        {
            return TextureDict[name];
        }
    }
}
