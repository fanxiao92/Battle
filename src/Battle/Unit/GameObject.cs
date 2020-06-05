//TODO 配置文件增加
//TODO 普通攻击处理 AttackSpeed

using Battle.Common;
using Battle.Enum;

namespace Battle.Unit   
{
    /// <summary>
    /// 游戏单位对象
    /// </summary>
    public abstract class GameObject
    {

        #region 驱动

        /// <summary>
        /// Tick 驱动
        /// </summary>
        /// <param name="deltaTime"></param>
        public virtual void Tick(float deltaTime)
        {

        }

        #endregion

        #region 构建

        /// <summary>
        /// 创建游戏对象
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <param name="gameObjectType"></param>
        /// <param name="location"></param>
        /// <param name="facing"></param>
        /// <returns></returns>
        public static GameObject Create(World.GameWorld gameWorld, GameObjectType gameObjectType, Vector2D location,
            float facing)
        {
            var gameObject = GameObjectFactory.CreateGameObject(gameObjectType);
            if (!gameObject.Initialize(gameWorld, location, facing))
            {
                return null;
            }
            return gameObject;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual bool Initialize(World.GameWorld gameWorld, Vector2D location, float facing)
        {
            if (!gameWorld.AddUnit(this))
            {
                return false;
            }

            Location = location;
            Facing = facing;
            return true;
        }

        #endregion

        /// <summary>
        /// 实例 ID
        /// </summary>
        public int InstanceId { get; set; }


        /// <summary>
        /// 朝向
        /// </summary>
        public float Facing { get; set; }

        /// <summary>
        /// 所有者
        /// </summary>
        public Creature Owner { get; set; }

        /// <summary>
        /// 对象在世界中的位置
        /// </summary>
        public Vector2D Location { get; set; }
    }
}
