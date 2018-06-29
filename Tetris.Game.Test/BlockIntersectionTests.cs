using NUnit.Framework;

namespace Tetris.Game.Test
{
    public class BlockIntersectionTests
    {
        [Test]

        public void TestIntersectionSingle()
        {
            var block = TestBlock.Create(
                "   ",
                " X ",
                "   ");

            var grid = new BlockGrid(3, 3);
            grid.Freeze(block);
            
            
            Assert.True(grid.Intersects(block.At(0, 0)));

            for (var dy = -1; dy <= 1; dy++)
            for (var dx = -1; dx <= 1; dx++)
            {
                if(dx == 0 && dy == 0) continue;

                Assert.False(grid.Intersects(block.At(dx, dy)));
            }
        }

        [Test]

        public void TestIntersectionLineVertical()
        {
            var block = TestBlock.Create(
                " X ",
                " X ",
                " X "
            );

            var grid = new BlockGrid(3 ,3);
            grid.Freeze(block);

            Assert.True(grid.Intersects(block.At(0, 0)));
            Assert.False(grid.Intersects(block.At(1, 0)));
            Assert.False(grid.Intersects(block.At(-1, 0)));
        }

        [Test]

        public void TestIntersectionLineHorizontal()
        {
            var block = TestBlock.Create(
                "   ",
                "XXX",
                "   "
            );
            var grid = new BlockGrid(3, 3);
            grid.Freeze(block);


            Assert.True(grid.Intersects(block.At(0, 0)));
            Assert.False(grid.Intersects(block.At(0, -1)));
            Assert.False(grid.Intersects(block.At(0, 1)));
        }

        [Test]
        public void TestOverlap()
        {
            var block = TestBlock.Create(
                "XXX",
                "XXX",
                "XXX"
            );

            var grid = new BlockGrid(9, 9);
            grid.Freeze(block.At(3, 3));

            Assert.False(grid.Intersects(block.At(0, 0)));
            Assert.False(grid.Intersects(block.At(4, 0)));
            Assert.True(grid.Intersects(block.At(4, 1)));
            Assert.False(grid.Intersects(block.At(0, 3)));
            Assert.False(grid.Intersects(block.At(6, 6)));
            Assert.False(grid.Intersects(block.At(4, 6)));
        }


        //[Test]
        //public void TestIntersectionFine()
        //{
        //    var b1 = BlockModel.FromShape(
        //        "XXX",
        //        "X X",
        //        "XXX"
        //    ).Spawn(0,0);

        //    var model2 = BlockModel.FromShape(
        //        "   ",
        //        " X ",
        //        "   "
        //    );

        //    Assert.False(b1.Intersects(model2.Spawn(0,0)));

        //    for (var dy = -1; dy <= 1; dy++)
        //    for (var dx = -1; dx <= 1; dx++)
        //    {
        //        if (dx == 0 && dy == 0) continue;

        //        var bn = model2.Spawn(dx, dy);
        //        Assert.True(b1.Intersects(bn));
        //    }
        //}
    }
}
