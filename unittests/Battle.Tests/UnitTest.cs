using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Unit
{
    [TestClass]
    public class UnitTest
    {
        [TestInitialize]
        public void StartUp()
        {
            unit = Battle.Unit.Unit.CreateUnit(world);
        }

        [TestMethod]
        public void GetAttribute()
        {
            Assert.AreEqual(unit.GetHealth(), 575);
            Assert.AreEqual(unit.GetMaxHealth(), 575);
            Assert.AreEqual(unit.GetAttackDamage(), 52);
            Assert.AreEqual(unit.GetArmor(), 34);
        }

        [TestMethod]
        public void AddHealth()
        {
            unit.AddHealth(-20);
            Assert.AreEqual(unit.GetHealth(), 555);

            unit.AddHealth(20);
            Assert.AreEqual(unit.GetHealth(), 575);

            unit.AddHealth(20);
            Assert.AreEqual(unit.GetHealth(), 575);
        }

        private Battle.Unit.Unit unit;
        private Battle.World.World world = new Battle.World.World();
    }
}
