using Battle.Common;
using Battle.Unit;

namespace Battle.Movement
{
    /// <summary>
    /// 直线运动
    /// </summary>
    public class SpecialMovePathLine
    {
        #region 驱动
        public void Tick(float deltaTime)
        {
            float displacement = TickMove(deltaTime);

            var deltaLocation = destLocation - m_owner.Location;
            if (deltaLocation.SquaredLength <= displacement * displacement)
            {
                OverDestLocation();
            }
            else
            {
                MoveDistance(displacement);
            }
        }

        #endregion

        #region 构建

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="gameObject"></param>
        public void Initialize(GameObject gameObject)
        {
            m_owner = gameObject;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 已经完成移动
        /// </summary>
        private void OnFinish()
        {

        }

        /// <summary>
        /// 将拥有者从世界中移除
        /// </summary>
        private void OnRemove()
        {
            m_owner.Remove();
        }

        #endregion

        #region Helper

        /// <summary>
        /// Tick 中进行移动
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        private float TickMove(float deltaTime)
        {
            return 10.0f;
        }

        /// <summary>
        /// 已超越目标位置 
        /// </summary>
        private void OverDestLocation()
        {
            m_owner.Location = destLocation;
            OnFinish();
            OnRemove();
        }

        /// <summary>
        /// 移动指定的距离
        /// </summary>
        /// <param name="distance"></param>
        private void MoveDistance(float distance)
        {
            Vector2D nextLocation = m_owner.Location + new Vector2D(0, distance);
            m_owner.Location = nextLocation;
        }
        #endregion

        /// <summary>
        /// 所有者
        /// </summary>
        private GameObject m_owner;

        /// <summary>
        /// 目的地位置
        /// </summary>
        private Vector2D destLocation = new Vector2D(0, 40);
    }
}