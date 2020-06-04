using Battle.Enum;
using Battle.Spell;

namespace Battle.Unit
{
    public class Projectile : GameObject
    {
        #region 驱动
        public override void Tick(float deltaTime)
        {
            base.Tick(deltaTime);
        }

        #endregion

        #region 构建
        public static Projectile Create(World.World world, Creature owner, float facing)
        {
            var projectile = (Projectile)Create(world, GameObjectType.Projectile, facing);
            if (projectile == null)
            {
                return null;
            }

            projectile.Owner = owner;
            return projectile;
        }

        public override bool Initialize(World.World world)
        {
            return base.Initialize(world);
        }

        #endregion
        
        /// <summary>
        /// 攻击上下文
        /// </summary>
        private  DamageEvent m_attackContext = new DamageEvent();

    }
}
