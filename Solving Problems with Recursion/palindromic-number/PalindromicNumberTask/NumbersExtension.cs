using System;

namespace PalindromicNumberTask
{
    /// <summary>
    /// Provides static method for working with integers.
    /// </summary>
    public static class NumbersExtension
    {
        /// <summary>
        /// Determines if a number is a palindromic number, see https://en.wikipedia.org/wiki/Palindromic_number.
        /// </summary>
        /// <param name="number">Verified number.</param>
        /// <returns>true if the verified number is palindromic number; otherwise, false.</returns>
        /// <exception cref="ArgumentException"> Thrown when source number is less than zero. </exception>
        public static bool IsPalindromicNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Source number was less than zero", nameof(number));
            }

            if (number < 10 && number > 0)
            {
                return true;
            }

            int palindromic = GetPalindrome(number, 0);

            static int GetPalindrome(int number, int sum)
            {
                if (number > 0)
                {
                    sum *= 10;
                    sum += number % 10;
                    return GetPalindrome(number / 10, sum);
                }
                else
                {
                    return sum;
                }
            }

            return palindromic == number;
        }
    }
}
