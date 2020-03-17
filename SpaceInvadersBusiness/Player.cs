using Microsoft.Xna.Framework;
using System;
using System.Timers;

namespace SpaceInvadersBusiness
{
	public class Player : ICollidable
	{
		private BombFactory bombFactory;
		private Rectangle boundingBox;
		private LaserFactory laserFactory;
		private ScoreAndLife scoreAndLife;
		private Timer timerPlayerRespawn;

		private int screenWidth;

		private readonly int speed;

		public Player(int screenWidth, int screenHeight, int speed, int width, int height, LaserFactory laserFactory, BombFactory bombFactory, ScoreAndLife scoreAndLife, int timerIntervalPlayerRespawn)
		{
			this.screenWidth = screenWidth;
			this.speed = speed;
			this.boundingBox = new Rectangle(screenWidth / 2 - width / 2, screenHeight - height, width, height);
			this.laserFactory = laserFactory;
			this.bombFactory = bombFactory;
			this.scoreAndLife = scoreAndLife;

			Alive = true;

			timerPlayerRespawn = new Timer(timerIntervalPlayerRespawn);
			timerPlayerRespawn.Elapsed += playerRespawn;
			bombFactory.playerDeath += handlePlayerDeath;
		}

		public bool Alive
		{
			get;
			set;
		}

        public Rectangle BoundingBox
        {
            get { return boundingBox; }
            set { boundingBox = value; }
        }

		public void MoveLeft()
		{
			boundingBox.X = Math.Max(0, boundingBox.X - speed);
		}

		public void MoveRight()
		{
			boundingBox.X = Math.Min(screenWidth - boundingBox.Width, boundingBox.X + speed);
		}

		public void ResetPosition()
		{
			boundingBox.X = screenWidth / 2 - boundingBox.Width / 2;
		}

		public void Shoot()
		{
			laserFactory.CreateProjectile(boundingBox.X + (boundingBox.Width / 2), boundingBox.Y);
		}

		private void handlePlayerDeath()
		{
			timerPlayerRespawn.Enabled = true;
			scoreAndLife.OnPlayerDeath();
		}

		private void playerRespawn(Object sender, EventArgs args)
		{
			timerPlayerRespawn.Enabled = false;
			Alive = true;
            ResetPosition();
			bombFactory.ClearProjectiles();
		}
	}
}