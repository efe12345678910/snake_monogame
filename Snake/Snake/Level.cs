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
    class Level
    {
        public Snake Snake { get; private set; }
        public Vector2 GridSize { get; } = new Vector2(10,10);
        private readonly int _levelRows;
        private readonly int _levelColumns;
        private readonly Texture2D _wallTexture;
        private readonly Random random;
        public Food Food { get; private set; }
        public  Rectangle GameArena { get; }
        private Food CreateFood()
        {
            int a = random.Next(0, (int)GameArena.Width / (int)GridSize.X);
            int b = random.Next(0, (int)GameArena.Height / (int)GridSize.Y);
            Vector2 position = new Vector2(a*GridSize.X, b * GridSize.Y);
            Rectangle rectangle = new Rectangle(position.ToPoint(), GridSize.ToPoint());
            //If snake is at the position , find another position (we do not want to create the food on the snake)
            if (!DoesGivenRecIntersectsWithSnakeParts(rectangle))
            {
                //Create the food
                return new Food(rectangle.Location.ToVector2(),GridSize);
            }
            else
            {
                //Find another position to create the food
                return CreateFood();
            }

        }
        /// <summary>
        /// Checks whether the given rectangle intersects with any of the snake parts
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        private bool DoesGivenRecIntersectsWithSnakeParts(Rectangle rec)
        {
            foreach (Rectangle r in Snake.SnakeParts)
            {
                if (r.Intersects(rec))
                {
                    return true;
                }
            }
            return false;
        }
        private void DrawBackground()
        {
            Globals.SpriteBatch.Draw(_wallTexture, GameArena, Color.White);
        }
        public Level()
        {
            random = new();
            _wallTexture = Contents.GetTexture2D(TextureName.Wall);
            _levelRows = Globals.SpriteBatch.GraphicsDevice.Viewport.Width / (int)GridSize.X;
            _levelColumns = Globals.SpriteBatch.GraphicsDevice.Viewport.Height / (int)GridSize.Y;
            GameArena = new Rectangle(GridSize.ToPoint().X,GridSize.ToPoint().Y, Globals.SpriteBatch.GraphicsDevice.Viewport.Bounds.Width-(int)GridSize.X*2,Globals.SpriteBatch.GraphicsDevice.Viewport.Bounds.Height-(int)GridSize.Y *2);
            Snake = new Snake(this);
            Food = CreateFood();

        }

        public void Draw()
        {
            DrawBackground();
            Snake.Draw();
            Food.Draw();
        }
        public void Update()
        {
            Snake.Update();
        }
        [Obsolete("This method is deprecated, use DrawBackground instead.This method draws the walls of the level piece by piece so it is not well optimized.")]
        private void DrawS()
        {
            for (int i = 0; i < _levelRows; i++)
            {
                Globals.SpriteBatch.Draw(_wallTexture, new Vector2(i * GridSize.X, 0), Color.White);
                Globals.SpriteBatch.Draw(_wallTexture, new Vector2(i * GridSize.X, (_levelColumns - 1) * GridSize.Y), Color.White);
            }
            for (int i = 0; i < _levelColumns; i++)
            {
                Globals.SpriteBatch.Draw(_wallTexture, new Vector2(0, i * GridSize.Y), Color.White);
                Globals.SpriteBatch.Draw(_wallTexture, new Vector2(GridSize.X * (_levelRows - 1), i * GridSize.Y), Color.White);
            }
        }
    }
}
