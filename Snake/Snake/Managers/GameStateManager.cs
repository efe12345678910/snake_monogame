using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal static class GameStateManager
    {
        public enum GameStateEnum
        {
            Play,
            Pause,
            GameOver,
            Intro
        }
        public static  Dictionary<GameStateEnum,GameState> gameStates = new Dictionary<GameStateEnum, GameState>();
        static GameStateManager()
        {
            gameStates.Add(GameStateEnum.Play, new PlayState());
            gameStates.Add(GameStateEnum.Pause, new PauseState());
            gameStates.Add(GameStateEnum.GameOver, new GameOverState());
            gameStates.Add(GameStateEnum.Intro, new IntroMenuState());
        }
        
    }
}
