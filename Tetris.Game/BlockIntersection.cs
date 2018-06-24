using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Game
{
    public static class BlockIntersection
    {
        public static bool Intersects(Block block1, Block block2)
        {
            return Overlaps(block1, block2);

            //todo check if Shapes intersect
            //return true;
        }

        private static bool Overlaps(Block block1, Block block2)
        {
            var b1 = block1.Bounds;
            var b2 = block2.Bounds;
            return b1.x1 <= b2.x2 && b1.x2 >= b2.x1 &&
                   b1.y1 <= b2.y2 && b1.y2 >= b2.y1;
        }
    }
}
