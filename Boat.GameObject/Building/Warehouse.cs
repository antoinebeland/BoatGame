namespace Boat.GameObject.Building
{
    class Warehouse : GameObject, IDestructible
    {
        public override GameObjectImage Image
        {
            get { return GameObjectImage.Warehouse; }
        }
    }
}
