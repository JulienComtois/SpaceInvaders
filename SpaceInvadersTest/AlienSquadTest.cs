using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvadersBusiness;

namespace SpaceInvadersTest
{
    [TestClass]
    public class AlienSquadTest
    {
        private const int alienHeight = 30;
        private const int alienSpeed = 1;
        private const int alienWidth = 30;
        private const int alienPointStart = 25;
        private const int alienPointDecrement = 5; //TODO: algorithm
        private const int alienSpacerFromTop = 0; //TODO: change to alien + 20
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
        private const int numBombSlots = 20; //Increa (DOCUMENT)
        private const int numBunkers = 1;
        private const int numRows = 5;
        private const int numColumns = 11;
        private const int playerWidth = 54;
        private const int playerHeight = 33;
        private const int playerSpeed = 5;
        private const int timerIntervalMothership = 20000;
        private const int timerIntervalPlayerRespawn = 1000;
        private const int screenWidth = 100;
        private const int screenHeight = 100;
        private const int spacer = 0;
        private const int spaceBetweenBunkerAndPlayer = 50;
        private const int speedIncrease = 1;

        
        
       [TestMethod]
       public void OneDown()
       {
           int alienWidth = 1;
           int alienHeight = 1;
           int alienSpeed = 1;
           int spacer = 1;
           int numRows = 1;
           int rowLength = 1;
           int numBunkers = 1;
           int screenWidth = 100;
           int screenHeight = 100;
           int bunkerWidth = 5;
           int bunkerHeight = 5;
           int bunkerHealth = 3;
           int playerHeight = 5;
           int spaceBetweenBunkerAndPlayer = 1;
           LaserFactory laserFactory = new LaserFactory(laserSpeed, laserWidth, laserHeight, numRows * rowLength);
           BombFactory bombFactory = new BombFactory(bombSpeed, bombWidth, bombHeight, numBombSlots);

           ScoreAndLife scoreAndLife = new ScoreAndLife(lives, laserFactory, bombFactory);
           Player player = new Player(screenWidth, screenHeight, playerSpeed, playerWidth, playerHeight, laserFactory, bombFactory, scoreAndLife, timerIntervalPlayerRespawn);
           Bunkers bunkers = new Bunkers(numBunkers, screenWidth, screenHeight, bunkerWidth, bunkerHeight, bunkerHealth, playerHeight, spaceBetweenBunkerAndPlayer);
           Mothership mothership = new Mothership(screenWidth, mothershipWidth, mothershipHeight, mothershipSpeed, mothershipPoints, timerIntervalMothership, mothershipSpacerFromTop);
          //arrange
           //Bunkers bunkers = new Bunkers(numBunkers, screenWidth, screenHeight, bunkerWidth, bunkerHeight, bunkerHealth, playerHeight, spaceBetweenBunkerAndPlayer);
            BombFactory bf=new BombFactory(0,0,0,0);


            AlienSquad alienS = new AlienSquad(bunkers, bombFactory, laserFactory, player, mothership, scoreAndLife, numRows, rowLength, screenWidth, player.BoundingBox.Height, alienWidth, alienHeight, alienSpeed, spacer, bombFrequency, alienPointStart, alienPointDecrement, alienSpacerFromTop, speedIncrease, bombFrequencyIncrement, bombFrequencyMin);

           //act
           alienS.OneDown();
           int result = alienS[0].BoundingBox.Y;
           
           //assert
           Assert.AreEqual(2, result); //expected, actual
       }
       

        [TestMethod]
        public void Update()
        {
            LaserFactory laserFactory = new LaserFactory(laserSpeed, laserWidth, laserHeight, numRows * numColumns);
            BombFactory bombFactory = new BombFactory(bombSpeed, bombWidth, bombHeight, numBombSlots);

            ScoreAndLife scoreAndLife = new ScoreAndLife(lives, laserFactory, bombFactory);
            Player player = new Player(screenWidth, screenHeight, playerSpeed, playerWidth, playerHeight, laserFactory, bombFactory, scoreAndLife, timerIntervalPlayerRespawn);
            Bunkers bunkers = new Bunkers(numBunkers, screenWidth, screenHeight, bunkerWidth, bunkerHeight, bunkerHealth, playerHeight, spaceBetweenBunkerAndPlayer);
            Mothership mothership = new Mothership(screenWidth, mothershipWidth, mothershipHeight, mothershipSpeed, mothershipPoints, timerIntervalMothership, mothershipSpacerFromTop);
            //int screenWidth = 100;
            //int alienWidth = 1;
            //int alienHeight = 2;
            //int alienSpeed = 1;
            //int spacer = 1;
            //int numRows = 1;
            //int rowLength = 1;
            //int playerHeight = 0;
            //arrange
            //Bunkers bunkers = new Bunkers(numBunkers, screenWidth, screenHeight, bunkerWidth, bunkerHeight, bunkerHealth, playerHeight, spaceBetweenBunkerAndPlayer);
            BombFactory bf = new BombFactory(0, 0, 0, 0);

            AlienSquad alienS = new AlienSquad(bunkers, bombFactory, laserFactory, player, mothership, scoreAndLife, numRows, numColumns, screenWidth, player.BoundingBox.Height, alienWidth, alienHeight, alienSpeed, spacer, bombFrequency, alienPointStart, alienPointDecrement, alienSpacerFromTop, speedIncrease, bombFrequencyIncrement, bombFrequencyMin);

            //act
            alienS.Update();

            //assert
            //Assert.AreEqual(,); //expected, actual
        }
    }
}
