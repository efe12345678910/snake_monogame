using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class PauseState :GameState
    {
        public override void Update(GameManager gm)
        {
        }
        public override void Draw(GameManager gm)
        {
            gm.Level.Draw();
        }
    }
}
