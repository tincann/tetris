using System;
using Tetris.Game.Constants;
using Tetris.Game.Controls;

namespace Tetris.App.Controllers
{
    public class RandomController : ITetrisController
    {
        private readonly float _moveChance;
        Random _r = new Random();

        public RandomController(float moveChance)
        {
            _moveChance = moveChance;
        }

        public GameAction GetKeyState()
        {
            if (_r.NextDouble() <= 1 - _moveChance)
            {
                return GameAction.None;
            }

            var n = _r.Next(3);
            switch (n)
            {
                case 0:
                    return GameAction.MoveLeft;
                case 1:
                    return GameAction.MoveRight;
                case 2:
                    return GameAction.Rotate;
            }
            return GameAction.MoveDown;
        }
    }
}
