using Snake.Consoles;
using Snake.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Games
{
    public class Food : IDraw
    {
        private readonly Random _random = new Random();
        private readonly Snake _snake;
        private readonly SnakeConsole _console;

        private MyUnit _food;

        public Food(Snake snake, SnakeConsole console) 
        {
            _snake = snake;
            _console = console;
        }
        public int X => _food.X;
        public int Y => _food.Y;

        public void Draw() =>
            _food.Draw();

        public MyUnit GenerationFood() 
        {
            do 
            {
                _console.SetColor(3);
                _food = new MyUnit(x: _random.Next(1, _console.MapWidth - 2), y: _random.Next(1, _console.MapHeight - 2), _console);

            } while (_snake.Head.X == _food.X && _snake.Head.Y == _food.Y
            || _snake.Body.Any(body => body.X == _food.X && body.Y == _food.Y));

            return _food;   
        }
    }
}
