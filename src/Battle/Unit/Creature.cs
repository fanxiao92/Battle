using Battle.Attribute;
using Battle.Common;
using Battle.Spell;

namespace Battle.Unit
{
    /// <summary>
    /// 单位具有属性值，可死亡
    /// 单位具有Buff.
    /// </summary>
    public class Creature :  GameObject
    {
        #region 驱动

        public override void Tick(float deltaTime)
        {
            base.Tick(deltaTime);
        }

        #endregion

        #region 属性值

        /// <summary>
        /// 获取血量值
        /// </summary>
        /// <returns></returns>
        public float GetHealth()
        {
            return GetAttribute(AttributeType.Health);
        }

        /// <summary>
        /// 血量值设置
        /// </summary>
        /// <param name="value"></param>
        public void AddHealth(float value)
        {
            AddAttribute(AttributeType.Health, value);
        }

        /// <summary>
        /// 获取最大血量值
        /// </summary>
        public float GetMaxHealth()
        {
            return GetAttribute(AttributeType.MaxHealth);
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private float GetAttribute(AttributeType type)
        {
            return m_attributeMgr.GetAttribute(type);
        }

        /// <summary>
        /// 增加属性值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="isLevelUpCause"></param>
        private void AddAttribute(AttributeType type, float value, bool isLevelUpCause = false)
        {
            m_attributeMgr.AddAttribute(type, value, isLevelUpCause);
        }

        /// <summary>
        /// 增加属性百分比
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        private void AddAttributePercent(AttributeType type, float value)
        {
            m_attributeMgr.AddAttributePercent(type, value);
        }

        /// <summary>
        /// 获取攻击力
        /// </summary>
        /// <returns></returns>
        public float GetAttackDamage()
        {
            return m_attributeMgr.GetAttribute(AttributeType.AttackDamage);
        }

        /// <summary>
        /// 获取护甲值
        /// </summary>
        /// <returns></returns>
        public float GetArmor()
        {
            return m_attributeMgr.GetAttribute(AttributeType.Armor);
        }


        /// <summary>
        /// 获取穿透
        /// </summary>
        /// <returns></returns>
        public float GetArmorPenetrationPercent()
        {
            return m_attributeMgr.GetAttribute(AttributeType.ArmorPenetrationPercent);
        }

        /// <summary>
        /// 获取破甲
        /// </summary>
        /// <returns></returns>
        public float GetArmorPenetrationFlat()
        {
            return m_attributeMgr.GetAttribute(AttributeType.ArmorPenetrationFlat);
        }

        /// <summary>
        /// 设置属性值,用于初始化角色属性
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        private void SetAttribute(AttributeType type, float value)
        {
            m_attributeMgr.SetAttribute(type, value);
        }

        /// <summary>
        /// 单位属性管理
        /// </summary>
        private readonly UnitAttributeManager m_attributeMgr = new UnitAttributeManager();

        #endregion

        #region 伤害修改事件

        /// <summary>
        /// 造成伤害
        /// </summary>
        public void OnDamage(DamageEvent damageEvent)
        {
            Buff?.OnDamage(damageEvent);
        }

        /// <summary>
        /// 受到伤害
        /// </summary>
        public void OnDamaged(DamageEvent damageEvent)
        {
            Buff?.OnDamaged(damageEvent);
        }

        public Buff.Buff Buff { get; set; }

        #endregion

        #region 构建
        public override bool Initialize(World.GameWorld gameWorld, Vector2D location, float facing)
        {
            SetAttribute(AttributeType.MaxHealth, 575);
            SetAttribute(AttributeType.Health, 575);
            SetAttribute(AttributeType.MaxMana, 350);
            SetAttribute(AttributeType.Mana, 350);
            SetAttribute(AttributeType.AttackDamage, 52);
            SetAttribute(AttributeType.Armor, 34);
            SetAttribute(AttributeType.ArmorPenetrationFlat, 0);
            SetAttribute(AttributeType.ArmorPenetrationPercent, 0);
            SetAttribute(AttributeType.CritChance, 0);
            SetAttribute(AttributeType.CritDamage, 200);
            SetAttribute(AttributeType.AbilityPower, 0);

            return base.Initialize(gameWorld, location, facing);
        }
        #endregion

    }
}
