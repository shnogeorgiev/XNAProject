using Application.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Entities.Classes
{
    public enum MoveDirection
    {
        Right, Left, Up, Down,
        UpRight, UpLeft,
        DownRight, DownLeft
    }

    public abstract class Entity : MovableObject
    {
        protected bool isAlive;
        protected int health;

        public Entity()
            : base()
        {
            this.IsAlive = true;
            base.Speed = 5;

            base.width = Constants.EntityDefaultWidth;
            base.height = Constants.EntityDefaultHeight;
            this.Health = Constants.EntityDefaultHealth;
        }

        public bool IsAlive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }

        public int JumpCount { get; set; }

        public bool Falling { get; set; }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }
    }
}
