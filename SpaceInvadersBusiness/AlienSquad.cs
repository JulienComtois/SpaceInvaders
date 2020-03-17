using Microsoft.Xna.Framework;
using System;

namespace SpaceInvadersBusiness
{
	public delegate void GeneralDelegate();
	public delegate void AlienDeathDelegate(int points);

	public class AlienSquad : ICollidableCollection
	{
        private Alien[,] aliens;
        private BombFactory bombFactory;
		private Bunkers bunkers;
        private LaserFactory laserFactory;
        private Mothership mothership;
        private Player player;
        private Random random = new Random();
        private ScoreAndLife scoreAndLife;

        private bool areBunkersDead;
		private int alienSpeed;
		private int bombFrequency;

		private readonly int alienHeight;
		private readonly int alienPointDecrement;
		private readonly int alienPointStart;
        private readonly int alienSpacerFromTop;
		private readonly int alienWidth;
        private readonly int bombFrequencyIncrement;
        private readonly int bombFrequencyMin;
        private readonly int numRows;
        private readonly int numColumns;
		private readonly int spacer;

        public AlienSquad(Bunkers bunkers, BombFactory bombFactory, LaserFactory laserFactory, Player player, Mothership mothership, ScoreAndLife scoreAndLife, int numRows, int numColums, int screenWidth, int playerHeight, int alienWidth, int alienHeight, int alienSpeed, int spacer, int bombFrequency, int alienPointStart, int alienPointDecrement, int alienSpacerFromTop, int speedIncrease, int bombFrequencyIncrement, int bombFrequencyMin)
		{
			this.bunkers = bunkers;
			this.bombFactory = bombFactory;
            this.laserFactory = laserFactory;
			this.numRows = numRows;
            this.numColumns = numColums;
			this.alienWidth = alienWidth;
			this.alienHeight = alienHeight;
			this.alienSpeed = alienSpeed;
			this.spacer = spacer;
			this.bombFrequency = bombFrequency;
			this.alienPointStart = alienPointStart;
			this.alienPointDecrement = alienPointDecrement;
            this.alienSpacerFromTop = alienSpacerFromTop;
            this.player = player;
            this.mothership = mothership;
            this.bombFrequencyIncrement = bombFrequencyIncrement;
            this.bombFrequencyMin = bombFrequencyMin;
            this.scoreAndLife = scoreAndLife;

            populateAliens();

			// Set static fields
            Alien.bunkerHeight = bunkers[0].BoundingBox.Y;
            Alien.playerHeight = playerHeight;
            Alien.screenWidth = screenWidth;
            Alien.speedIncrease = speedIncrease;

            laserFactory.nextWave += handleNextWave;
            scoreAndLife.gameOver += KillAll;
		}

		public int Length
		{
			get { return aliens.Length; }
		}

		public ICollidable this[int index]
		{
			get
			{
				if (index < 0 || index >= Length)
				{
					throw new IndexOutOfRangeException("Index out of range!");
				}
				else
				{
					int row = index / numColumns;
					int col = index % numColumns;
					return aliens[row, col];
				}
			}
		}

		public void KillAll()
		{
			bunkers.RemoveBunkers();
			player.Alive = false;
			mothership.Kill();
			laserFactory.ClearProjectiles();
			bombFactory.ClearProjectiles();
			killAliens();
		}

		public void OneDown()
		{
			foreach (var alien in aliens)
			{
				alien.MoveDown();
				alien.SwitchDirection();
			}
		}

		public void Update()
		{
			if (!tryMove())
			{
				OneDown();
				if (!tryMoveDown())
				{
					KillAll();
					return;
				}
			}

			// Move all aliens
			for (var rowCtr = 0; rowCtr < numRows; rowCtr++)
			{
				for (var colCtr = 0; colCtr < numColumns; colCtr++)
				{
					aliens[rowCtr, colCtr].Move();
				}
			}
			randomDrop();
		}

        private void handleNextWave()
        {
            player.ResetPosition();
            respawnAliens();
            resetAlienPositions();
            increaseBombFrequency();
            increaseAlienSpeed();
            bunkers.ResetBunkers();
            mothership.ResetMothership();
            laserFactory.ClearProjectiles();
            bombFactory.ClearProjectiles();
            areBunkersDead = false;
        }

        private void increaseAlienSpeed()
        {
            for (var row = 0; row < numRows; row++)
            {
                for (var col = 0; col < numColumns; col++)
                {
                    aliens[row, col].ResetDirection();
                    aliens[row, col].IncreaseSpeed();
                }
            }
        }

        private void increaseBombFrequency()
        {
            int newBombFrequency = bombFrequency -= bombFrequencyIncrement;
            bombFrequency = newBombFrequency < bombFrequencyMin ? bombFrequencyMin : newBombFrequency;
        }

		private void killAliens()
		{
			for (var row = 0; row < numRows; row++)
			{
				for (var col = 0; col < numColumns; col++)
				{
					aliens[row, col].Alive = false;
				}
			}
		}

		private void populateAliens()
		{
			aliens = new Alien[numRows, numColumns];
			for (var row = 0; row < numRows; row++)
			{
				for (var col = 0; col < numColumns; col++)
				{
					Alien al = new Alien(alienWidth, alienHeight, col * alienWidth + col * spacer, alienSpacerFromTop + spacer * row + row * alienHeight + alienHeight, alienSpeed, alienPointStart - row * alienPointDecrement);
					aliens[row, col] = al;
				}
			}
		}

		private void randomDrop()
		{
			if (random.Next(0, bombFrequency) == 0) // Chance to drop bomb per tick
			{
				Alien al;
				int ctr;
				int rand;
				bool hasBeenFound = false;
				while (!hasBeenFound)
				{
					ctr = numRows - 1;
					rand = random.Next(0, numColumns);
					// Ensures only the bottom alien in each column which is alive can drop bombs
					do
					{
						al = aliens[ctr, rand];
						if (al.Alive)
						{
							hasBeenFound = true;
							bombFactory.CreateProjectile(al.BoundingBox);
							break;
						}
						else
							ctr--;
					} while (ctr >= 0);
				}
			}
		}

        private void resetAlienPositions()
        {
            for (var row = 0; row < numRows; row++)
            {
                for (var col = 0; col < numColumns; col++)
                {
                    Alien al = aliens[row, col];
                    al.BoundingBox = new Rectangle(col * alienWidth + col * spacer, alienSpacerFromTop + spacer * row + row * alienHeight + alienHeight, al.BoundingBox.Width, al.BoundingBox.Height);
                }
            }
        }

        private void respawnAliens()
        {
            for (var row = 0; row < numRows; row++)
            {
                for (var col = 0; col < numColumns; col++)
                {
                    aliens[row, col].Alive = true;
                }
            }
        }

        private bool tryMove()
        {
			for (var rowCtr = 0; rowCtr < numRows; rowCtr++)
            {
				for (var colCtr = 0; colCtr < numColumns; colCtr++)
                {
					if (aliens[rowCtr, colCtr].Alive && !aliens[rowCtr, colCtr].TryMove())
                        return false;
                }
            }
            return true;
        }

		private bool tryMoveDown()
		{
			if (areBunkersDead)
			{
				for (var rowCtr = numRows - 1; rowCtr >= 0; rowCtr--)
				{
					for (var colCtr = 0; colCtr < numColumns; colCtr++)
					{
						if (aliens[rowCtr, colCtr].Alive && aliens[rowCtr, colCtr].HasReachedBottom())
							return false;
					}
				}
			}
			else
			{
				for (var rowCtr = numRows - 1; rowCtr >= 0; rowCtr--)
				{
					for (var colCtr = 0; colCtr < numColumns; colCtr++)
					{
						if (aliens[rowCtr, colCtr].Alive && aliens[rowCtr, colCtr].HasReachedBunker())
						{
							bunkers.RemoveBunkers();
							areBunkersDead = true;
						}
					}
				}
			}
			return true;
		}
	}
}
