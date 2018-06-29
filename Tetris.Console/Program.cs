using System.Threading;
using Tetris.Game;

namespace Tetris.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var (width, height) = (20, 15);

            var renderer = new TetrisConsoleRenderer(width, height);
            var controller = new TetrisConsoleController();

            do
            {
                var game = new TetrisGame(new TetrisConfig { GameWidth = width, GameHeight = height }, renderer, controller);
                game.Run();
                Thread.Sleep(1000);
            } while (true);
        }
    }
}
