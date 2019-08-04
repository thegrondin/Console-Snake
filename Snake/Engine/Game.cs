using Snake.Entities;
using Snake.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake.Engine
{
    class Game
    {

        public static BoardRenderer Renderer { get; set; }
        public static Entities.Snake Snake { get; set; }
        public static Food Food { get; set; }

        public static Block TestBlocks { get; set; }

        public static int Size { get; set; }
        public static bool Started = false;
        public static Move CurrentMove { get; set; } = new Move(0, 0);

        public static void Initialize(int size)
        {
            Size = size;

            Snake = new Entities.Snake(new Position { X = 5, Y = Size / 2 });

            var foodInitialRandom = new Random();

            Food = new Food(new Position { X = foodInitialRandom.Next(0, Size), Y = foodInitialRandom.Next(0, Size) });

            TestBlocks =  new Block(new Position(0, 7));

            Renderer = new BoardRenderer(Size);
            Renderer
                .AddBlocks(Snake.GetBlocks(), 0)
                .AddBlock(Food.GetBlock(), 1)
                .Render();
            

        }

        public static void Loop()
        {
            int interation = 0;

            while (true)
            {

                Console.Clear();

                var moveMode = new Position();


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            CurrentMove.Y = -1;
                            CurrentMove.X = 0;
                            Started = true;
                            break;
                        case ConsoleKey.RightArrow:
                            CurrentMove.X = 1;
                            CurrentMove.Y = 0;
                            Started = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            CurrentMove.Y = 0;
                            CurrentMove.X = -1;
                            Started = true;
                            break;
                        case ConsoleKey.DownArrow:
                            CurrentMove.X = 0;
                            CurrentMove.Y = 1;
                            Started = true;
                            break;
                        default:
                            break;
                    }

                   
                }



                if (Started)
                {
                    Snake.Move(Snake.GetHead().Position.X + CurrentMove.X, Snake.GetHead().Position.Y + CurrentMove.Y);

                }


                if (Snake.HasCollision())
                {
                    break;
                    
                }


                if (Snake.GetHead().Position.X == Food.GetBlock().Position.X && Snake.GetHead().Position.Y == Food.GetBlock().Position.Y)
                {
                    var rand = new Random();
                    Food = new Food(new Position { X = rand.Next(0, Size), Y = rand.Next(0, Size) });
                    Renderer
                        .ClearSlot(1)
                        .AddBlock(Food.GetBlock(), 1);
                    Snake.Grow();
                }

                Renderer
                     .ClearSlot(0)
                     .AddBlocks(Snake.GetBlocks(), 0)
                     .Render();


                interation++;
                Thread.Sleep(200);
            }
        }
    }
}
