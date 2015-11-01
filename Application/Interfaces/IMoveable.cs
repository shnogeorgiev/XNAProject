﻿using Application.Core;

namespace Application.Interfaces
{
    public interface IMoveable : IGameObject
    {
        MoveDirection Direction { get; set; }

        float Speed { get; set; }
        bool IsMoving { get; set; }

        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
    }
}