﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersBusiness;

namespace SpaceInvadersGUI
{
	public class BunkerSprite : DrawableGameComponent
	{
		private Bunker bunker;
		private SpriteBatch spriteBatch;
		private Texture2D texture;

        public BunkerSprite(Game game, Bunker bunker, Texture2D texture)
			: base(game)
		{
			this.bunker = bunker;
            this.texture = texture;
		}
		public override void Draw(GameTime gameTime)
		{
			if(bunker.Alive)
			{
				spriteBatch.Begin();
				spriteBatch.Draw(texture, new Vector2(bunker.BoundingBox.X, bunker.BoundingBox.Y), Color.White);
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