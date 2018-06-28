using System.Collections.Generic;
using System.Collections.Immutable;

namespace Tetris.Game
{
    public static class BlockModels
    {
        public static IReadOnlyList<BlockModel> Types = new []
        {
            Type1, Type2, Type3, Type4, Type5, Type6, Type7
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

        private static BlockModel Type3 => BlockModel.FromShape(
            "     ",
            "   X ",
            "  XX ",
            "  X  ",
            "     ");

        private static BlockModel Type4 => BlockModel.FromShape(
            "     ",
            "  X  ",
            "  XX ",
            "   X ",
            "     ");

        private static BlockModel Type5 => BlockModel.FromShape(
            "     ",
            "  X  ",
            "  X  ",
            "  XX ",
            "     ");

        private static BlockModel Type6 => BlockModel.FromShape(
            "     ",
            "   X ",
            "   X ",
            "  XX ",
            "     ");

        private static BlockModel Type7 => BlockModel.FromShape(
            "     ",
            "  X  ",
            " XXX ",
            "     ",
            "     ");
    }
}