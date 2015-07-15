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

        public Entity()
            : base()
        {
            this.IsAlive = true;
            base.Speed = 5;

            base.width = Constants.EntityDefaultWidth;
            base.height = Constants.EntityDefaultHeight;
        }

        public bool IsAlive
        {
            get { return this.IsAlive; }
            set { this.isAlive = value; }
        }

        public int JumpCount { get; set; }

        public bool Falling { get; set; }
    }
}
