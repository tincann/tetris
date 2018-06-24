using System.Linq;
using System.Threading;

namespace Tetris.Game
{
    public class TetrisGame
    {
        private readonly TetrisConfig _config;
        private readonly ITetrisRenderer _renderer;

        private readonly TetrisGameState _gameState = new TetrisGameState();
        private readonly BlockSpawner _spawner;

        public TetrisGame(TetrisConfig config, ITetrisRenderer renderer)
        {
            _config = config;
            _renderer = renderer;
            _spawner = new BlockSpawner(_config.GameWidth / 2, 0, BlockModels.Types);
        }

        public void Run()
        {

            var activeBlock = SpawnBlock();
            while (true)
            {
                activeBlock.MoveDown();
                _renderer.Render(_gameState);

                Thread.Sleep(500);

                if (ShouldSpawnNewBlock(activeBlock))
                {
                    activeBlock = SpawnBlock();
                    if (ShouldSpawnNewBlock(activeBlock))
                    {
                        break;
                    }
                }
            }
        }

        private bool ShouldSpawnNewBlock(Block activeBlock)
        {
            if (activeBlock.Position.y + 5 > _config.GameHeight)
            {
                return true;
            }

            if (_gameState.Blocks.Where(b => b != activeBlock).Any(b => b.Intersects(activeBlock)))
            {
                return true;
            }

            return false;
        }

        private Block SpawnBlock()
        {
            var activeBlock = _spawner.SpawnRandomBlock();
            _gameState.AddBlock(activeBlock);
            return activeBlock;
        }
    }

    public class TetrisConfig
    {
        /// <summary>
        /// Width of play area
        /// </summary>
        public int GameWidth { get; set; } = 10;

        /// <summary>
        /// Height of play area
        /// </summary>
        public int GameHeight { get; set; } = 15;
    }
}
