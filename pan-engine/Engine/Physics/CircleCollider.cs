using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public override bool Collide(Collider c)
        {
            if (c is RectangleCollider)
            {
                return CollisionHandler.Collide(this, c as RectangleCollider);
            }
            else if (c is CircleCollider)
            {
                return CollisionHandler.Collide(this, c as CircleCollider);
            }
            else
            {
                Console.WriteLine($"The {GetType().Name} collider class has no implementation to collide with this object");
                return false;
            }
        }
    }
}
