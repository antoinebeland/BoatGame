namespace Boat.GameObject.Building
{
    class Headquarters : GameObject, IAttack, IDestructible
    {
        public uint Range { get; set; }
        public uint Damage { get; set; }
        public bool IsAttacking { get; set; }

        public override GameObjectImage Image
        {
            get { return GameObjectImage.Headquarters; }
        }
    }
}
