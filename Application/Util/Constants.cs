using Application.Entities.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Util
{
    public static class Constants
    {
        /// <summary>
        /// Constants and default values of variables.
        /// </summary>
        public const int
            GameObjectDefaultWidth = 20, GameObjectDefaultHeight = 20,
            EntityDefaultWidth = 20, EntityDefaultHeight = 20, EntityDefaultHealth = 100, EntityDefaultSpeed = 2,
            LandDefaultWidth = 1000, LandDefaultHeight = 50,
            ProjectileDefaultWidth = 10, ProjectileDefaultHeight = 5, ProjectileDefaultDamage = 50, ProjectileDefaultSpeed = 25;

        public const int
            NPCDefaultCount = 30;

        //These are set in the GameMenu.cs class.
        public static Texture2D
            playerDefaultImage,
            npcDefaultImage,
            terrainDefaultImage;
        //

        //Default Positions
        public static Vector2
            playerDefaultPosition = new Vector2(200, 200),
            npcDefaultPosition = new Vector2(600, 200),
            terrainDefaultPosition = new Vector2(0, 220);

        public static NPC DefaultNPC()
        {
            return new NPC()
                {
                    Position = new Vector2(800, ObjectFactory.RandomInstance.Next(10, 200)),
                    Texture = Constants.npcDefaultImage,
                    Speed = ObjectFactory.RandomInstance.Next(0, 2),
                    IsAlive = true
                };
        }
    }
}
