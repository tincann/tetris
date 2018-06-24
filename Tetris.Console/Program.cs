using System.Threading;
using Tetris.Game;

namespace Tetris.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var (width, height) = (10, 15);

            var renderer = new TetrisRenderer(width, height);
            var game = new TetrisGame(new TetrisConfig { GameWidth = width, GameHeight = height }, renderer);
            game.Run();

            System.Console.WriteLine("Done");
            System.Console.ReadKey();
        }
    }
}
