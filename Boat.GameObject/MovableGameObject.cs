using System.Drawing;

namespace Boat.GameObject
{
    abstract class MovableGameObject : GameObject, IMovable
    {
        public uint Speed { get; set; }
        public Point Destination { get; set; }
        public bool IsMoving { get; private set; }
    }
}
