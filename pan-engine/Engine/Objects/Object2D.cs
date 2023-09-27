using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Engine;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace pan_engine.Engine.Objects
{
    public class Object2D
    {
        public Texture2D texture;
        public Vector2 position, scale;
        public float rotation;
        public float drawOrder
            /// <summary>
            /// The drawing order of this sprite. Value between 0 and 1, with 0 being the frontmost layer.
            /// </summary>
        {
            get { return drawOrder; } 
            set
            {
                if (value < 0) drawOrder = 0;
                else if (value > 1) drawOrder = 1;
                else drawOrder = value;
            }
        }


        // might add something like this later for collision.
        // public Rectangle rect;


        public Object2D(string texturePath, Vector2 _position, Vector2 _scale, float _rotation = 0, float _drawOrder = 0) 
        { 
            // might move this into a new Load method at some point.
            texture = Pan.content.Load<Texture2D>(texturePath);
            position = _position; 
            scale = _scale;
            rotation = _rotation;
            drawOrder = _drawOrder;
        }

        public virtual void Update() {  }

        public virtual void Draw() 
        { 
            if (texture != null)
            {
                Pan.spriteBatch.Draw(
                    texture,
                    position,
                    null,
                    Color.White,
                    rotation,
                    new Vector2(texture.Width / 2, texture.Height / 2),
                    scale,
                    SpriteEffects.None,
                    drawOrder
                );
            }
        }


    }
}
