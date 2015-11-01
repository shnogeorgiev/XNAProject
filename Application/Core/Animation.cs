using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Application.Core
{
    public class Animation
    {
        public bool Active { get; set; }

        public int FrameCount { get; set; }
        public int SwitchFrame { get; set; }

        public float StartFrame { get; set; }
        public float EndFrame { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 AmountOfFrames { get; set; }
        public Vector2 CurrentFrame { get; set; }

        public Texture2D Image { get; set; }
        public Rectangle SourceRect { get; set; }

        public int FrameWidth { get { return this.Image.Width / (int)AmountOfFrames.X; } }
        public int FrameHeight { get { return this.Image.Height / (int)AmountOfFrames.Y; } }
        public float DefaultFrameX { get; set; }
        public float DefaultFrameY { get; set; }

        public Animation()
        {

        }

        public void Initialize(Vector2 position, Vector2 frames, Texture2D image)
        {
            this.Active = false;
            this.SwitchFrame = 150;
            this.AmountOfFrames = frames;
            this.Position = position;
            this.Image = image;
            this.CurrentFrame = new Vector2(0, 0);
            this.StartFrame = 0;
            this.EndFrame = 0;
            this.DefaultFrameX = 0;
            this.DefaultFrameY = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (Active)
            {
                this.FrameCount += (int)gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                this.FrameCount = 0;
                this.CurrentFrame = new Vector2(this.DefaultFrameX, this.DefaultFrameY);
            }
            if (FrameCount >= SwitchFrame)
            {
                FrameCount = 0;
                if ((!(this.CurrentFrame.X <= this.EndFrame)) ||
                    this.CurrentFrame.X >= this.Image.Width)
                {
                    this.CurrentFrame = new Vector2(this.StartFrame, this.CurrentFrame.Y);
                }
                else
                {
                    this.CurrentFrame = new Vector2(this.CurrentFrame.X + this.FrameWidth, this.CurrentFrame.Y);
                    if (this.CurrentFrame.X >= this.EndFrame) this.CurrentFrame = new Vector2(this.StartFrame, this.CurrentFrame.Y);
                }
            }
            this.SourceRect = new Rectangle((int)this.CurrentFrame.X, (int)this.CurrentFrame.Y, this.FrameWidth, this.FrameHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Image, this.Position, this.SourceRect, Color.White);
        }
    }
}
