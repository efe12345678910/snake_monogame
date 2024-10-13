using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class IntroMenuState : GameState
    {
        private Texture2D _introBackground;
        private Button _newGameButton;
        public IntroMenuState()
        {
            _introBackground = Contents.TextureDict[TextureName.Intro];
            _newGameButton = new PlayButton("Play",new Vector2(400,100));
            buttons.Add(_newGameButton);
        }
        public override void Update(GameManager gm)
        {
        }
        public override void Draw(GameManager gm)
        {
            Globals.SpriteBatch.Draw(_introBackground, Vector2.Zero, Microsoft.Xna.Framework.Color.White);
            _newGameButton.Draw();
        }
        
    }
}
