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
    internal class Snake
    {
        public enum DirectionFacing {Right, Up, Left, Down}
        public readonly Texture2D Texture;
        private Level _level;
        private DirectionFacing _currentDirection =DirectionFacing.Right;
        private float _movementInterval = 0.5f;
        private float _lastMovementTime;
        private bool _isMovementInProgress=true;
        public int SnakeLength { get; private set; }
        private int _snakeStartingLenght = 3;
        public Vector2 PositionHead { get; private set; }
        public Rectangle SnakeHead { get; private set; }
        public List<Rectangle> SnakeParts { get; private set; } = new List<Rectangle>();
        public List<Vector2> Positions { get; private set; } = new List<Vector2>();
        public Snake(Level level)
        {
            Texture = Contents.GetTexture2D(TextureName.Snake);
            SnakeLength = _snakeStartingLenght;
            PositionHead = new Vector2(20,0);
            _level = level;
            _lastMovementTime = Globals.Time;
            SnakeHead = new Rectangle(PositionHead.ToPoint(), _level.GridSize.ToPoint());
            InitializePositionsAndRects();
            InputManager.RightArrowPressed += TurnRight;
            InputManager.LeftArrowPressed += TurnLeft;

        }
        private void InitializePositionsAndRects()
        {
            Positions.Insert(0, new Vector2(0,0));
            Positions.Insert(0, new Vector2(10, 0));
            Positions.Insert(0, PositionHead);
            for (int i=0; i < SnakeLength; i++)
            {
                SnakeParts.Insert(0,new Rectangle(Positions[i].ToPoint(), _level.GridSize.ToPoint()));
            }
        }
        private void CheckCollision()
        {
            foreach (Rectangle part in SnakeParts)
            {
                if (part != SnakeHead && SnakeHead.Intersects(part))
                {
                    Debug.WriteLine("GAME OVER!");
                }
            }
        }
        public void Draw()
        {
            for (int i = 0; i<Positions.Count; i++)
            {
                Globals.SpriteBatch.Draw(Texture, Positions[i], Microsoft.Xna.Framework.Color.White);
            }
        }
        public void Update()
        {
            SnakeHead = new Rectangle(PositionHead.ToPoint(), _level.GridSize.ToPoint());
            if (Globals.Time - _lastMovementTime >= _movementInterval)
            {
                MoveForward();
                _lastMovementTime = Globals.Time;
            }
            CheckCollision();

        }
        
        //Take care that positive Y coordinate means down in Monogame
        public void MoveForward()
        {
            switch (_currentDirection)
            {
                case DirectionFacing.Up:
                    PositionHead -= new Vector2(0, _level.GridSize.Y);
                    break;
                case DirectionFacing.Down:
                    PositionHead += new Vector2(0, _level.GridSize.Y);
                    break;
                case DirectionFacing.Right:
                    PositionHead += new Vector2(_level.GridSize.X, 0);
                    break;
                case DirectionFacing.Left:
                    PositionHead -= new Vector2(_level.GridSize.X, 0);
                    break;
                default:
                    break;
            }
            Positions.Insert(0, PositionHead);
            Positions.RemoveAt(Positions.Count - 1);
        }
        public void TurnLeft()
        {
            _currentDirection = (DirectionFacing)((int)(_currentDirection + 1) % 4);
            Debug.WriteLine("turn left");
            Debug.WriteLine($"{_currentDirection}");
            Debug.WriteLine($"{_level.GridSize.Y}");

        }
        public void TurnRight()
        {
            _currentDirection = (DirectionFacing)((int)(_currentDirection - 1+4) % 4);
            Debug.WriteLine("turn right");
            Debug.WriteLine($"{_currentDirection}");
        }

    }
}
