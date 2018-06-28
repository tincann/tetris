using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Game.Test
{
    public class TestBlock : Block
    {
        public TestBlock(BlockModel model, int x, int y, BlockOrientation orientation) : base(model, x, y, orientation)
        {
        }
        public void Pos(int x, int y)
        {
            Position = (x, y);
        }
    }
}
