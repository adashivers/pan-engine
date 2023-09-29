using Engine;
using Microsoft.Xna.Framework;
using pan_engine.Engine.Objects;
using pan_engine.Engine.Scenes;
using System.Runtime.CompilerServices;

namespace pan_engine
{
    public class TestGame : Pan
    {
        Object2D ball;
        Object2D pongStickL;

        protected override void LoadContent()
        {
            base.LoadContent();
            ball = new Object2D(windowSize * 0.5f);
            pongStickL = new Object2D(new Vector2(0, 0));
            pongStickL.scale = new Vector2(1, 1.4f);
            pongStickL.position = new Vector2(pongStickL.texture.Width * 0.5f + windowSize.Y * 0.1f, windowSize.Y / 2);

            currentScene = new Scene(ball, pongStickL);
        }
    }
}
