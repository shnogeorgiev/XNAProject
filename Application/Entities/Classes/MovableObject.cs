using Application.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Entities.Classes
{
    public abstract class MovableObject : GameObject
    {
        protected int speed;
        protected MoveDirection direction;

        public MovableObject()
            : base()
        {

        }
        public int Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }
        public MoveDirection Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }

        #region Movement Methods

        #region Basic Movement Methods

        public void MoveUp()
        {

            float x = this.Position.X;
            float y = this.Position.Y - this.speed;

            this.Direction = MoveDirection.Up;
            this.Position = new Vector2(x, y);
        }
        public void MoveDown()
        {
            float x = this.Position.X;
            float y = this.Position.Y + this.speed;

            this.Direction = MoveDirection.Down;
            this.Position = new Vector2(x, y);
        }
        public void MoveLeft()
        {
            float x = this.Position.X - this.speed;
            float y = this.Position.Y;

            this.Direction = MoveDirection.Left;
            this.Position = new Vector2(x, y);
        }
        public void MoveRight()
        {
            float x = this.Position.X + this.speed;
            float y = this.Position.Y;

            this.Direction = MoveDirection.Right;
            this.Position = new Vector2(x, y);
        }

        #endregion

        #region Diagonal Movement Methods

        public void MoveUpRight()
        {
            float x = this.Position.X + this.speed;
            float y = this.Position.Y - this.speed;

            this.Direction = MoveDirection.UpRight;
            this.Position = new Vector2(x, y);
        }
        public void MoveUpLeft()
        {
            float x = this.Position.X - this.speed;
            float y = this.Position.Y - this.speed;

            this.Direction = MoveDirection.UpLeft;
            this.Position = new Vector2(x, y);
        }
        public void MoveDownRight()
        {
            float x = this.Position.X + this.speed;
            float y = this.Position.Y + this.speed;

            this.Direction = MoveDirection.DownRight;
            this.Position = new Vector2(x, y);
        }
        public void MoveDownLeft()
        {
            float x = this.Position.X - this.speed;
            float y = this.Position.Y + this.speed;

            this.Direction = MoveDirection.DownLeft;
            this.Position = new Vector2(x, y);
        }

        #endregion

        #endregion
    }
}
