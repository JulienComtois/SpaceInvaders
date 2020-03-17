using Microsoft.Xna.Framework;
using System;

namespace SpaceInvadersBusiness
{
	public class Alien : ICollidable
	{
		public static int bunkerHeight;
		public static int playerHeight;
        public static int screenWidth;
        public static int speedIncrease;

		private Rectangle boundingBox;

		private int speed;
		private int width;
		private int height;

		private readonly int points;

		public Alien(int width, int height, int xPos, int yPos, int speed, int points)
		{
			this.width = width;
			this.height = height;
			this.speed = speed;
			this.points = points;
            boundingBox = new Rectangle(xPos, yPos, width, height);
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

		public int Points
		{
			get { return points; }
		}

        public bool TryMove()
        {
            if (BoundingBox.X + speed < 0) // Touch left wall
            {
                return false;
            }
            else if (BoundingBox.X + width + speed > screenWidth) // Touch right wall
            {
                return false;
            }
            return true;
        }

		public bool HasReachedBottom()
		{
			return boundingBox.Y + height >= playerHeight;
		}

        public bool HasReachedBunker()
        {
            return boundingBox.Y + height >= bunkerHeight;
        }

        public void IncreaseSpeed()
        {
            speed += speedIncrease;
        }

		public void Move()
		{
			boundingBox.X += speed;
		}

		public void MoveDown()
		{
			boundingBox.Y += this.BoundingBox.Height;
		}

        public void ResetDirection()
        {
            speed = Math.Abs(speed);
        }

        public void SwitchDirection()
        {
            speed *= -1;
        }
	}
}

