using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Util;

namespace Application.Entities.Classes
{
    public class Player : Entity
    {
        private Projectile playerAttack;

        public Player()
            : base()
        {

        }

        public Projectile PlayerAttack
        {
            get { return this.playerAttack; }
            set { this.playerAttack = value; }
        }

        public void Attack(MoveDirection direction)
        {
            this.PlayerAttack = new Projectile(base.Position, direction);
        }
    }
}
