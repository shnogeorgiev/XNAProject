using System.Linq;
using Application.Objects;
using Application.Objects.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Application.Core
{
    public static class InputManager
    {
        /// <summary>
        /// Controls and input is handled in this class.
        /// </summary>
        public static KeyboardState PreviousKeyboardState;
        public static KeyboardState CurrentKeyboardState;

        public static void MovementKeysListener()
        {
            if (Keys.F1.IsPressed())
            {
                ObjectFactory.PLAYER.SwitchWeapon(WeaponType.Knife);
            }
            if (Keys.F2.IsPressed())
            {
                ObjectFactory.PLAYER.SwitchWeapon(WeaponType.Uzi);
            }
            if (Keys.Space.IsDown())
            {
                switch (ObjectFactory.PLAYER.Weapon)
                {
                    case WeaponType.Uzi:
                        if (PreviousKeyboardState.IsKeyUp(Keys.Space))
                        {
                            ObjectFactory.PLAYER.AnimationController.CurrentFrame =
                                new Vector2(ObjectFactory.PLAYER.AnimationController.Image.Width -
                                            ObjectFactory.PLAYER.AnimationController.FrameWidth, 0);
                        }

                        ObjectFactory.PLAYER.AnimationController.StartFrame =
                            ObjectFactory.PLAYER.AnimationController.Image.Width -
                            ObjectFactory.PLAYER.AnimationController.FrameWidth * 2;

                        ObjectFactory.PLAYER.AnimationController.EndFrame =
                            ObjectFactory.PLAYER.AnimationController.Image.Width;
                        break;
                    case WeaponType.Knife:
                        if (PreviousKeyboardState.IsKeyUp(Keys.Space))
                        {
                            ObjectFactory.PLAYER.AnimationController.CurrentFrame =
                                new Vector2(ObjectFactory.PLAYER.AnimationController.Image.Width -
                                            ObjectFactory.PLAYER.AnimationController.FrameWidth * 5, 0);
                        }
                        ObjectFactory.PLAYER.AnimationController.StartFrame =
                            ObjectFactory.PLAYER.AnimationController.Image.Width -
                            ObjectFactory.PLAYER.AnimationController.FrameWidth * 5;

                        ObjectFactory.PLAYER.AnimationController.EndFrame =
                            ObjectFactory.PLAYER.AnimationController.Image.Width -
                            ObjectFactory.PLAYER.AnimationController.FrameWidth;
                        break;
                }
                ObjectFactory.PLAYER.AnimationController.Active = true;

                foreach (var o in ObjectFactory.AllObjects.Where(obj => obj is NPC))
                {
                    var npc = (NPC)o;
                    bool targetFound = false;
                    if (npc.Bounds.Intersects(ObjectFactory.PLAYER.Bounds))
                    {
                        switch (ObjectFactory.PLAYER.Weapon)
                        {
                            case WeaponType.Uzi:
                                npc.Health -= 25;
                                targetFound = true;
                                break;
                            case WeaponType.Knife:
                                npc.Health -= 10;
                                targetFound = true;
                                break;
                        }
                    }
                    else
                    {
                        switch (ObjectFactory.PLAYER.Direction)
                        {
                            case MoveDirection.Left:
                                if (npc.Bounds.X <= ObjectFactory.PLAYER.Bounds.X &&
                                    npc.Bounds.Y >= ObjectFactory.PLAYER.Bounds.Y - 25 &&
                                    npc.Bounds.Y + npc.Bounds.Height <= ObjectFactory.PLAYER.Bounds.Y + ObjectFactory.PLAYER.Bounds.Height + 25)
                                {
                                    switch (ObjectFactory.PLAYER.Weapon)
                                    {
                                        case WeaponType.Uzi:
                                            npc.Health -= 25;
                                            targetFound = true;
                                            break;
                                        case WeaponType.Knife:
                                            if (ObjectFactory.PLAYER.Bounds.X - npc.Bounds.X <=
                                                ObjectFactory.PLAYER.AnimationController.FrameWidth + 10)
                                            {
                                                npc.Health -= 10;
                                                targetFound = true;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case MoveDirection.Down:
                                if (npc.Bounds.X >= ObjectFactory.PLAYER.Bounds.X - 25 &&
                                    npc.Bounds.X + npc.Bounds.Width <= ObjectFactory.PLAYER.Bounds.X + ObjectFactory.PLAYER.Bounds.Width + 25 &&
                                    npc.Bounds.Y >= ObjectFactory.PLAYER.Bounds.Y)
                                {
                                    switch (ObjectFactory.PLAYER.Weapon)
                                    {
                                        case WeaponType.Uzi:
                                            npc.Health -= 25;
                                            targetFound = true;
                                            break;
                                        case WeaponType.Knife:
                                            if (npc.Bounds.Y - ObjectFactory.PLAYER.Bounds.Y <=
                                                ObjectFactory.PLAYER.AnimationController.FrameWidth + 10)
                                            {
                                                npc.Health -= 10;
                                                targetFound = true;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case MoveDirection.Right:
                                if (npc.Bounds.X >= ObjectFactory.PLAYER.Bounds.X &&
                                    npc.Bounds.Y >= ObjectFactory.PLAYER.Bounds.Y - 25 &&
                                    npc.Bounds.Y + npc.Bounds.Height <= ObjectFactory.PLAYER.Bounds.Y + ObjectFactory.PLAYER.Bounds.Height + 25)
                                {
                                    switch (ObjectFactory.PLAYER.Weapon)
                                    {
                                        case WeaponType.Uzi:
                                            npc.Health -= 25;
                                            targetFound = true;
                                            break;
                                        case WeaponType.Knife:
                                            if (npc.Bounds.X - ObjectFactory.PLAYER.Bounds.X <=
                                                ObjectFactory.PLAYER.AnimationController.FrameWidth + 10)
                                            {
                                                npc.Health -= 10;
                                                targetFound = true;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case MoveDirection.Up:
                                if (npc.Bounds.X >= ObjectFactory.PLAYER.Bounds.X &&
                                    npc.Bounds.X <= ObjectFactory.PLAYER.Bounds.X + ObjectFactory.PLAYER.Bounds.Width &&
                                    npc.Bounds.Y + npc.Bounds.Height <= ObjectFactory.PLAYER.Bounds.Y)
                                {
                                    switch (ObjectFactory.PLAYER.Weapon)
                                    {
                                        case WeaponType.Uzi:
                                            npc.Health -= 25;
                                            targetFound = true;
                                            break;
                                        case WeaponType.Knife:
                                            if (ObjectFactory.PLAYER.Bounds.Y - npc.Bounds.Y <=
                                                ObjectFactory.PLAYER.AnimationController.FrameWidth + 10)
                                            {
                                                npc.Health -= 10;
                                                targetFound = true;
                                            }
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                    if (targetFound) break;
                }
            }
            else
            {
                if (Keys.A.IsDown())
                {
                    GameObject collidedGameObject;
                    if (
                        CollisionHandler.ObjectCollisionDetector(ObjectFactory.PLAYER, MoveDirection.Left,
                            out collidedGameObject) &&
                        (collidedGameObject.Position.Y < ObjectFactory.PLAYER.Position.Y))
                    {
                        ObjectFactory.PLAYER.MoveRight();
                        ObjectFactory.PLAYER.AnimationController.Active = false;
                    }
                    ObjectFactory.PLAYER.MoveLeft();
                    ObjectFactory.PLAYER.AnimationController.Active = true;
                }
                if (Keys.D.IsDown())
                {
                    GameObject collidedGameObject;
                    if (
                        CollisionHandler.ObjectCollisionDetector(ObjectFactory.PLAYER, MoveDirection.Right,
                            out collidedGameObject) &&
                        (collidedGameObject.Position.Y < ObjectFactory.PLAYER.Position.Y))
                    {
                        ObjectFactory.PLAYER.MoveLeft();
                        ObjectFactory.PLAYER.AnimationController.Active = false;
                    }
                    ObjectFactory.PLAYER.AnimationController.Active = true;
                    ObjectFactory.PLAYER.MoveRight();
                }
                if (Keys.W.IsDown())
                {
                    GameObject collidedGameObject;
                    if (
                        CollisionHandler.ObjectCollisionDetector(ObjectFactory.PLAYER, MoveDirection.Up,
                            out collidedGameObject) &&
                        (collidedGameObject.Position.Y < ObjectFactory.PLAYER.Position.Y))
                    {
                        ObjectFactory.PLAYER.MoveDown();
                        ObjectFactory.PLAYER.AnimationController.Active = false;
                    }
                    ObjectFactory.PLAYER.MoveUp();
                    ObjectFactory.PLAYER.AnimationController.Active = true;
                }
                if (Keys.S.IsDown())
                {
                    GameObject collidedGameObject;
                    if (
                        CollisionHandler.ObjectCollisionDetector(ObjectFactory.PLAYER, MoveDirection.Down,
                            out collidedGameObject) &&
                        (collidedGameObject.Position.Y > ObjectFactory.PLAYER.Position.Y))
                    {
                        ObjectFactory.PLAYER.MoveUp();
                        ObjectFactory.PLAYER.AnimationController.Active = false;
                    }
                    ObjectFactory.PLAYER.MoveDown();
                    ObjectFactory.PLAYER.AnimationController.Active = true;
                }
                if (Keys.A.IsReleased())
                {
                    ObjectFactory.PLAYER.AnimationController.CurrentFrame =
                        new Vector2(0, 0);

                    ObjectFactory.PLAYER.AnimationController.Active = false;
                }
                if (Keys.D.IsReleased())
                {
                    ObjectFactory.PLAYER.AnimationController.CurrentFrame =
                        new Vector2(0, 0);

                    ObjectFactory.PLAYER.AnimationController.Active = false;
                }
                if (Keys.W.IsReleased())
                {
                    ObjectFactory.PLAYER.AnimationController.CurrentFrame =
                         new Vector2(0, 0);

                    ObjectFactory.PLAYER.AnimationController.Active = false;
                }
                if (Keys.S.IsReleased())
                {
                    ObjectFactory.PLAYER.AnimationController.CurrentFrame =
                         new Vector2(0, 0);

                    ObjectFactory.PLAYER.AnimationController.Active = false;
                }
            }
            if (Keys.Space.IsReleased())
            {
                switch (ObjectFactory.PLAYER.Weapon)
                {
                    case WeaponType.Uzi: ObjectFactory.PLAYER.AnimationController.EndFrame =
                        ObjectFactory.PLAYER.AnimationController.Image.Width -
                        ObjectFactory.PLAYER.AnimationController.FrameWidth;
                        break;
                    case WeaponType.Knife: ObjectFactory.PLAYER.AnimationController.EndFrame =
                        ObjectFactory.PLAYER.AnimationController.Image.Width -
                        ObjectFactory.PLAYER.AnimationController.FrameWidth * 4;
                        break;
                }
                ObjectFactory.PLAYER.AnimationController.Active = false;
            }

            #region Other Input

            if (Keys.G.IsPressed())
            {
                Point position = Mouse.GetState().Position;
                ObjectFactory.AllObjects.Add(ObjectFactory.GenerateEnemy(position.X, position.Y, EnemyType.Zombie));
            }
            #endregion
        }

        public static bool IsPressed(this Keys key)
        {
            if (PreviousKeyboardState.IsKeyUp(key) && CurrentKeyboardState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }
        public static bool IsDown(this Keys key)
        {
            if (CurrentKeyboardState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        public static bool IsReleased(this Keys key)
        {
            if (CurrentKeyboardState.IsKeyUp(key) && PreviousKeyboardState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }
    }
}
