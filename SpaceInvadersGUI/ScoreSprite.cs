using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersBusiness;

namespace SpaceInvadersGUI
{
	public class ScoreSprite : DrawableGameComponent
	{
        private SpriteFont font;
        private Game game;
        private ScoreAndLife score;
		private SpriteBatch spriteBatch;

        public ScoreSprite(Game game, ScoreAndLife score)
			: base(game)
		{
            this.game = game;
            this.score = score;
		}
		public override void Draw(GameTime gameTime)
		{
		    spriteBatch.Begin();
            spriteBatch.DrawString(font, "Score: " + score.Score + "        Lives: " + score.Lives, new Vector2(5, 5), Color.White);
		    spriteBatch.End();
			base.Draw(gameTime);
		}
		public override void Initialize()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			base.Initialize();
		}
		protected override void LoadContent()
		{
            font = game.Content.Load<SpriteFont>(@"assets/scoreFont");
			base.LoadContent();
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}
	}
}