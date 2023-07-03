using System;
using System.Globalization;
using System.Text;

namespace TransformerToWords
{
    /// <summary>
    /// Implements transformer class.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transforms each element of source array into its 'word format'.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of 'word format' of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <example>
        /// new[] { 2.345, -0.0d, 0.0d, 0.1d } => { "Two point three four five", "Minus zero", "Zero", "Zero point one" }.
        /// </example>
        public string[] Transform(double[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Source array was empty");
            }

            string[] numbersAsWords = new string[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                numbersAsWords[i] = TransformToWords(source[i]);
            }

            return numbersAsWords;
        }

        private static string TransformToWords(double number)
        {
            if (double.IsNaN(number))
            {
                return "Not a Number";
            }
            else if (double.IsNegativeInfinity(number))
            {
                return "Negative Infinity";
            }
            else if (double.IsPositiveInfinity(number))
            {
                return "Positive Infinity";
            }
            else if (number == double.Epsilon)
            {
                return "Double Epsilon";
            }

            string numberString = number.ToString(CultureInfo.InvariantCulture);
            char[] numberChar = numberString.ToCharArray();
            StringBuilder result = new StringBuilder();

            foreach (var item in numberChar)
            {
                switch (item)
                {
                    case '-':
                        result.Append("Minus ");
                        break;
                    case '+':
                        result.Append("plus ");
                        break;
                    case 'E':
                        result.Append("E ");
                        break;
                    case '0':
                        result.Append("zero ");
                        break;
                    case '.':
                        result.Append("point ");
                        break;
                    case '1':
                        result.Append("one ");
                        break;
                    case '2':
                        result.Append("two ");
                        break;
                    case '3':
                        result.Append("three ");
                        break;
                    case '4':
                        result.Append("four ");
                        break;
                    case '5':
                        result.Append("five ");
                        break;
                    case '6':
                        result.Append("six ");
                        break;
                    case '7':
                        result.Append("seven ");
                        break;
                    case '8':
                        result.Append("eight ");
                        break;
                    case '9':
                        result.Append("nine ");
                        break;
                    default:
                        result.Append(item);
                        break;
                }
            }

            string resultString = result.ToString().TrimEnd();

            return char.ToUpper(resultString[0], CultureInfo.InvariantCulture).ToString() + resultString[1..];
        }
    }
}
