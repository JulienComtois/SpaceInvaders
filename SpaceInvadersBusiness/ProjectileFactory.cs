namespace SpaceInvadersBusiness
{
	public abstract class ProjectileFactory
	{
		public event AlienDeathDelegate alienDeath;

		public abstract void ClearProjectiles();

		public abstract void UpdateProjectiles();

		protected bool detectCollidedObjects(ICollidableCollection collidables, Projectile projectile)
		{
			for (int i = 0; i < collidables.Length; i++)
			{
				if (collidables[i].Alive && projectile.BoundingBox.Intersects(collidables[i].BoundingBox))
				{
					if (collidables[i] is Alien)
					{
						alienDeath(((Alien)(collidables[i])).Points);
						collidables[i].Alive = false;
					}
					else if (collidables[i] is Bunker)
					{
						((Bunker)(collidables[i])).HandleHit();
					}
					else
					{
						collidables[i].Alive = false;

					}
					return true;
				}
			}
			return false;
		}
	}
}