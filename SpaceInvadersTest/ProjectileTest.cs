using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvadersBusiness;

namespace SpaceInvadersTest
{
    [TestClass]
    public class ProjectileTest
    {
        [TestMethod]
        public void Move()
        {
            //arrange
            int xPos=0;
            int yPos=1;
            int velocity=1;
            int width=1;
            int height = 1;
            Projectile pjt = new Projectile(xPos, yPos, velocity, width, height);
            
            //act
            pjt.Move();
            int y = pjt.BoundingBox.Y;


            //assert
            Assert.AreEqual(2, y); //expected, actual
            
        }
    }
}
