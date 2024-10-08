using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Level
    {
        public Snake Snake { get; private set; }
        public Vector2 GridSize { get; } = new Vector2(10,10);
        private readonly int _levelRows = 50;
        private readonly int _levelColumns = 50;

        public Level()
        {
            Snake = new Snake(this);
            //Setting gridSize to snake's texture size so that everything will be based on the snake's texture size
        }
        public void Draw()
        {
            //Globals.SpriteBatch.Draw(Snake.Texture, Snake.Position, Microsoft.Xna.Framework.Color.White);
            Snake.Draw();
        }
        public void Update()
        {
            Snake.Update();
        }
    }
}
