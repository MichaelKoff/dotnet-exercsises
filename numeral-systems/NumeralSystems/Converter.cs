using System;
using System.Globalization;
using System.Text;

namespace NumeralSystems
{
    public static class Converter
    {
        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the octal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the octal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveOctal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number was less than 0");
            }

            StringBuilder octal = new StringBuilder();

            while (number != 0)
            {
                octal.Insert(0, number % 8);
                number /= 8;
            }

            return octal.ToString();
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the decimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the decimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveDecimal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number was less than 0");
            }

            return number.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the hexadecimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the hexadecimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveHex(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number was less than 0");
            }

            StringBuilder hexNumber = new StringBuilder();

            while (number != 0)
            {
                int remainderInt = number % 16;
                string remainder = remainderInt switch
                {
                    10 => "A",
                    11 => "B",
                    12 => "C",
                    13 => "D",
                    14 => "E",
                    15 => "F",
                    _ => remainderInt.ToString(CultureInfo.InvariantCulture)
                };

                hexNumber.Insert(0, remainder);
                number /= 16;
            }

            return hexNumber.ToString();
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveRadix(this int number, int radix)
        {
            if (number < 0)
            {
                throw new ArgumentException("number was less than 0");
            }

            return radix switch
            {
                8 => GetPositiveOctal(number),
                10 => GetPositiveDecimal(number),
                16 => GetPositiveHex(number),
                _ => throw new ArgumentException("Radix was not equal to 8, 10 or 16")
            };
        }

        /// <summary>
        /// Gets the value of a signed integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        public static string GetRadix(this int number, int radix)
        {
            if (number >= 0)
            {
                return GetPositiveRadix(number, radix);
            }
            else
            {
                return radix switch
                {
                    8 => GetSignedOctal(number),
                    10 => number.ToString(CultureInfo.InvariantCulture),
                    16 => GetSignedHex(number),
                    _ => throw new ArgumentException("Radix was not equal to 8, 10 or 16")
                };
            }
        }

        /// <summary>
        /// Gets the value of a signed integer to its equivalent string representation in the octal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the octal numeral systems.</returns>
        public static string GetSignedOctal(this int number)
        {
            uint inverted = (uint)(uint.MaxValue + number + 1);
            StringBuilder octal = new StringBuilder();

            while (inverted != 0)
            {
                octal.Insert(0, inverted % 8);
                inverted /= 8;
            }

            return octal.ToString();
        }

        /// <summary>
        /// Gets the value of a signed integer to its equivalent string representation in the hexadecimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the hexadecimal numeral systems.</returns>
        public static string GetSignedHex(this int number)
        {
            uint inverted = (uint)(uint.MaxValue + number + 1);
            StringBuilder hexNumber = new StringBuilder();

            while (inverted != 0)
            {
                uint remainderInt = inverted % 16;
                string remainder = remainderInt switch
                {
                    10 => "A",
                    11 => "B",
                    12 => "C",
                    13 => "D",
                    14 => "E",
                    15 => "F",
                    _ => remainderInt.ToString(CultureInfo.InvariantCulture)
                };

                hexNumber.Insert(0, remainder);
                inverted /= 16;
            }

            return hexNumber.ToString();
        }
    }
}
