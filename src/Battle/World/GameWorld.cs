using System.Collections.Generic;

namespace Battle.World
{
    /// <summary>
    /// ��Ϸ���磬
    /// </summary>
    public class GameWorld
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
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public bool AddUnit(Unit.GameObject gameObject)
        {
            if (gameObject == null)
            {
                return false;
            }

            gameObject.InstanceId = GenerateUnitInstanceId();
            m_waitAddUnits.Add(gameObject.InstanceId, gameObject);
            return true;
        }

        /// <summary>
        /// ������λ��ӵ�������
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        private void AddUnitNow(Unit.GameObject gameObject)
        {
            
            m_units.Add(gameObject.InstanceId, gameObject);
        }

        /// <summary>
        /// Tick����ʱ������λ���������Ƴ�
        /// </summary>
        /// <param name="gameObject"></param>
        public void RemoveUnit(Unit.GameObject gameObject)
        {
            m_waitRemoveUnitIds.Add(gameObject.InstanceId);
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
        private Dictionary<int, Unit.GameObject> m_waitAddUnits = new Dictionary<int, Unit.GameObject>();

        /// <summary>
        /// ���������е�λ
        /// </summary>
        private Dictionary<int, Unit.GameObject> m_units = new Dictionary<int, Unit.GameObject>();

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