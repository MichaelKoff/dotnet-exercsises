﻿using System;
using System.Globalization;
using System.Text;

#pragma warning disable CA1822

namespace TransformToWordsTask
{
    /// <summary>
    /// Provides transformer methods.
    /// </summary>
    public sealed class Transformer
    {
        /// <summary>
        /// Converts number's digital representation into words.
        /// </summary>
        /// <param name="number">Number to convert.</param>
        /// <returns>Words representation.</returns>
        public string TransformToWords(double number)
        {
            if (double.IsNaN(number))
            {
                return "NaN";
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
