using System.Collections;
using System.Diagnostics;
using System.Linq;

namespace Tetris.Game
{
    public class BlockModel
    {
        public bool[,] Shape { get; private set; }
        public int MaxWidth => Shape.GetLength(0);
        public int MaxHeight => Shape.GetLength(1);

        public Block Spawn(int x, int y, BlockOrientation orientation = BlockOrientation.North)
        {
            return new Block(this, x, y, orientation);
        }

        public static BlockModel FromShape(params string[] shape)
        {
            (int maxWidth, int maxHeight) = (5, 5);
            Debug.Assert(shape.Length == maxHeight && shape.First().Length == maxWidth);

            var b = new BlockModel
            {
                Shape = new bool[maxWidth, maxHeight]
            };

            for (var y = 0; y < maxHeight; y++)
            for (var x = 0; x < maxWidth; x++)
            {
                b.Shape[x, y] = shape[y][x] != ' ';
            }

            return b;
        }
    }
}
