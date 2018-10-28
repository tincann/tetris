using System;
using Tetris.Game.Constants;
using Tetris.Game.Controls;

namespace Tetris.App.Controllers
{
    public class TetrisConsoleController : ITetrisController
    {
        public GameAction GetKeyState()
        {
            if (!System.Console.KeyAvailable)
            {
                return GameAction.None;
            }

            var key = System.Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    return GameAction.MoveLeft;
                case ConsoleKey.RightArrow:
                    return GameAction.MoveRight;
                case ConsoleKey.DownArrow:
                    return GameAction.MoveDown;
                case ConsoleKey.UpArrow:
                    return GameAction.Rotate;
                case ConsoleKey.Escape:
                    return GameAction.Pause;
                default:
                    return GameAction.None;
            }
        }
    }
}
