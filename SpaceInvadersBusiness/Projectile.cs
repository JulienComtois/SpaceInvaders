using Microsoft.Xna.Framework;

namespace SpaceInvadersBusiness
{
	public class Projectile
	{
		private Rectangle boundingBox;

		private readonly int velocity; //Will be negative if laser, positive if bomb

		public Projectile(int xPos, int yPos, int velocity, int width, int height)
		{
			this.velocity = velocity;
			boundingBox = new Rectangle(xPos, yPos, width, height);
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

		public void Move()
		{
			boundingBox.Y += velocity;
		}
	}
}
