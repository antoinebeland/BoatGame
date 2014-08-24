namespace Boat.GameObject.Vehicule
{
    abstract class Airplane : GameObject, IMovable, IAttack, IDestructible
    {
        public uint Speed { get; set; }
        public uint Range { get; set; }
        public uint Damage { get; set; }
        public bool IsAttacking { get; set; }
    }
}
