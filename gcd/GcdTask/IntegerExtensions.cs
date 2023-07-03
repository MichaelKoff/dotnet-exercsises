using System;

namespace GcdTask
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int FindGcd(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException($"{nameof(a)} and {nameof(b)} are 0");
            }

            if (a == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(a), "One of arguments equals int.MinValue");
            }

            if (b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(b), "One of arguments equals int.MinValue");
            }

            if (a < 0)
            {
                a *= -1;
            }

            if (b < 0)
            {
                b *= -1;
            }

            if (a == b)
            {
                return a;
            }
            else if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }
    }
}
