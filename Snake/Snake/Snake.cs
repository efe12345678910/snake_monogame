using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake
    {
        public readonly Texture2D Texture;
        public Vector2 Position { get; private set; }
        public Snake()
        {
            Texture = Contents.GetTexture2D(TextureName.Snake);
        }
        
    }
}
