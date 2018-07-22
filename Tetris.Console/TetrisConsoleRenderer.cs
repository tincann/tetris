using System.Linq;
using System.Text;
using Tetris.Game;
using Tetris.Game.Render;
using Tetris.Utility;

namespace Tetris.Console
{
    public class TetrisConsoleRenderer : ITetrisRenderer
    {
        private readonly int _gridWidth;
        private readonly int _gridHeight;

        public TetrisConsoleRenderer(int gridWidth, int gridHeight)
        {
            _gridWidth = gridWidth;
            _gridHeight = gridHeight;

            System.Console.CursorVisible = false;
        }
        public void Render(TetrisGameState state)
        {
            DrawBlocks(state);
            DrawScore(state);
        }

        private void DrawScore(TetrisGameState state)
        {
            var (x, y) = (_gridWidth + 2 + 5, 4);
            System.Console.SetCursorPosition(x, y);
            System.Console.Write("Score: " + state.Score);
        }

        private static void DrawBlocks(TetrisGameState state)
        {
            var grid = state.Grid.Blocks;
            if (state.ActiveBlock != null)
            {
                var block = state.ActiveBlock;
                grid.Imprint(block.Shape, block.Position);
            }

            var sb = new StringBuilder();
            for (var y = 0; y < grid.GetLength(1); y++)
            {
                sb.Append("| ");
                for (var x = 0; x < grid.GetLength(0); x++)
                {
                    var p = grid[x, y] ? "\u2588\u2588" : "  ";
                    sb.Append(p);
                }
                sb.AppendLine($"|{y}");
            }

            var hLine = "`" + new string(Enumerable.Repeat('-', grid.GetLength(0) * 2 + 1).ToArray()) + "`";
            sb.AppendLine(hLine);
            System.Console.SetCursorPosition(0, 0);
            System.Console.Write(sb.ToString());
        }
    }
}