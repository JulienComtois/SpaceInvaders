using Microsoft.Xna.Framework;

namespace SpaceInvadersBusiness
{
	public class BombFactory : ProjectileFactory
	{
        public event GeneralDelegate playerDeath;

		private Projectile[] bombs;
		private Bunkers bunkers;
		private Player player;

		private int slotCtr = 0;

        private readonly int numBombSlots;

		public BombFactory(int bombSpeed, int bombWidth, int bombHeight, int numBombSlots)
		{
            this.numBombSlots = numBombSlots;
			bombs = new Projectile[numBombSlots];
			for (var x = 0; x < numBombSlots; x++)
			{
				bombs[x] = new Projectile(0, 0, bombSpeed, bombWidth, bombHeight);
			}
		}

        public Projectile[] Bombs
        {
            get { return bombs; }
        }

		public override void ClearProjectiles()
		{
			foreach(var bomb in bombs)
			{
				bomb.Alive = false;
			}
		}

		public void CreateProjectile(Rectangle alienBoundingBox)
		{
            if (slotCtr >= numBombSlots)
            { 
                slotCtr = 0;
            }
			var bomb = bombs[slotCtr++];
			bomb.Alive = true;
			// Places the bomb directly under the alien
            bomb.BoundingBox = new Rectangle(alienBoundingBox.X + alienBoundingBox.Width / 2 - bomb.BoundingBox.Width / 2, alienBoundingBox.Y + alienBoundingBox.Height, bomb.BoundingBox.Width, bomb.BoundingBox.Height);
		}

		public void RegisterBunkers(Bunkers bunkers)
		{
			this.bunkers = bunkers;
		}

		public void RegisterPlayer(Player player)
		{
			this.player = player;
		}

		public override void UpdateProjectiles()
		{
			foreach (var bomb in bombs)
			{
				if(bomb.Alive)
				{
					bomb.Move();
				}
			}
		    CheckForCollisions();
		}

		private void CheckForCollisions()
		{
			foreach (var bomb in bombs)
			{
				if (bomb.Alive)
				{
					if (player.Alive && bomb.BoundingBox.Intersects(player.BoundingBox))
					{
						player.Alive = false;
						bomb.Alive = false;
						playerDeath();
					}
					else if (detectCollidedObjects(bunkers, bomb))
					{
						bomb.Alive = false;
					}
				}
			}
		}
	}
}