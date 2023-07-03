using System;

#pragma warning disable S2368

namespace LookingForArrayElementsRecursion
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges)
        {
            // #5. Implement the method using recursion.
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            ValidateRanges(ranges, 0);

            if (arrayToSearch.Length == 0 || ranges.Length == 0)
            {
                return 0;
            }

            int elementsInRanges = CountAllOccurencies(arrayToSearch, ranges, 0, 0);

            int CountAllOccurencies(decimal[] arrayToSearch, decimal[][] ranges, int index, int occurencies)
            {
                occurencies = CountOccurencies(arrayToSearch[index], ranges, 0, occurencies);

                if (index + 1 < arrayToSearch.Length)
                {
                    occurencies = CountAllOccurencies(arrayToSearch, ranges, index + 1, occurencies);
                }

                return occurencies;
            }

            int CountOccurencies(decimal arrayElement, decimal[][] ranges, int index, int occurencies)
            {
                if (ranges[index].Length != 0 && arrayElement >= ranges[index][0] && arrayElement <= ranges[index][1])
                {
                    occurencies++;

                    return occurencies;
                }
                else
                {
                    if (index + 1 < ranges.Length)
                    {
                        occurencies = CountOccurencies(arrayElement, ranges, index + 1, occurencies);
                    }
                }

                return occurencies;
            }

            return elementsInRanges;
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            // #6. Implement the method using recursion.
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            ValidateRanges(ranges, 0);

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

            if (arrayToSearch.Length == 0 || ranges.Length == 0 || count == 0)
            {
                return 0;
            }

            int elementsInRanges = CountAllOccurencies(arrayToSearch, ranges, startIndex, 0);

            int CountAllOccurencies(decimal[] arrayToSearch, decimal[][] ranges, int index, int occurencies)
            {
                occurencies = CountOccurencies(arrayToSearch[index], ranges, 0, occurencies);

                if (index + 1 < startIndex + count)
                {
                    occurencies = CountAllOccurencies(arrayToSearch, ranges, index + 1, occurencies);
                }

                return occurencies;
            }

            int CountOccurencies(decimal arrayElement, decimal[][] ranges, int index, int occurencies)
            {
                if (ranges[index].Length != 0 && arrayElement >= ranges[index][0] && arrayElement <= ranges[index][1])
                {
                    occurencies++;

                    return occurencies;
                }
                else
                {
                    if (index + 1 < ranges.Length)
                    {
                        occurencies = CountOccurencies(arrayElement, ranges, index + 1, occurencies);
                    }
                }

                return occurencies;
            }

            return elementsInRanges;
        }

        private static void ValidateRanges(decimal[][] ranges, int index)
        {
            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            if (ranges.Length == 0)
            {
                return;
            }

            if (ranges[index] == null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            if (ranges[index].Length > 2)
            {
                throw new ArgumentException($"{nameof(ranges)} contains invalid range");
            }

            if (ranges[index].Length != 0 && ranges[index][0] > ranges[index][1])
            {
                throw new ArgumentException($"{nameof(ranges)} contains invalid range");
            }

            if (index + 1 < ranges.Length)
            {
                ValidateRanges(ranges, index + 1);
            }
        }
    }
}
