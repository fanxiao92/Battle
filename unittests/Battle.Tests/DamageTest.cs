﻿using Battle.Spell;
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


        private readonly DamageEvent attackContext = new DamageEvent();
        private readonly Battle.Unit.Unit source = new Battle.Unit.Unit();
        private readonly Battle.Unit.Unit target = new Battle.Unit.Unit();
    }
}
