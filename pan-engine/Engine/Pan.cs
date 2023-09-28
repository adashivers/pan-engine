using Engine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using pan_engine.Engine.Scenes;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace Engine
{
    public class Pan : Game
    {
        // globals
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static InputManager inputManager;
        public static ContentManager content;
        public static Vector2 windowSize
        {
            get { return new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight); }
        }
        public static Scene currentScene;
        public static Texture2D defaultTexture;



        public Pan()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            inputManager = new InputManager(this);
            Components.Add(inputManager);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            content = Content;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            defaultTexture = Content.Load<Texture2D>("default_texture");
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            currentScene.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, null);
            currentScene.Draw();
            base.Draw(gameTime);
        }

        protected override void EndRun()
        {
            spriteBatch.End();
            base.EndRun();
        }
    }
}