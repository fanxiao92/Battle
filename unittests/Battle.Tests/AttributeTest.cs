using Battle.Attribute;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Attribute
{
    [TestClass]
    public class AttributeTest
    {
        public AttributeTest()
        {
            this.unitAttributeMgr = new UnitAttributeManager();
            unitAttributeMgr.SetAttribute(AttributeType.MaxHealth, InitValue);
            unitAttributeMgr.SetAttribute(AttributeType.Health, InitValue);
            unitAttributeMgr.SetAttribute(AttributeType.MaxMana, InitValue);
            unitAttributeMgr.SetAttribute(AttributeType.Mana, InitValue);
            unitAttributeMgr.SetAttribute(AttributeType.AttackDamage, InitValue);
            unitAttributeMgr.SetAttribute(AttributeType.Armor, InitValue);
            unitAttributeMgr.SetAttribute(AttributeType.ArmorPenetrationFlat, InitValue);
            unitAttributeMgr.SetAttribute(AttributeType.ArmorPenetrationPercent, InitValue);
            unitAttributeMgr.SetAttribute(AttributeType.CritChance, InitValue);
            unitAttributeMgr.SetAttribute(AttributeType.CritDamage, InitValue);
            unitAttributeMgr.SetAttribute(AttributeType.AbilityPower, InitValue);
        }

        [DataTestMethod]
        [DataRow(AttributeType.Health)]
        [DataRow(AttributeType.MaxHealth)]
        [DataRow(AttributeType.Mana)]
        [DataRow(AttributeType.MaxMana)]
        [DataRow(AttributeType.AttackDamage)]
        [DataRow(AttributeType.Armor)]
        [DataRow(AttributeType.ArmorPenetrationFlat)]
        [DataRow(AttributeType.ArmorPenetrationPercent)]
        [DataRow(AttributeType.CritChance)]
        [DataRow(AttributeType.CritDamage)]
        [DataRow(AttributeType.AbilityPower)]
        public void SetAttribute(AttributeType type)
        {
            var result = unitAttributeMgr.GetAttribute(type);
            Assert.AreEqual(result, InitValue);
        }

        [DataTestMethod]
        [DataRow(AttributeType.Health)]
        [DataRow(AttributeType.MaxHealth)]
        [DataRow(AttributeType.Mana)]
        [DataRow(AttributeType.MaxMana)]
        [DataRow(AttributeType.AttackDamage)]
        [DataRow(AttributeType.Armor)]
        [DataRow(AttributeType.ArmorPenetrationFlat)]
        [DataRow(AttributeType.ArmorPenetrationPercent)]
        [DataRow(AttributeType.CritChance)]
        [DataRow(AttributeType.CritDamage)]
        [DataRow(AttributeType.AbilityPower)]
        public void AddAttribute(AttributeType type)
        {
            unitAttributeMgr.AddAttribute(type, -200);
            var result = unitAttributeMgr.GetAttribute(type);
            Assert.AreEqual(result, InitValue - 200);

            unitAttributeMgr.AddAttribute(type, 200);
            result = unitAttributeMgr.GetAttribute(type);
            Assert.AreEqual(result, InitValue);

        }

        [DataTestMethod]
        [DataRow(AttributeType.Health)]
        [DataRow(AttributeType.Mana)]
        [DataRow(AttributeType.ArmorPenetrationFlat)]
        [DataRow(AttributeType.ArmorPenetrationPercent)]
        [DataRow(AttributeType.CritChance)]
        [DataRow(AttributeType.CritDamage)]
        public void AddAttributeNoPercent(AttributeType type)
        {
            unitAttributeMgr.AddAttributePercent(type, 10);
            var result = unitAttributeMgr.GetAttribute(type);
            Assert.AreEqual(result, InitValue);

            unitAttributeMgr.AddAttributePercent(type, -10);
            result = unitAttributeMgr.GetAttribute(type);
            Assert.AreEqual(result, InitValue);
        }

        [DataTestMethod]
        [DataRow(AttributeType.MaxHealth)]
        [DataRow(AttributeType.MaxMana)]
        [DataRow(AttributeType.AttackDamage)]
        [DataRow(AttributeType.Armor)]
        [DataRow(AttributeType.AbilityPower)]
        public void AddAttributePercent(AttributeType type)
        {
            unitAttributeMgr.AddAttributePercent(type, 10);
            var result = unitAttributeMgr.GetAttribute(type);
            Assert.AreEqual(result, InitValue * 1.1f);

            unitAttributeMgr.AddAttributePercent(type, -10);
            result = unitAttributeMgr.GetAttribute(type);
            Assert.AreEqual(result, InitValue);
        }

        [DataTestMethod]
        [DataRow(AttributeType.Health, AttributeType.MaxHealth)]
        [DataRow(AttributeType.Mana, AttributeType.MaxMana)]
        public void MixedEffect(AttributeType curType, AttributeType maxType)
        {
            unitAttributeMgr.AddAttribute(maxType, 200);
            var result = unitAttributeMgr.GetAttribute(curType);
            Assert.AreEqual(result, InitValue + 200);

            unitAttributeMgr.AddAttribute(curType, -300);
            unitAttributeMgr.AddAttribute(maxType, -200);
            result = unitAttributeMgr.GetAttribute(curType);
            Assert.AreEqual(result, 200);

            unitAttributeMgr.AddAttribute(curType, 200);
        }

        [DataTestMethod]
        [DataRow(AttributeType.Health)]
        [DataRow(AttributeType.Mana)]
        public void AttributeIsLessThanMaxType(AttributeType type)
        {
            unitAttributeMgr.AddAttribute(type, 200);
            var result = unitAttributeMgr.GetAttribute(type);
            Assert.AreEqual(result, InitValue);
        }

        [TestMethod]
        public void InvalidAttributeType()
        {
            Assert.AreEqual(0.0f, unitAttributeMgr.GetAttribute(AttributeType.End));
            unitAttributeMgr.AddAttribute(AttributeType.End, 500);
            unitAttributeMgr.AddAttributePercent(AttributeType.End, 10);
            unitAttributeMgr.SetAttribute(AttributeType.End, 10);
        }


        private UnitAttributeManager unitAttributeMgr;

        private const float InitValue = 400.0f;
    }
}
