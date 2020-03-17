using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvadersBusiness;

namespace SpaceInvadersTest
{
    [TestClass]
    public class MothershipTest
    {
        private const int mothershipSpacerFromTop = 40;
        private const int timerIntervalMothership = 20000;
        private const int mothershipPoints = 150;
        private const int mothershipHeight = 14; //TODO: base off image

        [TestMethod]
        public void Move_Left()
        {
            //arrange
            int mothershipW = 10;
            int screenW = 20;
            int speed = 5; //should end up at 0
            Mothership ms = new Mothership(screenW, mothershipW, mothershipHeight, speed, mothershipPoints, timerIntervalMothership, mothershipSpacerFromTop);

            //act
            ms.Move();
            int x = ms.BoundingBox.X;

            //assert
            Assert.AreEqual(5, x); //expected, actual

        }



        [TestMethod]
        public void Move_Right()
        {
            //arrange
            int mothershipW = 10;
            int screenW = 20;
            int speed = 5; //should end up at 0
            Mothership ms = new Mothership(screenW, mothershipW, mothershipHeight, speed, mothershipPoints, timerIntervalMothership, mothershipSpacerFromTop);

            //act
            ms.Move();
            int x = ms.BoundingBox.X;


            //assert
            Assert.AreEqual(5, x); //expected, actual
        }

    }
}
