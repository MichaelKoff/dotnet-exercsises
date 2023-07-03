using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace QuickSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with quick sort algorithm.
        /// </summary>
        public static void QuickSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length <= 1)
            {
                return;
            }

            int[] stack = new int[array.Length];
            int left = 0;
            int right = array.Length - 1;
            int top = -1;

            stack[++top] = left;
            stack[++top] = right;

            while (top > 0)
            {
                right = stack[top--];
                left = stack[top--];

                int key = array[right];
                int i = left - 1;

                for (int j = left; j < right; j++)
                {
                    if (array[j] <= key)
                    {
                        i++;
                        (array[i], array[j]) = (array[j], array[i]);
                    }
                }

                (array[i + 1], array[right]) = (array[right], array[i + 1]);
                int keyIndex = i + 1;

                if (keyIndex - 1 > left)
                {
                    stack[++top] = left;
                    stack[++top] = keyIndex - 1;
                }

                if (keyIndex + 1 < right)
                {
                    stack[++top] = keyIndex + 1;
                    stack[++top] = right;
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive quick sort algorithm.
        /// </summary>
        public static void RecursiveQuickSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length <= 1)
            {
                return;
            }

            RecursiveQuickSort(array, 0, array.Length - 1);
        }

        private static void RecursiveQuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int keyIndex = PartitionRecursive(array, left, right, left - 1);
                RecursiveQuickSort(array, left, keyIndex - 1);
                RecursiveQuickSort(array, keyIndex + 1, right);
            }
        }

        private static int PartitionRecursive(int[] array, int left, int right, int i)
        {
            int key = array[right];

            if (array[left] <= key)
            {
                i++;
                (array[i], array[left]) = (array[left], array[i]);
            }

            if (left + 1 < right)
            {
                return PartitionRecursive(array, left + 1, right,  i);
            }
            else
            {
                (array[i + 1], array[right]) = (array[right], array[i + 1]);
                return i + 1;
            }
        }
    }
}
