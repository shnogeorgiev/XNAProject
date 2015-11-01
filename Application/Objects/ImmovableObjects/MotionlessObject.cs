using Application.Core;
using Application.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Application.Objects.ImmovableObjects
{
    public class MotionlessObject : GameObject, IMotionless
    {
        public bool IsSolid { get; set; }

        public MotionlessObject(Texture2D texture, Vector2 position)
            : base(texture)
        {
            Position = position;
            IsSolid = false;
            base.AnimationController.Initialize(this.Position, new Vector2(3.0f, 4.0f), this.Texture);
        }
        public MotionlessObject(Texture2D texture, Vector2 position, bool isSolid)
            : this(texture, position)
        {
            IsSolid = isSolid;
        }

        public override void HandleCollision(IMoveable other, MoveDirection direction)
        {

        }
    }
}
