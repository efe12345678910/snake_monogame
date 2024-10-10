using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal  abstract class GameState
    {
        public abstract void Update(GameManager gm);
        public abstract void Draw(GameManager gm);
    }
}
