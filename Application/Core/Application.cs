using System.Collections.Generic;
using System.Linq;

using Application.Core;
using Application.Core.Enumerations;

using Application.Interfaces;
using Application.Objects.MoveableObjects.Entities;
using Application.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Application
{
    public class Application : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Application()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = false;
            Constants.WINDOW_DEFAULT_WIDTH = 1024;
            Constants.WINDOW_DEFAULT_HEIGHT = 720;

            ObjectFactory.AllObjects = new List<GameObject>();
            ObjectFactory.DeadObjects = new List<KeyValuePair<Texture2D, Vector2>>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Constants.Hitman_Knife_Down = Content.Load<Texture2D>("Graphics\\HitmanSpriteKnifeDown");
            Constants.Hitman_Knife_Up = Content.Load<Texture2D>("Graphics\\HitmanSpriteKnifeUp");
            Constants.Hitman_Knife_Right = Content.Load<Texture2D>("Graphics\\HitmanSpriteKnifeRight");
            Constants.Hitman_Knife_Left = Content.Load<Texture2D>("Graphics\\HitmanSpriteKnifeLeft");

            Constants.Hitman_Uzi_Down = Content.Load<Texture2D>("Graphics\\HitmanSpriteUziDown");
            Constants.Hitman_Uzi_Up = Content.Load<Texture2D>("Graphics\\HitmanSpriteUziUp");
            Constants.Hitman_Uzi_Right = Content.Load<Texture2D>("Graphics\\HitmanSpriteUziRight");
            Constants.Hitman_Uzi_Left = Content.Load<Texture2D>("Graphics\\HitmanSpriteUziLeft");

            Constants.ZombieCorpseLeft = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Zombie_Corpse_Left");
            Constants.ZombieCorpseRight = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Zombie_Corpse_Right");
            Constants.ZombieCorpseUp = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Zombie_Corpse_Up");
            Constants.ZombieCorpseDown = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Zombie_Corpse_Down");

            Constants.GhoulCorpseLeft = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Ghoul_Corpse_Left");
            Constants.GhoulCorpseRight = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Ghoul_Corpse_Right");
            Constants.GhoulCorpseUp = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Ghoul_Corpse_Up");
            Constants.GhoulCorpseDown = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Ghoul_Corpse_Down");

            Constants.SkeletonCorpseLeft = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Skeleton_Corpse_Left");
            Constants.SkeletonCorpseRight = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Skeleton_Corpse_Right");
            Constants.SkeletonCorpseUp = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Skeleton_Corpse_Up");
            Constants.SkeletonCorpseDown = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Skeleton_Corpse_Down");

            Constants.WarriorCorpseLeft = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Warrior_Corpse_Left");
            Constants.WarriorCorpseRight = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Warrior_Corpse_Right");
            Constants.WarriorCorpseUp = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Warrior_Corpse_Up");
            Constants.WarriorCorpseDown = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Warrior_Corpse_Down");

            Constants.ButcherCorpseLeft = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Butcher_Corpse_Left");
            Constants.ButcherCorpseRight = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Butcher_Corpse_Right");
            Constants.ButcherCorpseUp = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Butcher_Corpse_Up");
            Constants.ButcherCorpseDown = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Butcher_Corpse_Down");

            Constants.MindlessCorpseLeft = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Mindless_Corpse_Left");
            Constants.MindlessCorpseRight = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Mindless_Corpse_Right");
            Constants.MindlessCorpseUp = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Mindless_Corpse_Up");
            Constants.MindlessCorpseDown = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Mindless_Corpse_Down");

            Constants.InfestedHumanCorpseLeft =
                Content.Load<Texture2D>("Graphics\\EnemyCorpses\\InfestedHuman_Corpse_Left");
            Constants.InfestedHumanCorpseRight =
                Content.Load<Texture2D>("Graphics\\EnemyCorpses\\InfestedHuman_Corpse_Right");
            Constants.InfestedHumanCorpseUp = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\InfestedHuman_Corpse_Up");
            Constants.InfestedHumanCorpseDown =
                Content.Load<Texture2D>("Graphics\\EnemyCorpses\\InfestedHuman_Corpse_Down");

            Constants.GladiatorCorpseLeft = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Gladiator_Corpse_Left");
            Constants.GladiatorCorpseRight = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Gladiator_Corpse_Right");
            Constants.GladiatorCorpseUp = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Gladiator_Corpse_Up");
            Constants.GladiatorCorpseDown = Content.Load<Texture2D>("Graphics\\EnemyCorpses\\Gladiator_Corpse_Down");

            Constants.ENTITY_DEFAULT_TEXTURE = Content.Load<Texture2D>("Graphics\\EnemySprite");
            Constants.GRASS_DEFAULT_TEXTURE = Content.Load<Texture2D>("Graphics\\Terrain");

            ObjectFactory.PLAYER = new Player(Constants.Hitman_Uzi_Down);
            ObjectFactory.AllObjects.Add(ObjectFactory.PLAYER);

            ObjectFactory.DeadObjectsInfo = new List<object>()
            {
                {new {type = EnemyType.Zombie, direction = MoveDirection.Left, texture = Constants.ZombieCorpseRight}},
                {new {type = EnemyType.Zombie, direction = MoveDirection.Right, texture = Constants.ZombieCorpseLeft}},
                {new {type = EnemyType.Zombie, direction = MoveDirection.Up, texture = Constants.ZombieCorpseDown}},
                {new {type = EnemyType.Zombie, direction = MoveDirection.Down, texture = Constants.ZombieCorpseUp}},

                {new {type = EnemyType.Ghoul, direction = MoveDirection.Left, texture = Constants.GhoulCorpseRight}},
                {new {type = EnemyType.Ghoul, direction = MoveDirection.Right, texture = Constants.GhoulCorpseLeft}},
                {new {type = EnemyType.Ghoul, direction = MoveDirection.Up, texture = Constants.GhoulCorpseDown}},
                {new {type = EnemyType.Ghoul, direction = MoveDirection.Down, texture = Constants.GhoulCorpseUp}},

                {
                    new
                    {
                        type = EnemyType.Skeleton,
                        direction = MoveDirection.Left,
                        texture = Constants.SkeletonCorpseRight
                    }
                },
                {
                    new
                    {
                        type = EnemyType.Skeleton,
                        direction = MoveDirection.Right,
                        texture = Constants.SkeletonCorpseLeft
                    }
                },
                {new {type = EnemyType.Skeleton, direction = MoveDirection.Up, texture = Constants.SkeletonCorpseDown}},
                {new {type = EnemyType.Skeleton, direction = MoveDirection.Down, texture = Constants.WarriorCorpseUp}},

                {new {type = EnemyType.Warrior, direction = MoveDirection.Left, texture = Constants.WarriorCorpseRight}},
                {new {type = EnemyType.Warrior, direction = MoveDirection.Right, texture = Constants.WarriorCorpseLeft}},
                {new {type = EnemyType.Warrior, direction = MoveDirection.Up, texture = Constants.WarriorCorpseDown}},
                {new {type = EnemyType.Warrior, direction = MoveDirection.Down, texture = Constants.WarriorCorpseUp}},

                {new {type = EnemyType.Butcher, direction = MoveDirection.Left, texture = Constants.ButcherCorpseRight}},
                {new {type = EnemyType.Butcher, direction = MoveDirection.Right, texture = Constants.ButcherCorpseLeft}},
                {new {type = EnemyType.Butcher, direction = MoveDirection.Up, texture = Constants.ButcherCorpseDown}},
                {new {type = EnemyType.Butcher, direction = MoveDirection.Down, texture = Constants.ButcherCorpseUp}},

                {
                    new
                    {
                        type = EnemyType.Mindless,
                        direction = MoveDirection.Left,
                        texture = Constants.MindlessCorpseRight
                    }
                },
                {
                    new
                    {
                        type = EnemyType.Mindless,
                        direction = MoveDirection.Right,
                        texture = Constants.MindlessCorpseLeft
                    }
                },
                {new {type = EnemyType.Mindless, direction = MoveDirection.Up, texture = Constants.MindlessCorpseDown}},
                {new {type = EnemyType.Mindless, direction = MoveDirection.Down, texture = Constants.MindlessCorpseUp}},

                {
                    new
                    {
                        type = EnemyType.InfestedHuman,
                        direction = MoveDirection.Left,
                        texture = Constants.InfestedHumanCorpseRight
                    }
                },
                {
                    new
                    {
                        type = EnemyType.InfestedHuman,
                        direction = MoveDirection.Right,
                        texture = Constants.InfestedHumanCorpseLeft
                    }
                },
                {
                    new
                    {
                        type = EnemyType.InfestedHuman,
                        direction = MoveDirection.Up,
                        texture = Constants.InfestedHumanCorpseDown
                    }
                },
                {
                    new
                    {
                        type = EnemyType.InfestedHuman,
                        direction = MoveDirection.Down,
                        texture = Constants.InfestedHumanCorpseUp
                    }
                },

                {
                    new
                    {
                        type = EnemyType.Gladiator,
                        direction = MoveDirection.Left,
                        texture = Constants.GladiatorCorpseRight
                    }
                },
                {
                    new
                    {
                        type = EnemyType.Gladiator,
                        direction = MoveDirection.Right,
                        texture = Constants.GladiatorCorpseLeft
                    }
                },
                {
                    new {type = EnemyType.Gladiator, direction = MoveDirection.Up, texture = Constants.GladiatorCorpseDown}
                },
                {
                    new {type = EnemyType.Gladiator, direction = MoveDirection.Down, texture = Constants.GladiatorCorpseUp}
                }
            };

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            InputManager.CurrentKeyboardState = Keyboard.GetState();
            InputManager.MovementKeysListener();

            ObjectFactory.CleanObjects();
            ObjectFactory.GenerateEnemies().ToList().ForEach(enemy =>
            {
                ObjectFactory.AllObjects.Add(enemy);
            });

            foreach (GameObject gameObject in ObjectFactory.AllObjects)
            {
                GameObject collidedGameObject;
                if (gameObject is IMoveable)
                {
                    if (gameObject is NPC)
                    {
                        if (!CollisionHandler.ObjectCollisionDetector(
                            (gameObject as NPC),
                            MoveDirection.Left,
                            out collidedGameObject) &&
                            ObjectFactory.PLAYER.Bounds.X + ObjectFactory.PLAYER.Bounds.Width < gameObject.Bounds.X)
                        {
                            (gameObject as NPC).MoveLeft();
                        }
                        if (!CollisionHandler.ObjectCollisionDetector(
                            (gameObject as NPC),
                            MoveDirection.Right,
                            out collidedGameObject) &&
                            ObjectFactory.PLAYER.Bounds.X > gameObject.Bounds.X + gameObject.Bounds.Width)
                        {
                            (gameObject as NPC).MoveRight();
                        }
                        if (!CollisionHandler.ObjectCollisionDetector(
                            (gameObject as NPC),
                            MoveDirection.Up,
                            out collidedGameObject) &&
                            ObjectFactory.PLAYER.Bounds.Y + ObjectFactory.PLAYER.Bounds.Height < gameObject.Bounds.Y)
                        {
                            (gameObject as NPC).MoveUp();
                        }
                        if (!CollisionHandler.ObjectCollisionDetector(
                            (gameObject as NPC),
                            MoveDirection.Down,
                            out collidedGameObject) &&
                            ObjectFactory.PLAYER.Bounds.Y > gameObject.Bounds.Y + gameObject.Bounds.Height)
                        {
                            (gameObject as NPC).MoveDown();
                        }
                    }
                }
            }

            ObjectFactory.AllObjects = ObjectFactory.AllObjects.OrderBy(obj => obj.Position.Y).ToList<GameObject>();

            InputManager.PreviousKeyboardState = InputManager.CurrentKeyboardState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(Constants.GRASS_DEFAULT_TEXTURE, new Vector2(0, 0), Color.White);
            foreach (KeyValuePair<Texture2D, Vector2> deadObj in ObjectFactory.DeadObjects)
            {
                spriteBatch.Draw(deadObj.Key, deadObj.Value);
            }
            ObjectFactory.AllObjects.ForEach(gameobj =>
            {
                gameobj.Update(gameTime);
                gameobj.Draw(spriteBatch, gameobj.ColorType);
            });
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
