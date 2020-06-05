using Battle.Common;
using Battle.Unit;

namespace Battle.Movement
{
    /// <summary>
    /// ֱ���˶�
    /// </summary>
    public class SpecialMovePathLine
    {
        #region ����
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

        #region ����

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="gameObject"></param>
        public void Initialize(GameObject gameObject)
        {
            m_owner = gameObject;
        }

        #endregion

        #region �¼�

        /// <summary>
        /// �Ѿ�����ƶ�
        /// </summary>
        private void OnFinish()
        {

        }

        /// <summary>
        /// ��ӵ���ߴ��������Ƴ�
        /// </summary>
        private void OnRemove()
        {
            m_owner.Remove();
        }

        #endregion

        #region Helper

        /// <summary>
        /// Tick �н����ƶ�
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        private float TickMove(float deltaTime)
        {
            return 10.0f;
        }

        /// <summary>
        /// �ѳ�ԽĿ��λ�� 
        /// </summary>
        private void OverDestLocation()
        {
            m_owner.Location = destLocation;
            OnFinish();
            OnRemove();
        }

        /// <summary>
        /// �ƶ�ָ���ľ���
        /// </summary>
        /// <param name="distance"></param>
        private void MoveDistance(float distance)
        {
            Vector2D nextLocation = m_owner.Location + new Vector2D(0, distance);
            m_owner.Location = nextLocation;
        }
        #endregion

        /// <summary>
        /// ������
        /// </summary>
        private GameObject m_owner;

        /// <summary>
        /// Ŀ�ĵ�λ��
        /// </summary>
        private Vector2D destLocation = new Vector2D(0, 40);
    }
}