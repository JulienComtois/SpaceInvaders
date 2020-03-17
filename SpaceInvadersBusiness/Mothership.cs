using Microsoft.Xna.Framework;
using System;
using System.Timers;

namespace SpaceInvadersBusiness
{
	public class Mothership : ICollidable
	{
		private Rectangle boundingBox;
		private Timer timerMothership;

		private int screenWidth;
		private int speed;

        private readonly int mothershipSpacerFromTop;
		private readonly int points;

        public Mothership(int screenWidth, int width, int height, int speed, int points, int timerIntervalMothership, int mothershipSpacerFromTop)
		{
			this.points = points;
			this.screenWidth = screenWidth;
			this.speed = speed;
            this.mothershipSpacerFromTop = mothershipSpacerFromTop;

            boundingBox = new Rectangle(0, mothershipSpacerFromTop, width, height);

			timerMothership = new Timer(timerIntervalMothership);
			timerMothership.Elapsed += Launch;
			timerMothership.Enabled = true;
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

		public void Kill()
		{
			Alive = false;
			timerMothership.Enabled = false;
		}

		public void Move()
		{
			boundingBox.X += speed;
		}

        public void ResetMothership()
        {
            Alive = false;
            timerMothership.Enabled = false;
            timerMothership.Enabled = true;
        }

		private void Launch(Object sender, EventArgs e)
		{
			speed *= -1;
			boundingBox.X = speed > 0 ? 0 : screenWidth - boundingBox.Width;
			Alive = true;
		}
    }
}
