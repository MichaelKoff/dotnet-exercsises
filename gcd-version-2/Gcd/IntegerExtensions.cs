using System;

namespace Gcd
{
    /// <summary>
    /// Provide methods with integers.
    /// </summary>
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
        public static int GetGcdByEuclidean(int a, int b)
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

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException($"All arguments are 0");
            }

            if (a == 0 && b == 0)
            {
                return GetGcdByEuclidean(b, c);
            }

            return GetGcdByEuclidean(GetGcdByEuclidean(a, b), c);
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, params int[] other)
        {
            int[] numberArray = new int[other.Length + 2];
            numberArray[0] = a;
            numberArray[1] = b;
            for (int i = 2; i < numberArray.Length; i++)
            {
                numberArray[i] = other[i - 2];
            }

            bool allAreZeroes = true;
            bool hasIntMinValue = false;

            for (int i = 0; i < numberArray.Length; i++)
            {
                if (numberArray[i] != 0)
                {
                    allAreZeroes = false;
                }

                if (numberArray[i] == int.MinValue)
                {
                    hasIntMinValue = true;
                }
            }

            if (allAreZeroes)
            {
                throw new ArgumentException("All numbers are 0 at the same time");
            }

            if (hasIntMinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(other), "One or more numbers is Int.MinValue");
            }

            int gcd = 0;
            for (int i = 1; i < numberArray.Length; i++)
            {
                if (numberArray[i] == 0 && numberArray[i - 1] == 0)
                {
                    continue;
                }

                gcd = GetGcdByEuclidean(numberArray[i], numberArray[i - 1]);
                break;
            }

            foreach (int number in numberArray)
            {
                gcd = GetGcdByEuclidean(gcd, number);
            }

            return gcd;
        }

        /// <summary>
        /// Calculates GCD of two integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b)
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

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            int shift = 0;
            while (a % 2 == 0 && b % 2 == 0)
            {
                a /= 2;
                b /= 2;
                shift++;
            }

            while (a != b)
            {
                while (a % 2 == 0)
                {
                    a /= 2;
                }

                while (b % 2 == 0)
                {
                    b /= 2;
                }

                if (a < b)
                {
                    b -= a;
                }

                if (b < a)
                {
                    a -= b;
                }
            }

            return a << shift;
        }

        /// <summary>
        /// Calculates GCD of three integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException($"All arguments are 0");
            }

            if (a == 0 && b == 0)
            {
                return GetGcdByStein(b, c);
            }

            return GetGcdByStein(GetGcdByStein(a, b), c);
        }

        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, params int[] other)
        {
            int[] numberArray = new int[other.Length + 2];
            numberArray[0] = a;
            numberArray[1] = b;
            for (int i = 2; i < numberArray.Length; i++)
            {
                numberArray[i] = other[i - 2];
            }

            bool allAreZeroes = true;
            bool hasIntMinValue = false;

            for (int i = 0; i < numberArray.Length; i++)
            {
                if (numberArray[i] != 0)
                {
                    allAreZeroes = false;
                }

                if (numberArray[i] == int.MinValue)
                {
                    hasIntMinValue = true;
                }
            }

            if (allAreZeroes)
            {
                throw new ArgumentException("All numbers are 0 at the same time");
            }

            if (hasIntMinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(other), "One or more numbers is Int.MinValue");
            }

            int gcd = 0;
            for (int i = 1; i < numberArray.Length; i++)
            {
                if (numberArray[i] == 0 && numberArray[i - 1] == 0)
                {
                    continue;
                }

                gcd = GetGcdByStein(numberArray[i], numberArray[i - 1]);
                break;
            }

            foreach (int number in numberArray)
            {
                gcd = GetGcdByStein(gcd, number);
            }

            return gcd;
        }
        
        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b)
        {
            System.Diagnostics.Stopwatch measure = new System.Diagnostics.Stopwatch();

            measure.Start();
            int result = GetGcdByEuclidean(a, b);
            measure.Stop();

            elapsedTicks = measure.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, int c)
        {
            System.Diagnostics.Stopwatch measure = new System.Diagnostics.Stopwatch();

            measure.Start();
            int result = GetGcdByEuclidean(a, b, c);
            measure.Stop();

            elapsedTicks = measure.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, params int[] other)
        {
            System.Diagnostics.Stopwatch measure = new System.Diagnostics.Stopwatch();

            measure.Start();
            int result = GetGcdByEuclidean(a, b, other);
            measure.Stop();

            elapsedTicks = measure.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b)
        {
            System.Diagnostics.Stopwatch measure = new System.Diagnostics.Stopwatch();

            measure.Start();
            int result = GetGcdByStein(a, b);
            measure.Stop();

            elapsedTicks = measure.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, int c)
        {
            System.Diagnostics.Stopwatch measure = new System.Diagnostics.Stopwatch();

            measure.Start();
            int result = GetGcdByStein(a, b, c);
            measure.Stop();

            elapsedTicks = measure.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, params int[] other)
        {
            System.Diagnostics.Stopwatch measure = new System.Diagnostics.Stopwatch();

            measure.Start();
            int result = GetGcdByStein(a, b, other);
            measure.Stop();

            elapsedTicks = measure.ElapsedMilliseconds;
            return result;
        }
    }
}
