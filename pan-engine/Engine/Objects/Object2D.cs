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
        public Color color;

        private float drawOrder;
        public float DrawOrder
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

        // constructor taking texture2D
        public Object2D(Texture2D texture, Vector2 position, float scaleX = 1, float scaleY = 1, float rotation = 0, float drawOrder = 0)
        {
            this.texture = texture;
            this.position = position;
            this.scale = new Vector2(scaleX, scaleY);
            this.rotation = rotation;
            this.DrawOrder = drawOrder;
            this.color = Color.White;
        }

        // constructor loading texture from content manager
        public Object2D(string texturePath, Vector2 position, float scaleX = 1, float scaleY = 1, float rotation = 0, float drawOrder = 0)
            : this
            (
                  // might move this into a new Load method at some point.
                  Pan.content.Load<Texture2D>(texturePath),
                  position,
                  scaleX,
                  scaleY,
                  rotation,
                  drawOrder
              )
        { }

        // constructor copying from another Object2D
        public Object2D(Object2D cloneFrom)
            : this(cloneFrom.texture, cloneFrom.position, cloneFrom.scale.X, cloneFrom.scale.Y, cloneFrom.rotation, cloneFrom.drawOrder) { }

        // constructor with default texture
        public Object2D(Vector2 position, float scaleX = 1, float scaleY = 1, float rotation = 0, float drawOrder = 0)
            : this(Pan.defaultTexture, position, scaleX, scaleY, rotation, drawOrder) { }

        public virtual void Update() { }

        public virtual void Draw() 
        { 
            if (texture != null)
            {
                Pan.spriteBatch.Draw(
                    texture,
                    position,
                    null,
                    color,
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
