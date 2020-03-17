using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvadersBusiness;

namespace SpaceInvadersTest
{
    [TestClass]
    public class AlienTest
    {
        private const int alienHeight = 5;
        private const int alienSpeed = 1;
        private const int alienWidth = 30;
        private const int alienPointStart = 25;
        private const int alienPointDecrement = 5; //TODO: algorithm
        private const int alienSpacerFromTop = 400; //TODO: change to alien + 20
        private const int spacer = 15;
        [TestMethod]
        public void Move_ToLeft()
        {
            //arrange
            int xPos = 20;
            int yPos = 10;
            int speed = -5;
            Alien alien = new Alien(10, 10, xPos, yPos, speed, 0);

            //act
            alien.Move();
            int x = alien.BoundingBox.X;

            //assert
            Assert.AreEqual(15, x); //expected, actual
        }
        [TestMethod]
        public void Move_ToRight()
        {
            //arrange
            int xPos = 20;
            int yPos = 10;
            int speed = 5;
            Alien alien = new Alien(10, 10, xPos, yPos, speed, 0);

            //act
            alien.Move();
            int x = alien.BoundingBox.X;

            //assert
            Assert.AreEqual(25, x); //expected, actual
        }

        [TestMethod]
        public void TryMove_ToLeftNoSpace()
        {
            //arrange
            int row = 0;
            int col = 0;
            //int width = 10;
            //int xPos = 4;
            //int speed = 5;
            //int screeW = 20;
            Alien alien = new Alien(alienWidth, alienHeight, col * alienWidth + col * spacer, alienSpacerFromTop + spacer * row + row * alienHeight + alienHeight, alienSpeed, alienPointStart - row * alienPointDecrement);

            //act
            bool result = alien.TryMove();

            //assert
            Assert.AreEqual(false, result); //expected, actual
        }

        [TestMethod]
        public void TryMove_ToLeftHaveSpace()
        {
            //arrange
            //int col = 0;
            int row = 0;
            int width = 1;
            int xPos = 10;
            int speed = 1;
            //int screeW = 2000;
            Alien alien = new Alien(width, 1, xPos, 0, speed, alienPointStart - row * alienPointDecrement);
            Alien.screenWidth = 2000;
            //act
            bool result = alien.TryMove();

            //assert
            Assert.AreEqual(true, result); //expected, actual
        }

        [TestMethod]
        public void TryMove_ToRightNoSpace()
        {
            //arrange
            int row = 0;
            //int col = 0;
            int width = 10;
            int xPos = 10;
            int speed = 5;
            //int screeW = 20;
            Alien alien = new Alien(width, 1, xPos, 0, speed, alienPointStart - row * alienPointDecrement);
            Alien.screenWidth = 20;
            //act
            bool result = alien.TryMove();

            //assert
            Assert.AreEqual(false, result); //expected, actual
        }

        [TestMethod]
        public void TryMove_ToRightHaveSpace()
        {
            //arrange
            int row = 0;
            //int col = 0;
            int width = 5;
            int xPos = 10;
            int speed = 5;
            //int screenW = 2000;
            Alien alien = new Alien(width, alienHeight, xPos, 0, speed, alienPointStart - row * alienPointDecrement);
            Alien.screenWidth = 2000;
            //act
            bool result = alien.TryMove();

            //assert
            Assert.AreEqual(true, result); //expected, actual
        }

        [TestMethod]
        public void HasReachBottom_reach()
        {
            //arrange
            int width = 1;
            int xPos = 10;
            int yPos = 295;
            int height = 10;
            int speed = 5;
            Alien alien = new Alien(width, height, xPos, yPos, speed, 0);

            //act
            bool result = alien.HasReachedBottom();

            //assert
            Assert.AreEqual(true, result); //expected, actual
        }

        [TestMethod]
        public void HasReachBottom_notReach()
        {
            //arrange
            int width = 1;
            int xPos = 10;
            int yPos = 280;
            int height = 1;
            int speed = 5;
            Alien alien = new Alien(width, height, xPos, yPos, speed, 0);
            Alien.playerHeight = 300;

            //act
            bool result = alien.HasReachedBottom();

            //assert
            Assert.AreEqual(false, result); //expected, actual
        }
        [TestMethod]
        public void HasReachBunker_reach()
        {
            //arrange
            int width = 1;
            int xPos = 10;
            int yPos = 195;
            int height = 10;
            int speed = 5;
            Alien alien = new Alien(width, height, xPos, yPos, speed, 0);

            //act
            bool result = alien.HasReachedBunker();

            //assert
            Assert.AreEqual(true, result); //expected, actual
        }

        [TestMethod]
        public void HasReachBunker_notReach()
        {
            //arrange
            int width = 1;
            int xPos = 10;
            int yPos = 180;
            int height = 10;
            int speed = 5;
            Alien alien = new Alien(width, height, xPos, yPos, speed, 0);
            Alien.bunkerHeight = 191;

            //act
            bool result = alien.HasReachedBunker();

            //assert
            Assert.AreEqual(false, result); //expected, actual
        }

        [TestMethod]
        public void MoveDown()
        {
            //arrange
            int width = 1;
            int xPos = 10;
            int yPos = 80;
            int height = 10;
            int speed = 5;
            Alien alien = new Alien(width, height, xPos, yPos, speed, 0);

            //act
            alien.MoveDown();
            int result = alien.BoundingBox.Y;

            //assert
            Assert.AreEqual(90, result); //expected, actual
        }

    }
}
