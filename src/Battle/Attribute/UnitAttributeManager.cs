using System;
using System.Collections.Generic;

namespace Battle.Attribute
{
    public class UnitAttributeManager
    {

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public float GetAttribute(AttributeType type)
        {
            float result = 0.0f;
            do
            {
                if (type < AttributeType.Begin || type >= AttributeType.End)
                {
                    break;
                }

                result = m_attributes[(int) type].Result;
            } while (false);

            return result;
        }

        /// <summary>
        /// 增加属性值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="isLevelUpCause"></param>
        public void AddAttribute(AttributeType type, float value, bool isLevelUpCause = false)
        {
            if (type < AttributeType.Begin || type >= AttributeType.End)
            {
                return;
            }

            switch (type)
            {
                case AttributeType.Health:
                {
					value = Math.Clamp(m_attributes[(int)type].Main + value, 0, m_attributes[(int)AttributeType.MaxHealth].Result);
					m_attributes[(int)type].SetAttribute(type, value);

                }
				break;
                case AttributeType.Mana:
                {
					value = Math.Clamp(m_attributes[(int)type].Main + value, 0, m_attributes[(int)AttributeType.MaxMana].Result);
					m_attributes[(int)type].SetAttribute(type, value);
                }
				break;
                default:
                {
					//先 hold 改变之前状态,方便改变属性后处理
					var func = GetChangeAttributePostProcess(type);
					m_attributes[(int)type].AddAttribute(type, value, isLevelUpCause);
					func?.Invoke();
                }
				break;
            }

        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void SetAttribute(AttributeType type, float value)
        {
            if (type < AttributeType.Begin || type >= AttributeType.End)
            {
                return;
            }

            switch (type)
            {
                case AttributeType.Health:
                {
					value = Math.Clamp(value, 0, m_attributes[(int)AttributeType.MaxHealth].Result);

                }
				break;
                case AttributeType.Mana:
                {
					value = Math.Clamp(value, 0, m_attributes[(int)AttributeType.MaxMana].Result);
                }
				break;

            }

            //先 hold 改变之前状态,方便改变属性后处理
            var func = GetChangeAttributePostProcess(type);
            m_attributes[(int)type].SetAttribute(type, value);
            func?.Invoke();
        }

        /// <summary>
        /// 增加属性百分比值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void AddAttributePercent(AttributeType type, float value)
        {
            if (type < AttributeType.Begin || type >= AttributeType.End)
            {
                return;
            }

            if (NoPercentAttributes.Contains(type))
            {
                return;
            }

            var func = GetChangeAttributePostProcess(type);
            m_attributes[(int)type].AddAttributePercent(type, value);
            func?.Invoke();
        }

        /// <summary>
        /// 属性修改后的额外处理
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Action GetChangeAttributePostProcess(AttributeType type)
        {
            Action result = null;
            switch (type)
            {
                case AttributeType.MaxHealth:
                {
					//获取原始数据进行处理
					float maxHealth = GetAttribute(type);
					float health = GetAttribute(AttributeType.Health);
					float percent = maxHealth != 0.0f ? health / maxHealth : 1.0f;
					result = () => { SetAttribute(AttributeType.Health, GetAttribute(type) * percent); };
                }
				break;
                case AttributeType.MaxMana:
                {
					//获取原始数据进行处理
					float maxMana = GetAttribute(type);
					float health = GetAttribute(AttributeType.Mana);
					float percent = maxMana != 0.0f ? health / maxMana : 1.0f;
					result = () => { SetAttribute(AttributeType.Mana, GetAttribute(type) * percent); };
				}
				break;
            }
            return result;
        }


        /// <summary>
        /// 属性
        /// </summary>
        private readonly UnitAttribute[] m_attributes = new UnitAttribute[(int)AttributeType.End];

        /// <summary>
        /// 无法百分比的属性
        /// </summary>
        private static readonly HashSet<AttributeType> NoPercentAttributes =  new HashSet<AttributeType>
        {
           AttributeType.Health,
           AttributeType.Mana,
           AttributeType.ArmorPenetrationFlat,
           AttributeType.ArmorPenetrationPercent,
           AttributeType.CritChance,
           AttributeType.CritDamage,
        };
    }
}
