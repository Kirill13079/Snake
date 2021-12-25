using Snake.Consoles;
using Snake.Unit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Games
{
    public class Board : IDraw
    {
        private readonly SnakeConsole _console;
        public Board(SnakeConsole console) 
            => _console = console;

        public void Draw()
        {
            _console.SetColor(1);

            for (int i = 0; i < _console.MapWidth; i++)
            {
                new MyUnit(x: i, y: 0, _console).Draw();
                new MyUnit(x: i, y: _console.MapHeight - 1, _console).Draw();
            }

            for (int i = 0; i < _console.MapHeight; i++)
            {
                new MyUnit(x: 0, y: i, _console).Draw();
                new MyUnit(x: _console.MapWidth - 1, y: i, _console).Draw();
            }
        }
    }
}
