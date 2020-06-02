namespace Battle.Attribute
{
	/// <summary>
	/// 属性类型
	/// </summary>
    public enum AttributeType
	{
		Begin = 0,
		/// <summary>
		/// 当前生命值
		/// </summary>
		Health = 0, 
		/// <summary>
		/// 最大生命值
		/// </summary>
		MaxHealth, //最大生命值
		/// <summary>
		/// 蓝量
		/// </summary>
		Mana,
		/// <summary>
		/// 最大蓝量
		/// </summary>
		MaxMana,
		/// <summary>
		/// 攻击伤害
		/// </summary>
		AttackDamage,
		/// <summary>
		/// 护甲
		/// </summary>
		Armor,
		/// <summary>
		/// 破甲
		/// </summary>
		ArmorPenetrationFlat,
		/// <summary>
		/// 穿透
		/// </summary>
		ArmorPenetrationPercent,
		/// <summary>
		/// 暴击概率
		/// </summary>
		CritChance,
		/// <summary>
		/// 暴击伤害值 默认200%
		/// </summary>
		CritDamage,
		/// <summary>
		/// 法术加成
		/// </summary>
		AbilityPower,
		End,
    }
}
