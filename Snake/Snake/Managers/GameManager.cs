using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class GameManager
    {
        public Snake Snake { get; private set; }
        public GameManager()
        {
            Snake = new Snake();
        }

        public void Update()
        {

        }
        public void Draw()
        {
            Globals.SpriteBatch.Draw(Snake.Texture, Snake.Position, Microsoft.Xna.Framework.Color.White);
        }
    }
}
