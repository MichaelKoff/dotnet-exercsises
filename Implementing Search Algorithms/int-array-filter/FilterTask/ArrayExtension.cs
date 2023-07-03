using System;
using System.Collections.Generic;

namespace FilterTask
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain expected digit from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="digit">Expected digit.</param>
        /// <returns>Array of elements that contain expected digit.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit value is out of range (0..9).</exception>
        /// <example>
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7.
        /// </example>
        public static int[] FilterByDigit(int[] source, int digit)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Source array was empty", nameof(source));
            }

            if (digit > 9 || digit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(digit));
            }

            List<int> result = new List<int>();

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == digit && digit == 0)
                {
                    result.Add(source[i]);
                    continue;
                }

                int temp = source[i] > 0 ? source[i] : -source[i];

                while (temp > 0)
                {
                    int remainder = temp % 10;
                    temp /= 10;
                    if (remainder == digit)
                    {
                        result.Add(source[i]);
                        break;
                    }
                }
            }

            return result.ToArray();
        }
    }
}
