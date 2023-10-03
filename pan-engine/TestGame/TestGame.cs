using Engine;
using Engine.Input;
using Microsoft.Xna.Framework;
using pan_engine.Engine.Objects;
using pan_engine.Engine.Physics;
using pan_engine.Engine.Scenes;
using System;
using System.Runtime.CompilerServices;

namespace TestGame
{
    public class TestGame : Pan
    {
        Object2D square;
        Object2D ball;
        RectangleCollider squareC;
        CircleCollider ballC;

        protected override void LoadContent()
        {
            base.LoadContent();
            square = new Object2D(defaultSquare, windowSize * 0.5f);
            ball = new Object2D(new Vector2(0, 0));
            ball.scale = Vector2.One * 0.5f;
            ball.position = new Vector2(ball.texture.Width * 0.5f + windowSize.Y * 0.1f, windowSize.Y / 2);
            squareC = new RectangleCollider(square.position, square.scale * new Vector2(square.texture.Width, square.texture.Height));
            ballC = new CircleCollider(ball.position, MathF.Max(ball.scale.X, ball.scale.Y) * MathF.Max(ball.texture.Width, ball.texture.Height) * 0.5f);
            // ball2C = new RectangleCollider(ball2.position, ball2.scale * new Vector2(ball2.texture.Width, ball2.texture.Height));


            currentScene = new Scene(square, ball);
        }

        protected override void Update(GameTime gameTime)
        {
            // if (inputManager.isMouseButtonStartDown(InputManager.MouseInput.leftButton)) 
            // {
            ball.position = new Vector2(inputManager.MouseX, inputManager.MouseY);
            ballC.centerPosition = ball.position + ball.scale * 0.5f;
            bool collided = squareC.Collide(ballC);
            square.color = (collided) ? Color.Red : Color.White;
            // }
            

            
            base.Update(gameTime);
        }
    }
}
