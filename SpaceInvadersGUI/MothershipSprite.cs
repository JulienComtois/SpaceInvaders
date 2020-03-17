using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersBusiness;

namespace SpaceInvadersGUI
{
	public class MothershipSprite : DrawableGameComponent
	{
		private Mothership mothership;
		private Player player;
		private SpriteBatch spriteBatch;
		private Texture2D texture;

        public MothershipSprite(Game game, Mothership mothership, Player player, Texture2D texture)
			: base(game)
		{
			this.mothership = mothership;
			this.player = player;
            this.texture = texture;
		}
		public override void Draw(GameTime gameTime)
		{
			if (mothership.Alive)
			{
				spriteBatch.Begin();
				spriteBatch.Draw(texture, new Vector2(mothership.BoundingBox.X, mothership.BoundingBox.Y), Color.White);
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
			if(mothership.Alive && player.Alive)
			{
				mothership.Move();
			}
			base.Update(gameTime);
		}
	}
}