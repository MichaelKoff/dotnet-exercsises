using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace BubbleSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with bubble sort algorithm.
        /// </summary>
        public static void BubbleSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            bool needIteration = true;

            while (needIteration)
            {
                needIteration = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        needIteration = true;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive bubble sort algorithm.
        /// </summary>
        public static void RecursiveBubbleSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0 || array.Length == 1)
            {
                return;
            }

            bool needIteration = Iterate(array, 0, false);

            if (!needIteration)
            {
                return;
            }

            RecursiveBubbleSort(array);
        }

        private static bool Iterate(int[] array, int index, bool needIteration)
        {
            if (array[index] > array[index + 1])
            {
                (array[index], array[index + 1]) = (array[index + 1], array[index]);
                needIteration = true;
            }

            if (index + 1 < array.Length - 1)
            {
                return Iterate(array, index + 1, needIteration);
            }

            return needIteration;
        }
    }
}
