using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Defs;
using System.Net.Mime;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D ballTexture;
        Vector2 ballPosition;
        float ballSpeed;

        Pawn PlayerPawn = null;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
        // TODO: Add your initialization logic here
            PlayerPawn = new Pawn(100, 100f, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            // ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            // ballSpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            PlayerPawn.Texture = Content.Load<Texture2D>("Pointer");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();
            var playerpawnposition = PlayerPawn.Position;
            if (kstate.IsKeyDown(Keys.Up))
            {
                playerpawnposition.Y -= PlayerPawn.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                playerpawnposition.Y += PlayerPawn.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                playerpawnposition.X -= PlayerPawn.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                playerpawnposition.X += PlayerPawn.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (playerpawnposition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
            {
                playerpawnposition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
            }
            else if (PlayerPawn.Position.X < ballTexture.Width / 2)
            {
                playerpawnposition.X = ballTexture.Width / 2;
            }

            if (playerpawnposition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
            {
                playerpawnposition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
            }
            else if (playerpawnposition.Y < ballTexture.Height / 2)
            {
                playerpawnposition.Y = ballTexture.Height / 2;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(PlayerPawn.Texture, PlayerPawn.Position, null, Color.White, 0f, new Vector2(PlayerPawn.Texture.Width/2, PlayerPawn.Texture.Height/2), Vector2.One, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}