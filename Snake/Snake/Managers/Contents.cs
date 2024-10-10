using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum TextureName { Snake,Wall, Intro, Button}
    internal static class Contents
    {
        public static ContentManager Content { get; set; }

        private static Texture2D _snakeTexture;
        private static Texture2D _wallTexture;
        private static Texture2D _introTexture;
        private static Texture2D _buttonTexture;
        public static Dictionary<TextureName, Texture2D> TextureDict { get; private set; } = new Dictionary<TextureName, Texture2D>();
        
        static Contents()
        {
            
            
        }
        public static void Init()
        {
            _snakeTexture = Content.Load<Texture2D>("Art/Snake/snake");
            _wallTexture = Content.Load<Texture2D>("Art/Level/wall");
            _introTexture = Content.Load<Texture2D>("Art/Intro/intro_screen");
            _buttonTexture = Content.Load<Texture2D>("Art/Intro/button");
            TextureDict.Add(TextureName.Button, _buttonTexture);
            TextureDict.Add(TextureName.Wall, _wallTexture);
            TextureDict.Add(TextureName.Snake, _snakeTexture);
            TextureDict.Add(TextureName.Intro, _introTexture);
        }
        public static Texture2D GetTexture2D(TextureName name)
        {
            return TextureDict[name];
        }
    }
}
