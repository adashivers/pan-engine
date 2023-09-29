using Engine;
using Engine.Input;
using Microsoft.Xna.Framework;
using pan_engine.Engine.Objects;
using pan_engine.Engine.Physics;
using pan_engine.Engine.Scenes;
using System.Runtime.CompilerServices;

namespace TestGame
{
    public class TestGame : Pan
    {
        Object2D ball;
        Object2D ball2;
        RectangleCollider ball1C;
        RectangleCollider ball2C;

        protected override void LoadContent()
        {
            base.LoadContent();
            ball = new Object2D(windowSize * 0.5f);
            ball2 = new Object2D(new Vector2(0, 0));
            ball2.scale = Vector2.One * 0.5f;
            ball2.position = new Vector2(ball2.texture.Width * 0.5f + windowSize.Y * 0.1f, windowSize.Y / 2);
            ball1C = new RectangleCollider(ball.position, ball.scale * new Vector2(ball.texture.Width, ball.texture.Height));
            ball2C = new RectangleCollider(ball2.position, ball2.scale * new Vector2(ball2.texture.Width, ball2.texture.Height));


            currentScene = new Scene(ball, ball2);
        }

        protected override void Update(GameTime gameTime)
        {
            // if (inputManager.isMouseButtonStartDown(InputManager.MouseInput.leftButton)) 
            // {
            ball2.position = new Vector2(inputManager.MouseX, inputManager.MouseY);
            ball2C.centerPosition = ball2.position + ball2.scale * 0.5f;
            ball.color = (ball1C.Collide(ball2C)) ? Color.Red : Color.White;
            // }
            

            
            base.Update(gameTime);
        }
    }
}
