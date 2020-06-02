using Battle.Spell;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Damage
{
    [TestClass]
    public class DamageTest
    {
        [TestInitialize]
        public void StartUp()
        {
            source.Initialize();
            target.Initialize();
            attackContext.OnAttackStart(source, target);
        }

        [TestMethod]
        public void Hit()
        {
            attackContext.OnAttackHit();
            Assert.AreEqual(target.GetHealth(), 537);
        }

        private readonly DamageEvent attackContext = new DamageEvent();
        private readonly Battle.Unit.Unit source = new Battle.Unit.Unit();
        private readonly Battle.Unit.Unit target = new Battle.Unit.Unit();
    }
}
