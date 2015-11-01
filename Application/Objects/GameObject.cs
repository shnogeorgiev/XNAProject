using Application.Core;
using Application.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Application.Objects
{
    public abstract class GameObject : IGameObject
    {
        private Animation animationController;

        protected GameObject(Texture2D texture)
        {
            ObjectFactory.AllObjects.Add(this);
            this.Position = Constants.ENTITY_LEFT_POSITION;
            this.Texture = texture;
            this.AnimationController = new Animation();
        }

        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                  (int)this.Position.X,
                  (int)this.Position.Y,
                  this.AnimationController.FrameWidth - 27,
                  this.AnimationController.FrameHeight - 27);
            }
        }
        public Animation AnimationController
        {
            get { return this.animationController; }
            set { this.animationController = value; }
        }


        public abstract void HandleCollision(IMoveable other, MoveDirection direction);

        public virtual void Update(GameTime gameTime)
        {
            this.AnimationController.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.AnimationController.Draw(spriteBatch);
        }
    }
}
