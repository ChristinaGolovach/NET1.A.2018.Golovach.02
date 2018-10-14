using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Logic.BitInsertion;

namespace Logic.Tests
{
    [TestClass]
    public class BitInsertionTests
    {
        [TestMethod]
        public void InsertNumber_15InsertTo8From3To8Bits_Return120()
        {
            // Arrange
            int original = 8;
            int insert = 15;
            int smallerBitNumber = 3;
            int largeBitNumber = 8;

            // Act 
            int result = InsertNumber(original, insert, smallerBitNumber, largeBitNumber);

            // Assert
            Assert.AreEqual(120, result);
        }

        [TestMethod]
        public void InsertNumber_Minus1InsertToMaxIntFrom31To31Bits_ReturnMinus1()
        {
            // Arrange
            int smallerBitNumber = 31;
            int largeBitNumber = 31;

            // Act 
            int result = InsertNumber(int.MaxValue, -1, smallerBitNumber, largeBitNumber);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void InsertNumber_8InsertTo8From0To31Bits_Return8()
        {
            // Arrange
            int original = 8;
            int insert = 8;
            int smallerBitNumber = 0;
            int largeBitNumber = 31;

            // Act 
            int result = InsertNumber(original, insert, smallerBitNumber, largeBitNumber);

            // Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]        
        public void InsertNumber_InsertingWithSmallerBitPositionLessThan0_ThrownArgumentOutOfRangeException()
            => InsertNumber(12, 12, -1, 12);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_InsertingWithLargeBitPositionMoreThan31_ThrownArgumentOutOfRangeException()
            => InsertNumber(12, 12, 1, 32);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_InsertingWithSmallerBitPositionLessThan0AndWithLargeBitPositionMoreThan31_ThrownArgumentOutOfRangeException()
            => InsertNumber(12, 12, -1, 32);
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_InsertingWithSmallerBitPositionMoreThanLargeBitPosition_TrownArgumentException()
            => InsertNumber(12, 12, 12, 0);
    }
}
