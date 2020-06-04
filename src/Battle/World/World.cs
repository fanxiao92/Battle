using System.Collections.Generic;

namespace Battle.World
{
    public class World
    {

        #region ����
        /// <summary>
        /// Tick ������������
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Tick(float deltaTime)
        {
            foreach (var unit in m_units)
            {
                unit.Value.Tick(deltaTime);
            }
        }

        /// <summary>
        /// Tick ��������
        /// </summary>
        public void TickEnd()
        {

            foreach (var unitId in m_waitRemoveUnitIds)
            {
                RemoveUnitNow(unitId);
            }    
            m_waitRemoveUnitIds.Clear();

            foreach (var unit in m_waitAddUnits)
            {
               AddUnitNow(unit.Value); 
            }
            m_waitAddUnits.Clear();
        }

        #endregion

        #region ��λ

        /// <summary>
        /// Tick ����ʱ������λ��ӵ�������
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public bool AddUnit(Unit.Unit unit)
        {
            if (unit == null)
            {
                return false;
            }

            unit.InstanceId = GenerateUnitInstanceId();
            m_waitAddUnits.Add(unit.InstanceId, unit);
            return true;
        }

        /// <summary>
        /// ������λ��ӵ�������
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        private void AddUnitNow(Unit.Unit unit)
        {
            
            m_units.Add(unit.InstanceId, unit);
        }

        /// <summary>
        /// Tick����ʱ������λ���������Ƴ�
        /// </summary>
        /// <param name="unit"></param>
        public void RemoveUnit(Unit.Unit unit)
        {
            m_waitRemoveUnitIds.Add(unit.InstanceId);
        }

        /// <summary>
        /// ������λ���������Ƴ�
        /// </summary>
        /// <param name="unitId"></param>
        private void RemoveUnitNow(int unitId)
        {
            if (!m_units.Remove(unitId))
            {
                m_waitAddUnits.Remove(unitId);
            }
        }

        /// <summary>
        /// ���ɵ�λʵ��Id
        /// </summary>
        /// <returns></returns>
        private int GenerateUnitInstanceId()
        {
            return ++m_nextUnitInstanceId;
        }

        /// <summary>
        /// ��һ����λʵ�� ID
        /// </summary>
        private int m_nextUnitInstanceId;

        /// <summary>
        /// �ȴ���ӵĵ�λ
        /// </summary>
        private Dictionary<int, Unit.Unit> m_waitAddUnits = new Dictionary<int, Unit.Unit>();

        /// <summary>
        /// ���������е�λ
        /// </summary>
        private Dictionary<int, Unit.Unit> m_units = new Dictionary<int, Unit.Unit>();

        /// <summary>
        /// �ȴ����Ƴ��ĵ�λ
        /// </summary>
        private HashSet<int> m_waitRemoveUnitIds = new HashSet<int>();

        /// <summary>
        /// �����еĵ�λ����
        /// </summary>
        public int UnitCount => m_waitAddUnits.Count + m_units.Count;
        #endregion

    }
}