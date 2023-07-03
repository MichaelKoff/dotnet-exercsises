using System;

namespace Numbers
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Obtains formalized information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number. 
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number
        /// or null if the information is not defined.</returns>
        public static ComparisonSigns? GetTypeComparisonSigns(this long number)
        {
            ComparisonSigns? signs = 0;

            while (number != 0)
            {
                long lastDigit = number % 10 < 0 ? (number % 10) * -1 : number % 10;

                number /= 10;

                if (number == 0)
                {
                    break;
                }
                
                long nextDigit = number % 10 < 0 ? (number % 10) * -1 : number % 10;

                if (lastDigit < nextDigit)
                {
                    signs |= ComparisonSigns.MoreThan;
                }

                if (lastDigit > nextDigit)
                {
                    signs |= ComparisonSigns.LessThan;
                }

                if (lastDigit == nextDigit)
                {
                    signs |= ComparisonSigns.Equals;
                }
            }

            return signs == 0 ? null : signs;
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            ComparisonSigns? signs = number.GetTypeComparisonSigns();

            return signs switch
            {
                ComparisonSigns.LessThan => "Strictly Increasing.",
                ComparisonSigns.LessThan | ComparisonSigns.Equals => "Increasing.",
                ComparisonSigns.Equals => "Monotonous.",
                ComparisonSigns.MoreThan => "Strictly Decreasing.",
                ComparisonSigns.MoreThan | ComparisonSigns.Equals => "Decreasing.",
                null => "One digit number.",
                _ => "Unordered.",
            };
        }
    }
}
