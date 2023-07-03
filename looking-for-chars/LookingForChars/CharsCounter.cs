using System;

namespace LookingForChars
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
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            int charsCount = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (chars[i] == str[j])
                    {
                        charsCount++;
                    }
                }
            }

            return charsCount;
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

            int charsCount = 0;
            int i = 0;
            while (i < chars.Length)
            {
                int j = startIndex;
                while (j < endIndex + 1)
                {
                    if (chars[i] == str[j])
                    {
                        charsCount++;
                    }

                    j++;
                }

                i++;
            }

            return charsCount;
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

            int charsCount = 0;
            int i = 0;

            do
            {
                int j = startIndex;
                do
                {
                    if (chars[i] == str[j])
                    {
                        charsCount++;
                        if (charsCount == limit)
                        {
                            return charsCount;
                        }
                    }

                    j++;
                }
                while (j < endIndex + 1);

                i++;
            }
            while (i < chars.Length);

            return charsCount;
        }
    }
}
