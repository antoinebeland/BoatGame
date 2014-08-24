using System;

namespace Boat.GameObject
{
    [Serializable]
    public abstract class GameObject : ISelectable
    {
        public bool IsSelected { get; set; }
        public Player Owner { get; private set; }
        public abstract GameObjectImage Image { get; }
    }
}
