using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Entities
{
    class SnakeBlock : Block
    {

        public bool IsHead { get;}

        public SnakeBlock(Position pos, bool isHead) : base(pos)
        {

            IsHead = isHead;

        }
    }
}
