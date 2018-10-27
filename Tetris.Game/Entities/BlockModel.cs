using Tetris.Game.Constants;
using Tetris.Utility;

namespace Tetris.Game.Entities
{
    public class BlockModel
    {
        public int[,] Shape { get; private set; }
        public int MaxWidth => Shape.GetLength(0);
        public int MaxHeight => Shape.GetLength(1);

        public int Type { get; private set; }

        public Block Spawn(int x, int y, BlockOrientation orientation)
        {
            return new Block(this, x, y, orientation);
        }

        public static BlockModel FromShape(int type, params string[] shape)
        {
            return new BlockModel
            {
                Type = type,
                Shape = GridHelper.CreateFromString(type, shape)
            };
        }
    }
}
