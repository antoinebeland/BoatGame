namespace Boat.GameObject.Building
{
    class Port : GameObject, IDestructible
    {
        public override GameObjectImage Image
        {
            get { return GameObjectImage.Port; }
        }
    }
}
