using System;
using System.Collections.Generic;
using System.Drawing;
using Boat.GameEngine.Properties;
using Boat.GameObject;
using SdlDotNet.Graphics;

namespace Boat.GameEngine
{
    /// <summary>
    ///     Provides the available surfaces of the game.
    /// </summary>
    internal static class SurfaceProvider
    {
        private static readonly Dictionary<string, Surface> Surfaces;

        /// <summary>
        ///     Initializes the SurfaceProvider class.
        /// </summary>
        static SurfaceProvider()
        {
            Surfaces = new Dictionary<string, Surface>();
            Initialize();
        }

        /// <summary>
        ///     Initializes the surfaces into the Dictionary.
        /// </summary>
        private static void Initialize()
        {
            foreach (string name in Enum.GetNames(typeof (GameObjectImage)))
                Surfaces.Add(name, new Surface((Bitmap) Resources.ResourceManager.GetObject(name)));
        }

        /// <summary>
        ///     Gets the surface of the specified game object.
        /// </summary>
        /// <param name="gameObject">A game object</param>
        /// <returns>A surface representing the game object.</returns>
        public static Surface GetSurface(IGameObject gameObject)
        {
            if (gameObject == null)
                throw new ArgumentNullException("gameObject");

            if (!Surfaces.ContainsKey(gameObject.Image.ToString()))
                throw new ArgumentException();

            return Surfaces[gameObject.Image.ToString()];
        }
    }
}