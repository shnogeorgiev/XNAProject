using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Application.Entities.Classes;
using Application.Util;

namespace Application
{
    public class GameMenu : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public CollisionHandler collisionHandler;

        public Player PlayerChar;
        public NPC NPCChar;

        public Terrain Land;

        public GameMenu()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            PlayerChar = new Player()
            {
                Position = new Vector2(200, 200),
                Texture = Content.Load<Texture2D>("Graphics\\RedBox"),
                Speed = 2
            };

            NPCChar = new NPC()
            {
                Position = new Vector2(600, 200),
                Texture = Content.Load<Texture2D>("Graphics\\BlueBox")
            };

            Land = new Terrain()
            {
                Position = new Vector2(0, 220),
                Texture = Content.Load<Texture2D>("Graphics\\Land"),
            };

            collisionHandler = new Util.CollisionHandler();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            #region Movement Listener
            else
            {
                if (PlayerChar.Position.X < 0)
                {
                    PlayerChar.Position = new Vector2(PlayerChar.Position.X + 1, PlayerChar.Position.Y);
                }
                else if (PlayerChar.Position.Y < 0)
                {
                    PlayerChar.Position = new Vector2(PlayerChar.Position.X, PlayerChar.Position.Y + 1);
                }
                else if (PlayerChar.Position.X + PlayerChar.Width >= graphics.PreferredBackBufferWidth)
                {
                    PlayerChar.Position = new Vector2(PlayerChar.Position.X - 1, PlayerChar.Position.Y);
                }
                else if (PlayerChar.Position.Y + PlayerChar.Height >= graphics.PreferredBackBufferHeight)
                {
                    PlayerChar.Position = new Vector2(PlayerChar.Position.X, PlayerChar.Position.Y - 1);
                }
                else
                {
                    //Move Up
                    /*if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.W))
                    {
                        if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.D))
                            PlayerChar.MoveUpRight();
                        else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.A))
                            PlayerChar.MoveUpLeft();
                        else
                            PlayerChar.MoveUp();
                    }*/

                    //Move Down
                    /*else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.S))
                    {
                        if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.D))
                            PlayerChar.MoveDownRight();
                        else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.A))
                            PlayerChar.MoveDownLeft();
                        else
                            PlayerChar.MoveDown();
                    }*/

                    //Jump Method
                    if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Space))
                    {
                        if (!PlayerChar.Falling)
                        {
                            PlayerChar.JumpCount = 30;
                        }
                    }
                    //Movement Methods
                    else if (Keyboard.GetState(PlayerIndex.One).GetPressedKeys().Contains(Keys.A))
                    {
                        PlayerChar.MoveLeft();
                    }
                    else if (Keyboard.GetState(PlayerIndex.One).GetPressedKeys().Contains(Keys.D))
                    {
                        PlayerChar.MoveRight();
                    }
                    //Attack Methods
                    else if (Util.CollisionHandler.AllObjects.Count((obj) => obj is Projectile) < 11)
                    {
                        if (Keyboard.GetState(PlayerIndex.One).GetPressedKeys().Contains(Keys.NumPad4))
                        {
                            if (!PlayerChar.Falling) PlayerChar.Attack(MoveDirection.Left);
                        }
                        else if (Keyboard.GetState(PlayerIndex.One).GetPressedKeys().Contains(Keys.NumPad6))
                        {
                            if (!PlayerChar.Falling) PlayerChar.Attack(MoveDirection.Right);
                        }
                        else if (Keyboard.GetState(PlayerIndex.One).GetPressedKeys().Contains(Keys.NumPad8))
                        {
                            if (!PlayerChar.Falling) PlayerChar.Attack(MoveDirection.Up);
                        }
                        else if (Keyboard.GetState(PlayerIndex.One).GetPressedKeys().Contains(Keys.NumPad9))
                        {
                            if (!PlayerChar.Falling) PlayerChar.Attack(MoveDirection.UpRight);
                        }
                        else if (Keyboard.GetState(PlayerIndex.One).GetPressedKeys().Contains(Keys.NumPad7))
                        {
                            if (!PlayerChar.Falling) PlayerChar.Attack(MoveDirection.UpLeft);
                        }
                    }
                }

                if (PlayerChar.JumpCount > 0)
                {
                    PlayerChar.MoveUp();
                    PlayerChar.JumpCount--;
                }
                else if (PlayerChar.Falling)
                {
                    PlayerChar.MoveDown();
                }
            }
            #endregion

            collisionHandler.EntityCollisionCheck();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            List<GameObject> objectsForRemoval = new List<GameObject>();

            foreach (GameObject obj in CollisionHandler.AllObjects)
            {
                if (obj is Projectile)
                {
                    obj.Texture = Content.Load<Texture2D>("Graphics\\Laser");
                    if (obj.Position.X < 0
                        || obj.Position.Y < 0
                        || obj.Position.X > graphics.PreferredBackBufferWidth
                        || obj.Position.Y > graphics.PreferredBackBufferHeight)

                        objectsForRemoval.Add(obj);
                }


                spriteBatch.Draw(obj.Texture, obj.Position, Color.White);
            }
            foreach (GameObject obj in objectsForRemoval)
            {
                CollisionHandler.AllObjects.RemoveAll(projectile => obj.ID == projectile.ID);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
