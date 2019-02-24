using System;
using RGBLedMatrix;
using Tetris.Game;
using Tetris.Game.Render;
using Tetris.Utility;

namespace Tetris.App.Renderers
{
    public class LedMatrixRenderer : ITetrisRenderer
    {
        private readonly RGBLedMatrix.RGBLedMatrix _matrix;
        private readonly RGBLedCanvas _canvas;
        private readonly int _borderWidth;

        public LedMatrixRenderer(
            int width, 
            int height, 
            int brightness, 
            int ledMultiplexing, 
            int ledScanmode, 
            int ledPwmLsbNanoSeconds, 
            int ledPwmBits,
            int ledPwmDither,
            string ledPixelMapper,
            bool drawBorder = true
        )
        {
            _borderWidth = drawBorder ? 1 : 0;
            _matrix = new RGBLedMatrix.RGBLedMatrix(new RGBLedMatrixOptions
            {
                Rows = height, 
                Cols = width, 
                Brightness = brightness, 
                PwmLsbNanoseconds = ledPwmLsbNanoSeconds,
                Multiplexing = ledMultiplexing,
                ScanMode = ledScanmode,
                PwmBits = ledPwmBits,
                PwmDitherBits = ledPwmDither,
                PixelMapperConfig = ledPixelMapper
            });
            _canvas = _matrix.CreateOffscreenCanvas();
        }
        public void Render(TetrisGameState state)
        {
            _canvas.Clear();

            DrawBorder(state);
            DrawBlocks(state);
            DrawScore(state);

            _matrix.SwapOnVsync(_canvas);
        }

        private void DrawBorder(TetrisGameState state)
        {
            if (_borderWidth == 0)
            {
                return;
            }

            var x2 = state.Grid.Width + 1;
            var y2 = state.Grid.Height + 1;

            var borderColor = new Color(50, 50, 50);
            _canvas.DrawLine(0, 0, 0, y2, borderColor);
            _canvas.DrawLine(0, 0, x2, 0, borderColor);
            _canvas.DrawLine(0, y2, x2, y2, borderColor);
            _canvas.DrawLine(x2, 0, x2, y2, borderColor);
        }

        private void DrawBlocks(TetrisGameState state)
        {
            if (state.Grid.Width > _canvas.Width - 2 * _borderWidth || state.Grid.Height > _canvas.Height - 2 * _borderWidth)
            {
                throw new Exception(
                    $"Game grid ({state.Grid.Width}x{state.Grid.Height}) does not fit inside " +
                    $"Canvas ({_canvas.Width}x{_canvas.Height}) with Border size ({_borderWidth})");
            }

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
                        _canvas.SetPixel(x + _borderWidth, y + _borderWidth, color);
                    }
                }
            }
        }

        private void DrawScore(TetrisGameState state)
        {
            var xOffset = 1;
            var yOffset = state.Grid.Height + 2 * _borderWidth + 1;

            var digitRenderer = new DigitRenderer(_canvas, 4);
            digitRenderer.RenderNumber(xOffset, yOffset, state.Score);
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
