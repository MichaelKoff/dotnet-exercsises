using System;

#pragma warning disable S2368

namespace JaggedArrays
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingBySum(this int[][] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int[] sums = new int[source.Length];
            
            for (int i = 0; i < source.Length; i++)
            {
                int sum = 0;

                if (source[i] is null)
                {
                    sums[i] = sum;
                }
                else
                {
                    for (int j = 0; j < source[i].Length; j++)
                    {
                        sum += source[i][j];
                    }

                    sums[i] = sum;
                }
            }

            for (int i = 0; i < source.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < source.Length; j++)
                {
                    if (sums[j] < sums[min])
                    {
                        min = j;
                    }
                }

                (sums[min], sums[i]) = (sums[i], sums[min]);
                (source[min], source[i]) = (source[i], source[min]);
            }
        }
        
        /// <summary>
        /// Orders the rows in a jagged-array by descending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingBySum(this int[][] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int[] sums = new int[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                int sum = 0;

                if (source[i] is null)
                {
                    sums[i] = sum;
                }
                else
                {
                    for (int j = 0; j < source[i].Length; j++)
                    {
                        sum += source[i][j];
                    }

                    sums[i] = sum;
                }
            }

            for (int i = 0; i < source.Length - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < source.Length; j++)
                {
                    if (sums[j] > sums[max])
                    {
                        max = j;
                    }
                }

                (sums[max], sums[i]) = (sums[i], sums[max]);
                (source[max], source[i]) = (source[i], source[max]);
            }
        }
        
        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingByMax(this int[][] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int[] maxs = new int[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                int maximum = int.MinValue;

                if (source[i] is null)
                {
                    maxs[i] = maximum;
                }
                else
                {
                    for (int j = 0; j < source[i].Length; j++)
                    {
                        if (source[i][j] > maximum)
                        {
                            maximum = source[i][j];
                        }
                    }

                    maxs[i] = maximum;
                }
            }

            for (int i = 0; i < source.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < source.Length; j++)
                {
                    if (maxs[j] < maxs[min])
                    {
                        min = j;
                    }
                }

                (maxs[min], maxs[i]) = (maxs[i], maxs[min]);
                (source[min], source[i]) = (source[i], source[min]);
            }
        }
        
        /// <summary>
        /// Orders the rows in a jagged-array by descending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingByMax(this int[][] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int[] maxs = new int[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                int maximum = int.MinValue;

                if (source[i] is null)
                {
                    maxs[i] = maximum;
                }
                else
                {
                    for (int j = 0; j < source[i].Length; j++)
                    {
                        if (source[i][j] > maximum)
                        {
                            maximum = source[i][j];
                        }
                    }

                    maxs[i] = maximum;
                }
            }

            for (int i = 0; i < source.Length - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < source.Length; j++)
                {
                    if (maxs[j] > maxs[max])
                    {
                        max = j;
                    }
                }

                (maxs[max], maxs[i]) = (maxs[i], maxs[max]);
                (source[max], source[i]) = (source[i], source[max]);
            }
        }
    }
}
