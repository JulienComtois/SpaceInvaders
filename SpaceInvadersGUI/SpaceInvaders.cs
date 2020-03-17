using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersBusiness;
using System.Collections.Generic;

namespace SpaceInvadersGUI
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class SpaceInvaders : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		private AlienSquad alienSquad;
		private BombFactory bombFactory;
		private Bunkers bunkers;
		private LaserSprite laserSprite;
		private LaserFactory laserFactory;
		private Mothership mothership;
		private MothershipSprite mothershipSprite;
		private Player player;
		private PlayerSprite playerSprite;
        private ScoreAndLife scoreAndLife;
        private ScoreSprite scoreSprite;

		private List<Alien> aliens = new List<Alien>();
		private List<AlienSprite> alienSprites = new List<AlienSprite>();
		private List<BunkerSprite> bunkerSprites = new List<BunkerSprite>();

		private int alienHeight;
        private int alienWidth;
        private int bombHeight;
        private int bombWidth;
        private int bunkerHeight;
        private int bunkerWidth;
        private int laserHeight;
        private int laserWidth;
        private int mothershipWidth;
        private int mothershipHeight;
        private int playerWidth;
        private int playerHeight;

        //This section is a config section, it ensures there are no hard coded values anywhere.
		private const int alienSpeed = 1;
        private const int alienPointsPerRow = 5;
        private const int alienSpacerFromTop = 60; // Minimum 20
        private const int alienPointStart = alienPointsPerRow * numRows;
		private const int bombFrequency = 60; // Lower = more frequent
		private const int bombFrequencyIncrement = 5; // Increases rate of bomb frequency each round
		private const int bombFrequencyMin = 30; // Minimum (fastest) bomb frequency
		private const int bombSpeed = 5;
		private const int bunkerHealth = 10; // How many hits to kill bunker
		private const int laserSpeed = -10; // Negative because it moves upwards
        private const int lives = 3;
		private const int mothershipPoints = 150;
        private const int mothershipSpacerFromTop = alienSpacerFromTop - 20;
		private const int mothershipSpeed = 2;
		private const int numBombSlots = 20; // This must be increased to accomodate for a higher screenHeight or a faster bomb rate
		private const int numBunkers = 4;
		private const int numRows = 5;
		private const int numColumns = 11;
		private const int playerSpeed = 5;
		private const int timerIntervalMothership = 20000; // Milliseconds
        private const int timerIntervalPlayerRespawn = 1000; // Milliseconds
		private const int screenWidth = 800;
		private const int screenHeight = 800;
		private const int spacer = 15; // Space between aliens
        private const int spaceBetweenBunkerAndPlayer = 50;
        private const int speedIncrease = 1; // Alien speed increase per round


		public SpaceInvaders() 
			: base()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			// Change game resolution
			graphics.PreferredBackBufferWidth = screenWidth;
			graphics.PreferredBackBufferHeight = screenHeight;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
            // Create textures
            Texture2D textureAlien = this.Content.Load<Texture2D>(@"assets/bug");
            Texture2D textureBomb = this.Content.Load<Texture2D>(@"assets/bomb");
            Texture2D textureBunker = this.Content.Load<Texture2D>(@"assets/bunker");
            Texture2D textureLaser = this.Content.Load<Texture2D>(@"assets/laser");
            Texture2D textureMothership = this.Content.Load<Texture2D>(@"assets/mothership");
            Texture2D texturePlayer = this.Content.Load<Texture2D>(@"assets/player");

            // Initialize variables
            alienHeight = textureAlien.Height;
            alienWidth = textureAlien.Width;
            bombHeight = textureBomb.Height;
            bombWidth = textureBomb.Width;
            bunkerHeight = textureBunker.Height;
            bunkerWidth = textureBunker.Width;
            laserHeight = textureLaser.Height;
            laserWidth = textureLaser.Width;
            mothershipHeight = textureMothership.Height;
            mothershipWidth = textureMothership.Width;
            playerHeight = texturePlayer.Height;
            playerWidth = texturePlayer.Width;

			// Create factories
			laserFactory = new LaserFactory(laserSpeed, laserWidth, laserHeight, numRows * numColumns);
			bombFactory = new BombFactory(bombSpeed, bombWidth, bombHeight, numBombSlots);

			// Create game objects
            scoreAndLife = new ScoreAndLife(lives, laserFactory, bombFactory);
			player = new Player(screenWidth, screenHeight, playerSpeed, playerWidth, playerHeight, laserFactory, bombFactory, scoreAndLife, timerIntervalPlayerRespawn);
			bunkers = new Bunkers(numBunkers, screenWidth, screenHeight, bunkerWidth, bunkerHeight, bunkerHealth, playerHeight, spaceBetweenBunkerAndPlayer);
            mothership = new Mothership(screenWidth, mothershipWidth, mothershipHeight, mothershipSpeed, mothershipPoints, timerIntervalMothership, mothershipSpacerFromTop);
            alienSquad = new AlienSquad(bunkers, bombFactory, laserFactory, player, mothership, scoreAndLife, numRows, numColumns, screenWidth, player.BoundingBox.Height, alienWidth, alienHeight, alienSpeed, spacer, bombFrequency, alienPointStart, alienPointsPerRow, alienSpacerFromTop, speedIncrease, bombFrequencyIncrement, bombFrequencyMin);
			
			// Create sprite objects
            laserSprite = new LaserSprite(this, laserFactory.Laser, textureLaser);
			mothershipSprite = new MothershipSprite(this, mothership, player, textureMothership);
			playerSprite = new PlayerSprite(this, player, texturePlayer);
            scoreSprite = new ScoreSprite(this, scoreAndLife);
			
			for (var x = 0; x < alienSquad.Length; x++)
			{
                Components.Add(new AlienSprite(this, (Alien)alienSquad[x], textureAlien));
			}
            foreach (Bunker bunker in bunkers)
            {
                Components.Add(new BunkerSprite(this, bunker, textureBunker));
            }
			foreach (Projectile bomb in bombFactory.Bombs)
			{
                Components.Add(new BombSprite(this, bomb, textureBomb));
			}

			// Add components
			Components.Add(mothershipSprite);
            Components.Add(playerSprite);
            Components.Add(scoreSprite);
			Components.Add(laserSprite);

			// Register objects
			laserFactory.RegisterAlienSquad(alienSquad);
			laserFactory.RegisterBunkers(bunkers);
			laserFactory.RegisterMothership(mothership);
			bombFactory.RegisterBunkers(bunkers);
			bombFactory.RegisterPlayer(player);

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			
			if (player.Alive)
			{
				laserFactory.UpdateProjectiles();
				bombFactory.UpdateProjectiles();
				alienSquad.Update();
			}

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			base.Draw(gameTime);
		}
	}
}
