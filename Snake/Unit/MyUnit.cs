using System;
using Snake.Consoles;

namespace Snake.Unit
{
    public class MyUnit : IUnit, IDraw, IClear
    {
        private const char @char = '█';

        private readonly SnakeConsole _console;
        private readonly int _x;
        private readonly int _y;
        private readonly int _pixelSize;

        public MyUnit(int x, int y, SnakeConsole console, int pixelSize = 3)
        {
            _x = x;
            _y = y;
            _console = console;
            _pixelSize = pixelSize;
        }

        public int X => _x;
        public int Y => _y;

        public void Draw()
        {
            for (int x = 0; x < _pixelSize; x++)
            {
                for (int y = 0; y < _pixelSize; y++)
                {
                    _console.SetCursorPosition(_x * _pixelSize + x, _y * _pixelSize + y);
                    _console.Write(@char);
                }
            }
        }

        public void Clear()
        {
            for (int x = 0; x < _pixelSize; x++)
            {
                for (int y = 0; y < _pixelSize; y++)
                {
                   _console.SetCursorPosition(_x * _pixelSize + x, _y * _pixelSize + y);
                   _console.Write(' ');
                }
            }
        }
    }
}
