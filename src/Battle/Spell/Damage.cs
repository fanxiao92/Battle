using System;

namespace Battle.Spell
{
    public class DamageEvent
    {
        /// <summary>
        /// 攻击开始
        /// </summary>
        public void OnAttackStart(Unit.Unit source, Unit.Unit target)
        {
            Source = source;
            Target = target;
            InitValue = Source.GetAttackDamage();
            //Observer 攻击开始
            //ObServer 被攻击开始
        }

        /// <summary>
        /// 攻击出手
        /// </summary>
        //public void OnAttackShot()
        //{
        //    //Observer 攻击出手
        //    //Observer 被攻击出手
        //}

        /// <summary>
        /// 攻击造成伤害
        /// </summary>
        public void OnAttackHit()
        {
            //初始化属性
            InitializeAttribute();

            //设置当前伤害值
            CurValue = InitValue;

            //护甲公式伤害
            ApplyArmorFormula();
            //乘法伤害公式-加成、减免
            MulIncreaseAndReduction();
            //加法伤害公式-加成、减免
            AddIncreaseAndReduction();

            CurValue = (int)Math.Floor(CurValue);
            float cur_health = Target.GetHealth();
            if (cur_health <= CurValue)
            {
                Kill();
            }
            else
            {
                Target.AddHealth(-CurValue);
            }
        }

        /// <summary>
        /// 初始化属性
        /// </summary>
        private void InitializeAttribute()
        {
            Armor = Target.GetArmor();
            ArmorPenetrationPercent = Source.GetArmorPenetrationPercent();
            ArmorPenetrationFlat = Source.GetArmorPenetrationFlat();
        }

        /// <summary>
        /// 击杀目标
        /// </summary>
        void Kill()
        {
            //Target.Kill(Source);
        }

        /// <summary>
        /// 护甲伤害公式
        /// </summary>
        private void ApplyArmorFormula()
        {
            var realArmor = CalculateRealArmor();
            var damageMul = CalculateDamageMulByArmor(realArmor);
            CurValue *= damageMul;
        }

        /// <summary>
        /// 通过护甲计算伤害乘系数
        /// </summary>
        /// <param name="armor"></param>
        /// <returns></returns>
        private static float CalculateDamageMulByArmor(float armor)
        {
            float damageMul;
            if (armor >= 0)
            {
                damageMul = (100.0f / (100.0f + armor));
            }
            else
            {
                damageMul = 2 - (100.0f / (100.0f - armor));
            }

            return damageMul;
        }

        /// <summary>
        /// 护甲穿透,计算真实护甲值
        /// </summary>
        /// <returns></returns>
        private float CalculateRealArmor()
        {
            float realArmor = Armor;
            if (realArmor > 0)
            {
                realArmor *= (1 - ArmorPenetrationPercent / 100.0f);
            }
            else
            {
                realArmor *= (1 + ArmorPenetrationPercent / 100.0f);
            }

            realArmor -= ArmorPenetrationFlat;
            return realArmor;
        }


        /// <summary>
        /// 乘法伤害公式-增加
        /// </summary>
        /// <param name="value"></param>
        void MulIncrease(float value)
        {
            ChangeRate *= (1 + value / 100.0f);
        }

        /// <summary>
        /// 乘法伤害公式-减免
        /// </summary>
        /// <param name="value"></param>
        void MulReduction(float value)
        {
            ChangeRate *= (1 - value / 100.0f);
        }

        /// <summary>
        /// 加法伤害公式-加成
        /// </summary>
        void AddIncrease(float value)
        {
            ChangeNum += value; 
        }

        /// <summary>
        /// 加法伤害公式-减免
        /// </summary>
        void AddReduction(float value)
        {
            ChangeNum -= value; 
        }

        /// <summary>
        /// 乘法公式伤害加成、减免
        /// </summary>
        void MulIncreaseAndReduction()
        {
            CurValue *= ChangeRate;
        }

        /// <summary>
        /// 加法伤害公式加成、减免
        /// </summary>
        void AddIncreaseAndReduction()
        {
            CurValue += ChangeNum;
        }

        /// <summary>
        /// 初始伤害值
        /// </summary>
        private float InitValue { get; set; }

        /// <summary>
        /// 当前伤害值
        /// </summary>
        private float CurValue { get; set; }

        /// <summary>
        /// 攻击者
        /// </summary>
        private Unit.Unit Source { get; set; }

        /// <summary>
        /// 被攻击者
        /// </summary>
        private Unit.Unit Target { get; set; }

        /// <summary>
        /// 被攻击者护甲值
        /// </summary>
        private float Armor { get; set; }

        /// <summary>
        /// 攻击者破甲
        /// </summary>
        private float ArmorPenetrationFlat { get; set; }

        /// <summary>
        /// 攻击者穿透
        /// </summary>
        private float ArmorPenetrationPercent { get; set; }

        /// <summary>
        /// 伤害倍率变化
        /// </summary>
        private float ChangeRate { get; set; } = 1;

        /// <summary>
        /// 伤害值变化
        /// </summary>
        private float ChangeNum { get; set; }
    }
}
