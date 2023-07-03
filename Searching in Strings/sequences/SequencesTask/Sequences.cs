using System;

namespace SequencesTask
{
    public static class Sequences
    {
        /// <summary>
        /// Find all the contiguous substrings of length length in given string of digits in the order that they appear.
        /// </summary>
        /// <param name="numbers">Source string.</param>
        /// <param name="length">Length of substring.</param>
        /// <returns>All the contiguous substrings of length n in that string in the order that they appear.</returns>
        /// <exception cref="ArgumentException">
        /// Throw if length of substring less and equals zero
        /// -or-
        /// more than length of source string
        /// - or-
        /// source string containing a non-digit character
        /// - or
        /// source string is null or empty or white space.
        /// </exception>
        public static string[] GetSubstrings(string numbers, int length)
        {
            Validate(numbers, length);

            int substringsLength = 0;

            for (int i = 0; i + length <= numbers.Length; i++)
            {
                substringsLength++;
            }

            string[] substrings = new string[substringsLength];

            for (int i = 0; i + length <= numbers.Length; i++)
            {
                substrings[i] = numbers[i.. (length + i)];
            }

            return substrings;
        }

        private static void Validate(string numbers, int length)
        {
            if (string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers))
            {
                throw new ArgumentException("Source string was null or empty or whitespace", nameof(numbers));
            }

            bool hasNonDigits = false;

            foreach (char c in numbers)
            {
                if (c < '0' || c > '9')
                {
                    hasNonDigits = true;
                }
            }

            if (hasNonDigits)
            {
                throw new ArgumentException("Source contains non-digit characters", nameof(numbers));
            }

            if (length <= 0)
            {
                throw new ArgumentException("Length of substring was less than or equal to zero", nameof(length));
            }

            if (length > numbers.Length)
            {
                throw new ArgumentException("Length of substring was more than source string length", nameof(length));
            }
        }
    }
}
