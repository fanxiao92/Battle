using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.World
{
    [TestClass]
    public class WorldTest
    {
        [TestMethod]
        public void AddUnit()
        {
            var unit = Battle.Unit.Unit.CreateUnit(world);
            Assert.AreEqual(world.UnitCount, 1);
            world.Tick(33);
            world.TickEnd();
            Assert.AreEqual(world.UnitCount, 1);
            world.RemoveUnit(unit);
            Assert.AreEqual(world.UnitCount, 1);
            world.Tick(33);
            world.TickEnd();
            Assert.AreEqual(world.UnitCount, 0);
        }

        private Battle.World.World world = new Battle.World.World();
    }
}
