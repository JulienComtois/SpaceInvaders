using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersBusiness;

namespace SpaceInvadersGUI
{
	public class PlayerSprite : DrawableGameComponent
	{
		private KeyboardState oldState;
		private Player player;
		private SpriteBatch spriteBatch;
		private Texture2D texture;

		public PlayerSprite(Game game, Player player, Texture2D texture) 
			: base(game)
		{
			this.player = player;
            this.texture = texture;
		}
		public override void Draw(GameTime gameTime)
		{
            if (player.Alive)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(texture, new Vector2(player.BoundingBox.X, player.BoundingBox.Y), Color.White);
                spriteBatch.End();
            }
			base.Draw(gameTime);
		}
		public override void Initialize()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			base.Initialize();
		}
		protected override void LoadContent()
		{
			base.LoadContent();
		}

		public override void Update(GameTime gameTime)
		{
			if (player.Alive)
			{
				KeyboardState newState = Keyboard.GetState();
                if (newState.IsKeyDown(Keys.A) && !oldState.IsKeyUp(Keys.A) || newState.IsKeyDown(Keys.Left) && !oldState.IsKeyUp(Keys.Left))
				    player.MoveLeft();
                if (newState.IsKeyDown(Keys.D) && !oldState.IsKeyUp(Keys.D) || newState.IsKeyDown(Keys.Right) && !oldState.IsKeyUp(Keys.Right))
				    player.MoveRight();
			    if (newState.IsKeyDown(Keys.Space) && !oldState.IsKeyUp(Keys.Space))
				    player.Shoot();
				oldState = newState;
            }

			base.Update(gameTime);
		}
	}
}