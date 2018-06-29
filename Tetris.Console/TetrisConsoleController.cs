using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Game.Constants;
using Tetris.Game.Controls;

namespace Tetris.Console
{
    public class TetrisConsoleController : ITetrisController
    {
        public GameAction GetKeyState()
        {
            if (!System.Console.KeyAvailable)
            {
                return GameAction.None;
            }

            var key = System.Console.ReadKey(false);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    return GameAction.MoveLeft;
                case ConsoleKey.RightArrow:
                    return GameAction.MoveRight;
                case ConsoleKey.DownArrow:
                    return GameAction.MoveDown;
                case ConsoleKey.Escape:
                    return GameAction.Pause;
                default:
                    return GameAction.None;
            }
        }
    }
}
