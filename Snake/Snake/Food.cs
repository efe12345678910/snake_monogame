using Microsoft.Xna.Framework;
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
        public Food(Vector2 position, Vector2 gridSize)
        {
            Position = position;
            Rectangle = new Rectangle(Position.ToPoint(), gridSize.ToPoint());
        }
        //It is more efficient to change the position of the food rather than creating a new food object
        public void ChangeFoodLocation(Vector2 position)
        {
            Position = position;
        }
    }
}
