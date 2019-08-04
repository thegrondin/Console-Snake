using Snake.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Rendering
{

    struct Cell
    {
        List<Block> Blocks { get; set; }
    }

    class BoardRenderer
    {

        public static char UnicodeBox = '\u2596';

        public List<(int Id, List<dynamic> Elements)> MemorySlots { get; set; }

        public Char[,] Board { get; set; }

        public int Size { get; set; }

       

        public void Render()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ClearBoard();

            for (int i = 0; i < MemorySlots.Count; i++)
            {
                var currentSlot = MemorySlots[i];
                for (int y = 0; y < currentSlot.Elements.Count; y++)
                {
                    var currentElement = currentSlot.Elements[y];
                    if (currentElement.GetType() == typeof(List<Block>))
                    {
                        List<Block> blocks = Convert.ChangeType(currentElement, typeof(List<Block>)) as List<Block>;

                        for (int b = 0; b < blocks.Count; b++)
                        {
                            var block = blocks[b];
                            Board[block.Position.Y, block.Position.X] = UnicodeBox;
                        }
                    }
                    else
                    {
                        var block = Convert.ChangeType(currentElement, typeof(Block)) as Block;

                        Board[block.Position.Y, block.Position.X] = UnicodeBox;
                    }
                }
            }

            var boardOutput = "";

            for (int k = 0; k < Board.GetLength(0); k++)
            {
                for (int l = 0; l < Board.GetLength(1); l++)
                {
                    boardOutput += Board[k, l];
                    
                }

                boardOutput += '\n';
            }

            Console.Write(boardOutput);

          
        }

        public BoardRenderer(int size)
        {
            Size = size;
            Board = new Char[Size, Size];
            Initialize();
        }

        public void Initialize()
        {
            MemorySlots = new List<(int Id, List<dynamic> Elements)>();

            ClearBoard();
        }

        protected void ClearBoard()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    Board[y, x] = ' ';
                }
            }
        }
        
        public BoardRenderer ClearMemory()
        {
            MemorySlots.Clear();
            return this;
        }

        public BoardRenderer ClearSlot(int id)
        {
            var el = MemorySlots.Where(x => x.Id == id).FirstOrDefault();

            MemorySlots.Remove(el);
            return this;
        }

        public BoardRenderer AddBlock(Block block, int id)
        {
            if (MemorySlots.Any(m => m.Id == id))
            {
                MemorySlots
                    .Where(x => x.Id == id)
                    .FirstOrDefault()
                    .Elements
                    .Add(block);
            }
            else
            {
                MemorySlots.Add((id, new List<dynamic> { block }));
            }

            return this;
        } 

        public BoardRenderer AddBlocks(IEnumerable<Block> blocks, int id)
        {
            if (MemorySlots.Any(m => m.Id == id))
            {
                MemorySlots
                    .Where(x => x.Id == id)
                    .FirstOrDefault()
                    .Elements
                    .Add(blocks);
            }
            else
            {
                MemorySlots.Add((id, new List<dynamic> { blocks }));
            }



            return this;
        }
    }
}
