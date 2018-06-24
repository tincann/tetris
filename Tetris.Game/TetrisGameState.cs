using System.Collections.Generic;

namespace Tetris.Game
{
    public class TetrisGameState
    {
        public IReadOnlyCollection<Block> Blocks => _blocks;
        internal readonly List<Block> _blocks = new List<Block>();

        internal void AddBlock(Block block)
        {
            _blocks.Add(block);
        }
    }
}
