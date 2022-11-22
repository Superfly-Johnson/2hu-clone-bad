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

        Pawn playerPawn = null;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
        // TODO: Add your initialization logic here
            playerPawn = new Pawn(100, 100f, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            // ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            // ballSpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            playerPawn.Texture = Content.Load<Texture2D>("Pointer");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();
            Vector2 playerPawnposition = playerPawn.Position;
            if (kstate.IsKeyDown(Keys.Up))
            {
                playerPawnposition.Y -= playerPawn.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                playerPawnposition.Y += playerPawn.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                playerPawnposition.X -= playerPawn.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                playerPawnposition.X += playerPawn.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (playerPawnposition.X > _graphics.PreferredBackBufferWidth - playerPawn.Texture.Width / 2)
            {
                playerPawnposition.X = _graphics.PreferredBackBufferWidth - playerPawn.Texture.Width / 2;
            }
            else if (playerPawn.Position.X < playerPawn.Texture.Width / 2)
            {
                playerPawnposition.X = playerPawn.Texture.Width / 2;
            }

            if (playerPawnposition.Y > _graphics.PreferredBackBufferHeight - playerPawn.Texture.Height / 2)
            {
                playerPawnposition.Y = _graphics.PreferredBackBufferHeight - playerPawn.Texture.Height / 2;
            }
            else if (playerPawnposition.Y < playerPawn.Texture.Height / 2)
            {
                playerPawnposition.Y = playerPawn.Texture.Height / 2;
            }
            playerPawn.Position = playerPawnposition;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(playerPawn.Texture, playerPawn.Position, null, Color.White, 0f, new Vector2(playerPawn.Texture.Width/2, playerPawn.Texture.Height/2), Vector2.One, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}