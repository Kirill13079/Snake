using System;

namespace Snake.Consoles
{
    public class SnakeConsole : IWrite, ISet
    {
        private const int _mapWidth = 30;
        private const int _mapHeight = 20;
        private const int _screenWidth = _mapWidth * 3;
        private const int _screenHeight = _mapHeight * 3;
        private readonly ConsoleColor[] _colors = 
        { 
            ConsoleColor.Gray, 
            ConsoleColor.Cyan, 
            ConsoleColor.DarkBlue,
            ConsoleColor.Red
        };

        public int MapWidth => _mapWidth;
        public int MapHeight => _mapHeight;
        public int ScreenWidth => _screenWidth;
        public int ScreenHeight => _screenHeight;

        public void SetCursorPosition(int left, int top) 
            => System.Console.SetCursorPosition(left, top);

        public void WriteLine(string message)
            => System.Console.WriteLine(message);

        public void SetColor(int value) 
            => System.Console.ForegroundColor = _colors[value];

        public void Write(object value)
        {
            if (value is char)
                System.Console.Write(Convert.ToChar(value));
            else if (value is int)
                System.Console.Write(Convert.ToInt32(value));
        }

        public void SetWindowSize()
            => System.Console.SetWindowSize(_screenWidth, _screenHeight);

        public void SetBufferSize() =>
             System.Console.SetBufferSize(_screenWidth, _screenHeight);

        public void SetCursorVisible(bool value) =>
            System.Console.CursorVisible = value;
    }
}
