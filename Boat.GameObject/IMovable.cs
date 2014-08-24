namespace Boat.GameObject
{
    public interface IMovable : IGameObject
    {
        /// <summary>
        /// The speed of the game object
        /// </summary>
        uint Speed { get; set; }



    }
}
