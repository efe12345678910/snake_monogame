using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        public Vector2 Position { get; private set; }
        public Rectangle Rectangle { get; private set; }
        private Texture2D _foodTexture;
        public Food(Vector2 position, Vector2 gridSize)
        {
            Position = position;
            Rectangle = new Rectangle(Position.ToPoint(), gridSize.ToPoint());
            //TODO !!!!!!!!!!!!!!!!! for now we use the snake texture for the food texture
            _foodTexture = Contents.GetTexture2D(TextureName.Snake);
        }
        //It is more efficient to change the position of the food rather than creating a new food object
        public void ChangeFoodLocation(Vector2 position)
        {
            Position = position;
        }
        public void Draw()
        {
            Globals.SpriteBatch.Draw(_foodTexture,Position,Color.White);
        }
    }
}
