using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace InsertionSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with insertion sort algorithm.
        /// </summary>
        public static void InsertionSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (int i = 1; i < array.Length; i++)
            {
                int keyItem = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > keyItem)
                {
                    array[j + 1] = array[j];
                    j -= 1;
                }

                array[j + 1] = keyItem;
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive insertion sort algorithm.
        /// </summary>
        public static void RecursiveInsertionSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0 || array.Length == 1)
            {
                return;
            }

            RecursiveInsertionSort(array, 1);
        }

        private static void RecursiveInsertionSort(int[] array, int index)
        {
            int keyItem = array[index];

            int j = FindInsertIndex(array, keyItem, index);

            array[j] = keyItem;

            if (index + 1 < array.Length)
            {
                RecursiveInsertionSort(array, index + 1);
            }
        }

        private static int FindInsertIndex(int[] array, int keyItem, int index)
        {
            if (index - 1 >= 0 && array[index - 1] > keyItem)
            {
                array[index] = array[index - 1];
                return FindInsertIndex(array, keyItem, index - 1);
            }

            return index;
        }
    }
}
