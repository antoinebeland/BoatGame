using System;
using System.Drawing;
using System.Threading;
using Boat.Utilities.Geometry;

namespace Boat.GameObject.Vehicule
{
    public abstract class Vehicule : GameObject, IMovable, IDestructible
    {
        private readonly ManualResetEvent _stoppingMovementEvent = new ManualResetEvent(false);
        private Thread _backgroundWorker;

        private Point _finalPosition;
        private Point _initialPosition;

        public uint Speed { get; set; }
        public int Orientation { get; set; }

        public Point Destination
        {
            get { return _finalPosition; }
            set
            {
                StoppingMovement();

                _finalPosition = value;
                _initialPosition = Position;

                _backgroundWorker = new Thread(ExecuteMovement);

                // TODO: Start movement... in other function?
                _backgroundWorker.Start();
            }
        }

        public bool IsMoving { get; private set; }
        public event EventHandler OrientationModified;

        private void ExecuteMovement()
        {
            IsMoving = true;
            _stoppingMovementEvent.Reset();

            double angle = GeometryUtilities.GetAngle(_initialPosition, _finalPosition);
            uint distance = GeometryUtilities.GetDistance(_initialPosition, _finalPosition);

            var lastOrientation = Orientation;
            Orientation = (-1 * (int)(angle * 180 / Math.PI));

            if (lastOrientation != Orientation)
            {
                if (OrientationModified != null)
                    OrientationModified.BeginInvoke(this, EventArgs.Empty, null, null);
            }

            for (int i = 1; i <= distance; i++)
            {
                Position = new Point(_initialPosition.X + (int) (i*Math.Cos(angle)),
                    _initialPosition.Y + (int) (i*Math.Sin(angle)));

                if (_stoppingMovementEvent.WaitOne(10))
                    break;
            }

            IsMoving = false;
        }

        private void StoppingMovement()
        {
            if (!IsMoving)
                return;

            _stoppingMovementEvent.Set();
            _backgroundWorker.Join();
        }
    }
}