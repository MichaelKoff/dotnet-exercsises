using System;

namespace RotateMatrix
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Rotates the image clockwise by 90° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate90DegreesClockwise(this int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - i; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[size - 1 - j, size - 1 - i];
                    matrix[size - 1 - j, size - 1 - i] = temp;
                }
            }

            for (int i = 0; i < size / 2; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[size - 1 - i, j];
                    matrix[size - 1 - i, j] = temp;
                }
            }
        }

        /// <summary>
        /// Rotates the image counterclockwise by 90° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate90DegreesCounterClockwise(this int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int size = matrix.GetLength(0);

            for (int i = 0; i < size / 2; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[size - 1 - i, j];
                    matrix[size - 1 - i, j] = temp;
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - i; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[size - 1 - j, size - 1 - i];
                    matrix[size - 1 - j, size - 1 - i] = temp;
                }
            }
        }

        /// <summary>
        /// Rotates the image clockwise by 180° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate180DegreesClockwise(this int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int size = matrix.GetLength(0);

            if (size % 2 != 0)
            {
                for (int i = 0; i < size / 2; i++)
                {
                    int temp = matrix[size / 2, i];
                    matrix[size / 2, i] = matrix[size / 2, size - 1 - i];
                    matrix[size / 2, size - 1 - i] = temp;
                }
            }

            for (int i = 0; i <= (size / 2) - 1; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[size - 1 - i, size - 1 - j];
                    matrix[size - 1 - i, size - 1 - j] = temp;
                }
            }
        }

        /// <summary>
        /// Rotates the image counterclockwise by 180° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate180DegreesCounterClockwise(this int[,] matrix)
        {
            Rotate180DegreesClockwise(matrix);
        }

        /// <summary>
        /// Rotates the image clockwise by 270° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate270DegreesClockwise(this int[,] matrix)
        {
            Rotate90DegreesCounterClockwise(matrix);
        }

        /// <summary>
        /// Rotates the image counterclockwise by 270° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate270DegreesCounterClockwise(this int[,] matrix)
        {
            Rotate90DegreesClockwise(matrix);
        }

        /// <summary>
        /// Rotates the image clockwise by 360° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate360DegreesClockwise(this int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
        }

        /// <summary>
        /// Rotates the image counterclockwise by 360° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate360DegreesCounterClockwise(this int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
        }
    }
}
