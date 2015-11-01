using System;
using Application.Core;
using Application.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Application.Objects.Entities
{
    public class NPC : Entity
    {
        public NPC(Texture2D texture, EnemyType type)
            : base(texture)
        {
            this.Type = type;
            this.Position = Constants.ENTITY_RIGHT_POSITION;
            this.AnimationController.Initialize(this.Position, new Vector2(12.0f, 8.0f), Constants.ENTITY_DEFAULT_TEXTURE);

            switch (this.Type)
            {
                case EnemyType.Zombie:
                case EnemyType.Ghoul:
                    base.AnimationController.StartFrame = 3.00f;
                    base.AnimationController.EndFrame = 220.25f;
                    base.AnimationController.DefaultFrameX = 73.75f;
                    break;
                case EnemyType.Skeleton:
                case EnemyType.Warrior:
                    base.AnimationController.StartFrame = 225.25f;
                    base.AnimationController.EndFrame = 440.5f;
                    base.AnimationController.DefaultFrameX = 295.0f;
                    break;
                case EnemyType.Butcher:
                case EnemyType.Mindless:
                    base.AnimationController.StartFrame = 442.5f;
                    base.AnimationController.EndFrame = 661.75f;
                    base.AnimationController.DefaultFrameX = 516.25f;
                    break;
                case EnemyType.Gladiator:
                case EnemyType.InfestedHuman:
                    base.AnimationController.StartFrame = 663.75f;
                    base.AnimationController.EndFrame = 883.00f;
                    base.AnimationController.DefaultFrameX = 737.50f;
                    break;
                default: throw new Exception("Invalid enemy type " + type.ToString() + "!");

            }
            switch (this.Type)
            {
                case EnemyType.Zombie:
                case EnemyType.Skeleton:
                case EnemyType.Butcher:
                case EnemyType.Gladiator:
                    this.AnimationController.DefaultFrameY = 194;
                    break;
                case EnemyType.Ghoul:
                case EnemyType.Warrior:
                case EnemyType.Mindless:
                case EnemyType.InfestedHuman:
                    this.AnimationController.DefaultFrameY = 582;
                    break;
            }
            this.AnimationController.CurrentFrame = new Vector2(this.AnimationController.StartFrame, 0.0f);
        }

        public EnemyType Type { get; set; }

        public override void HandleCollision(IMoveable other, MoveDirection direction)
        {

        }

        public override void MoveLeft()
        {
            switch (this.Type)
            {
                case EnemyType.Zombie:
                case EnemyType.Skeleton:
                case EnemyType.Butcher:
                case EnemyType.Gladiator:
                    this.AnimationController.CurrentFrame = new Vector2(
                        this.AnimationController.CurrentFrame.X,
                        291.0f);
                    break;
                case EnemyType.Ghoul:
                case EnemyType.Warrior:
                case EnemyType.Mindless:
                case EnemyType.InfestedHuman:
                    this.AnimationController.CurrentFrame = new Vector2(
                        this.AnimationController.CurrentFrame.X,
                        679.0f);
                    break;
            }
            this.AnimationController.Active = true;
            this.AnimationController.Position = this.Position;
            base.MoveLeft();
        }

        public override void MoveRight()
        {
            switch (this.Type)
            {
                case EnemyType.Zombie:
                case EnemyType.Skeleton:
                case EnemyType.Butcher:
                case EnemyType.Gladiator:
                    this.AnimationController.CurrentFrame = new Vector2(
                        this.AnimationController.CurrentFrame.X,
                        97.0f);
                    break;
                case EnemyType.Ghoul:
                case EnemyType.Warrior:
                case EnemyType.Mindless:
                case EnemyType.InfestedHuman:
                    this.AnimationController.CurrentFrame = new Vector2(
                        this.AnimationController.CurrentFrame.X,
                        485.0f);
                    break;
            }
            this.AnimationController.Active = true;
            this.AnimationController.Position = this.Position;
            base.MoveRight();
        }

        public override void MoveDown()
        {
            switch (this.Type)
            {
                case EnemyType.Zombie:
                case EnemyType.Skeleton:
                case EnemyType.Butcher:
                case EnemyType.Gladiator:
                    this.AnimationController.CurrentFrame = new Vector2(
                        this.AnimationController.CurrentFrame.X,
                        194.0f);
                    break;
                case EnemyType.Ghoul:
                case EnemyType.Warrior:
                case EnemyType.Mindless:
                case EnemyType.InfestedHuman:
                    this.AnimationController.CurrentFrame = new Vector2(
                        this.AnimationController.CurrentFrame.X,
                        582.0f);
                    break;
            }
            this.AnimationController.Active = true;
            this.AnimationController.Position = this.Position;
            base.MoveDown();
        }

        public override void MoveUp()
        {
            switch (this.Type)
            {
                case EnemyType.Zombie:
                case EnemyType.Skeleton:
                case EnemyType.Butcher:
                case EnemyType.Gladiator:
                    this.AnimationController.CurrentFrame = new Vector2(
                        this.AnimationController.CurrentFrame.X,
                        3.3f);
                    break;
                case EnemyType.Ghoul:
                case EnemyType.Warrior:
                case EnemyType.Mindless:
                case EnemyType.InfestedHuman:
                    this.AnimationController.CurrentFrame = new Vector2(
                        this.AnimationController.CurrentFrame.X,
                        388.0f);
                    break;
            }
            this.AnimationController.Active = true;
            this.AnimationController.Position = this.Position;
            base.MoveUp();
        }
    }
}
