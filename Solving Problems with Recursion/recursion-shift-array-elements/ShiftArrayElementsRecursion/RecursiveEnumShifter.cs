﻿using System;

namespace ShiftArrayElements
{
    public static class RecursiveEnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[] source, Direction[] directions)
        {
            // TODO #1. Implement the method using recursive local functions and Array.Copy method.
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (directions is null)
            {
                throw new ArgumentNullException(nameof(directions));
            }

            if (directions.Length == 0)
            {
                return source;
            }

            Shift(source, directions, 0);

            static void Shift(int[] source, Direction[] directions, int index)
            {
                if (directions[index] == Direction.Right)
                {
                    int temp = source[^1];
                    Array.Copy(source, 0, source, 1, source.Length - 1);
                    source[0] = temp;
                }
                else if (directions[index] == Direction.Left)
                {
                    int temp = source[0];
                    Array.Copy(source, 1, source, 0, source.Length - 1);
                    source[^1] = temp;
                }
                else
                {
                    throw new InvalidOperationException($"Incorrect {directions[index]} enum value.");
                }

                if (index + 1 < directions.Length)
                {
                    Shift(source, directions, index + 1);
                }
            }

            return source;
        }
    }
}
