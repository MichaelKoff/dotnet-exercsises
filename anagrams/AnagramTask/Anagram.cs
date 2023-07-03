using System;
using System.Collections.Generic;

namespace AnagramTask
{
    public class Anagram
    {
        private string word;

        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class.
        /// </summary>
        /// <param name="sourceWord">Source word.</param>
        /// <exception cref="ArgumentNullException">Thrown when source word is null.</exception>
        /// <exception cref="ArgumentException">Thrown when  source word is empty.</exception>
        public Anagram(string sourceWord)
        {
            this.Word = sourceWord;
        }

        public string Word
        {
            get
            {
                return this.word;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value.Length == 0)
                {
                    throw new ArgumentException("Source word was empty", nameof(value));
                }

                this.word = value;
            }
        }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns>
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[] candidates)
        {
            if (candidates is null)
            {
                throw new ArgumentNullException(nameof(candidates));
            }

            List<string> result = new List<string>();
            bool isAnagramOfItself = true;

            for (int i = 0; i < candidates.Length; i++)
            {
                if (this.Word.ToUpperInvariant() != candidates[i].ToUpperInvariant())
                {
                    isAnagramOfItself = false;
                    break;
                }
            }

            if (isAnagramOfItself)
            {
                return result.ToArray();
            }

            char[] sourceWord = this.Word.ToUpperInvariant().ToCharArray();
            Array.Sort(sourceWord);

            char[][] candidatesAsChars = new char[candidates.Length][];
            
            for (int i = 0; i < candidates.Length; i++)
            {
                candidatesAsChars[i] = candidates[i].ToUpperInvariant().ToCharArray();
                Array.Sort(candidatesAsChars[i]);
                
                if (sourceWord.Length == candidatesAsChars[i].Length)
                {
                    bool hasSameLetters = true;
                    for (int j = 0; j < sourceWord.Length; j++)
                    {
                        if (sourceWord[j] != candidatesAsChars[i][j])
                        {
                            hasSameLetters = false;
                            break;
                        }
                    }

                    if (hasSameLetters)
                    {
                        result.Add(candidates[i]);
                    }
                }
            }
            
            return result.ToArray();
        }
    }
}
