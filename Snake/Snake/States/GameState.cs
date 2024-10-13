using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal  abstract class GameState
    {
        protected List<Button> buttons = new List<Button>(); 
        public void ActivateButtons()
        {
            foreach (var button in buttons)
            {
                button.IsVisible = true;
            }
        }
        public void DeactivateButtons()
        {
            foreach (var button in buttons)
            {
                button.IsVisible = false;
            }
        }
        public abstract void Update(GameManager gm);
        public abstract void Draw(GameManager gm);
    }
}
