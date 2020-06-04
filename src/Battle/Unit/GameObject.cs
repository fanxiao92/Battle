﻿//TODO 配置文件增加
//TODO 普通攻击处理 AttackSpeed

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
        /// <returns></returns>
        public static GameObject Create(World.World world, GameObjectType gameObjectType, float facing)
        {
            var gameObject = GameObjectFactory.CreateGameObject(gameObjectType);
            gameObject.Facing = facing;

            if (!gameObject.Initialize(world))
            {
                return null;
            }
            return gameObject;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual bool Initialize(World.World world)
        {

            if (!world.AddUnit(this))
            {
                return false;
            }
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
    }
}