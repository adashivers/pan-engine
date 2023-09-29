using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan_engine.Engine.Physics
{
    internal static class CollisionHandler
    {
        public static bool Collide(RectangleCollider c1, RectangleCollider c2)
        {
            return
                (
                    c1.Right > c2.Left
                    && c1.Left < c2.Right
                    && c1.Bottom > c2.Top
                    && c1.Top < c2.Bottom
                );
        }

        public static bool Collide(CircleCollider c1, CircleCollider c2)
        {
            return (c1.centerPosition - c2.centerPosition).Length() < c1.radius + c2.radius;
        }

        public static bool Collide(RectangleCollider c1, CircleCollider c2)
        {
            // TODO
            return false;
        }
    }
}
