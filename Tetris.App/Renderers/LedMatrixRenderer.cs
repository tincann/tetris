using rpi_rgb_led_matrix_sharp;
using Tetris.Game;
using Tetris.Game.Render;
using Tetris.Utility;

namespace Tetris.App.Renderers
{
    public class LedMatrixRenderer : ITetrisRenderer
    {
        private readonly RGBLedMatrix _matrix;
        private readonly RGBLedCanvas _canvas;

        public LedMatrixRenderer(int rows, int cols, int brightness)
        {
            _matrix = new RGBLedMatrix(new RGBLedMatrixOptions { Rows = rows, Cols = cols, Brightness = brightness });
            _canvas = _matrix.CreateOffscreenCanvas();
        }
        public void Render(TetrisGameState state)
        {
            DrawBlocks(state);
        }

        private void DrawBlocks(TetrisGameState state)
        {
            _canvas.Clear();

            var grid = state.Grid.Blocks;
            if (state.ActiveBlock != null)
            {
                var block = state.ActiveBlock;
                grid.Imprint(block.Shape, block.Position);
            }

            for (var y = 0; y < grid.GetLength(1); y++)
            {
                for (var x = 0; x < grid.GetLength(0); x++)
                {
                    var type = grid[x, y];
                    if (type != 0)
                    {
                        var color = GetColor(type);
                        _canvas.SetPixel(x, y, color);
                    }
                }
            }

            _matrix.SwapOnVsync(_canvas);
        }

        private static Color GetColor(int type)
        {
            switch (type)
            {
                case 1:
                    return new Color(0, 0, 128);
                case 2:
                    return new Color(128, 0, 0);
                case 3:
                    return new Color(0, 128, 0);
                case 4:
                    return new Color(0, 255, 255);
                case 5:
                    return new Color(128, 0, 128);
                case 6:
                    return new Color(255, 255, 0);
                case 7:
                    return new Color(0, 0, 255);
            }
            return new Color(255, 255, 255);
        }
    }
}
