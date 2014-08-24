namespace Boat.GameObject
{
    public interface ISelectable : IGameObject
    {
        bool IsSelected { get; set; }
    }
}
