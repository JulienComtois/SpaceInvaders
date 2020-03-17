﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvadersBusiness;


namespace SpaceInvadersTest
{
    [TestClass]
    public class BunkersTest
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
        private const int mothershipSpacerFromTop = 40;
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
        public void RemoveBunkers()
        {
            //arrange
            int numBunkers = 2;
            int screenWidth = 100;
            int screenHeight = 100;
            Bunkers bunkers = new Bunkers(numBunkers, screenWidth, screenHeight, bunkerWidth, bunkerHeight, bunkerHealth, playerHeight, spaceBetweenBunkerAndPlayer);

            //act
            bunkers.RemoveBunkers();

            bool alive0=bunkers[0].Alive;
            bool alive1 = bunkers[1].Alive;

            //assert
            Assert.AreEqual(false, alive0);
            Assert.AreEqual(false, alive1);
        }
    }
}
