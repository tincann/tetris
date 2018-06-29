using System.Collections;
using System.Diagnostics;
using System.Linq;
using Tetris.Game.Constants;
using Tetris.Game.Entities;
using Tetris.Utility;

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
            return new BlockModel
            {
                Shape = GridHelper.CreateFromString(shape)
            };
        }
    }
}
