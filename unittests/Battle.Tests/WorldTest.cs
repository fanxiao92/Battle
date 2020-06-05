using Battle.Common;
using Battle.Enum;
using Battle.Unit;
using Battle.World;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.World
{
    [TestClass]
    public class WorldTest
    {
        [TestMethod]
        public void AddUnit()
        {
            var unit = GameObject.Create(gameWorld, GameObjectType.Creature, location, 40);
            Assert.AreEqual(gameWorld.UnitCount, 1);
            gameWorld.Tick(33);
            gameWorld.TickEnd();
            Assert.AreEqual(gameWorld.UnitCount, 1);
            gameWorld.RemoveUnit(unit);
            Assert.AreEqual(gameWorld.UnitCount, 1);
            gameWorld.Tick(33);
            gameWorld.TickEnd();
            Assert.AreEqual(gameWorld.UnitCount, 0);
        }

        private GameWorld gameWorld = new GameWorld();
        private Vector2D location = new Vector2D(0, 0);
    }
}
