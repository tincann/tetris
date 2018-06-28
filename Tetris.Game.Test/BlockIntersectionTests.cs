using NUnit.Framework;

namespace Tetris.Game.Test
{
    public class BlockIntersectionTests
    {
        [Test]

        public void TestIntersectionSingle()
        {
            var b = BlockModel.FromShape(
                "   ",
                " X ",
                "   "
                ).Spawn(0, 0);

            new Block()


            
            
            Assert.True(b1.Intersects(b2));

            for (var dy = -1; dy <= 1; dy++)
            for (var dx = -1; dx <= 1; dx++)
            {
                if(dx == 0 && dy == 0) continue;

                var bn = model.Spawn(dx, dy);
                Assert.False(b1.Intersects(bn));
            }
        }

        [Test]

        public void TestIntersectionLineVertical()
        {
            var model = BlockModel.FromShape(
                " X ",
                " X ",
                " X "
            );

            var b1 = model.Spawn(0, 0);

            Assert.True(b1.Intersects(model.Spawn(0, 0)));
            Assert.False(b1.Intersects(model.Spawn(1, 0)));
            Assert.False(b1.Intersects(model.Spawn(-1, 0)));
        }

        [Test]

        public void TestIntersectionLineHorizontal()
        {
            var model = BlockModel.FromShape(
                "   ",
                "XXX",
                "   "
            );

            var b1 = model.Spawn(0, 0);

            Assert.True(b1.Intersects(model.Spawn(0, 0)));
            Assert.False(b1.Intersects(model.Spawn(0, -1)));
            Assert.False(b1.Intersects(model.Spawn(0, 1)));
        }

        [Test]
        public void TestOverlap()
        {
            var model = BlockModel.FromShape(
                "XXX",
                "XXX",
                "XXX"
            );

            var b1 = model.Spawn(0, 0);

            Assert.False(b1.Intersects(model.Spawn(3, 0)));
            Assert.False(b1.Intersects(model.Spawn(3, -3)));
            Assert.False(b1.Intersects(model.Spawn(0, -3)));
            Assert.False(b1.Intersects(model.Spawn(-3, 3)));
            Assert.False(b1.Intersects(model.Spawn(0, 3)));

            Assert.False(b1.Intersects(model.Spawn(0, 3)));
            Assert.False(b1.Intersects(model.Spawn(-3, 3)));
            Assert.False(b1.Intersects(model.Spawn(-3, 0)));
        }


        [Test]
        public void TestIntersectionFine()
        {
            var b1 = BlockModel.FromShape(
                "XXX",
                "X X",
                "XXX"
            ).Spawn(0,0);

            var model2 = BlockModel.FromShape(
                "   ",
                " X ",
                "   "
            );

            Assert.False(b1.Intersects(model2.Spawn(0,0)));

            for (var dy = -1; dy <= 1; dy++)
            for (var dx = -1; dx <= 1; dx++)
            {
                if (dx == 0 && dy == 0) continue;

                var bn = model2.Spawn(dx, dy);
                Assert.True(b1.Intersects(bn));
            }
        }
    }
}
