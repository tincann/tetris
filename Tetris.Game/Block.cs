using System.Diagnostics;
using System.Linq;

namespace Tetris.Console
{
    public class Block
    {
        private Block() { }

        public (int x, int y) Position { get; private set; }

        public bool[,] Shape { get; private set; }

        public BlockOrientation Orientation { get; private set; }


        public void MoveDown()
        {
            Position = (Position.x, Position.y + 1);
        }

        public void RotateLeft()
        {
            Orientation = (BlockOrientation)(((int)Orientation - 1) % 4);
        }

        public void RotateRight()
        {
            Orientation = (BlockOrientation)(((int)Orientation + 1) % 4);
        }

        public static Block FromShape(params string[] shape)
        {
            (int maxWidth, int maxHeight) = (4, 4);
            Debug.Assert(shape.Length == maxHeight && shape.First().Length == maxWidth);

            var b = new Block();
            b.Shape = new bool[maxWidth, maxHeight];

            for (var y = 0; y < maxHeight; y++)
            for (var x = 0; x < maxWidth; x++)
            {
                b.Shape[x, y] = shape[y][x] != ' ';
            }

            return b;
        }
    }
}