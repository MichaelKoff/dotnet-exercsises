using System;

namespace ShiftArrayElements
{
    public static class RecursiveShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (odd elements - left direction, even elements - right direction).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            // #2. Implement the method using recursive local functions and indexers only (don't use Array.Copy method here).
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (iterations is null)
            {
                throw new ArgumentNullException(nameof(iterations));
            }

            if (source.Length <= 1)
            {
                return source;
            }

            if (iterations.Length == 0)
            {
                return source;
            }

            Iterate(source, iterations, 0);

            static void Iterate(int[] source, int[] iterations, int index)
            {
                Shift(source, iterations, index, 1);

                if (index + 1 < iterations.Length)
                {
                    Iterate(source, iterations, index + 1);
                }
            }

            static void Shift(int[] source, int[] iterations, int index, int shiftIndex)
            {
                if (iterations[index] == 0)
                {
                    return;
                }

                if (index % 2 != 0 && index != 0)
                {
                    int temp = source[^1];
                    ShiftRight(source, source.Length - 1);
                    source[0] = temp;
                }
                else if (index % 2 == 0 || index == 0)
                {
                    int temp = source[0];
                    ShiftLeft(source, 1);
                    source[^1] = temp;
                }

                if (shiftIndex + 1 <= iterations[index])
                {
                    Shift(source, iterations, index, shiftIndex + 1);
                }

                static void ShiftLeft(int[] source, int index)
                {
                    source[index - 1] = source[index];

                    if (index + 1 < source.Length)
                    {
                        ShiftLeft(source, index + 1);
                    }
                }

                static void ShiftRight(int[] source, int index)
                {
                    source[index] = source[index - 1];

                    if (index - 1 > 0)
                    {
                        ShiftRight(source, index - 1);
                    }
                }
            }

            return source;
       }
    }
}
