using Application.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Entities.Classes
{
    public class Projectile : MovableObject
    {
        protected int damage;

        public Projectile(Vector2 position, MoveDirection direction)
            : base()
        {
            base.Position = position;
            base.Direction = direction;
            
            base.width = Constants.ProjectileDefaultWidth;
            base.height = Constants.ProjectileDefaultHeight;
            base.speed = Constants.ProjectileDefaultSpeed;
            this.Damage = Constants.ProjectileDefaultDamage;
        }

        public int Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }
    }
}
