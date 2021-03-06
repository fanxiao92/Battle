﻿using Battle.Common;
using Battle.Enum;
using Battle.Spell;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Buff
{
    [TestClass]
    public class BuffTest
    {
        [TestInitialize]
        public void StartUp()
        {
            source =(Battle.Unit.Creature)Battle.Unit.GameObject.Create(_gameWorld, GameObjectType.Creature, location, 40);
            target = (Battle.Unit.Creature)Battle.Unit.GameObject.Create(_gameWorld, GameObjectType.Creature, location, 40);
        }

        [TestMethod]
        public void DamageModify()
        {
            var originHealth = target.GetHealth();
            attackContext.OnAttackStart(source, target);
            attackContext.OnAttackHit();
            var damageNum = originHealth - target.GetHealth();
            Assert.AreEqual(damageNum, 38);

            originHealth = target.GetHealth();
            target.Buff = new Battle.Buff.Buff();
            attackContext.OnAttackStart(source, target);
            attackContext.OnAttackHit();
            damageNum = originHealth - target.GetHealth();
            Assert.AreEqual(damageNum, 24);

            originHealth = target.GetHealth();
            source.Buff = new Battle.Buff.Buff();
            attackContext.OnAttackStart(source, target);
            attackContext.OnAttackHit();
            damageNum = originHealth - target.GetHealth();
            Assert.AreEqual(damageNum, 43);

            originHealth = target.GetHealth();
            target.Buff = null;
            attackContext.OnAttackStart(source, target);
            attackContext.OnAttackHit();
            damageNum = originHealth - target.GetHealth();
            Assert.AreEqual(damageNum, 57);
        }

        private Battle.Unit.Creature source;
        private Battle.Unit.Creature target;
        private Battle.World.GameWorld _gameWorld = new Battle.World.GameWorld();
        private DamageEvent attackContext =  new DamageEvent();
        private Vector2D location = new Vector2D(0, 0);
        
    }
}
