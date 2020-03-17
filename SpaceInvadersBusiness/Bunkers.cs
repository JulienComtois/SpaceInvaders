using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SpaceInvadersBusiness
{
	public class Bunkers : ICollidableCollection, IEnumerable
	{
		private List<Bunker> bunkers = new List<Bunker>();

		private readonly int bunkerWidth;
		private readonly int bunkerHeight;
		private readonly int bunkerHealth;
		private readonly int bunkerYPos;

		public Bunkers(int numBunkers, int screenWidth, int screenHeight, int bunkerWidth, int bunkerHeight, int bunkerHealth, int playerHeight, int spaceBetweenBunkerAndPlayer)
		{
			this.bunkerWidth = bunkerWidth;
			this.bunkerHeight = bunkerHeight;
			this.bunkerHealth = bunkerHealth;
			bunkerYPos = screenHeight - bunkerHeight - playerHeight - spaceBetweenBunkerAndPlayer;
			populateBunkers(numBunkers, screenWidth, screenHeight);
		}

		public int Length
		{
			get { return bunkers.Count; }
		}

		public IEnumerator GetEnumerator()
		{
			return bunkers.GetEnumerator();
		}

		public ICollidable this[int index]
		{
			get { return bunkers.ElementAt(index); }
		}

        public void RemoveBunkers()
        {
			foreach(var bunker in bunkers)
			{
				bunker.Alive = false;
			}
        }

        public void ResetBunkers()
        {
            foreach(Bunker b in bunkers)
            {
                b.Alive = true;
                b.ResetHealth();
            }
        }

		private void populateBunkers(int numBunkers, int screenWidth, int screenHeight)
		{
			// The math in here is just so the number of bunkers is scalable
			int bunkerSpacing = (screenWidth - numBunkers * bunkerWidth) / (numBunkers + 1);
			for (var x = 0; x < numBunkers; x++)
			{
				bunkers.Add(new Bunker(new Rectangle(x * bunkerWidth + bunkerSpacing * (x + 1), bunkerYPos, bunkerWidth, bunkerHeight), bunkerHealth));
			}
		}
    }
}
