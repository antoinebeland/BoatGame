using System;
using System.Drawing;

namespace Boat.GameObject
{
    [Serializable]
    public abstract class GameObject : ISelectable
    {
        public bool IsSelected { get; set; }
        public Player Owner { get; private set; }
        public Point Position { get; set; }
        public abstract GameObjectImage Image { get; }
    }
}
