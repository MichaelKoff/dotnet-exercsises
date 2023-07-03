using System;

namespace LookingForArrayElementsRecursion
{
    public static class IntegersCounter
    {
        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor)
        {
            // #1. Implement the method using recursion.
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor));
            }

            if (arrayToSearch.Length == 0 || elementsToSearchFor.Length == 0)
            {
                return 0;
            }

            int occurencies = CountAllOccurencies(arrayToSearch, elementsToSearchFor, 0, 0);

            int CountAllOccurencies(int[] arrayToSearch, int[] elementsToSearchFor, int occurencies, int index)
            {
                occurencies = CountOccurencies(arrayToSearch[index], elementsToSearchFor, occurencies, 0);

                if (index + 1 < arrayToSearch.Length)
                {
                    occurencies = CountAllOccurencies(arrayToSearch, elementsToSearchFor, occurencies, index + 1);
                }

                return occurencies;
            }

            int CountOccurencies(int arrayElement, int[] elementsToSearchFor, int occurencies, int index)
            {
                if (arrayElement == elementsToSearchFor[index])
                {
                    occurencies++;
                }

                if (index + 1 < elementsToSearchFor.Length)
                {
                    occurencies = CountOccurencies(arrayElement, elementsToSearchFor, occurencies, index + 1);
                }

                return occurencies;
            }

            return occurencies;
        }

        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements withing the range of elements in the <see cref="Array"/> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor, int startIndex, int count)
        {
            // #2. Implement the method using recursion.
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor));
            }

            if (startIndex < 0 || startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "StartIndex is out of array boundaries");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count is less than zero");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Can't count beyond array boundaries");
            }

            if (arrayToSearch.Length == 0 || elementsToSearchFor.Length == 0)
            {
                return 0;
            }

            int occurencies = CountAllOccurencies(arrayToSearch, elementsToSearchFor, startIndex, 0);

            int CountAllOccurencies(int[] arrayToSearch, int[] elementsToSearchFor, int index, int occurencies)
            {
                occurencies = CountOccurencies(arrayToSearch[index], elementsToSearchFor, occurencies, 0);

                if (index + 1 < startIndex + count)
                {
                    occurencies = CountAllOccurencies(arrayToSearch, elementsToSearchFor, index + 1, occurencies);
                }

                return occurencies;
            }

            int CountOccurencies(int arrayElement, int[] elementsToSearchFor, int occurencies, int index)
            {
                if (arrayElement == elementsToSearchFor[index])
                {
                    occurencies++;
                }

                if (index + 1 < elementsToSearchFor.Length)
                {
                    occurencies = CountOccurencies(arrayElement, elementsToSearchFor, occurencies, index + 1);
                }

                return occurencies;
            }

            return occurencies;
        }
    }
}
