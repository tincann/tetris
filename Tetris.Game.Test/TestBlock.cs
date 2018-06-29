using Tetris.Game.Constants;
using Tetris.Game.Entities;

namespace Tetris.Game.Test
{
    public class TestBlock : Block
    {
        private TestBlock(BlockModel model, int x, int y, BlockOrientation orientation) : base(model, x, y, orientation)
        {
        }
        public Block At(int x, int y, BlockOrientation orientation = BlockOrientation.North)
        {
            return new TestBlock(Model, x, y, orientation);
        }

        public static TestBlock Create(params string[] shape)
        {
            return new TestBlock(BlockModel.FromShape(shape), 0, 0, BlockOrientation.North);
        }
    }
}
