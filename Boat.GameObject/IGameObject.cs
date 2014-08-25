using System.Drawing;

namespace Boat.GameObject
{
    public interface IGameObject
    {
        Point Position { get; set; }
        GameObjectImage Image { get; }
    }
}
