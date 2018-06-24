using System.Threading;

namespace Tetris.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var renderer = new TetrisRenderer();
            var block = Block.FromShape(
                "X   ",
                "X   ",
                "X   ",
                "X   ");
            renderer.AddBlock(block);
            while (true)
            {
                block.MoveDown();
                renderer.Draw();
                Thread.Sleep(500);

                if (block.Position.y > 15)
                {
                    break;
                }
            }

            System.Console.ReadKey();
        }
    }
}
