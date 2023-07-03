using System;

namespace FindBalanceElementTask
{
    /// <summary>
    /// Class for operations with arrays.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Finds an index of element in an integer array for which the sum of the elements
        /// on the left and the sum of the elements on the right are equal.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <returns>The index of the balance element, if it exists, and null otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when source array is empty.</exception>
        public static int? FindBalanceElement(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array was empty", nameof(array));
            }

            if (array.Length < 3)
            {
                return null;
            }

            long sumToLeft = 0;
            long sumToRight = 0;

            for (int i = 1; i < array.Length; i++)
            {
                foreach (int element in array[0..i])
                {
                    sumToLeft += element;
                }

                foreach (int element in array[(i + 1) ..])
                {
                    sumToRight += element;
                }

                if (sumToLeft == sumToRight)
                {
                    return i;
                }

                sumToLeft = 0;
                sumToRight = 0;
            }

            return null;
        }
    }
}
