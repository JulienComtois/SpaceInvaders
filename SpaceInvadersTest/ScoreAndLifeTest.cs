using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvadersBusiness;

namespace SpaceInvadersTest
{
    [TestClass]
    public class ScoreAndLifeTest
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

        LaserFactory laserFactory = new LaserFactory(laserSpeed, laserWidth, laserHeight, numRows * numColumns);
        BombFactory bombFactory = new BombFactory(bombSpeed, bombWidth, bombHeight, numBombSlots);
			
        [TestMethod]
        public void OnAlienDeath()
        {
            //arrange
            int lives=1;
		    //int score=10;
            ScoreAndLife sl = new ScoreAndLife(lives, laserFactory, bombFactory);
            
            //act
            sl.OnAlienDeath(20);
            int result = sl.Score;

            //assert
            Assert.AreEqual(20, result); //expected, actual

        }

        
        [TestMethod]
        public void OnPlayerDeath_HaveLife()
        {
            //arrange
            int lives = 2;
            //int score = 10;
            ScoreAndLife sl = new ScoreAndLife(lives, laserFactory, bombFactory);

            //act
            sl.OnPlayerDeath();
            int result = sl.Lives;

            //assert
            Assert.AreEqual(1, result); //expected, actual
        }

        [TestMethod]
        public void OnPlayerDeath_gameOver()
        {

            //arrange
           // bool eventCaught=true;
            int lives = 1;
            //int score = 10;
            ScoreAndLife sl = new ScoreAndLife(lives, laserFactory, bombFactory);
            Player player = new Player(screenWidth, screenHeight, playerSpeed, playerWidth, playerHeight, laserFactory, bombFactory, sl, timerIntervalPlayerRespawn);
            Bunkers bunkers = new Bunkers(numBunkers, screenWidth, screenHeight, bunkerWidth, bunkerHeight, bunkerHealth, playerHeight, spaceBetweenBunkerAndPlayer);
            Mothership mothership = new Mothership(screenWidth, mothershipWidth, mothershipHeight, mothershipSpeed, mothershipPoints, timerIntervalMothership, mothershipSpacerFromTop);
            AlienSquad alienSquad = new AlienSquad(bunkers, bombFactory, laserFactory, player, mothership, sl, numRows, numColumns, screenWidth, player.BoundingBox.Height, alienWidth, alienHeight, alienSpeed, spacer, bombFrequency, alienPointStart, alienPointDecrement, alienSpacerFromTop, speedIncrease, bombFrequencyIncrement, bombFrequencyMin);
            //act
            laserFactory.RegisterAlienSquad(alienSquad);
            laserFactory.RegisterBunkers(bunkers);
            laserFactory.RegisterMothership(mothership);
            //sl.gameOver += delegate()
            //{
            //    eventCaught = true;
            //};
            sl.OnPlayerDeath();
            int result = sl.Lives;
            //assert
            Assert.AreEqual(0, result); //expected, actual
            //Assert.IsTrue(eventCaught);
        }
    }
}
