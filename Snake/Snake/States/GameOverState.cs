using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private Texture2D _gameoverTexture;
        private Button _restartButton;
        private Button _returnButton;
        private SpriteFont _font;
        public GameOverState()
        {
            _gameoverTexture = Contents.TextureDict[TextureName.Gameover];
            _restartButton = new RestartButton("Restart Game",new Vector2(400,100));
            _returnButton = new ReturnToMainMenuButton("Return to Main Menu", new Vector2(400, 200));
            buttons.Add(_restartButton);
            buttons.Add(_returnButton);
            _font = Contents.FontDict[FontName.Default];
        }
        public override void Update(GameManager gm)
        {
        }
        public override void Draw(GameManager gm)
        {
            Globals.SpriteBatch.Draw(_gameoverTexture, Vector2.Zero, Microsoft.Xna.Framework.Color.White);
            Globals.SpriteBatch.DrawString(_font, "Game Over!\nScore: " + gm.Level.Snake.Score, new Vector2(100, 100), Microsoft.Xna.Framework.Color.Red,0,Vector2.Zero,3,SpriteEffects.None,1);
            _restartButton.Draw();
            _returnButton.Draw();
        }
    }
}
