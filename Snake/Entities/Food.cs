using Snake.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Entities
{
    class Food
    {
        public Block Block { get; set; } 

        public Food(Position Position)
        {
            Block = new Block(Position);
            
        }

        public Food () { }

        public Block GetBlock()
        {
            return Block;
        }
    }
}
