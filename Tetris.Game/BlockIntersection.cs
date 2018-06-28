using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Utility;

namespace Tetris.Game
{
    public static class BlockIntersection
    {
        public static bool Intersects(Block block1, Block block2)
        {
            //if (!Overlaps(block1, block2))
            //{
            //    return false;
            //}

            var shift = (x: block2.Position.x - block1.Position.x, y: block2.Position.y - block1.Position.y);

            foreach (var b1Pos in block1.Shape.GetCoordinates())
            {
                var b2Pos = (x: b1Pos.x - shift.x, y: b1Pos.y - shift.y);

                if (block2.Shape.WithinBounds(b2Pos))
                {
                    if (block2.Shape[b2Pos.x, b2Pos.y] && block1.Shape[b1Pos.x, b1Pos.y])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //private static bool Overlaps(Block block1, Block block2)
        //{
        //    var b1 = block1.Bounds;
        //    var b2 = block2.Bounds;
        //    return b1.x1 < b2.x2 && b1.x2 > b2.x1 &&
        //           b1.y1 < b2.y2 && b1.y2 > b2.y1;
        //}
    }
}
