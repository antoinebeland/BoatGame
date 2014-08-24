using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boat.GameObject.Building
{
    class Shed : GameObject, IDestructible
    {
        public override GameObjectImage Image
        {
            get { return GameObjectImage.Shed; }
        }
    }
}
