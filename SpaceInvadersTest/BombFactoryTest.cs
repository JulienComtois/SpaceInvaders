using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvadersBusiness;

namespace SpaceInvadersTest
{
    [TestClass]
    public class BombFactoryTest
    {
        private const int alienHeight = 30;
        private const int alienSpeed = 1;
        private const int alienWidth = 30;
        private const int alienPointStart = 25;
        private const int alienPointDecrement = 5;
        private const int alienSpacerFromTop = 400;
        private const int bombFrequency = 60;
        private const int bombFrequencyIncrement = 5;
        private const int bombFrequencyMin = 10;
        private const int bombHeight = 10;
        private const int bombWidth = 3;
        private const int bombSpeed = 5;
        private const int bunkerHealth = 10;
        private const int bunkerHeight = 50;
        private const int bunkerWidth = 90;
        private const int laserHeight = 10;
        private const int laserSpeed = -10;
        private const int laserWidth = 3;
        private const int lives = 3;
        private const int mothershipWidth = 32;
        private const int mothershipHeight = 14;
        private const int mothershipPoints = 150;
        private const int mothershipSpacerFromTop = 40;
        private const int mothershipSpeed = 2;
        private const int numBombSlots = 20;
        private const int numBunkers = 4;
        private const int numRows = 5;
        private const int numColumns = 11;
        private const int playerWidth = 54;
        private const int playerHeight = 33;
        private const int playerSpeed = 5;
        private const int timerIntervalMothership = 20000;
        private const int timerIntervalPlayerRespawn = 1000;
        private const int screenWidth = 800;
        private const int screenHeight = 800;
        private const int spacer = 15;
        private const int spaceBetweenBunkerAndPlayer = 50;
        private const int speedIncrease = 1;
        [TestMethod]
        public void UpdateProjectiles_TouchBunkers()
        {
            //arrange
            int bombSpeed = 5;
            int bombWidth = 1;
            int bombHeight = 1;
            int numBombSlots = 5;
            BombFactory bomb = new BombFactory(bombSpeed, bombWidth, bombHeight, numBombSlots);

            int numBunkers = 1;
            int screenWidth = 100;
            int screenHeight = 100;
            Bunkers bunkers = new Bunkers(numBunkers, screenWidth, screenHeight, bunkerWidth, bunkerHeight, bunkerHealth, playerHeight, spaceBetweenBunkerAndPlayer);

            //act
            int xBomb = bomb.Bombs[0].BoundingBox.X;
            int yBomb = bomb.Bombs[0].BoundingBox.Y;

            bomb.UpdateProjectiles();

            int xBomb1 = bomb.Bombs[0].BoundingBox.X;
            int yBomb1 = bomb.Bombs[0].BoundingBox.Y;

            //assert

            Assert.AreEqual(0, xBomb); //expected, actual
            Assert.AreEqual(0, yBomb);

            Assert.AreEqual(0, xBomb1); //expected, actual
            Assert.AreEqual(0, yBomb1);
        }

        [TestMethod]
        public void UpdateProjectiles_TouchPlayer()
        {
            int bombSpeed = 5;
            int bombWidth = 1;
            int bombHeight = 1;
            int numBombSlots = 5;
            LaserFactory laserFactory = new LaserFactory(laserSpeed, laserWidth, laserHeight, numRows * numColumns);
            BombFactory bombFactory = new BombFactory(bombSpeed, bombWidth, bombHeight, numBombSlots);

            // Create game objects
            ScoreAndLife scoreAndLife = new ScoreAndLife(lives, laserFactory, bombFactory);
            Player player = new Player(screenWidth, screenHeight, playerSpeed, playerWidth, playerHeight, laserFactory, bombFactory, scoreAndLife, timerIntervalPlayerRespawn);
            //arrange
            BombFactory bomb = new BombFactory(bombSpeed, bombWidth, bombHeight, numBombSlots);

            //int playerW = 10;
            //int screenW = 20;
            //int speed = 5; //should end up at 0

            //act
            int xBomb = bomb.Bombs[0].BoundingBox.X;
            int yBomb = bomb.Bombs[0].BoundingBox.Y;

            bomb.UpdateProjectiles();

            int xBomb1 = bomb.Bombs[0].BoundingBox.X;
            int yBomb1 = bomb.Bombs[0].BoundingBox.Y;

            //assert

            Assert.AreEqual(0, xBomb); //expected, actual
            Assert.AreEqual(0, yBomb);

            Assert.AreEqual(0, xBomb1); //expected, actual
            Assert.AreEqual(0, yBomb1);
        }
    }
}
