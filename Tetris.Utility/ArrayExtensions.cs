using System.Collections.Generic;

namespace Tetris.Utility
{
    public static class ArrayExtensions
    {

        public static IEnumerable<(int x, int y)> GetCoordinates<TElement>(this TElement[,] array)
        {
            for (var y = 0; y < array.GetLength(1); y++)
            {
                for (var x = 0; x < array.GetLength(0); x++)
                {
                    yield return (x, y);
                }
            }
        }

        public static IEnumerable<(TElement element, int x, int y)> GetValues<TElement>(this TElement[,] array)
        {
            for (var y = 0; y < array.GetLength(1); y++)
            {
                for (var x = 0; x < array.GetLength(0); x++)
                {
                    yield return (array[x, y], x, y);
                }
            }
        }
    }
}