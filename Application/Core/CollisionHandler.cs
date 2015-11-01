using System;
using System.Linq;
using Application.Interfaces;
using Application.Objects;
using Application.Objects.Entities;
using Microsoft.Xna.Framework;

namespace Application.Core
{
    public static class CollisionHandler
    {
        /// <summary>
        /// All logic about collision and physics is kept here.
        /// </summary>

        public static bool ObjectCollisionDetector(IMoveable moveableObject, MoveDirection moveDirection, out GameObject collisionObj)
        {
            Vector2 currentPosition = moveableObject.Position;
            float x = currentPosition.X;
            float y = currentPosition.Y;

            switch (moveDirection)
            {
                case MoveDirection.Up:
                    y -= moveableObject.Speed;
                    break;
                case MoveDirection.Down:
                    y += moveableObject.Speed;
                    break;
                case MoveDirection.Left:
                    x -= moveableObject.Speed;
                    break;
                case MoveDirection.Right:
                    x += moveableObject.Speed;
                    break;
            }

            Rectangle futureBounds = new Rectangle((int)x, (int)y, moveableObject.Bounds.Width, moveableObject.Bounds.Height);
            foreach (GameObject gameObject in ObjectFactory.AllObjects.Where(obj => !(obj is Player)))
            {
                if (futureBounds.Intersects(gameObject.Bounds))
                {
                    if (moveableObject is Player)
                    {
                        collisionObj = gameObject;
                        Console.WriteLine("collision detected!");
                        return true;
                    }
                    if (moveableObject is NPC)
                    {
                        if (gameObject is NPC)
                        {
                            collisionObj = gameObject;
                            return false;
                        }
                        else if (gameObject is Player)
                        {
                            collisionObj = gameObject;
                            return true;
                        }
                    }
                }
            }
            if (futureBounds.X <= 0 ||
               !(futureBounds.X + futureBounds.Width <= Constants.WINDOW_DEFAULT_WIDTH) ||
               futureBounds.Y <= 0 ||
               futureBounds.Y + futureBounds.Height >= Constants.WINDOW_DEFAULT_HEIGHT)
            {
                collisionObj = ObjectFactory.PLAYER;
                Console.WriteLine("Collision detected at ({0},{1})", futureBounds.X, futureBounds.Y);
                return true;
            }
            collisionObj = null;
            return false;
        }
    }
}
