using System;
using System.Text;

#pragma warning disable SA1625

namespace NumeralSystems
{
    /// <summary>
    /// Converts a string representations of a numbers to its integer equivalent.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Converts the string representation of a positive number in the octal numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the octal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-octal alphabetic characters).
        /// Valid octal alphabetic characters: 0,1,2,3,4,5,6,7.
        /// </exception>
        public static int ParsePositiveFromOctal(this string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 11 && (source.StartsWith("3", StringComparison.InvariantCultureIgnoreCase) || source.StartsWith("2", StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ArgumentException("Source string presents a negative number");
            }

            foreach (char c in source)
            {
                if (!(c >= '0' && c <= '7'))
                {
                    throw new ArgumentException("Source string contains invalid symbols");
                }
            }

            double result = 0;
            double digit;
            int power = source.Length - 1;
            for (int i = 0; i < source.Length; i++)
            {
                digit = source[i];
                switch (digit)
                {
                    case '0':
                        result += 0;
                        break;
                    case '1':
                        result += 1 * Math.Pow(8, power);
                        break;
                    case '2':
                        result += 2 * Math.Pow(8, power);
                        break;
                    case '3':
                        result += 3 * Math.Pow(8, power);
                        break;
                    case '4':
                        result += 4 * Math.Pow(8, power);
                        break;
                    case '5':
                        result += 5 * Math.Pow(8, power);
                        break;
                    case '6':
                        result += 6 * Math.Pow(8, power);
                        break;
                    case '7':
                        result += 7 * Math.Pow(8, power);
                        break;
                }

                power--;
            }

            return (int)result;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the decimal numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the decimal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-decimal alphabetic characters).
        /// Valid decimal alphabetic characters: 0,1,2,3,4,5,6,7,8,9.
        /// </exception>
        public static int ParsePositiveFromDecimal(this string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.StartsWith("-", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException("Source string presents a negative number");
            }

            foreach (char c in source)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    throw new ArgumentException("Source string contains invalid symbols");
                }
            }

            double result = 0;
            double digit;
            int power = source.Length - 1;
            for (int i = 0; i < source.Length; i++)
            {
                digit = source[i];
                switch (digit)
                {
                    case '0':
                        result += 0;
                        break;
                    case '1':
                        result += 1 * Math.Pow(10, power);
                        break;
                    case '2':
                        result += 2 * Math.Pow(10, power);
                        break;
                    case '3':
                        result += 3 * Math.Pow(10, power);
                        break;
                    case '4':
                        result += 4 * Math.Pow(10, power);
                        break;
                    case '5':
                        result += 5 * Math.Pow(10, power);
                        break;
                    case '6':
                        result += 6 * Math.Pow(10, power);
                        break;
                    case '7':
                        result += 7 * Math.Pow(10, power);
                        break;
                    case '8':
                        result += 8 * Math.Pow(10, power);
                        break;
                    case '9':
                        result += 9 * Math.Pow(10, power);
                        break;
                }

                power--;
            }

            return (int)result;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the hex numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-hex alphabetic characters).
        /// Valid hex alphabetic characters: 0,1,2,3,4,5,6,7,8,9,A(or a),B(or b),C(or c),D(or d),E(or e),F(or f).
        /// </exception>
        public static int ParsePositiveFromHex(this string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length >= 8 && ((source[0] >= '8' && source[0] <= '9') || (source[0] >= 'a' && source[0] <= 'f') || (source[0] >= 'A' && source[0] <= 'F')))
            {
                throw new ArgumentException("Source string presents a negative number");
            }

            foreach (char c in source)
            {
                if (!(c >= '0' && c <= '9') && !(c >= 'a' && c <= 'f') && !(c >= 'A' && c <= 'F'))
                {
                    throw new ArgumentException("Source string contains invalid symbols");
                }
            }

            double result = 0;
            double digit;
            int power = source.Length - 1;
            for (int i = 0; i < source.Length; i++)
            {
                digit = source[i];
                switch (digit)
                {
                    case '0':
                        result += 0;
                        break;
                    case '1':
                        result += 1 * Math.Pow(16, power);
                        break;
                    case '2':
                        result += 2 * Math.Pow(16, power);
                        break;
                    case '3':
                        result += 3 * Math.Pow(16, power);
                        break;
                    case '4':
                        result += 4 * Math.Pow(16, power);
                        break;
                    case '5':
                        result += 5 * Math.Pow(16, power);
                        break;
                    case '6':
                        result += 6 * Math.Pow(16, power);
                        break;
                    case '7':
                        result += 7 * Math.Pow(16, power);
                        break;
                    case '8':
                        result += 8 * Math.Pow(16, power);
                        break;
                    case '9':
                        result += 9 * Math.Pow(16, power);
                        break;
                    case 'a':
                    case 'A':
                        result += 10 * Math.Pow(16, power);
                        break;
                    case 'b':
                    case 'B':
                        result += 11 * Math.Pow(16, power);
                        break;
                    case 'c':
                    case 'C':
                        result += 12 * Math.Pow(16, power);
                        break;
                    case 'd':
                    case 'D':
                        result += 13 * Math.Pow(16, power);
                        break;
                    case 'e':
                    case 'E':
                        result += 14 * Math.Pow(16, power);
                        break;
                    case 'f':
                    case 'F':
                        result += 15 * Math.Pow(16, power);
                        break;
                }

                power--;
            }

            return (int)result;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid for given numeral system symbols
        /// -or-
        /// the radix is not equal 8, 10 or 16.
        /// </exception>
        public static int ParsePositiveByRadix(this string source, int radix)
        {
            return radix switch
            {
                8 => ParsePositiveFromOctal(source),
                10 => ParsePositiveFromDecimal(source),
                16 => ParsePositiveFromHex(source),
                _ => throw new ArgumentException("Radix was not equal to 8, 10 or 16")
            };
        }

        /// <summary>
        /// Converts the string representation of a signed number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a signed number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A signed decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source contains invalid for given numeral system symbols
        /// -or-
        /// the radix is not equal 8, 10 or 16.
        /// </exception>
        public static int ParseByRadix(this string source, int radix)
        {
            try
            {
                return radix switch
                {
                    8 => ParsePositiveFromOctal(source),
                    10 => ParsePositiveFromDecimal(source),
                    16 => ParsePositiveFromHex(source),
                    _ => throw new ArgumentException("Radix was not equal to 8, 10 or 16")
                };
            }
            catch (ArgumentException)
            {
                return radix switch
                {
                    8 => ParsePositiveFromOctal(InvertNegativeOctal(source)) * -1,
                    10 => ParsePositiveFromDecimal(source[1..]) * -1,
                    16 => ParsePositiveFromHex(InvertNegativeHex(source)) * -1,
                    _ => throw new ArgumentException("Radix was not equal to 8, 10 or 16")
                };
            }
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the octal numeral system.</param>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromOctal(this string source, out int value)
        {
            try
            {
                value = ParsePositiveFromOctal(source);
                return true;
            }
            catch (ArgumentException)
            {
                value = 0;
                return false;
            }
        }

        /// <summary>
        /// Converts the string representation of a positive number in the decimal numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the decimal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromDecimal(this string source, out int value)
        {
            try
            {
                value = ParsePositiveFromDecimal(source);
                return true;
            }
            catch (ArgumentException)
            {
                value = 0;
                return false;
            }
        }

        /// <summary>
        /// Converts the string representation of a positive number in the hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the hex numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromHex(this string source, out int value)
        {
            try
            {
                value = ParsePositiveFromHex(source);
                return true;
            }
            catch (ArgumentException)
            {
                value = 0;
                return false;
            }
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown the radix is not equal 8, 10 or 16.</exception>
        public static bool TryParsePositiveByRadix(this string source, int radix, out int value)
        {
            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix was not equal 8, 10 or 16");
            }

            try
            {
                value = ParsePositiveByRadix(source, radix);
                return true;
            }
            catch (ArgumentException)
            {
                value = 0;
                return false;
            }
        }

        /// <summary>
        /// Converts the string representation of a signed number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a signed number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown the radix is not equal 8, 10 or 16.</exception>
        public static bool TryParseByRadix(this string source, int radix, out int value)
        {
            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix was not equal 8, 10 or 16");
            }

            try
            {
                value = ParseByRadix(source, radix);
                return true;
            }
            catch (ArgumentException)
            {
                value = 0;
                return false;
            }
        }

        /// <summary>
        /// Inverts the string representation of a negative number in the hex numeral system.
        /// </summary>
        /// <example>
        /// "FFF5B198" => "000A4E68",
        /// "FFFFFFFF" => "00000001".
        /// </example>
        /// <param name="source">The string representation of a negative number in the hex numeral system.</param>
        /// <returns>A string representing inverted hexadecimal number.</returns>
        /// <exception cref="ArgumentException">
        /// contains invalid symbols (non-hex alphabetic characters).
        /// Valid hex alphabetic characters: 0,1,2,3,4,5,6,7,8,9,A(or a),B(or b),C(or c),D(or d),E(or e),F(or f).
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When source string is null or empty.
        /// </exception>
        private static string InvertNegativeHex(this string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }
            
            foreach (char c in source)
            {
                if (!(c >= '0' && c <= '9') && !(c >= 'a' && c <= 'f') && !(c >= 'A' && c <= 'F'))
                {
                    throw new ArgumentException("Source string contains invalid symbols");
                }
            }

            StringBuilder inverted = new StringBuilder();

            for (int i = 0; i < source.Length; i++)
            {
                switch (source[i])
                {
                    case '0':
                        inverted.Append('F');
                        break;
                    case '1':
                        inverted.Append('E');
                        break;
                    case '2':
                        inverted.Append('D');
                        break;
                    case '3':
                        inverted.Append('C');
                        break;
                    case '4':
                        inverted.Append('B');
                        break;
                    case '5':
                        inverted.Append('A');
                        break;
                    case '6':
                        inverted.Append('9');
                        break;
                    case '7':
                        inverted.Append('8');
                        break;
                    case '8':
                        inverted.Append('7');
                        break;
                    case '9':
                        inverted.Append('6');
                        break;
                    case 'A':
                    case 'a':
                        inverted.Append('5');
                        break;
                    case 'B':
                    case 'b':
                        inverted.Append('4');
                        break;
                    case 'C':
                    case 'c':
                        inverted.Append('3');
                        break;
                    case 'D':
                    case 'd':
                        inverted.Append('2');
                        break;
                    case 'E':
                    case 'e':
                        inverted.Append('1');
                        break;
                    case 'F':
                    case 'f':
                        inverted.Append('0');
                        break;
                    default:
                        break;
                }
            }

            inverted[^1] = (char)(inverted[^1] + 1);

            return inverted.ToString();
        }

        /// <summary>
        /// Inverts the string representation of a negative number in the octal numeral system.
        /// </summary>
        /// <example>
        /// "13546214754" => "24231563024",
        /// "17777777777" => "20000000001",
        /// "37665330632" => "00112447146".
        /// </example>
        /// <param name="source">The string representation of a negative number in the octal numeral system.</param>
        /// <returns>A string representing inverted octal number.</returns>
        /// <exception cref="ArgumentException">
        /// contains invalid symbols (non-octal alphabetic characters).
        /// Valid octal alphabetic characters: 0,1,2,3,4,5,6,7.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When source string is null or empty.
        /// </exception>
        private static string InvertNegativeOctal(this string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            foreach (char c in source)
            {
                if (!(c >= '0' && c <= '7'))
                {
                    throw new ArgumentException("Source string contains invalid symbols");
                }
            }

            StringBuilder inverted = new StringBuilder();

            for (int i = 0; i < source.Length; i++)
            {
                switch (source[i])
                {
                    case '0':
                        inverted.Append('7');
                        break;
                    case '1':
                        inverted.Append('6');
                        break;
                    case '2':
                        inverted.Append('5');
                        break;
                    case '3':
                        inverted.Append('4');
                        break;
                    case '4':
                        inverted.Append('3');
                        break;
                    case '5':
                        inverted.Append('2');
                        break;
                    case '6':
                        inverted.Append('1');
                        break;
                    case '7':
                        inverted.Append('0');
                        break;
                    default:
                        break;
                }
            }

            if (source.Length == 11 && source[0].Equals('3'))
            {
                inverted[0] = '0';
            }

            if (source.Length == 11 && source[0].Equals('1'))
            {
                inverted[0] = '2';
            }

            if (source.Length == 11 && source[0].Equals('2'))
            {
                inverted[0] = '1';
            }

            inverted[^1] = (char)(inverted[^1] + 1);

            return inverted.ToString();
        }
    }
}
