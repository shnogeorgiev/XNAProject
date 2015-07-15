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
        public Projectile(Vector2 position, MoveDirection direction)
            : base()
        {
            base.Position = position;
            base.Direction = direction;
            
            base.width = Constants.ProjectileDefaultWidth;
            base.height = Constants.ProjectileDefaultHeight;
        }
    }
}
