using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvadersBusiness;

namespace SpaceInvadersTest
{
    [TestClass]
    public class LaserFactoryTest
    {
        private const int alienHeight = 30;
        private const int alienSpeed = 1;
        private const int alienWidth = 30;
        private const int alienPointStart = 25;
        private const int alienPointDecrement = 5; //TODO: algorithm
        private const int alienSpacerFromTop = 400; //TODO: change to alien + 20
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
        private const int mothershipSpacerFromTop = 0;
        private const int mothershipSpeed = 2;
        private const int numBombSlots = 20; //Increa (DOCUMENT)
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
        public void UpdateProjectiles_TouchMothership()
        {

            //arrange
           int laserSpeed=-5;
           int laserWidth=1;
           int laserHeight = 1;
           int alienCount=5;
           LaserFactory laser = new LaserFactory(laserSpeed, laserWidth, laserHeight, alienCount);

           int mothershipW = 10;
           int screenW = 20;
           int speed = 5; //should end up at 0
           Mothership ms = new Mothership(screenW, mothershipW, mothershipHeight, speed, mothershipPoints, timerIntervalMothership, mothershipSpacerFromTop);

            //act
           
           int xMothership = ms.BoundingBox.X;
           int yMothership = ms.BoundingBox.Y;
           int xLaser = laser.Laser.BoundingBox.X;
           int yLaser = laser.Laser.BoundingBox.Y;
            
            laser.UpdateProjectiles();

            int xMothership1 = ms.BoundingBox.X;
            int yMothership1 = ms.BoundingBox.Y;
            int xLaser1 = laser.Laser.BoundingBox.X;
            int yLaser1 = laser.Laser.BoundingBox.Y;

            //assert
           Assert.AreEqual(0, xMothership); //expected, actual
           Assert.AreEqual(0, yMothership);
           Assert.AreEqual(0, xLaser); //expected, actual
           Assert.AreEqual(0, yLaser);

           Assert.AreEqual(0, xMothership1); //expected, actual
           Assert.AreEqual(0, yMothership1);
           Assert.AreEqual(0, xLaser1); //expected, actual
           Assert.AreEqual(0, yLaser1);
        }

        [TestMethod]
        public void UpdateProjectiles_TouchTop()
        {
            //arrange
            int laserSpeed = -5;
            int laserWidth = 1;
            int laserHeight = 1;
            int alienCount = 5;
            LaserFactory laser = new LaserFactory(laserSpeed, laserWidth, laserHeight, alienCount);

            //act
            int xLaser = laser.Laser.BoundingBox.X;
            int yLaser = laser.Laser.BoundingBox.Y;

            laser.UpdateProjectiles();

            int xLaser1 = laser.Laser.BoundingBox.X;
            int yLaser1 = laser.Laser.BoundingBox.Y;

            //assert
           
            Assert.AreEqual(0, xLaser); //expected, actual
            Assert.AreEqual(0, yLaser);

          
            Assert.AreEqual(0, xLaser1); //expected, actual
            Assert.AreEqual(0, yLaser1);
        }

        [TestMethod]
        public void UpdateProjectiles_TouchBunkers()
        {
            //arrange
            int laserSpeed = -5;
            int laserWidth = 1;
            int laserHeight = 1;
            int alienCount = 5;
            LaserFactory laser = new LaserFactory(laserSpeed, laserWidth, laserHeight, alienCount);

            int numBunkers=1;
            int screenWidth=100;
            int screenHeight=100;
            int bunkerWidth = 5;
            int bunkerHeight = 5;
            int bunkerHealth = 3;
            int playerHeight = 5;
            int spaceBetweenBunkerAndPlayer = 1;
            Bunkers bunkers = new Bunkers(numBunkers, screenWidth, screenHeight, bunkerWidth,  bunkerHeight,  bunkerHealth,  playerHeight,  spaceBetweenBunkerAndPlayer);

            //act
            int xLaser = laser.Laser.BoundingBox.X;
            int yLaser = laser.Laser.BoundingBox.Y;

            laser.UpdateProjectiles();

            int xLaser1 = laser.Laser.BoundingBox.X;
            int yLaser1 = laser.Laser.BoundingBox.Y;

            //assert

            Assert.AreEqual(0, xLaser); //expected, actual
            Assert.AreEqual(0, yLaser);


            Assert.AreEqual(0, xLaser1); //expected, actual
            Assert.AreEqual(0, yLaser1);
        }
    }
}
