using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class GameManager
    {
        public GameState GameState { get; private set; }
        public Level Level { get; private set; }
        public GameManager()
        {
            ChangeState(GameStateManager.GameStateEnum.Play);
            Level = new Level(this);
            InputManager.RKeyPressed += Restart;
            InputManager.PauseKeyPressed += PauseTheGame;
        }
        private void PauseTheGame()
        {
            if (GameState is not PauseState)
            {
                ChangeState(GameStateManager.GameStateEnum.Pause);
            }
            else
            {
                ChangeState(GameStateManager.GameStateEnum.Play);
            }
        }
        public void ChangeState(GameStateManager.GameStateEnum gameState)
        {
            GameState = GameStateManager.gameStates[gameState];
        }
        public void Update()
        {
            InputManager.Update();
            GameState.Update(this);
        }
        public void Draw()
        {
            GameState.Draw(this);
        }
        public void Restart()
        {
            Level = new Level(this);
            ChangeState(GameStateManager.GameStateEnum.Play);
        }
    }
}
