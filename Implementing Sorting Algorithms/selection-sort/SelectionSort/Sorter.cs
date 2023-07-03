using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace SelectionSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with selection sort algorithm.
        /// </summary>
        public static void SelectionSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                (array[min], array[i]) = (array[i], array[min]);
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive selection sort algorithm.
        /// </summary>
        public static void RecursiveSelectionSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                return;
            }

            RecursiveSelectionSort(array, 0);
        }

        private static void RecursiveSelectionSort(int[] array, int index)
        {
            int min = FindIndexOfMinimum(array, index, index + 1);

            (array[min], array[index]) = (array[index], array[min]);

            if (index + 1 < array.Length)
            {
                RecursiveSelectionSort(array, index + 1);
            }
        }

        private static int FindIndexOfMinimum(int[] array, int index, int search)
        {
            if (search >= array.Length)
            {
                return index;
            }

            if (array[search] < array[index])
            {
                index = search;
            }

            return FindIndexOfMinimum(array, index, search + 1);
        }
    }
}
