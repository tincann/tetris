using Tetris.Game.Constants;
using Tetris.Game.Entities;

namespace Tetris.Game.Test
{
    public class TestBlock : Block
    {
        private TestBlock(BlockModel model, int x, int y, BlockOrientation orientation) : base(model, x, y, orientation)
        {
        }
        public Block At(int x, int y, BlockOrientation orientation = null)
        {
            return new TestBlock(Model, x, y, orientation ?? BlockOrientation.Up);
        }

        public static TestBlock Create(params string[] shape)
        {
            return new TestBlock(BlockModel.FromShape(1, shape), 0, 0, BlockOrientation.Up);
        }
    }
}
