using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace pan_engine.Engine.Physics
{
    public abstract class Collider
    {
        public abstract bool Collide(Collider c);
        public abstract bool Collide(RectangleCollider c);
    }
}
