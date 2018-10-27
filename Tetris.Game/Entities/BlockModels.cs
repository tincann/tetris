using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;

namespace Tetris.Game.Entities
{
    public static class BlockModels
    {
        public static IReadOnlyList<BlockModel> Types = new []
        {
            Type1, Type2, Type3, Type4, Type5, Type6, Type7
        }.ToImmutableList();

        private static BlockModel Type1 => BlockModel.FromShape(
            1,
            "  X  ",
            "  X  ",
            "  X  ",
            "     ");
        private static BlockModel Type2 => BlockModel.FromShape(
            2,
            "     ",
            " XX  ",
            " XX  ",
            "     ",
            "     ");

        private static BlockModel Type3 => BlockModel.FromShape(
            3,
            "     ",
            "   X ",
            "  XX ",
            "  X  ",
            "     ");

        private static BlockModel Type4 => BlockModel.FromShape(
            4,
            "     ",
            "  X  ",
            "  XX ",
            "   X ",
            "     ");

        private static BlockModel Type5 => BlockModel.FromShape(
            5,
            "     ",
            "  X  ",
            "  X  ",
            "  XX ",
            "     ");

        private static BlockModel Type6 => BlockModel.FromShape(
            6,
            "     ",
            "   X ",
            "   X ",
            "  XX ",
            "     ");

        private static BlockModel Type7 => BlockModel.FromShape(
            7,
            "  X  ",
            " XXX ",
            "     ",
            "     ");
    }
}