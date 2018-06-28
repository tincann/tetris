using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Tetris.Utility
{
    public static class GridHelper
    {
        public static bool[,] CreateFromString(params string[] shape)
        {
            Debug.Assert(shape.Select(x => x.Length).Distinct().Count() == 1, "Given shape is not rectangular");
            (int maxWidth, int maxHeight) = (shape.First().Length, shape.Length);

            var grid = new bool[maxWidth, maxHeight];

            for (var y = 0; y < maxHeight; y++)
            for (var x = 0; x < maxWidth; x++)
            {
                grid[x, y] = shape[y][x] != ' ';
            }

            return grid;
        }
    }
}
