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

        public void MoveDown() => Position = (Position.x, Position.y + 1);
        public void MoveLeft() => Position = (Position.x - 1, Position.y);
        public void MoveRight() => Position = (Position.x + 1, Position.y);

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