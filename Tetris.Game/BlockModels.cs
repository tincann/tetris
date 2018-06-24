using System.Collections.Generic;
using System.Collections.Immutable;

namespace Tetris.Game
{
    public static class BlockModels
    {
        public static IReadOnlyList<BlockModel> Types = new []
        {
            Type1, Type2
        }.ToImmutableList();

        private static BlockModel Type1 => BlockModel.FromShape(
            "  X  ",
            "  X  ",
            "  X  ",
            "  X  ",
            "     ");
        private static BlockModel Type2 => BlockModel.FromShape(
            "     ",
            " XX  ",
            " XX  ",
            "     ",
            "     ");
    }
}