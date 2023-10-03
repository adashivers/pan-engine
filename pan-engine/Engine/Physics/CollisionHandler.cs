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
        // tested
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

        // tested
        public static bool Collide(RectangleCollider rect, CircleCollider circ)
        {
            // TODO

            // within top-bottom range
            if (circ.centerPosition.X <= rect.Right && circ.centerPosition.X >= rect.Left)
                return (circ.centerPosition.Y <= rect.Bottom + circ.radius && circ.centerPosition.Y >= rect.Top - circ.radius); 

            // within left-right range
            if (circ.centerPosition.Y <= rect.Bottom && circ.centerPosition.Y >= rect.Top)
                return (circ.centerPosition.X <= rect.Right + circ.radius && circ.centerPosition.X >= rect.Left - circ.radius);

            // closest corner
            float closestCornerX = (circ.centerPosition.X < rect.centerPosition.X) ? rect.Left : rect.Right;
            float closestCornerY = (circ.centerPosition.Y < rect.centerPosition.Y) ? rect.Top : rect.Bottom;

            Vector2 closestCorner = new Vector2(closestCornerX, closestCornerY);
            return (circ.centerPosition - closestCorner).Length() < circ.radius;
        }

        public static bool Collide(CircleCollider circ, RectangleCollider rect)
        {
            return Collide(rect, circ);
        }
    }
}
