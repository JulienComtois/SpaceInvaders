using Microsoft.Xna.Framework;

namespace SpaceInvadersBusiness
{
	public class LaserFactory : ProjectileFactory
	{
		public event AlienDeathDelegate mothershipDeath;
		public event GeneralDelegate nextWave;

		private AlienSquad alienSquad;
		private Bunkers bunkers;
		private Projectile laser;
		private Mothership mothership;

        private int aliensDead = 0;

        private readonly int alienCount;
		private readonly int laserHeight;
        private readonly int laserWidth;

		public LaserFactory(int laserSpeed, int laserWidth, int laserHeight, int alienCount)
		{
            this.laserHeight = laserHeight;
            this.laserWidth = laserWidth;
            this.alienCount = alienCount;
			laser = new Projectile(0, 0, laserSpeed, laserWidth, laserHeight);
		}

		public Projectile Laser
		{
			get { return laser; }
		}

		public override void ClearProjectiles()
		{
			laser.Alive = false;
		}

        public void CreateProjectile(int xPos, int yPos)
		{
			if (laser.Alive == false)
			{
				laser.Alive = true;
				laser.BoundingBox = new Rectangle(xPos, yPos, laser.BoundingBox.Width, laser.BoundingBox.Height);
			}
		}

		public void EndGame()
		{
			alienSquad.KillAll();
		}

		public void RegisterAlienSquad(AlienSquad alienSquad)
		{
			this.alienSquad = alienSquad;
		}

		public void RegisterBunkers(Bunkers bunkers)
		{
			this.bunkers = bunkers;
		}

		public void RegisterMothership(Mothership mothership)
		{
			this.mothership = mothership;
		}

		public override void UpdateProjectiles()
		{
			// Updates laser's position
			if (laser.Alive)
			{
				laser.Move();
				checkForCollisions();
			}
		}
        
		private void checkForCollisions()
		{
			if (mothership != null && mothership.Alive && laser.BoundingBox.Intersects(mothership.BoundingBox))
			{
				mothership.Alive = false;
				laser.Alive = false;
				mothershipDeath(mothership.Points);
			}
			else if (laser.BoundingBox.Y < -laserHeight)
			{
				laser.Alive = false;
			}
			else if (bunkers != null && detectCollidedObjects(bunkers, laser))
			{
				laser.Alive = false;
			}
			else if (alienSquad != null && detectCollidedObjects(alienSquad, laser))
			{
				laser.Alive = false;
				aliensDead++;
				if (aliensDead >= alienCount)
				{
					nextWave();
					aliensDead = 0;
				}
			}
		}
	}
}
