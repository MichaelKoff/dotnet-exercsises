using System;

#pragma warning disable CA1814
#pragma warning disable S2368

namespace SpiralMatrixTask
{
    /// <summary>
    /// Matrix manipulation.
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Fills the matrix with natural numbers, starting from 1 in the top-left corner, increasing in an inward, clockwise spiral order.
        /// </summary>
        /// <param name="size">Matrix size.</param>
        /// <returns>Filled matrix.</returns>
        /// <exception cref="ArgumentException">Thrown when matrix size less or equal zero.</exception>
        /// <example> size = 3
        ///     1 2 3
        ///     8 9 4
        ///     7 6 5.
        /// </example>
        /// <example> size = 4
        ///     1  2  3  4
        ///     12 13 14 5
        ///     11 16 15 6
        ///     10 9  8  7.
        /// </example>
        public static int[,] GetMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size was less or equal to zero", nameof(size));
            }

            int[,] matrix = new int[size, size];
            int x = 0, y = 0;
            int count = 1;

            do
            {
                // Traversing by columns right
                for (int i = y; i < y + size; i++)
                {
                    matrix[x, i] = count++;
                }

                // Traversing by rows down
                for (int i = x + 1; i < x + size; i++)
                {
                    matrix[i, y + size - 1] = count++;
                }

                // Traversing by columns left
                for (int i = y + size - 2; i >= y; i--)
                {
                    matrix[x + size - 1, i] = count++;
                }

                // Traversing by rows up
                for (int i = x + size - 2; i >= x + 1; i--)
                {
                    matrix[i, y] = count++;
                }

                x++;
                y++;
                size -= 2; /* As if next spiral starts in the "inside" matrix with size 2 less
                            * e.g matrix with size of 5 has matrix with size of 3 inside which 
                            * has another one with size of 1
                            */
            } 
            while (size > 0);

            return matrix;
        }
    }
}
