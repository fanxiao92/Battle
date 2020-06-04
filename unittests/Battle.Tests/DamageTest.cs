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
            source = Battle.Unit.Unit.CreateUnit(world);
            target = Battle.Unit.Unit.CreateUnit(world);
        }

        [TestMethod]
        public void Hit()
        {
            var originHealth = target.GetHealth();
            attackContext.OnAttackStart(source, target);
            attackContext.OnAttackHit();
            var damageNum = originHealth - target.GetHealth();
            Assert.AreEqual(damageNum, 38);

            originHealth = target.GetHealth();
            attackContext.OnAttackStart(source, target);
            attackContext.ModifyAdd(10);
            attackContext.OnAttackHit();
            damageNum = originHealth - target.GetHealth();
            Assert.AreEqual(damageNum, 38);

			originHealth = target.GetHealth();
            attackContext.OnAttackStart(source, target);
            attackContext.ModifyAdd(-10);
            attackContext.OnAttackHit();
			damageNum = originHealth - target.GetHealth();
            Assert.AreEqual(damageNum, 38);

			originHealth = target.GetHealth();
            attackContext.OnAttackStart(source, target);
            attackContext.ModifyMulIncrease(10);
            attackContext.OnAttackHit();
            damageNum = originHealth - target.GetHealth();
            Assert.AreEqual(damageNum, 38);

			originHealth = target.GetHealth();
            attackContext.OnAttackStart(source, target);
            attackContext.ModifyMulReduction(10);
            attackContext.OnAttackHit();
            damageNum = originHealth - target.GetHealth();
            Assert.AreEqual(damageNum, 38);

        }


        private Battle.Unit.Unit source;
        private Battle.Unit.Unit target;
        private Battle.World.World world = new Battle.World.World();
        private readonly DamageEvent attackContext = new DamageEvent();
    }
}
