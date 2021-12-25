using System;
using System.Diagnostics;

namespace Snake.Keys
{
    public class SnakeKey
    {
        private readonly int _frame;
        private Stopwatch _sw;
        private Direction _currentDirection;

        public SnakeKey(int frame, Direction startDirection) 
        {
            _frame = frame;
            _currentDirection = startDirection;
        }

        public Direction CurrentDirection
            => _currentDirection;

        private Direction ReadDirection()
        {
            if (!Console.KeyAvailable)
                return _currentDirection;

            ConsoleKey key = Console.ReadKey(true).Key;

            _currentDirection = key switch
            {
                ConsoleKey.UpArrow when _currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when _currentDirection != Direction.Up => Direction.Down,
                ConsoleKey.LeftArrow when _currentDirection != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when _currentDirection != Direction.Left => Direction.Right,
                _ => _currentDirection
            };

            return _currentDirection;
        }

        public Direction СhangeDirection()
        {
            while (_sw.ElapsedMilliseconds <= _frame)
                    _currentDirection = ReadDirection();

            return _currentDirection;
        }

        public void StartReadKey()
        { 
            _sw = new Stopwatch(); 
        }

        public void RestartReadKey() => _sw.Restart(); 
    }
}
