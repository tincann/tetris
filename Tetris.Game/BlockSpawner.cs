﻿using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Game.Entities;

namespace Tetris.Game
{
    public class BlockSpawner
    {
        private readonly (int x, int y) _spawnPosition;
        private readonly IReadOnlyList<BlockModel> _models;
        private readonly Random _random = new Random();

        public BlockSpawner(int spawnPositionX, int spawnPositionY, IReadOnlyList<BlockModel> models)
        {
            _spawnPosition = (spawnPositionX, spawnPositionY);
            _models = models;
        }

        public Block SpawnRandomBlock()
        {
            var i = _random.Next(_models.Count);
            var model = _models[i];
            return model.Spawn(_spawnPosition.x, _spawnPosition.y);
        }
    }
}
