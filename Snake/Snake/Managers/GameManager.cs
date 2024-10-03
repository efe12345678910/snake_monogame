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
            InputManager.RKeyPressed += Restart;
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
        public void Restart()
        {
            InputManager.RKeyPressed -= Restart;
            Level = new Level();
        }
    }
}
