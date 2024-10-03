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
    internal class Snake
    {
        public enum DirectionFacing {Right, Up, Left, Down}
        public readonly Texture2D Texture;
        private Level _level;
        private DirectionFacing _currentDirection =DirectionFacing.Right;
        private float _movementInterval = 0.5f;
        private float _lastMovementTime;
        private bool _isMovementInProgress=true;
        public Vector2 Position { get; private set; }
        public Snake(Level level)
        {
            Texture = Contents.GetTexture2D(TextureName.Snake);
            _level = level;
            _lastMovementTime = Globals.Time;
            InputManager.RightArrowPressed += TurnRight;
            InputManager.LeftArrowPressed += TurnLeft;

        }
        public void Update()
        {
            if(Globals.Time - _lastMovementTime >= _movementInterval)
            {
                MoveForward();
                _lastMovementTime = Globals.Time;
            }
            
        }
        public void MoveForward()
        {
            switch (_currentDirection)
            {
                case DirectionFacing.Up:
                    Position -= new Vector2(0, _level.GridSize.Y);
                    break;
                case DirectionFacing.Down:
                    Position += new Vector2(0, _level.GridSize.Y);
                    break;
                case DirectionFacing.Right:
                    Position += new Vector2(_level.GridSize.X, 0);
                    break;
                case DirectionFacing.Left:
                    Position -= new Vector2(_level.GridSize.X, 0);
                    break;
                default:
                    break;
            }
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
