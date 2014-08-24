namespace Boat.GameObject.Vehicule
{
    public abstract class Boat : GameObject, IMovable, IAttack, IDestructible
    {
        public uint Speed { get; set; }
        public uint Range { get; set; }
        public uint Damage { get; set; }
        public bool IsAttacking { get; set; }
    }
}
