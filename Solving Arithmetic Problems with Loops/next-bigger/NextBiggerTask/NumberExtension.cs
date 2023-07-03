using System;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Finds the nearest largest integer consisting of the digits of the given positive integer number and null if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits  of the given positive integer and null if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
        public static int? NextBiggerThan(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number is < 0", nameof(number));
            }

            if (number == int.MaxValue)
            {
                return null;
            }

            int[] numberArray = NumberToDigitArray(number);
            
            if (IsNumberValid(numberArray))
            {
                return null;
            }

            Array.Sort(numberArray);
            int nextBiggerNumber = number;

            do
            {
                nextBiggerNumber++;
                int[] nextBiggerNumberArray = NumberToDigitArray(nextBiggerNumber);
                Array.Sort(nextBiggerNumberArray);

                if (ArraysAreEqual(numberArray, nextBiggerNumberArray))
                {
                    break;
                }
            }
            while (true);
            return nextBiggerNumber;
        }

        public static int[] NumberToDigitArray(int number)
        {
            int numberLength = number switch
            {
                _ when number >= 1_000_000_000 => 10,
                _ when number >= 100_000_000 => 9,
                _ when number >= 10_000_000 => 8,
                _ when number >= 1_000_000 => 7,
                _ when number >= 100_000 => 6,
                _ when number >= 10_000 => 5,
                _ when number >= 1000 => 4,
                _ when number >= 100 => 3,
                _ when number >= 10 => 2,
                _ => 1
            };

            int[] digitArray = new int[numberLength];
            for (int i = numberLength - 1; i >= 0; i--)
            {
                digitArray[i] = number % 10;
                number /= 10;
            }

            return digitArray;
        }

        public static bool IsNumberValid(int[] digits)
        {
            if (digits == null)
            {
                throw new ArgumentNullException(nameof(digits));
            }

            if (digits.Length == 1)
            {
                return true;
            }

            for (int i = 1; i < digits.Length; i++)
            {
                if (digits[i - 1] < digits[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ArraysAreEqual(int[] firstArray, int[] secondArray)
        {
            if (firstArray?.Length != secondArray?.Length)
            {
                return false;
            }

            for (int i = 0; i < firstArray?.Length; i++)
            {
                if (firstArray[i] != secondArray?[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
