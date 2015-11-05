using Application.Core;
using Application.Core.Enumerations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Application.Interfaces
{
    public interface IGameObject
    {
        Rectangle Bounds { get; }
        Vector2 Position { get; set; }
        Texture2D Texture { get; set; }
        Animation AnimationController { get; set; }

        void HandleCollision(IMoveable other, MoveDirection direction);
    }
}
