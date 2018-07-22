﻿using System;
using System.Linq;
using System.Threading;
using Tetris.Game.Constants;
using Tetris.Game.Controls;
using Tetris.Game.Entities;
using Tetris.Game.Render;

namespace Tetris.Game
{
    public class TetrisGame
    {
        private readonly ITetrisRenderer _renderer;
        private readonly ITetrisController _controller;

        private readonly TetrisGameState _gameState;
        private readonly BlockSpawner _spawner;

        public TetrisGame(TetrisConfig config, ITetrisRenderer renderer, ITetrisController controller)
        {
            _renderer = renderer;
            _controller = controller;
            _spawner = new BlockSpawner(config.GameWidth / 2, 0, BlockModels.Types);
            _gameState = TetrisGameState.CreateFromConfig(config);
        }

        public void Run()
        {
            SpawnBlock();
            while (true)
            {
                NullifyFullRows();

                MoveActiveBlock(MoveDirection.Down);
                
                HandleInput(TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(20));

                if (ShouldSpawnNewBlock())
                {
                    SpawnBlock();
                    if (ShouldSpawnNewBlock())
                    {
                        break;
                    }
                }
            }
        }

        private void NullifyFullRows()
        {
            var fullRowNumbers = _gameState.Grid.GetFullRows();
            foreach (var rowNumber in fullRowNumbers)
            {
                _gameState.Grid.DeleteRowAndShiftDown(rowNumber);
            }
        }

        private void HandleInput(TimeSpan duration, TimeSpan pollInterval)
        {
            var total = TimeSpan.Zero;
            while (total <= duration)
            {
                var key = _controller.GetKeyState();

                switch (key)
                {
                    case GameAction.Pause:
                        //todo
                        break;
                    case GameAction.MoveLeft:
                        MoveActiveBlock(MoveDirection.Left);
                        break;
                    case GameAction.MoveRight:
                        MoveActiveBlock(MoveDirection.Right);
                        break;
                    case GameAction.MoveDown:
                        MoveActiveBlock(MoveDirection.Down);
                        break;
                    case GameAction.Rotate:
                        RotateActiveBlock();
                        break;
                }

                Thread.Sleep(pollInterval);
                total += pollInterval;
            }
        }
        private void RotateActiveBlock()
        {
            var block = _gameState.ActiveBlock;
            block.RotateRight();

            if (_gameState.Grid.Intersects(block))
            {
                block.RotateLeft();
            }
            else
            {
                _renderer.Render(_gameState);
            }
        }
        private void MoveActiveBlock(MoveDirection direction)
        {
            var block = _gameState.ActiveBlock;
            if (!_gameState.Grid.Intersects(block, direction.Vector))
            {
                block.Move(direction);
                _renderer.Render(_gameState);
            }
        }

        private bool ShouldSpawnNewBlock()
        {
            var block = _gameState.ActiveBlock;
            return _gameState.Grid.Intersects(block, (0, 1));
        }

        private void SpawnBlock()
        {
            if (_gameState.ActiveBlock != null)
            {
                _gameState.Grid.Freeze(_gameState.ActiveBlock);
            }

            _gameState.ActiveBlock = _spawner.SpawnRandomBlock();
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
