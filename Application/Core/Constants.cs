using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Application.Core
{
    public class Constants
    {
        /// <summary>
        /// Constant values are stored here.
        /// </summary>
        public const int
            PLAYER_DEFAULT_HP = 100, PLAYER_DEFAULT_SPEED = 3,
            ENTITY_DEFAULT_HP = 200, ENTITY_DEFAULT_SPEED = 1,
            ENTITIES_DEFAULT_COUNT = 4;

        public static Vector2
            PLAYER_DEFAULT_POSITION = new Vector2(150, 300),
            ENTITY_RIGHT_POSITION = new Vector2(500, 300),
            ENTITY_LEFT_POSITION = new Vector2(172, 420);

        public static int
            WINDOW_DEFAULT_WIDTH, WINDOW_DEFAULT_HEIGHT;

        public static Texture2D
            Hitman_Uzi_Left,
            Hitman_Uzi_Right,
            Hitman_Uzi_Up,
            Hitman_Uzi_Down,

            Hitman_Knife_Left,
            Hitman_Knife_Right,
            Hitman_Knife_Up,
            Hitman_Knife_Down,

            ZombieCorpseLeft,
            ZombieCorpseRight,
            ZombieCorpseUp,
            ZombieCorpseDown,
            
            GhoulCorpseLeft,
            GhoulCorpseRight,
            GhoulCorpseUp,
            GhoulCorpseDown,
            
            SkeletonCorpseLeft,
            SkeletonCorpseRight,
            SkeletonCorpseUp,
            SkeletonCorpseDown,
            
            WarriorCorpseLeft,
            WarriorCorpseRight,
            WarriorCorpseUp,
            WarriorCorpseDown,

            ButcherCorpseLeft,
            ButcherCorpseRight,
            ButcherCorpseUp,
            ButcherCorpseDown,
            
            MindlessCorpseLeft,
            MindlessCorpseRight,
            MindlessCorpseUp,
            MindlessCorpseDown,

            InfestedHumanCorpseLeft,
            InfestedHumanCorpseRight,
            InfestedHumanCorpseUp,
            InfestedHumanCorpseDown,

            GladiatorCorpseLeft,
            GladiatorCorpseRight,
            GladiatorCorpseUp,
            GladiatorCorpseDown,

            ENTITY_DEFAULT_TEXTURE,
            GRASS_DEFAULT_TEXTURE;
    }
}
