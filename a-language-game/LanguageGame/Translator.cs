using System;
using System.Globalization;
using System.Text;

namespace LanguageGame
{
    public static class Translator
    {
        /// <summary>
        /// Translates from English to Pig Latin. Pig Latin obeys a few simple following rules:
        /// - if word starts with vowel sounds, the vowel is left alone, and most commonly 'yay' is added to the end;
        /// - if word starts with consonant sounds or consonant clusters, all letters before the initial vowel are
        ///   placed at the end of the word sequence. Then, "ay" is added.
        /// Note: If a word begins with a capital letter, then its translation also begins with a capital letter,
        /// if it starts with a lowercase letter, then its translation will also begin with a lowercase letter.
        /// </summary>
        /// <param name="phrase">Source phrase.</param>
        /// <returns>Phrase in Pig Latin.</returns>
        /// <exception cref="ArgumentException">Thrown if phrase is null or empty.</exception>
        /// <example>
        /// "apple" -> "appleyay"
        /// "Eat" -> "Eatyay"
        /// "explain" -> "explainyay"
        /// "Smile" -> "Ilesmay"
        /// "Glove" -> "Oveglay".
        /// </example>
        public static string TranslateToPigLatin(string phrase)
        {
            if (string.IsNullOrEmpty(phrase) || string.IsNullOrWhiteSpace(phrase))
            {
                throw new ArgumentException("Phrase was null or empty", nameof(phrase));
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < phrase.Length; i++)
            {
                if (char.IsLetter(phrase, i))
                {
                    int start = i;
                    int end = i;

                    while (end < phrase.Length && (char.IsLetter(phrase, end) || phrase[end] == '’'))
                    {
                        end++;
                    }

                    if (end == phrase.Length)
                    {
                        i = end;
                        sb.Append(TranslateWord(phrase[start..]));
                    }
                    else
                    {
                        i = end - 1;
                        sb.Append(TranslateWord(phrase[start..end]));
                    }
                }
                else
                {
                    sb.Append(phrase[i]);
                }
            }

            return sb.ToString();
        }

        private static string TranslateWord(string word)
        {
            char[] vowels = new char[] { 'a', 'o', 'e', 'i', 'u', 'A', 'O', 'E', 'I', 'U' };
            int indexOfVowel = word.IndexOfAny(vowels);
            StringBuilder sb = new StringBuilder();

            if (indexOfVowel == 0)
            {
                word += "yay";
            }
            else if (indexOfVowel == -1)
            {
                word += "ay";
            }
            else
            {
                if (!char.IsUpper(word, 0))
                {
                    sb.Append(word[indexOfVowel..]);
                    sb.Append(word[..indexOfVowel].ToLower(CultureInfo.CurrentCulture)); // CultureInfo.CurrentCulture is used to suppress CA1308
                    sb.Append("ay");

                    word = sb.ToString();
                }
                else
                {
                    sb.Append(char.ToUpper(word[indexOfVowel], CultureInfo.InvariantCulture));
                    sb.Append(word[(indexOfVowel + 1) ..]);
                    sb.Append(word[..indexOfVowel].ToLower(CultureInfo.CurrentCulture)); // CultureInfo.CurrentCulture is used to suppress CA1308
                    sb.Append("ay");

                    word = sb.ToString();
                }
            }
            
            return word;
        }
    }
}
