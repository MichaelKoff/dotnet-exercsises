using System;
using System.Text;

namespace ShuffleCharacters
{
    public static class StringExtension
    {
        /// <summary>
        /// Shuffles characters in source string according some rule.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="count">The count of iterations.</param>
        /// <returns>Result string.</returns>
        /// <exception cref="ArgumentException">Source string is null or empty or white spaces.</exception>
        /// <exception cref="ArgumentException">Count of iterations is less than 0.</exception>
        public static string ShuffleChars(string source, int count)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException($"{nameof(source)} was null or empty or whitespace");
            }

            if (count < 0)
            {
                throw new ArgumentException($"Count of iterations was less than 0");
            }

            StringBuilder sbEven = new StringBuilder();
            StringBuilder sbOdd = new StringBuilder();
            StringBuilder sbSource = new StringBuilder(source);
            StringBuilder originalString = new StringBuilder(source);
            for (int i = 1; i <= count; i++)
            {
                for (int j = 0; j < sbSource.Length; j++)
                {
                    if ((j + 1) % 2 == 0)
                    {
                        sbEven.Append(sbSource[j]);
                    }
                    else if ((j + 1) % 2 != 0)
                    {
                        sbOdd.Append(sbSource[j]);
                    }
                }

                sbSource = sbSource.Clear().Append(sbOdd).Append(sbEven);
                sbOdd.Clear();
                sbEven.Clear();

                if (sbSource.Equals(originalString))
                {
                    count %= i;
                    i = 0;
                }
            }

            return sbSource.ToString();
        }
    }
}
