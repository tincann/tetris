using System;
using Tetris.Game.Constants;
using Tetris.Utility;

namespace Tetris.Game.Entities
{
    public class Block
    {
        protected readonly BlockModel Model;
        public bool[,] Shape { get; private set; }
        public (int x, int y) Position { get; private set; }

        public BlockOrientation Orientation { get; private set; }

        protected internal Block(BlockModel model, int x, int y, BlockOrientation orientation)
        {
            Model = model;
            Shape = Model.Shape;
            Orientation = orientation;
            Position = (x, y);
            SetOrientation(Orientation);
        }

        public void Move(MoveDirection direction)
        {
            var v = direction.Vector;
            Position = (Position.x + v.dx, Position.y + v.dy);
        }

        private void SetOrientation(BlockOrientation orientation)
        {
            //todo find a better way to do this. rotation matrix?
            if (orientation == BlockOrientation.Right)
            {
                RotateRight();
            }
            else if (orientation == BlockOrientation.Down)
            {
                RotateRight();
                RotateRight();
            }
            else if (orientation == BlockOrientation.Left)
            {
                RotateLeft();
            }
        }

        public void RotateLeft()
        {
            var copy = new bool[Shape.GetLength(1), Shape.GetLength(0)];

            foreach (var (x, y) in Shape.GetCoordinates())
            {
                copy[y, Shape.GetLength(0) - x - 1] = Shape[x, y];
            }

            Shape = copy;
            Orientation = Orientation.RotateLeft();
        }

        public void RotateRight()
        {
            var copy = new bool[Shape.GetLength(1), Shape.GetLength(0)];

            foreach (var (x, y) in Shape.GetCoordinates())
            {
                copy[Shape.GetLength(1) - y - 1, x] = Shape[x, y];
            }

            Shape = copy;
            Orientation = Orientation.RotateRight();
        }
    }
}