﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    struct Cell
    {
        public int x, y;
    }
    abstract class SnakeGame
    {
        protected Cell[] snake;
        protected static int countSnake = 3;
        protected ConsoleKeyInfo key = new ConsoleKeyInfo();
        public SnakeGame(int count)
        {
            snake = new Cell[count];
        }
        public void Create()
        {
            snake[0].x = 40;
            snake[0].y = 10;
            snake[1].x = 39;
            snake[1].y = 10;
            snake[2].x = 38;
            snake[2].y = 10;
        }
    }

    class Move : SnakeGame
    {
        MoveControls movecontrols;
        public Move(int count) : base(count)
        {
            movecontrols = new MoveControlsForSnake();
        }
        private int dx = 1;
        private int dy = 0;
        public void Moving()
        {
            while (true)
            {
                for (int i = 0; i < countSnake; i++)
                {
                    Console.SetCursorPosition(snake[i].x, snake[i].y);
                    Console.WriteLine("*");
                }
                Thread.Sleep(200);
                Console.SetCursorPosition(snake[countSnake - 1].x, snake[countSnake - 1].y);
                Console.WriteLine(" ");

                for (int i = countSnake - 1; i > 0; i--)
                {
                    snake[i] = snake[i - 1];

                }
                snake[0].x += dx;
                snake[0].y += dy;
                if(Console.KeyAvailable)
                {
                    key = Console.ReadKey();
                    switch(key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            movecontrols.Up(ref dy, ref dx);
                            break;
                    }
                }
            }
        }
    }
    abstract class MoveControls
    {
        public abstract void Up(ref int dy, ref int dx);
        public abstract void Down(ref int dy, ref int dx);

    }

    class MoveControlsForSnake : MoveControls
    {
        public override void Down(ref int dy, ref int dx)
        {

        }

        public override void Up(ref int dy, ref int dx)
        {
            dy = -1;
            dx = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Move start = new Move(100);
            start.Create();
            start.Moving();

        }
    }
}
