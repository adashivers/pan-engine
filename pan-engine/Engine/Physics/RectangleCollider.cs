using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace pan_engine.Engine.Physics
{
    public class RectangleCollider : Collider
    {
        public Vector2 centerPosition;
        public Vector2 size;
        public float Bottom 
        {
            get 
            {
                return centerPosition.Y + size.Y * 0.5f;
            }
        }
        public float Top
        {
            get
            {
                return centerPosition.Y - size.Y * 0.5f;
            }
        }
        public float Left
        {
            get
            {
                return centerPosition.X - size.X * 0.5f;
            }
        }
        public float Right
        {
            get
            {
                return centerPosition.X + size.X * 0.5f;
            }
        }

        public RectangleCollider(Vector2 centerPosition, Vector2 size)
        {
            this.centerPosition = centerPosition;
            this.size = size;
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
