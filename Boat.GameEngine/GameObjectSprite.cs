using System;
using System.Drawing;
using Boat.GameObject;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Input;

namespace Boat.GameEngine
{
    internal sealed class GameObjectSprite : Sprite
    {
        private readonly object _surfaceLock = new object();

        public GameObjectSprite(IMovable movableObject)
            : this((IGameObject) movableObject)
        {
            movableObject.OrientationModified += OnOrientationModified;
        }

        public GameObjectSprite(IGameObject gameObject)
            : base(SurfaceProvider.GetSurface(gameObject), gameObject.Position)
        {
            GameObject = gameObject;

            // TODO: Implements object type

            Events.MouseButtonDown += OnMouseButtonDown;
            Events.KeyboardDown += OnKeyboardDown;
        }

        private void OnOrientationModified(object sender, EventArgs eventArgs)
        {
            var movableObject = GameObject as IMovable;
            lock (_surfaceLock)
            {
                Surface = SurfaceProvider.GetSurface(movableObject);

                if(movableObject.Orientation != 0)
                    Surface = Surface.CreateRotatedSurface(movableObject.Orientation);

                GC.Collect();
            }
        }

        /// <summary>
        ///     Gets and sets the surface of the sprite.
        /// </summary>
        /// <remarks>Threading safe implementation.</remarks>
        public override Surface Surface
        {
            get
            {
                lock (_surfaceLock)
                {
                    return base.Surface;
                }
            }
            set { base.Surface = value; }
        }

        public new Rectangle Rectangle
        {
            get { return new Rectangle(GameObject.Position, Surface.Rectangle.Size); }
        }

        private void OnKeyboardDown(object sender, KeyboardEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    if (GameObject is ISelectable && GameObject is IDestructible)
                    {
                        var selectableObject = GameObject as ISelectable;
                        if(selectableObject.IsSelected)
                        {
                            var destructibleObject = GameObject as IDestructible;
                            Console.WriteLine("Destroy object");
                        }
                    }
                    break;
            }
        }

        private void OnMouseButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            switch (mouseButtonEventArgs.Button)
            {
                case MouseButton.PrimaryButton:
                    OnMousePrimaryButtonDown();
                    break;

                case MouseButton.SecondaryButton:
                    OnMouseSecondaryButtonDown();
                    break;
            }
        }

        private void OnMousePrimaryButtonDown()
        {
            if (IsValidateType<ISelectable>(GameObject))
            {
                var selectableObject = GetType<ISelectable>(GameObject);
                if (IsHovered(Mouse.MousePosition))
                {

                    Console.WriteLine("Selected object! {0}", GameObject.GetType());
                    selectableObject.IsSelected = true;
                }
                else
                    selectableObject.IsSelected = false;
            }
        }

        private void OnMouseSecondaryButtonDown()
        {
            if (GameObject is ISelectable)
            {
                var selectableObject = GameObject as ISelectable;
                if (selectableObject.IsSelected)
                {
                    /*if (GameObject is IAttack)
                    {
                        var attackObject = GameObject as IAttack;
                        Console.WriteLine("Object can attack!");

                    }*/
                    if (GameObject is IMovable)
                    {
                        var movableObject = GameObject as IMovable;
                        movableObject.Destination = Mouse.MousePosition;

                        Console.WriteLine("Object can move!");

                    }
                }
            }
        }

        public bool IsValidateType<T>(IGameObject gameObject) where T : class, IGameObject
        {
            return (gameObject is T);
        }

        public T GetType<T>(IGameObject gameObject) where T : class, IGameObject
        {
            return gameObject as T;
        }

        private bool IsHovered(Point position)
        {
            return Rectangle.Contains(position);
        }

        public IGameObject GameObject { get; private set; }
    }
}