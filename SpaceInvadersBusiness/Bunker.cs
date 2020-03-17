using Microsoft.Xna.Framework;

namespace SpaceInvadersBusiness
{
	public class Bunker : ICollidable
	{
		private Rectangle boundingBox;

        private int health;
        
        private readonly int initialHealth;

		public Bunker(Rectangle boundingBox, int health)
		{
			this.boundingBox = boundingBox;
            this.health = health;
			initialHealth = health;
			Alive = true;
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

		public void HandleHit()
		{
			health -= 1;
			if (health <= 0)
			{
				Alive = false;
			}
		}

        public void ResetHealth()
        {
            health = initialHealth;
        }
	}
}
