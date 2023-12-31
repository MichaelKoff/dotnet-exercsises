﻿using System;
using System.Collections.Generic;

namespace SearchByPatternInText
{
    public static class Searcher
    {
        /// <summary>
        /// Searches the pattern string inside the text and collects information about all hit positions in the order they appear.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <param name="pattern">Source pattern text.</param>
        /// <param name="overlap">Flag to overlap:
        /// if overlap flag is true collect every position overlapping included,
        /// if false no overlapping is allowed (next search behind).</param>
        /// <returns>List of positions of occurrence of the pattern string in the text, if any and empty otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if text or pattern is null.</exception>
        public static int[] SearchPatternString(this string text, string pattern, bool overlap)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Source text was null", nameof(text));
            }

            if (string.IsNullOrEmpty(pattern))
            {
                throw new ArgumentException("Search pattern was null", nameof(pattern));
            }

            List<int> positions = new List<int>();

            if (overlap)
            {
                for (int i = 0; i + pattern.Length <= text.Length; i++)
                {
                    if (text[i.. (i + pattern.Length)].Contains(pattern, StringComparison.InvariantCultureIgnoreCase))
                    {
                        positions.Add(i + 1);
                    }
                }
            }
            else
            {
                for (int i = 0; i + pattern.Length <= text.Length;)
                {
                    if (text[i.. (i + pattern.Length)].Contains(pattern, StringComparison.InvariantCultureIgnoreCase))
                    {
                        positions.Add(i + 1);
                        i += pattern.Length;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return positions.ToArray();
        }
    }
}
