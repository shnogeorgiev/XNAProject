using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Application.Core.Enumerations;
using Application.Objects;
using Application.Objects.MoveableObjects.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Application.Core
{
    public static class ObjectFactory
    {
        public static List<GameObject> AllObjects;
        public static List<object> DeadObjectsInfo;
        public static List<KeyValuePair<Texture2D, Vector2>> DeadObjects;
        
        public static Player PLAYER;
        private static Random RandomInstance = new Random();

        public static void CleanObjects()
        {
            List<GameObject> newObjects = new List<GameObject>();
            foreach (GameObject gameObject in AllObjects)
            {
                if (gameObject is NPC)
                {
                    if ((gameObject as NPC).Health <= 0)
                    {
                        MoveDirection direction = (gameObject as NPC).Direction;
                        EnemyType type = (gameObject as NPC).Type;
                        foreach (var gameObj in DeadObjectsInfo)
                        {
                            if (direction.Equals(gameObj.GetType().GetProperty("direction").GetValue(gameObj, null)) &&
                                type.Equals(gameObj.GetType().GetProperty("type").GetValue(gameObj, null)))
                            {
                                Texture2D texture =
                                    (Texture2D)gameObj.GetType().GetProperty("texture").GetValue(gameObj, null);

                                Vector2 position = new Vector2(gameObject.Position.X,
                                    gameObject.Position.Y + gameObject.AnimationController.FrameWidth / 2);

                                DeadObjects.Add(new KeyValuePair<Texture2D, Vector2>(texture, position));
                                if (DeadObjects.Count() > 15)
                                {
                                    DeadObjects.Remove(DeadObjects.ElementAt(0));
                                }
                            }
                        }
                    }
                }
                if (gameObject is Entity)
                {
                    if ((gameObject as Entity).Health > 0)
                    {
                        newObjects.Add(gameObject);
                    }
                }
            }
            AllObjects = newObjects;
        }

        public static IEnumerable<NPC> GenerateEnemies()
        {
            if (AllObjects.Count(gameObj => gameObj is NPC) < 10)
            {
                int rnd;
                for (int i = 0; i < Constants.ENTITIES_DEFAULT_COUNT; i++)
                {
                    rnd = RandomInstance.Next(0, 2);
                    EnemyType enemyType = EnemyType.Mindless;
                    switch (RandomInstance.Next(0, 6))
                    {
                        case 0:
                            enemyType = EnemyType.Zombie;
                            break;
                        case 1:
                            enemyType = EnemyType.Ghoul;
                            break;
                        case 2:
                            enemyType = EnemyType.Skeleton;
                            break;
                        case 3:
                            enemyType = EnemyType.Warrior;
                            break;
                        case 4:
                            //enemyType = EnemyType.Butcher;
                            break;
                        case 5:
                            enemyType = EnemyType.Mindless;
                            break;
                    }
                    NPC generatedNPC = new NPC(Constants.ENTITY_DEFAULT_TEXTURE, enemyType)
                    {
                        Position = rnd == 1 ? Constants.ENTITY_LEFT_POSITION : Constants.ENTITY_RIGHT_POSITION,
                        Direction = rnd == 1 ? MoveDirection.Left : MoveDirection.Right,
                        Speed = (float)RandomInstance.Next(3, 7) / 10
                    };
                    yield return generatedNPC;
                }
            }
        }
        public static NPC GenerateEnemy(float x, float y, EnemyType type)
        {
            NPC generatedNPC = new NPC(Constants.ENTITY_DEFAULT_TEXTURE, type)
            {
                Position = new Vector2(x, y),
                Speed = 1
            };
            return generatedNPC;
        }
       
    }
}
