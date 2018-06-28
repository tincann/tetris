namespace Tetris.Game
{
    public class TetrisGameState
    {

        public BlockGrid Grid { get; private set; }
        public Block ActiveBlock { get; set; }

        private TetrisGameState() { }

        public static TetrisGameState CreateFromConfig(TetrisConfig config)
        {
            return new TetrisGameState
            {
                ActiveBlock = null,
                Grid = new BlockGrid(config.GameWidth, config.GameHeight)
            };
        }
    }
}
