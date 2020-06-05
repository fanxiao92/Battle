using Battle.Common;
using Battle.Enum;

//TODO 弹道的移动,碰撞处理,造成伤害
namespace Battle.Unit
{
    /// <summary>
    /// 游戏弹道对象类型
    /// </summary>
    public sealed class Projectile : GameObject
    {
        #region 驱动
        public override void Tick(float deltaTime)
        {
            base.Tick(deltaTime);
        }

        #endregion

        #region 构建

        /// <summary>
        /// 创建弹道
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <param name="owner"></param>
        /// <param name="location"></param>
        /// <param name="facing"></param>
        /// <returns></returns>
        public static Projectile Create(World.GameWorld gameWorld, Creature owner, Vector2D location, float facing)
        {
            var projectile = (Projectile)Create(gameWorld, GameObjectType.Projectile, location, facing);
            if (projectile == null)
            {
                return null;
            }

            projectile.Owner = owner;
            return projectile;
        }

        /// <summary>
        /// 初始化弹道状态
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <param name="location"></param>
        /// <param name="facing"></param>
        /// <returns></returns>
        public override bool Initialize(World.GameWorld gameWorld, Vector2D location, float facing)
        {
            if (!base.Initialize(gameWorld, location, facing))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
