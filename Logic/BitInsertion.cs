using System;
using System.Collections;

namespace Logic
{
    /// <summary>
    /// Represents a class that works with integer numbers and performs the inserting bits from one number to another.
    /// </summary>
    public static class BitInsertion
    {
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
            if (smallerBitNumber < 0 || smallerBitNumber > 31)
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(smallerBitNumber)} must be in range between 0 - 31.");
            }

            if (largeBitNumber < 0 || largeBitNumber > 31)
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(largeBitNumber)} must be in range between 0 - 31.");
            }

            if (smallerBitNumber > largeBitNumber)
            {
                throw new ArgumentException($"The value of {nameof(smallerBitNumber)} must be less than or equal to {nameof(largeBitNumber)}");
            }

            numberIn = numberIn << smallerBitNumber;

            byte[] original = BitConverter.GetBytes(numberSource);
            byte[] insert = BitConverter.GetBytes(numberIn);

            BitArray originalBits = new BitArray(original);
            BitArray insertBits = new BitArray(insert);

            for (int i = smallerBitNumber; i <= largeBitNumber; i++)
            {
                originalBits[i] = insertBits[i];
            }

            int[] outNumber = new int[1];
            originalBits.CopyTo(outNumber, 0);

            return outNumber[0];
        }
    }
}
