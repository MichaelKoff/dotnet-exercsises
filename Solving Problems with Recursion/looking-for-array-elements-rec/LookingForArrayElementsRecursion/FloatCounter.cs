using System;

namespace LookingForArrayElementsRecursion
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            // #3. Implement the method using recursion.
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            ValidateRanges(rangeStart, rangeEnd, 0);

            if (arrayToSearch.Length == 0 || rangeStart.Length == 0)
            {
                return 0;
            }

            int elementsInRanges = CountAllOccurencies(arrayToSearch, rangeStart, rangeEnd, 0, 0);

            int CountAllOccurencies(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int index, int occurencies)
            {
                occurencies = CountOccurencies(arrayToSearch[index], rangeStart, rangeEnd, 0, occurencies);

                if (index + 1 < arrayToSearch.Length)
                {
                    occurencies = CountAllOccurencies(arrayToSearch, rangeStart, rangeEnd, index + 1, occurencies);
                }

                return occurencies;
            }

            int CountOccurencies(float arrayElement, float[] rangeStart, float[] rangeEnd, int index, int occurencies)
            {
                if (arrayElement >= rangeStart[index] && arrayElement <= rangeEnd[index])
                {
                    occurencies++;
                }

                if (index + 1 < rangeStart.Length)
                {
                    occurencies = CountOccurencies(arrayElement, rangeStart, rangeEnd, index + 1, occurencies);
                }

                return occurencies;
            }

            return elementsInRanges;
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            // #4. Implement the method using recursion.
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            ValidateRanges(rangeStart, rangeEnd, 0);

            if (startIndex < 0 || startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index is out of boundaries of arrayToSearch");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count is less than zero");
            }

            if (count + startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count is out of arrayToSearch boundaries");
            }

            if (arrayToSearch.Length == 0 || rangeStart.Length == 0)
            {
                return 0;
            }

            int elementsInRanges = CountAllOccurencies(arrayToSearch, rangeStart, rangeEnd, startIndex, 0);

            int CountAllOccurencies(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int index, int occurencies)
            {
                occurencies = CountOccurencies(arrayToSearch[index], rangeStart, rangeEnd, 0, occurencies);

                if (index + 1 < startIndex + count)
                {
                    occurencies = CountAllOccurencies(arrayToSearch, rangeStart, rangeEnd, index + 1, occurencies);
                }

                return occurencies;
            }

            int CountOccurencies(float arrayElement, float[] rangeStart, float[] rangeEnd, int index, int occurencies)
            {
                if (arrayElement >= rangeStart[index] && arrayElement <= rangeEnd[index])
                {
                    occurencies++;
                }

                if (index + 1 < rangeStart.Length)
                {
                    occurencies = CountOccurencies(arrayElement, rangeStart, rangeEnd, index + 1, occurencies);
                }

                return occurencies;
            }

            return elementsInRanges;
        }

        private static void ValidateRanges(float[] rangeStart, float[] rangeEnd, int index)
        {
            if (rangeStart == null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException($"{nameof(rangeStart)} and {nameof(rangeEnd)} have unequal lengths");
            }

            if (rangeStart.Length == 0)
            {
                return;
            }

            if (rangeStart[index] > rangeEnd[index])
            {
                throw new ArgumentException($"{nameof(rangeStart)} contains values greater than in {nameof(rangeEnd)}");
            }

            if (index + 1 < rangeStart.Length)
            {
                ValidateRanges(rangeStart, rangeEnd, index + 1);
            }
        }
    }
}
