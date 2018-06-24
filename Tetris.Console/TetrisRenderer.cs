using Tetris.Game;
using Tetris.Utility;

namespace Tetris.Console
{
    public class TetrisRenderer : ITetrisRenderer
    {
        private readonly bool[,] _screen;

        public TetrisRenderer(int width, int height)
        {
            _screen = new bool[width, height];
        }

        public void Render(TetrisGameState state)
        {
            System.Console.Clear();
            ClearBuffer();
            FillBuffer(state);
            DrawBuffer();
        }

        private void FillBuffer(TetrisGameState state)
        {
            foreach (var block in state.Blocks)
            {
                var (ox, oy) = block.Position;
                foreach (var (dx, dy) in block.Shape.GetCoordinates())
                {
                    var x = ox + dx;
                    var y = oy + dy;
                    if (!WithinBounds(x, y))
                    {
                        continue;
                    }

                    if (block.Shape[dx, dy])
                    {
                        _screen[x, y] = true;
                    }
                }
            }
        }

        private void DrawBuffer()
        {
            for (var y = 0; y < _screen.GetLength(1); y++)
            {
                for (var x = 0; x < _screen.GetLength(0); x++)
                {
                    var p = _screen[x, y] ? "X" : " ";
                    System.Console.Write(p);
                }
                System.Console.Write("\n");
            }
        }

        private bool WithinBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x < _screen.GetLength(0) && y < _screen.GetLength(1);
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