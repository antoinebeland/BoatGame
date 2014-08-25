using System;
using System.Drawing;
using Boat.GameObject;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Input;

namespace Boat.GameEngine
{
    internal sealed class GameObjectSprite : Sprite
    {
        public GameObjectSprite(IGameObject gameObject)
            : base(SurfaceProvider.GetSurface(gameObject), gameObject.Position)
        {
            GameObject = gameObject;

            // TODO: Implements object type

            Events.MouseButtonDown += OnMouseButtonDown;
            Events.KeyboardDown += OnKeyboardDown;
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
            if (GameObject is ISelectable)
            {
                var selectableObject = GameObject as ISelectable;
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

        private bool IsHovered(Point position)
        {
            return Rectangle.Contains(position);
        }

        public IGameObject GameObject { get; private set; }
    }
}