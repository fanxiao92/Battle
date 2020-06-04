using System.Collections.Generic;

namespace Battle.World
{
    public class World
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

        #region 单位

        /// <summary>
        /// Tick 结束时，将单位添加到世界中
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
        /// 立马将单位添加到世界中
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        private void AddUnitNow(Unit.Unit unit)
        {
            
            m_units.Add(unit.InstanceId, unit);
        }

        /// <summary>
        /// Tick结束时，将单位从世界中移除
        /// </summary>
        /// <param name="unit"></param>
        public void RemoveUnit(Unit.Unit unit)
        {
            m_waitRemoveUnitIds.Add(unit.InstanceId);
        }

        /// <summary>
        /// 立马将单位从世界中移除
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
        private Dictionary<int, Unit.Unit> m_waitAddUnits = new Dictionary<int, Unit.Unit>();

        /// <summary>
        /// 世界中所有单位
        /// </summary>
        private Dictionary<int, Unit.Unit> m_units = new Dictionary<int, Unit.Unit>();

        /// <summary>
        /// 等待被移除的单位
        /// </summary>
        private HashSet<int> m_waitRemoveUnitIds = new HashSet<int>();

        /// <summary>
        /// 世界中的单位总量
        /// </summary>
        public int UnitCount => m_waitAddUnits.Count + m_units.Count;
        #endregion

    }
}