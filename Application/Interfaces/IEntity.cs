namespace Application.Interfaces
{
    public interface IEntity : IMoveable
    {
        int Health { get; set; }
        bool IsAlive { get; set; }
    }
}
