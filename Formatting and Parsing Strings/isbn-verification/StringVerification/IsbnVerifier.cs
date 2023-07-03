using System;

namespace StringVerification
{
    public static class IsbnVerifier
    {
        /// <summary>
        /// Verifies if the string representation of number is a valid ISBN-10 identification number of book.
        /// </summary>
        /// <param name="number">The string representation of book's number.</param>
        /// <returns>true if number is a valid ISBN-10 identification number of book, false otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if number is null or empty or whitespace.</exception>
        public static bool IsValid(string number)
        {
            if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Number was null or empty");
            }

            if (number.Length > 13)
            {
                return false;
            }

            // Checks whether hyphen signs ('-') are in proper positions if they are not omitted
            if (number.Length == 13)
            {
                // 1st hypen - valid position index is 1
                if (number.IndexOf('-', 0, 1) == 0)
                {
                    return false;
                }

                // 2nd hypen - valid position index is 5
                if (number.IndexOf('-', 2, 3) < 5 && number.IndexOf('-', 2, 3) != -1)
                {
                    return false;
                }

                // 2nd hypen - valid position index is 11
                if (number.IndexOf('-', 6, 5) < 11 && number.IndexOf('-', 6, 5) != -1)
                {
                    return false;
                }
            }

            number = number.Replace("-", string.Empty, StringComparison.InvariantCulture);

            if (number.Length != 10)
            {
                return false;
            }

            // Checks whether string contains non-digits before check-digit
            if (!int.TryParse(number[..9], out _))
            {
                return false;
            }

            // Checks whether check-digit is a digit or 'X'
            if (!char.IsDigit(number[9]) && number[9] != 'X')
            {
                return false;
            }

            int checkSum = 0;
            for (int i = 0, j = 10; i < number.Length; i++, j--)
            {
                switch (number[i])
                {
                    case '9':
                        checkSum += 9 * j;
                        break;
                    case '8':
                        checkSum += 8 * j;
                        break;
                    case '7':
                        checkSum += 7 * j;
                        break;
                    case '6':
                        checkSum += 6 * j;
                        break;
                    case '5':
                        checkSum += 5 * j;
                        break;
                    case '4':
                        checkSum += 4 * j;
                        break;
                    case '3':
                        checkSum += 3 * j;
                        break;
                    case '2':
                        checkSum += 2 * j;
                        break;
                    case '1':
                        checkSum += 1 * j;
                        break;
                    case '0':
                        checkSum += 0 * j;
                        break;
                    case 'X':
                        checkSum += 10 * j;
                        break;
                }
            }

            if (checkSum % 11 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
