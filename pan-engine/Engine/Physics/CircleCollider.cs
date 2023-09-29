using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace pan_engine.Engine.Physics
{
    public class CircleCollider : Collider
    {
        public Vector2 centerPosition;
        public float radius;

        public CircleCollider(Vector2 centerPosition, float radius)
        {
            this.centerPosition = centerPosition;
            this.radius = radius;
        }
    }
}
