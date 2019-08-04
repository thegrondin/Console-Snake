using Snake.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Entities
{
    class Snake
    {

        public int Size { get; set; }
        public List<Block> Body { get; set; } = new List<Block>();
        public bool FullyStarted { get; set; } = false;
        public int NumberOfMoves { get; set; } = 0;
           
        public Snake(Position initialPosition)
        {
            Size = 4;
            var initialSize = 4;
            for (int i = 0; i < initialSize; i++)
            {
                var pos = new Position
                {
                    X = initialPosition.X + i,
                    Y = initialPosition.Y
                };

                if (i == 0)
                {
                    Body.Add(new Block(pos, true));
                }
                else
                {
                    Body.Add(createBlock(pos));
                }
            }
        }

        public bool HasCollision()
        {
            if (FullyStarted)
            {
                foreach(var block in Body)
                {
                    if (block != Body[0] && block.Position.X == Body[0].Position.X && block.Position.Y == Body[0].Position.Y)
                    {
                        return true;
                    }  
                }
            }
            return false;
        }

        public void Move(int x, int y)
        {
            Position prevPosition = null;
            for (int i = 0; i < Body.Count; i++)
            {
                if (i == 0)
                {
                    prevPosition = new Position { X = Body[i].Position.X, Y = Body[i].Position.Y };
                    Body[i].Position = new Position(x ,y);
                }
                else
                {
                    var temp = Body[i].Position;
                    Body[i].Position = prevPosition;
                    prevPosition = new Position { X = temp.X, Y = temp.Y };
                }   
            }

            NumberOfMoves++;
            if (NumberOfMoves >= Size && !FullyStarted)
            {
                FullyStarted = true;
            }
        }

        public void Grow()
        {
            Body.Add(new Block());
        }

        public Block GetHead()
        {
            return Body[0];
        }

        public IEnumerable<Block> GetBlocks()
        {
            return Body;
        }

        protected Block createBlock(Position position)
        {
            return new Block(position);
        }
    }
}
