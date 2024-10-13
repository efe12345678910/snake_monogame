using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class PlayButton : Button
    {
        public PlayButton(string text, Vector2 positions ): base(text, positions)
        {
        }
        protected override void onButtonClicked()
        {
            Globals.Game.GameManager.ChangeState(GameStateManager.GameStateEnum.Play);
            Debug.WriteLine("Play Button Clicked");
        }
    }
}
