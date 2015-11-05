using Application.Core;
using Application.Interfaces;
using Application.Objects.MoveableObjects;
using Microsoft.Xna.Framework.Graphics;

namespace Application.Objects.MoveableObjects.Entities
{
    public abstract class Entity : MoveableObject, IEntity
    {
        protected Entity(Texture2D texture)
            : base(texture)
        {
            Health = Constants.ENTITY_DEFAULT_HP;
            IsAlive = true;
        }

        public bool IsAlive { get; set; }
        public int Health { get; set; }
    }
}
