using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloGame
{
    public class HelloGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 ballPosition;
        private Vector2 ballVelocity;
        private Texture2D ballTexture;

        public HelloGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.Title = "Hello Game";

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            ballPosition = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            System.Random random = new System.Random();

            ballVelocity = new Vector2((float)random.NextDouble(), (float)random.NextDouble());
            ballVelocity.Normalize();
            ballVelocity *= 100;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var result = Content.Load<Texture2D>("Ball");
            ballTexture = result;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here
            ballPosition += ballVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (ballPosition.X < GraphicsDevice.Viewport.X || ballPosition.X > GraphicsDevice.Viewport.Width - 60)
            {
                ballVelocity.X *= -1;
            }

            if (ballPosition.Y < GraphicsDevice.Viewport.Y || ballPosition.Y > GraphicsDevice.Viewport.Height - 60)
            {
                ballVelocity.Y *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(ballTexture, ballPosition, Color.White);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}