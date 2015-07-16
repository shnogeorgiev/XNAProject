using Application.Entities.Classes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Util
{
    public class ObjectFactory
    {
        public static int ObjectID = 0;
        public static List<GameObject> AllObjects = new List<GameObject>();
        public static Random RandomInstance = new Random();

        public static void GenerateEnemies()
        {
            if (AllObjects.Where(obj => obj is NPC).Count() < Constants.NPCDefaultCount)
            {
                AllObjects.Add(new NPC()
                {
                    Position = new Vector2(800, ObjectFactory.RandomInstance.Next(10, 200)),
                    Texture = Constants.npcDefaultImage,
                    Speed = ObjectFactory.RandomInstance.Next(0, 3)
                });
            }
        }


    }
}
