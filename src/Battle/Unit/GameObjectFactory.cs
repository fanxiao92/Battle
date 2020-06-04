using Battle.Enum;

namespace Battle.Unit
{
    public static class GameObjectFactory
    {
        public static GameObject CreateGameObject(GameObjectType type)
        {
            GameObject gameObject = null;
            switch (type)
            {
                case GameObjectType.Creature:
                    gameObject = new Creature();
                    break;
                case GameObjectType.Projectile:
                    gameObject = new Projectile();
                    break;
            }

            return gameObject;
        }
    }
}
