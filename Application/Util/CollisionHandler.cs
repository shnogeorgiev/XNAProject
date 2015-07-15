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
        public static int ObjectID = 0;
        public static List<GameObject> AllObjects = new List<GameObject>();

        public void EntityCollisionCheck()
        {
            //Gravity Check
            foreach (GameObject entity in AllObjects)
            {
                if (entity is Player)
                {
                    foreach (GameObject obj in AllObjects)
                    {
                        if (obj is Terrain)
                        {
                            if (entity.Position.Y + 1 + entity.Height >= obj.Position.Y) (entity as Entity).Falling = false;
                            else (entity as Entity).Falling = true;
                        }
                    }
                }
            }

            //Projectile Movement
            foreach (GameObject obj in AllObjects)
            {
                if (obj is Projectile)
                {
                    switch ((obj as Projectile).Direction)
                    {
                        case MoveDirection.Left:
                            (obj as Projectile).MoveLeft();
                            break;
                        case MoveDirection.Right:
                            (obj as Projectile).MoveRight();
                            break;
                        case MoveDirection.Up:
                            (obj as Projectile).MoveUp();
                            break;
                        case MoveDirection.UpRight:
                            (obj as Projectile).MoveUpRight();
                            break;
                        case MoveDirection.UpLeft:
                            (obj as Projectile).MoveUpLeft();
                            break;
                    }
                }
            }
            
            //Collision Handling for the Player
            foreach (GameObject a in AllObjects)
            {
                foreach (GameObject b in AllObjects)
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
            return false;
        }
    }
}
