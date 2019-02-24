using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RGBLedMatrix;

namespace Tetris.App.Renderers
{
    public class DigitRenderer
    {
        private readonly RGBLedCanvas _canvas;
        private readonly int _numDigits;
        private const int DigitHeight = 5;
        private const int DigitWidth = 3;

        public DigitRenderer(RGBLedCanvas canvas, int numDigits)
        {
            _canvas = canvas;
            _numDigits = numDigits;
        }

        public void RenderNumber(int xOffset, int yOffset, int number)
        {
            for (var i = _numDigits; i > 0; i--)
            {
                var div = (int)Math.Pow(10, i - 1);
                var digit = (10 + number / div) % 10;

                var xDigitOffset = (_numDigits - i) * (DigitWidth + 1);
                RenderDigit(xOffset + xDigitOffset, yOffset, digit);
            }
        }

        public void RenderDigit(int xOffset, int yOffset, int digit)
        {
            Debug.Assert(digit >= 0 && digit < 10, "Digit is not 0-9");

            var lines = _digits[digit].Split('\n').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();

            Debug.Assert(lines.Length == DigitHeight && lines.All(x => x.Length == DigitWidth), $"One or more digit maps is not {DigitWidth}x{DigitHeight}");

            for(var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (var x = 0; x < line.Length; x++)
                {
                    if (line[x] == 'X')
                    {
                        _canvas.SetPixel(xOffset + x, yOffset + y, new Color(255, 255, 255));
                    }
                }
            }
        }

        private static readonly Dictionary<int, string> _digits = new Dictionary<int, string>
        {
            { 0, @"
XXX
X.X
X.X
X.X
XXX"
            },
            { 1, @"
.X.
XX.
.X.
.X.
XXX"
            }, 
            { 2, @"
.X.
X.X
.X.
X..
XXX"
            }, 
            { 3, @"
XXX
..X
.XX
..X
XXX"
            }, 
            { 4, @"
X.X
X.X
XXX
..X
..X"
            }, 
            { 5, @"
XXX
X..
XXX
..X
XXX"
            }, 
            { 6, @"
XXX
X..
XXX
X.X
XXX"
            }, 
            { 7, @"
XXX
..X
.X.
.X.
.X."
            }, 
            { 8, @"
XXX
X.X
XXX
X.X
XXX"
            }, 
            { 9, @"
XXX
X.X
XXX
..X
XXX"
            }
        };
    }
}
