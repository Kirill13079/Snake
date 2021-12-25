using Snake.Consoles;
using Snake.Unit;
using System;
using System.Collections.Generic;
using static System.Console;
using System.Threading;
using Snake.Games;
using Snake.Keys;
using System.Linq;

namespace Snake
{
    class Program
    {
        static SnakeConsole snakeConsole = new SnakeConsole();
        static SnakeKey snakeKey = new SnakeKey(frame: 200, startDirection: Direction.Right);
        static Board board = new Board(snakeConsole);

        static void Main()
        {
            snakeConsole.SetWindowSize();
            snakeConsole.SetBufferSize();
            snakeConsole.SetCursorVisible(false);
            while (true)
            {
                board.Draw();
                StartGame();
                ReadKey();
            }           
        }

        static void StartGame()
        {

            Games.Snake snake = new Games.Snake(10, 5, snakeConsole);
            Food food = new Food(snake, snakeConsole);
            food.GenerationFood();
            food.Draw();

            snakeKey.StartReadKey();
            while (true)
            {
                snakeKey.RestartReadKey();
                snakeKey.СhangeDirection();
                snake.GameState += GameState;

                bool move;
                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    move = snake.Move(snakeKey.CurrentDirection, true);
                    food.GenerationFood();
                    food.Draw();
                }
                else
                    move = snake.Move(snakeKey.CurrentDirection);

                if (!move)
                    break;
            }

        }

        static void GameState(object sendet, MessageEventArgs e)
        {
            snakeConsole.SetCursorPosition(snakeConsole.ScreenWidth / 3, snakeConsole.ScreenHeight / 3);
            snakeConsole.SetColor(3);
            snakeConsole.WriteLine(e.Message);
        }
    }
}
