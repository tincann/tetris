using System;
using Tetris.Game.Constants;

namespace Tetris.Game.Entities
{
    public class Block
    {
        protected readonly BlockModel Model;
        public bool[,] Shape => Model.Shape;
        public (int x, int y) Position { get; private set; }
        
        public BlockOrientation Orientation { get; private set; }

        protected internal Block(BlockModel model, int x, int y, BlockOrientation orientation)
        {
            Model = model;
            Orientation = orientation;
            Position = (x, y);
        }

        public void Move(MoveDirection direction)
        {
            var v = direction.Vector;
            Position = (Position.x + v.dx, Position.y + v.dy);
        }

        public void RotateLeft()
        {
            Orientation = (BlockOrientation)(((int)Orientation - 1) % 4);
        }

        public void RotateRight()
        {
            Orientation = (BlockOrientation)(((int)Orientation + 1) % 4);
        }
    }
}