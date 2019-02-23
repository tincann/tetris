using RGBLedMatrix;

namespace DebugScreen
{
    public class DebugRenderer
    {
        private readonly RGBLedMatrix.RGBLedMatrix _matrix;
        private readonly RGBLedCanvas _canvas;

        public DebugRenderer(int rows, int cols, int brightness)
        {
            _matrix = new RGBLedMatrix.RGBLedMatrix(new RGBLedMatrixOptions { PwmLsbNanoseconds = 200, Rows = rows, Cols = cols, Brightness = brightness, });
            _canvas = _matrix.CreateOffscreenCanvas();
        }

        public void FillScreen()
        {
            _canvas.Clear();
            var rows = _canvas.Height;
            var cols = _canvas.Width;

            for (var y = 0; y < rows; y++)
            {
                for (var x = 0; x < cols; x++)
                {
                    var color = new Color(0, 0, 0);

                    if (x == 0 && y == 0)
                    {
                        color = new Color(255, 0, 0);
                    }
                    else if (x == 0 && y == rows - 1)
                    {
                        color = new Color(0, 255, 0);
                    }
                    else if(x == cols - 1 && y == 0)
                    {
                        color = new Color(0, 0, 255);
                    }
                    else if(x == cols - 1 && y == rows - 1)
                    {
                        color = new Color(255, 255, 255);
                    }

                    _canvas.SetPixel(x, y, color);
                }
            }
            _matrix.SwapOnVsync(_canvas);
        }
    }
}
