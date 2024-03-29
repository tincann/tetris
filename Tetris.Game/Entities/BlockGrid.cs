﻿using System.Collections.Generic;
using System.Linq;
using Tetris.Utility;

namespace Tetris.Game.Entities
{
    public class BlockGrid
    {
        private readonly int[,] _grid;

        public int Width => _grid.GetLength(0);
        public int Height => _grid.GetLength(1);

        public int[,] Blocks => CopyGrid();

        private BlockGrid(int[,] grid)
        {
            _grid = grid;
        }

        public BlockGrid(int width, int height)
        {
            _grid = new int[width, height];
        }

        public ICollection<int> GetFullRows()
        {
            return _grid.GetRows()
                .Where(r => r.cols.All(c => c != 0))
                .Select(x => x.row)
                .ToList();
        }

        public void DeleteRowAndShiftDown(int rowNumber)
        {
            for (var y = rowNumber; y > 0; y--)
            {
                for (var x = 0; x < _grid.GetLength(0); x++)
                {
                    var row = _grid.GetRow(y - 1);
                    _grid.SetRow(y, row);
                }
            }
        }

        public bool Intersects(Block block)
        {
            return Intersects(block, (0, 0));
        }

        public bool Intersects(Block block, (int dx, int dy) offset)
        {
            foreach (var (bx, by) in block.Shape.GetCoordinates())
            {
                if(block.Shape[bx, by] == 0) continue;
                
                var (x, y) = (block.Position.x + bx + offset.dx, block.Position.y + by + offset.dy);
                if (!_grid.WithinBounds(x, y))
                {
                    return true;
                }
                    
                if(_grid[x, y] != 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void Freeze(Block block)
        {
            _grid.Imprint(block.Shape, block.Position);
        }

        private int[,] CopyGrid()
        {
            var copy = new int[_grid.GetLength(0), _grid.GetLength(1)];
            foreach (var (x, y) in _grid.GetCoordinates())
            {
                copy[x, y] = _grid[x, y];
            }
            return copy;
        }

        //public static BlockGrid CreateFromShape(params string[] shape)
        //{
        //    var grid = GridHelper.CreateFromString(shape);
        //    return new BlockGrid(grid);
        //}
    }
}
