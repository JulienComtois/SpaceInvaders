using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersBusiness;

namespace SpaceInvadersGUI
{
	public class AlienSprite : DrawableGameComponent
	{
		private Alien alien;
		private SpriteBatch spriteBatch;
		private Texture2D texture;

        public AlienSprite(Game game, Alien alien, Texture2D texture)
			: base(game)
		{
			this.alien = alien;
            this.texture = texture;
		}
		public override void Draw(GameTime gameTime)
		{
			if (alien.Alive)
			{
				spriteBatch.Begin();
				spriteBatch.Draw(texture, new Vector2(alien.BoundingBox.X, alien.BoundingBox.Y), Color.White);
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
			base.Update(gameTime);
		}
	}
}