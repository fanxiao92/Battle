using Battle.Unit;
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
                RemoveGameObjectNow(unitId);
            }    
            m_waitRemoveUnitIds.Clear();

            foreach (var unit in m_waitAddUnits)
            {
               AddGameObjectNow(unit.Value); 
            }
            m_waitAddUnits.Clear();
        }

        #endregion

        #region ��λ

        /// <summary>
        /// Tick ����ʱ������Ϸ������ӵ�������
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public bool AddGameObject(GameObject gameObject)
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
        /// ������Ϸ������ӵ�������
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        private void AddGameObjectNow(GameObject gameObject)
        {
            m_units.Add(gameObject.InstanceId, gameObject);
        }

        /// <summary>
        /// Tick����ʱ������Ϸ������������Ƴ�
        /// </summary>
        /// <param name="gameObject"></param>
        public void RemoveGameObject(GameObject gameObject)
        {
            m_waitRemoveUnitIds.Add(gameObject.InstanceId);
        }

        /// <summary>
        /// ������Ϸ������������Ƴ�
        /// </summary>
        /// <param name="unitId"></param>
        private void RemoveGameObjectNow(int unitId)
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
        private Dictionary<int, GameObject> m_waitAddUnits = new Dictionary<int, GameObject>();

        /// <summary>
        /// ���������е�λ
        /// </summary>
        private Dictionary<int, GameObject> m_units = new Dictionary<int, GameObject>();

        /// <summary>
        /// �ȴ����Ƴ��ĵ�λ
        /// </summary>
        private HashSet<int> m_waitRemoveUnitIds = new HashSet<int>();

        /// <summary>
        /// �����е���Ϸ��������
        /// </summary>
        public int GameObjectCount => m_waitAddUnits.Count + m_units.Count;
        #endregion

    }
}