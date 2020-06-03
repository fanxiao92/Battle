using Battle.Spell;

namespace Battle.Buff
{
    public class Buff
    {
        /// <summary>
        /// ����˺�
        /// </summary>
        public void OnDamage(DamageEvent damageEvent)
        {
            //���� 10%  �˺�
            damageEvent.ModifyMulIncrease(10);
            //׷�� 15 ���˺�
            damageEvent.ModifyAdd(15);
        }

        /// <summary>
        /// �ܵ��˺�
        /// </summary>
        public void OnDamaged(DamageEvent damageEvent)
        {
            //���� 10% �˺�
            damageEvent.ModifyMulReduction(10);
            //���� 10 ���˺�
            damageEvent.ModifyAdd(-10);
        }
    } 
}
