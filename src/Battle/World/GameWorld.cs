using Battle.Unit;
using System.Collections.Generic;

namespace Battle.World
{
    /// <summary>
    /// 游戏世界，
    /// </summary>
    public class GameWorld
    {

        #region 驱动
        /// <summary>
        /// Tick 驱动世界运行
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
        /// Tick 结束处理
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

        #region 单位

        /// <summary>
        /// Tick 结束时，将游戏对象添加到世界中
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
        /// 立马将游戏对象添加到世界中
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        private void AddGameObjectNow(GameObject gameObject)
        {
            m_units.Add(gameObject.InstanceId, gameObject);
        }

        /// <summary>
        /// Tick结束时，将游戏对象从世界中移除
        /// </summary>
        /// <param name="gameObject"></param>
        public void RemoveGameObject(GameObject gameObject)
        {
            m_waitRemoveUnitIds.Add(gameObject.InstanceId);
        }

        /// <summary>
        /// 立马将游戏对象从世界中移除
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
        /// 生成单位实例Id
        /// </summary>
        /// <returns></returns>
        private int GenerateUnitInstanceId()
        {
            return ++m_nextUnitInstanceId;
        }

        /// <summary>
        /// 下一个单位实例 ID
        /// </summary>
        private int m_nextUnitInstanceId;

        /// <summary>
        /// 等待添加的单位
        /// </summary>
        private Dictionary<int, GameObject> m_waitAddUnits = new Dictionary<int, GameObject>();

        /// <summary>
        /// 世界中所有单位
        /// </summary>
        private Dictionary<int, GameObject> m_units = new Dictionary<int, GameObject>();

        /// <summary>
        /// 等待被移除的单位
        /// </summary>
        private HashSet<int> m_waitRemoveUnitIds = new HashSet<int>();

        /// <summary>
        /// 世界中的游戏对象数量
        /// </summary>
        public int GameObjectCount => m_waitAddUnits.Count + m_units.Count;
        #endregion

    }
}