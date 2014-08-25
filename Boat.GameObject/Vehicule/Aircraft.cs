﻿using System.Drawing;

namespace Boat.GameObject.Vehicule
{
    abstract class Airplane : GameObject, IMovable, IAttack, IDestructible
    {
        public uint Speed { get; set; }
        public Point Destination { get; set; }
        public bool IsMoving { get; private set; }
        public uint Range { get; set; }
        public uint Damage { get; set; }
        public bool IsAttacking { get; set; }
    }
}
