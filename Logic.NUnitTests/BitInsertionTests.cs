using System;
using NUnit.Framework;
using static Logic.BitInsertion;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class BitInsertionTests
    {
        [TestCase(8, 15, 3, 8, 120)]
        [TestCase(15, 15, 0, 0, 15)]
        [TestCase(8, 8, 0, 31, 8)]
        [TestCase(int.MaxValue, -1, 31, 31, -1)]            
        [TestCase(-1, 0, 0, 30, int.MinValue)]
        public void InsertNumber_InsertingBitsOfNumberWithCorrectPositionOfThem_ReturnedNewNumber(int numberSource, int numberIn, int smallerBitNumber, int largeBitNumber, int result)
        {
            // Act
            int expectedResult = InsertNumber(numberSource, numberIn, smallerBitNumber, largeBitNumber);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(12, 12, -1, 12)]
        [TestCase(12, 12, 1, 32)]
        [TestCase(12, 12, -1, 32)]
        public void InsertNumber_InsertingBitsOfNumberWithOutRangePosition_ThrownArgumentOutOfRangeException(int numberSource, int numberIn, int smallerBitNumber, int largeBitNumber)
            => Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumber(numberSource, numberIn, smallerBitNumber, largeBitNumber));

        [TestCase(12, 12, 12, 0)]
        public void InsertNumber_InsertingBitsWhenSmallerBitPositionMoreThanLargeBitPosition(int numberSource, int numberIn, int smallerBitNumber, int largeBitNumber)
            => Assert.Throws<ArgumentException>(() => InsertNumber(numberSource, numberIn, smallerBitNumber, largeBitNumber));
    }
}
