using System.Linq;
using System.Text;
using Tetris.Game;
using Tetris.Game.Render;
using Tetris.Utility;

namespace Tetris.Console
{
    public class TetrisConsoleRenderer : ITetrisRenderer
    {
        private bool[,] _screen;

        public TetrisConsoleRenderer(int width, int height)
        {
            _screen = new bool[width, height];
        }

        public void Render(TetrisGameState state)
        {
            ClearBuffer();
            FillBuffer(state);
            DrawBuffer();
        }

        private void FillBuffer(TetrisGameState state)
        {
            _screen = state.Grid.Blocks;
            if (state.ActiveBlock != null)
            {
                var block = state.ActiveBlock;
                _screen.Imprint(block.Shape, block.Position);
            }
        }

        private void DrawBuffer()
        {
            var sb = new StringBuilder();
            for (var y = 0; y < _screen.GetLength(1); y++)
            {
                sb.Append("| ");
                for (var x = 0; x < _screen.GetLength(0); x++)
                {
                    var p = _screen[x, y] ? "X " : "  ";
                    sb.Append(p);
                }
                sb.AppendLine($"|{y}");
            }

            var hLine = "`" + new string(Enumerable.Repeat('-', _screen.GetLength(0) * 2 + 1).ToArray()) + "`";
            sb.AppendLine(hLine);
            System.Console.SetCursorPosition(0, 0);
            System.Console.Write(sb.ToString());
        }

        private void ClearBuffer()
        {
            foreach (var (x, y) in _screen.GetCoordinates())
            {
                _screen[x, y] = false;
            }
        }
    }
}