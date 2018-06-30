using System.Collections.Generic;

namespace Tetris.Game.Constants
{
    public class BlockOrientation
    {
        public static IList<BlockOrientation> Orientations => new[]
            {Up, Right, Down, Left};

        public static readonly BlockOrientation Up = new BlockOrientation(0, -1);
        public static readonly BlockOrientation Right = new BlockOrientation(1, 0);
        public static readonly BlockOrientation Down = new BlockOrientation(0, 1);
        public static readonly BlockOrientation Left = new BlockOrientation(-1, 0);

        public (int dx, int dy) Vector { get; }

        public BlockOrientation RotateLeft()
        {
            return new BlockOrientation(Vector.dy, -Vector.dx);
        }

        public BlockOrientation RotateRight()
        {
            return new BlockOrientation(-Vector.dy, Vector.dx);
        }

        private BlockOrientation(int dx, int dy)
        {
            Vector = (dx, dy);
        }
    }
}
