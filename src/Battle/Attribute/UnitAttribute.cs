
namespace Battle.Attribute
{
    /// <summary>
    /// 单位属性
    /// </summary>
    public struct UnitAttribute
    {
        /// <summary>
        /// 基础属性值, 主属性一部分，在整个游戏中不会改变.
        /// </summary>
        public float Base { get; private set; }

        /// <summary>
        /// 主属性值, 由基础值和英雄升级获得,白板数据值
        /// </summary>
        public float Main { get; private set; }

        /// <summary>
        /// 额外属性值, 绿版数据值
        /// </summary>
        public float Bonus { get; private set; }

        /// <summary>
        /// 百分比加成属性值
        /// </summary>
        public float Percent { get; private set; }

        /// <summary>
        /// 属性结果
        /// </summary>
        public  float Result { get; private set; }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void SetAttribute(AttributeType type, float value)
        {
            Base = value;
            Main = Base;
            Bonus = 0;
            Percent = 0;
            Result = CalAttributeResult(type);
        }

        /// <summary>
        /// 增加属性值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="isLevelUpCause"></param>
        public void AddAttribute(AttributeType type, float value, bool isLevelUpCause)
        {
            if (isLevelUpCause)
            {
                Main += value;
            }
            else
            {
                Bonus += value;
            }

            Result = CalAttributeResult(type);
        }

        /// <summary>
        /// 增加属性百分比值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void AddAttributePercent(AttributeType type, float value)
        {
            Percent += value;
            Result = CalAttributeResult(type);
        }

        /// <summary>
        /// 计算属性结果
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private float CalAttributeResult(AttributeType type)
        {
            switch (type)
            {
                case AttributeType.MaxHealth:
                case AttributeType.MaxMana:
                case AttributeType.AttackDamage:
                case AttributeType.AbilityPower:
                {
					return Main * (1 + Percent / 100.0f) + Bonus;
                }
				default:
                    return (Main + Bonus) * (1 + Percent / 100.0f);
            }
        }
    }
}
