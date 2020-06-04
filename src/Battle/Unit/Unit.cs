using Battle.Attribute;
using Battle.Spell;

//TODO 弹道增加处理
//TODO 配置文件增加
//TODO 普通攻击处理 AttackSpeed
//TODO CreateUnit
namespace Battle.Unit   
{
    public class Unit
    {
        #region 属性

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
        private readonly UnitAttributeManager m_attributeMgr;

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

        #region 驱动

        /// <summary>
        /// Tick 驱动
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Tick(float deltaTime)
        {

        }

        #endregion

        #region 创建单位

        /// <summary>
        /// 创建单位
        /// </summary>
        /// <returns></returns>
        public static Unit CreateUnit(World.World world)
        {
            Unit unit = new Unit();
            if (!unit.Initialize(world))
            {
                return null;
            }
            return unit;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private Unit()
        {
            m_attributeMgr = new UnitAttributeManager();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private bool Initialize(World.World world)
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

            if (!world.AddUnit(this))
            {
                return false;
            }
            return true;
        }

        #endregion

        /// <summary>
        /// 实例 ID
        /// </summary>
        public int InstanceId { get; set; }

    }
}
