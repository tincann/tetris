using System.Collections.Generic;
using Tetris.Utility;

namespace Tetris.Game
{
    public class BlockGrid
    {
        private readonly bool[,] _grid;

        public int Width => _grid.GetLength(0);
        public int Height => _grid.GetLength(1);

        public bool[,] Blocks => CopyGrid();

        private BlockGrid(bool[,] grid)
        {
            _grid = grid;
        }

        public BlockGrid(int width, int height)
        {
            _grid = new bool[width, height];
        }

        public bool Intersects(Block block, (int dx, int dy) offset)
        {
            foreach (var (bx, by) in block.Shape.GetCoordinates())
            {
                if(!block.Shape[bx, by]) continue;
                
                var (x, y) = (block.Position.x + bx + offset.dx, block.Position.y + by + offset.dy);
                if (!_grid.WithinBounds(x, y))
                {
                    return true;
                }
                    
                if(_grid[x, y])
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

        private bool[,] CopyGrid()
        {
            var copy = new bool[_grid.GetLength(0), _grid.GetLength(1)];
            foreach (var (x, y) in _grid.GetCoordinates())
            {
                copy[x, y] = _grid[x, y];
            }
            return copy;
        }

        public static BlockGrid CreateFromShape(params string[] shape)
        {
            var grid = GridHelper.CreateFromString(shape);
            return new BlockGrid(grid);
        }
    }
}
