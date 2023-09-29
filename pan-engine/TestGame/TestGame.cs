using Engine;
using Microsoft.Xna.Framework;
using pan_engine.Engine.Objects;
using pan_engine.Engine.Scenes;
using System.Runtime.CompilerServices;

namespace TestGame
{
    public class TestGame : Pan
    {
        Object2D ball;
        Object2D ball2;

        protected override void LoadContent()
        {
            base.LoadContent();
            ball = new Object2D(windowSize * 0.5f);
            ball2 = new Object2D(new Vector2(0, 0));
            ball2.scale = new Vector2(1, 1.4f);
            ball2.position = new Vector2(ball2.texture.Width * 0.5f + windowSize.Y * 0.1f, windowSize.Y / 2);

            currentScene = new Scene(ball, ball2);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
