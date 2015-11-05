using Application.Core;
using Application.Core.Enumerations;
using Application.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Application.Objects.MoveableObjects
{
    public abstract class MoveableObject : GameObject, IMoveable
    {
        protected MoveableObject(Texture2D texture)
            : base(texture)
        {
            Speed = Constants.ENTITY_DEFAULT_SPEED;
            IsMoving = false;
        }

        public MoveDirection Direction { get; set; }
        public bool IsMoving { get; set; }
        public float Speed { get; set; }

        public virtual void MoveLeft()
        {
            Vector2 newPosition = new Vector2(Position.X - this.Speed, Position.Y);
            this.Position = newPosition;
            this.Direction = MoveDirection.Left;
        }
        public virtual void MoveRight()
        {
            Vector2 newPosition = new Vector2(Position.X + this.Speed, Position.Y);
            base.Position = newPosition;
            this.Direction = MoveDirection.Right;

        }
        public virtual void MoveDown()
        {
            Vector2 newPosition = new Vector2(Position.X, Position.Y + this.Speed);
            base.Position = newPosition;
            this.Direction = MoveDirection.Down;
        }

        public virtual void MoveUp()
        {
            Vector2 newPosition = new Vector2(Position.X, Position.Y - this.Speed);
            base.Position = newPosition;
            this.Direction = MoveDirection.Up;
        }
    }
}
