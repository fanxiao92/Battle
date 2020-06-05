using Battle.Common;
using Battle.Enum;
using Battle.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Creature
{
    [TestClass]
    public class CreatureTest
    {
        [TestInitialize]
        public void StartUp()
        {
            creature = (Battle.Unit.Creature)GameObject.Create(_gameWorld, GameObjectType.Creature, location, 40);
        }

        [TestMethod]
        public void GetAttribute()
        {
            Assert.AreEqual(creature.GetHealth(), 575);
            Assert.AreEqual(creature.GetMaxHealth(), 575);
            Assert.AreEqual(creature.GetAttackDamage(), 52);
            Assert.AreEqual(creature.GetArmor(), 34);
        }

        [TestMethod]
        public void AddHealth()
        {
            creature.AddHealth(-20);
            Assert.AreEqual(creature.GetHealth(), 555);

            creature.AddHealth(20);
            Assert.AreEqual(creature.GetHealth(), 575);

            creature.AddHealth(20);
            Assert.AreEqual(creature.GetHealth(), 575);
        }

        private Battle.Unit.Creature creature;
        private Battle.World.GameWorld _gameWorld = new Battle.World.GameWorld();
        private Vector2D location = new Vector2D(0, 0);
    }
}
