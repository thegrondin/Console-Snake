using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Entities
{
    class Block
    {
        public bool IsHead { get; set; }
        public Position Position { get; set; }
        public int Id { get; set; }

        public Block (Position position, bool isHead = false)
        {
            IsHead = isHead;
            Position = position;
        }

        public Block()
        {
            Position = new Position();
        }
    }
}
