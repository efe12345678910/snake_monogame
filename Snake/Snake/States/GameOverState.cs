using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class GameOverState : GameState
    {
        public override void Update(GameManager gm)
        {
            Debug.WriteLine("GAME OVER!!!!");
        }
        public override void Draw(GameManager gm)
        {
            gm.Level.Draw();
        }
    }
}
