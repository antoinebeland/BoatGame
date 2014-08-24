namespace Boat.GameObject
{
    /// <summary>
    /// Defines the bases attributes/methods of a game object that can attacked.
    /// </summary>
    public interface IAttack : IGameObject
    {
        /// <summary>
        /// The range of the attack.
        /// </summary>
        uint Range { get; set; }

        /// <summary>
        /// The damage inflicted by the attack.
        /// </summary>
        uint Damage { get; set; }

        bool IsAttacking { get; set; }
    }
}
