using Battle.Spell;

namespace Battle.Buff
{
    public class Buff
    {
        /// <summary>
        /// ‘Ï≥……À∫¶
        /// </summary>
        public void OnDamage(DamageEvent damageEvent)
        {
            //‘ˆº” 10%  …À∫¶
            damageEvent.ModifyMulIncrease(10);
            //◊∑º” 15 µ„…À∫¶
            damageEvent.ModifyAdd(15);
        }

        /// <summary>
        ///  ‹µΩ…À∫¶
        /// </summary>
        public void OnDamaged(DamageEvent damageEvent)
        {
            //ºı√‚ 10% …À∫¶
            damageEvent.ModifyMulReduction(10);
            //ºı√‚ 10 µ„…À∫¶
            damageEvent.ModifyAdd(-10);
        }
    } 
}
