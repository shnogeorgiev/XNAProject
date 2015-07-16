using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Entities.Classes;

namespace Application.Util
{
    public class CollisionHandler
    {
        /// <summary>
        /// The methods inside this class are executed at every loop of the game.
        /// This class is suitable for writing and keeping logic about collision or mechanics.
        /// </summary>
        public void EntityCollisionCheck()
        {
            //Gravity Check
            foreach (GameObject a in ObjectFactory.AllObjects)
            {
                if (a is Player)
                {
                    foreach (GameObject b in ObjectFactory.AllObjects)
                    {
                        if (b is Terrain)
                        {
                            if (a.Position.Y + 1 + a.Height >= b.Position.Y) (a as Entity).Falling = false;
                            else (a as Entity).Falling = true;
                        }
                    }
                }
            }

            //Projectile Movement
            foreach (GameObject a in ObjectFactory.AllObjects)
            {
                if (a is Projectile)
                {
                    switch ((a as Projectile).Direction)
                    {
                        case MoveDirection.Left:
                            (a as Projectile).MoveLeft();
                            break;
                        case MoveDirection.Right:
                            (a as Projectile).MoveRight();
                            break;
                        case MoveDirection.Up:
                            (a as Projectile).MoveUp();
                            break;
                        case MoveDirection.UpRight:
                            (a as Projectile).MoveUpRight();
                            break;
                        case MoveDirection.UpLeft:
                            (a as Projectile).MoveUpLeft();
                            break;
                    }
                }
            }
            
            //Collision Handling for the Player
            foreach (GameObject a in ObjectFactory.AllObjects)
            {
                foreach (GameObject b in ObjectFactory.AllObjects)
                {
                    if (a.Position.X < b.Position.X + b.Width &&
                        a.Position.X + a.Width > b.Position.X &&
                        a.Position.Y < b.Position.Y + b.Height &&
                        a.Position.Y + a.Height > b.Position.Y)
                    {
                        if (a.ID != b.ID)
                        {
                            this.HandleCollision(a, b);
                        }
                        else continue;
                    }
                    else continue;
                }
            }
        }

        //Collision Handler for Entities
        private bool HandleCollision(GameObject a, GameObject b)
        {
            if (a is Entity)
            {
                switch ((a as Entity).Direction)
                {
                    case MoveDirection.Right:
                        (a as Entity).MoveLeft();
                        return true;
                    case MoveDirection.Left:
                        (a as Entity).MoveRight();
                        return true;
                    case MoveDirection.Up:
                        (a as Entity).MoveDown();
                        return true;
                    case MoveDirection.Down:
                        (a as Entity).MoveUp();
                        return true;
                    case MoveDirection.UpLeft:
                        (a as Entity).MoveDownRight();
                        return true;
                    case MoveDirection.UpRight:
                        (a as Entity).MoveDownLeft();
                        return true;
                    case MoveDirection.DownLeft:
                        (a as Entity).MoveUpRight();
                        return true;
                    case MoveDirection.DownRight:
                        (a as Entity).MoveUpLeft();
                        return true;
                }
                return false;
            }
            else if (a is Projectile)
            {
                if (b is Entity)
                {
                    if (b is NPC)
                    {
                        (b as Entity).Health -= (a as Projectile).Damage;
                        if ((b as Entity).Health <= 0) (b as Entity).IsAlive = false;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
