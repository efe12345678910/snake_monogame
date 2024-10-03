using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class GameManager
    {
        public Level Level { get; private set; }
        public GameManager()
        {
            Level = new Level();
        }

        public void Update()
        {
            InputManager.Update();
            Level.Update();
        }
        public void Draw()
        {
            Level.Draw();
        }
    }
}
