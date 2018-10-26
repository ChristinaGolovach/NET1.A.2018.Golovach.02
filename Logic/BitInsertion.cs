using System;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Represents a class that works with integer numbers and performs the inserting bits from one number to another.
    /// </summary>
    public static class BitInsertion
    {
        private static readonly int COUNTBITINONEBYTE;
        private static readonly int MINBITPOSITION;

        static BitInsertion()
        {
            COUNTBITINONEBYTE = 8;
            MINBITPOSITION = 0;
        }

        /// <summary>
        /// Performs the insert bits from one of the number to another in a certain range.
        /// </summary>
        /// <param name="numberSource">
        /// The target number for inserting bits from another number.
        /// </param>
        /// <param name="numberIn">
        /// The number from which bits are taken.
        /// </param>
        /// <param name="smallerBitNumber">
        /// The number of smaller bit.
        /// </param>
        /// <param name="largeBitNumber">
        /// The number of larger bit.
        /// </param>
        /// <returns>
        /// The new int number after insertig bits.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the values of smaller and large bits less than 0 or more than 31.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the value of smaller bit more than value of large bit.
        /// </exception>
        public static int InsertNumber(int numberSource, int numberIn, int smallerBitNumber, int largeBitNumber)
        {
            int maxBitPosition = COUNTBITINONEBYTE * sizeof(int) - 1; ;

            if (smallerBitNumber < MINBITPOSITION || smallerBitNumber > maxBitPosition)
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(smallerBitNumber)} must be in range between {MINBITPOSITION} - {maxBitPosition}.");
            }

            if (largeBitNumber < MINBITPOSITION || largeBitNumber > maxBitPosition)
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(largeBitNumber)} must be in range between {MINBITPOSITION} - {maxBitPosition}.");
            }

            if (smallerBitNumber > largeBitNumber)
            {
                throw new ArgumentException($"The value of {nameof(smallerBitNumber)} must be less than or equal to {nameof(largeBitNumber)}");
            }

            int offset = maxBitPosition - 1 - largeBitNumber + smallerBitNumber;

            int maskNumberIn = (int.MaxValue >> offset) << smallerBitNumber;
            int maskNumberSource = ~maskNumberIn;

            numberSource = numberSource & maskNumberSource;
            numberIn = (numberIn << smallerBitNumber) & maskNumberIn;

            int resullt = numberSource | numberIn;

            return resullt;            
        }
    }
}
