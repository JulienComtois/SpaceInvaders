using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersBusiness;

namespace SpaceInvadersGUI
{
	public class BombSprite : DrawableGameComponent
	{
		private Projectile projectile;
		private SpriteBatch spriteBatch;
		private Texture2D texture;

        public BombSprite(Game game, Projectile projectile, Texture2D texture)
			: base(game)
		{
			this.projectile = projectile;
            this.texture = texture;
		}
		public override void Draw(GameTime gameTime)
		{
			if(projectile.Alive)
			{
				spriteBatch.Begin();
				spriteBatch.Draw(texture, new Vector2(projectile.BoundingBox.X, projectile.BoundingBox.Y), Color.White);
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