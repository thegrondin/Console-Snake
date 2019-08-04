using Snake.Engine;
using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Initialize(15);
            Game.Loop();

            Console.WriteLine("Vous Avez perdu, Bravo ! ");
        }
    }
}
