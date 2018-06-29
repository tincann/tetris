using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Game.Constants
{
    public class MoveDirection
    {
        public static readonly MoveDirection Left = new MoveDirection(-1, 0);
        public static readonly MoveDirection Right = new MoveDirection(1, 0);
        public static readonly MoveDirection Down = new MoveDirection(0, 1);

        public (int dx, int dy) Vector { get; }
        private MoveDirection(int dx, int dy)
        {
            Vector = (dx, dy);
        }
    }
}
