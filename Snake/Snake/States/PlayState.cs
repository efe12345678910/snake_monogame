using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class PlayState : GameState
    {
        public override void Update(GameManager gm)
        {
            gm.Level.Update();
        }
        public override void Draw(GameManager gm)
        {
            gm.Level.Draw();
        }
    }
}
