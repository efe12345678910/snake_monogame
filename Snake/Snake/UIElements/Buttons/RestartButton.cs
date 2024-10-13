using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class RestartButton : Button
    {
        public RestartButton(string text, Vector2 positions) : base(text, positions)
        {
            
        }
        protected override void onButtonClicked()
        {
            Globals.Game.GameManager.ChangeState(GameStateManager.GameStateEnum.Play);
            Globals.Game.GameManager.Restart();
            Debug.WriteLine("Restart Button Clicked");
        }
    }
}
