namespace Tetris.Game
{
    public class Block
    {
        internal Block(BlockModel model, int x, int y, BlockOrientation orientation)
        {
            Model = model;
            Orientation = orientation;
            Position = (x, y);
        }

        private BlockModel Model { get; }

        public bool[,] Shape => Model.Shape;
        
        public (int x, int y) Position { get; private set; }

        public (int x1, int x2, int y1, int y2) Bounds =>
            (Position.x, Position.x + Model.MaxWidth, Position.y, Position.y + Model.MaxHeight);

        public BlockOrientation Orientation { get; private set; }

        public void MoveDown()
        {
            Position = (Position.x, Position.y + 1);
        }

        public void RotateLeft()
        {
            Orientation = (BlockOrientation)(((int)Orientation - 1) % 4);
        }

        public void RotateRight()
        {
            Orientation = (BlockOrientation)(((int)Orientation + 1) % 4);
        }

        public bool Intersects(Block other)
        {
            return BlockIntersection.Intersects(this, other);
        }
    }
}