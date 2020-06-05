using Battle.Common;
using Battle.Enum;
using Battle.Unit;
using Battle.World;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Unit
{
    [TestClass]
    public class ProjectileTest
    {
        [TestInitialize]
        public void StartUp()
        {
            creature = (Creature)GameObject.Create(gameWorld, GameObjectType.Creature, location, 40);
            projectile = Projectile.Create(gameWorld, creature, location, 40);

        }

        [TestMethod]
        public void Move()
        {
            gameWorld.Tick(33);
            gameWorld.TickEnd();
            Assert.AreEqual(projectile.Location, new Vector2D(0, 0));
            Assert.AreEqual(gameWorld.GameObjectCount, 2);

            gameWorld.Tick(33);
            gameWorld.TickEnd();
            Assert.AreEqual(projectile.Location, new Vector2D(0, 10));

            gameWorld.Tick(33);
            gameWorld.TickEnd();
            Assert.AreEqual(projectile.Location, new Vector2D(0, 20));
            
            gameWorld.Tick(33);
            gameWorld.TickEnd();
            Assert.AreEqual(projectile.Location, new Vector2D(0, 30));

            gameWorld.Tick(33);
            gameWorld.TickEnd();
            Assert.AreEqual(projectile.Location, new Vector2D(0, 40));

            gameWorld.Tick(33);
            gameWorld.TickEnd();
            Assert.AreEqual(gameWorld.GameObjectCount, 1);
        }

        private Creature creature;
        private Projectile projectile;
        private GameWorld gameWorld = new GameWorld();
        private Vector2D location = new Vector2D(0, 0);
    }
}
