using Snake.Consoles;
using Snake.Keys;
using Snake.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Games
{
    public class Snake : IDraw, IClear, IScore
    {
        private readonly SnakeConsole _console;
        private readonly Queue<MyUnit> _body = new Queue<MyUnit>();

        private int _score = 0;
        private MyUnit _head;
        private GameStateHandler _notifyGameState;

        public Snake(int initialX, int initialY, SnakeConsole console, int bodyLength = 3)
        {
            _console = console;
            _head = new MyUnit(x: initialX, y: initialY, console);

            for (int i = bodyLength; i >= 0; i--)
                _body.Enqueue(new MyUnit(x: _head.X - i - 1, y: initialY, console));

            Draw();
        }
        public MyUnit Head => _head;
        public Queue<MyUnit> Body => _body;

        public int Score 
        { 
            get { return _score; }
            set { _score = value; } 
        }

        public delegate void GameStateHandler(object sendet, MessageEventArgs args);
        public event GameStateHandler GameState 
        {
            add { _notifyGameState += value; }
            remove { _notifyGameState -= value; } 
        }

        public bool Move(Direction direction, bool eat = false)
        {
            Clear();
            _body.Enqueue(new MyUnit(x: _head.X, y: _head.Y, _console));

            if (!eat)
                _body.Dequeue();
            else 
                _score++;

            _head = direction switch
            {
                Direction.Right => new MyUnit(x: _head.X + 1, y: _head.Y, _console),
                Direction.Left => new MyUnit(x: _head.X - 1, y: _head.Y, _console),
                Direction.Up => new MyUnit(x: _head.X, y: _head.Y - 1, _console),
                Direction.Down => new MyUnit(x: _head.X, y: _head.Y + 1, _console),
                _ => _head
            };

            Draw();

            if (_head.X == _console.MapWidth - 1
                    || _head.X == 0
                    || _head.Y == _console.MapHeight - 1
                    || _head.Y == 0
                    || _body.Any(body => body.X == _head.X && body.Y == _head.Y))
            {
                _notifyGameState?.Invoke(this, new MessageEventArgs($"Score {_score}. Game Over"));
                return false;
            }

            return true;
        }

        public void Draw()
        {
            _console.SetColor(1);
            _head.Draw();

            _console.SetColor(2);
            foreach (MyUnit unit in _body)
                unit.Draw();
        }

        public void Clear()
        {
            _head.Clear();
            foreach (MyUnit unit in _body)
                unit.Clear();
        }
    }
}
