using System;
using System.Linq;
using System.Text;
using Tetris.Game;
using Tetris.Game.Render;
using Tetris.Utility;

namespace Tetris.App.Controllers
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
                    var type = grid[x, y];
                    if (type != 0)
                    {
                        System.Console.ForegroundColor = GetColor(type);
                        sb.Append("\u2588\u2588");
                    }
                    else
                    {
                        sb.Append("  ");
                    }
                }
                System.Console.ResetColor();
                sb.AppendLine($"|{y}");
            }

            var hLine = "`" + new string(Enumerable.Repeat('-', grid.GetLength(0) * 2 + 1).ToArray()) + "`";
            sb.AppendLine(hLine);
            System.Console.SetCursorPosition(0, 0);
            System.Console.Write(sb.ToString());
        }

        private static ConsoleColor GetColor(int type)
        {
            switch (type)
            {
                case 1:
                    return ConsoleColor.DarkBlue;
                case 2:
                    return ConsoleColor.DarkRed;
                case 3:
                    return ConsoleColor.DarkGreen;
                case 4:
                    return ConsoleColor.DarkCyan;
                case 5:
                    return ConsoleColor.DarkMagenta;
                case 6:
                    return ConsoleColor.DarkYellow;
                case 7:
                    return ConsoleColor.Blue;
            }
            return ConsoleColor.White;
        }
    }
}