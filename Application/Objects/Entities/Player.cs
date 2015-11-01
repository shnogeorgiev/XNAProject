using Application.Core;
using Application.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Application.Objects.Entities
{

    public class Player : Entity
    {
        public Player(Texture2D texture)
            : base(texture)
        {
            this.Position = Constants.PLAYER_DEFAULT_POSITION;
            this.Health = Constants.PLAYER_DEFAULT_HP;
            this.Speed = Constants.PLAYER_DEFAULT_SPEED;
            this.Weapon = WeaponType.Uzi;

            base.AnimationController.Initialize(this.Position, new Vector2(7.0f, 1.0f), this.Texture);
            base.AnimationController.StartFrame = 0.0f;
            base.AnimationController.EndFrame = base.AnimationController.Image.Width - base.AnimationController.FrameWidth;

            base.AnimationController.DefaultFrameX = 0.0f;
            base.AnimationController.DefaultFrameY = 0.0f;

        }

        public WeaponType Weapon { get; set; }

        public override void HandleCollision(IMoveable other, MoveDirection direction)
        {

        }

        public override void MoveLeft()
        {
            switch (this.Weapon)
            {
                case WeaponType.Uzi:
                    this.AnimationController.Image = Constants.Hitman_Uzi_Left;
                    this.AnimationController.StartFrame = 0.0f;
                    this.AnimationController.EndFrame = base.AnimationController.Image.Width - base.AnimationController.FrameWidth * 2;
                    break;
                case WeaponType.Knife:
                    this.AnimationController.Image = Constants.Hitman_Knife_Left;
                    this.AnimationController.StartFrame = 0.0f;
                    this.AnimationController.EndFrame = base.AnimationController.Image.Width - base.AnimationController.FrameWidth * 5;
                    break;
            }

            if (InputManager.PreviousKeyboardState.IsKeyUp(Keys.A))
                this.AnimationController.CurrentFrame = new Vector2(0.0f, 0.0f);

            this.AnimationController.Active = true;
            this.AnimationController.Position = this.Position;
            base.MoveLeft();
        }

        public override void MoveRight()
        {
            switch (this.Weapon)
            {
                case WeaponType.Uzi:
                    this.AnimationController.Image = Constants.Hitman_Uzi_Right;
                    this.AnimationController.StartFrame = 0.0f;
                    this.AnimationController.EndFrame = this.AnimationController.Image.Width - this.AnimationController.FrameWidth * 2;
                    break;
                case WeaponType.Knife:
                    this.AnimationController.Image = Constants.Hitman_Knife_Right;
                    this.AnimationController.StartFrame = 0.0f;
                    this.AnimationController.EndFrame = this.AnimationController.Image.Width - this.AnimationController.FrameWidth * 5;
                    break;
            }
            
            if (InputManager.PreviousKeyboardState.IsKeyUp(Keys.D))
                this.AnimationController.CurrentFrame = new Vector2(0.0f, 0.0f);

            this.AnimationController.Active = true;
            this.AnimationController.Position = this.Position;
            base.MoveRight();
        }

        public override void MoveDown()
        {
            switch (this.Weapon)
            {
                case WeaponType.Uzi:
                    this.AnimationController.Image = Constants.Hitman_Uzi_Down;
                    this.AnimationController.StartFrame = 0.0f;
                    this.AnimationController.EndFrame = this.AnimationController.Image.Width - this.AnimationController.FrameWidth * 2;
                    break;
                case WeaponType.Knife:
                    this.AnimationController.Image = Constants.Hitman_Knife_Down;
                    this.AnimationController.StartFrame = 0.0f;
                    this.AnimationController.EndFrame = this.AnimationController.Image.Width - this.AnimationController.FrameWidth * 5;
                    break;
            }

            if (InputManager.PreviousKeyboardState.IsKeyUp(Keys.S))
                this.AnimationController.CurrentFrame = new Vector2(0.0f, 0.0f);

            this.AnimationController.Active = true;
            this.AnimationController.Position = this.Position;
            base.MoveDown();
        }

        public override void MoveUp()
        {
            switch (this.Weapon)
            {
                case WeaponType.Uzi:
                    this.AnimationController.Image = Constants.Hitman_Uzi_Up;
                    this.AnimationController.StartFrame = 0.0f;
                    this.AnimationController.EndFrame = this.AnimationController.Image.Width - this.AnimationController.FrameWidth * 2;
                    break;
                case WeaponType.Knife:
                    this.AnimationController.Image = Constants.Hitman_Knife_Up;
                    this.AnimationController.StartFrame = 0.0f;
                    this.AnimationController.EndFrame = this.AnimationController.Image.Width - this.AnimationController.FrameWidth * 5;
                    break;
            }

            if (InputManager.PreviousKeyboardState.IsKeyUp(Keys.W))
                this.AnimationController.CurrentFrame = new Vector2(0.0f, 0.0f);

            this.AnimationController.Active = true;
            this.AnimationController.Position = this.Position;
            base.MoveUp();
        }

        public void SwitchWeapon(WeaponType weapon)
        {
            this.Weapon = weapon;
            switch (this.Weapon)
            {
                case WeaponType.Uzi:
                    base.AnimationController.Initialize(this.Position, new Vector2(7.0f, 1.0f), Constants.Hitman_Uzi_Down);
                    base.AnimationController.StartFrame = 0.0f;
                    base.AnimationController.EndFrame = base.AnimationController.Image.Width - base.AnimationController.FrameWidth;
                    break;
                case WeaponType.Knife:
                    base.AnimationController.Initialize(this.Position, new Vector2(10.0f, 1.0f), Constants.Hitman_Knife_Down);
                    base.AnimationController.StartFrame = 0.0f;
                    base.AnimationController.EndFrame = base.AnimationController.Image.Width - base.AnimationController.FrameWidth * 5;
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!this.AnimationController.Active)
                this.AnimationController.CurrentFrame = new Vector2(
                    this.AnimationController.DefaultFrameX,
                    this.AnimationController.DefaultFrameY);
            base.Update(gameTime);
        }
    }
}
