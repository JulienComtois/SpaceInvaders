namespace SpaceInvadersBusiness
{
	public class ScoreAndLife
	{
        public event GeneralDelegate gameOver;

        private BombFactory bombFactory;
        private LaserFactory laserFactory;

		private int lives;
		private int score;

		public ScoreAndLife(int lives, LaserFactory laserFactory, BombFactory bombFactory)
		{
            this.bombFactory = bombFactory;
            this.laserFactory = laserFactory;
            this.lives = lives;

			laserFactory.alienDeath += OnAlienDeath;
            laserFactory.mothershipDeath += OnAlienDeath;
            gameOver += laserFactory.EndGame;
		}

		public int Lives
		{
			get { return lives; }
		}

		public int Score
		{
			get { return score; }
		}

		public void OnAlienDeath(int points)
		{
			score += points;
		}

		public void OnPlayerDeath()
		{
			lives--;
            if(lives <= 0)
            {
                gameOver();
            }
		}
	}
}
