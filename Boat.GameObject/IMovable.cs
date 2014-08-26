using System;
using System.Drawing;

namespace Boat.GameObject
{
    /// <summary>
    ///     Defines the commons methods of a movable object.
    /// </summary>
    public interface IMovable : IGameObject
    {
        /// <summary>
        ///     Gets or sets the speed of the game object.
        /// </summary>
        uint Speed { get; set; }

        /// <summary>
        ///     Gets or sets the orientation of the game object.
        /// </summary>
        int Orientation { get; set; }

        /// <summary>
        ///     Gets or sets the destination position of the game object.
        /// </summary>
        Point Destination { get; set; }

        /// <summary>
        ///     Gets a value that indicates whether the game object is moving.
        /// </summary>
        bool IsMoving { get; }

        /// <summary>
        ///     Occurs when the orientation of the game object is modified.
        /// </summary>
        event EventHandler OrientationModified;
    }
}