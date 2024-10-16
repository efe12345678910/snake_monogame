﻿using Microsoft.Xna.Framework;
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
        public int Score { get; private set; }
        public enum DirectionFacing {Right, Up, Left, Down}
        public readonly Texture2D Texture;
        private Level _level;
        private DirectionFacing _currentDirection =DirectionFacing.Right;
        private float _movementInterval = 0.05f;
        private float _lastMovementTime;
        private bool _hasAlreadyTurned = false;
        private int _snakeStartingLenght = 5;
        public Vector2 LastPositionOfLastSnakePart { get; private set; }
        private Vector2 _startingPosition = new Vector2(60, 10);
        public Vector2 PositionHead { get; private set; }
        public List<Rectangle> SnakeParts { get; private set; } = new List<Rectangle>();
        public List<Vector2> Positions { get; private set; } = new List<Vector2>();
        public Snake(Level level)
        {
            Texture = Contents.GetTexture2D(TextureName.Snake);
            PositionHead = _startingPosition;
            _level = level;
            _lastMovementTime = Globals.Time;
            InitializePositionsAndRects();
            InputManager.RightArrowPressed += TurnRight;
            InputManager.LeftArrowPressed += TurnLeft;
            Debug.WriteLine("Snake created");

        }
        private void InitializePositionsAndRects()
        {
            for(int i = 0; i < _snakeStartingLenght; i++)
            {
                Positions.Insert(0, new Vector2(PositionHead.X - i * _level.GridSize.X, PositionHead.Y));
            }
            for (int i=0; i < _snakeStartingLenght; i++)
            {
                SnakeParts.Insert(0, new Rectangle(Positions[i].ToPoint(), _level.GridSize.ToPoint()));
            }
        }
        private void CheckCollision()
        {
            //We do not check for the last item of the SnakeParts list because it is the head and we do not want to see whether the rectangle of the head intersects with itself
            for (int i = 0; i < SnakeParts.Count-1; i++)
            {
                if (SnakeParts[i].Intersects(SnakeParts[SnakeParts.Count - 1])|| !_level.GameArena.Contains(SnakeParts[SnakeParts.Count - 1]))
                {
                    _level.GameManager.ChangeState(GameStateManager.GameStateEnum.GameOver);
                }
            }
        }
        private bool CheckIfEatenFood()
        {
            if (SnakeParts[SnakeParts.Count - 1].Intersects(_level.Food.Rectangle))
            {
                Score++;
                return true;
            }
            else return false;
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
            if (Globals.Time - _lastMovementTime >= _movementInterval)
            {
                MoveForward();
                _lastMovementTime = Globals.Time;
            }
            CheckIfEatenFood();
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
            LastPositionOfLastSnakePart = SnakeParts[0].Location.ToVector2();
            Positions.RemoveAt(0);
            Positions.Insert(Positions.Count,PositionHead);
            for(int i = 0; i<Positions.Count; i++)
            {
                SnakeParts[i] = new Rectangle(Positions[i].ToPoint(), _level.GridSize.ToPoint());
            }
            CheckCollision();
            if (CheckIfEatenFood())
            {
                Debug.WriteLine("FOOD EATEN!");
                Positions.Insert(0, LastPositionOfLastSnakePart);
                SnakeParts.Insert(0, new Rectangle(LastPositionOfLastSnakePart.ToPoint(), _level.GridSize.ToPoint()));
                _level.CreateFood();
            }
            _hasAlreadyTurned = false;
        }
        public void TurnLeft()
        {
            if (!_hasAlreadyTurned)
            {
                _currentDirection = (DirectionFacing)((int)(_currentDirection + 1) % 4);
            }
            _hasAlreadyTurned = true;
        }
        public void TurnRight()
        {
            if (!_hasAlreadyTurned)
            {
                _currentDirection = (DirectionFacing)((int)(_currentDirection - 1 + 4) % 4);
            }
            _hasAlreadyTurned = true;
        }

    }
}
