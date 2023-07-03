using System;

namespace LookingForCharsRecursion
{
    public static class CharsCounter
    {
        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <returns>The number of occurrences of all characters.</returns>
        public static int GetCharsCount(string str, char[] chars)
        {
            // #1. Implement the method using recursive algorithm.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int count = CountAll(str, chars, 0, 0);

            int CountAll(string str, char[] chars, int count, int index)
            {
                count = CountSingle(str, chars[index], count, 0);

                if (index + 1 < chars.Length)
                {
                    return CountAll(str, chars, count, index + 1);
                }

                return count;
            }

            int CountSingle(string str, char ch, int count, int index)
            {
                if (str[index] == ch)
                {
                    count++;
                }

                if (index + 1 < str.Length)
                {
                    count = CountSingle(str, ch, count, index + 1);
                }

                return count;
            }

            return count;
        }

        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <returns>The number of occurrences of all characters within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex)
        {
            // #2. Implement the method using recursive algorithm.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than str.Length");
            }

            if (endIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "endIndex is greater than str.Length");
            }

            if (endIndex <= startIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "endIndex is less than startIndex");
            }

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int count = CountAll(str, chars, 0, 0);

            int CountAll(string str, char[] chars, int count, int index)
            {
                count = CountSingle(str, chars[index], count, startIndex);

                if (index + 1 < chars.Length)
                {
                    count = CountAll(str, chars, count, index + 1);
                }

                return count;
            }

            int CountSingle(string str, char ch, int count, int index)
            {
                if (str[index] == ch)
                {
                    count++;
                }

                if (index + 1 < endIndex + 1)
                {
                    count = CountSingle(str, ch, count, index + 1);
                }

                return count;
            }

            return count;
        }

        /// <summary>
        /// Searches a string for a limited number of characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <param name="limit">A maximum number of characters to search.</param>
        /// <returns>The limited number of occurrences of characters to search for within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex, int limit)
        {
            // #3. Implement the method using recursive algorithm.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than str.Length");
            }

            if (endIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "endIndex is greater than str.Length");
            }

            if (endIndex <= startIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "endIndex is less than startIndex");
            }

            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int count = CountAll(str, chars, 0, 0);

            int CountAll(string str, char[] chars, int count, int index)
            {
                count = CountSingle(str, chars[index], count, startIndex);

                if (index + 1 < chars.Length && count < limit)
                {
                    count = CountAll(str, chars, count, index + 1);
                }

                return count;
            }

            int CountSingle(string str, char ch, int count, int index)
            {
                if (str[index] == ch)
                {
                    count++;

                    if (count == limit)
                    {
                        return count;
                    }
                }

                if (index + 1 < endIndex + 1)
                {
                    count = CountSingle(str, ch, count, index + 1);
                }

                return count;
            }

            return count;
        }
    }
}
