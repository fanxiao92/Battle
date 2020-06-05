using Battle.Common;
using Battle.Enum;
using Battle.Spell;
using Battle.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Damage
{
    [TestClass]
    public class DamageTest
    {
        [TestInitialize]
        public void StartUp()
        {
            source = (Battle.Unit.Creature)GameObject.Create(_gameWorld, GameObjectType.Creature, location, 40);
            target = (Battle.Unit.Creature)GameObject.Create(_gameWorld, GameObjectType.Creature, location, 40);
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


        private Battle.Unit.Creature source;
        private Battle.Unit.Creature target;
        private Battle.World.GameWorld _gameWorld = new Battle.World.GameWorld();
        private readonly DamageEvent attackContext = new DamageEvent();
        private Vector2D location = new Vector2D(0, 0);
    }
}
