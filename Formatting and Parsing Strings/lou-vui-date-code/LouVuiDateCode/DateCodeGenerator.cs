using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LouVuiDateCode
{
    public static class DateCodeGenerator
    {
        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1980 || manufacturingYear > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            return $"{manufacturingYear}"[2..] + $"{manufacturingMonth}";
        }

        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(DateTime manufacturingDate)
        {
            if (manufacturingDate.Year < 1980 || manufacturingDate.Year > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            return $"{manufacturingDate.Year}"[2..] + $"{manufacturingDate.Month}";
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, "^[a-zA-Z]+$"))
            {
                throw new ArgumentException("Factory location code has to be a two-letter value");
            }

            if (manufacturingYear < 1980 || manufacturingYear > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            string code = factoryLocationCode.ToUpper(CultureInfo.InvariantCulture);
            string year = $"{manufacturingYear}"[2..];

            return year + $"{manufacturingMonth}" + code;
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, "^[a-zA-Z]+$"))
            {
                throw new ArgumentException("Factory location code has to be a two-letter value");
            }

            if (manufacturingDate.Year < 1980 || manufacturingDate.Year > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            string code = factoryLocationCode.ToUpper(CultureInfo.InvariantCulture);
            string year = $"{manufacturingDate.Year}"[2..];
            string month = $"{manufacturingDate.Month}";

            return year + month + code;
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, "^[a-zA-Z]+$"))
            {
                throw new ArgumentException("Factory location code has to be a two-letter value");
            }

            if (manufacturingYear < 1990 || manufacturingYear > 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            string code = factoryLocationCode.ToUpper(CultureInfo.InvariantCulture);
            string month = $"{manufacturingMonth:d2}";
            string year = $"{manufacturingYear}"[2..];

            return code + month[0] + year[0] + month[1] + year[1];
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, "^[a-zA-Z]+$"))
            {
                throw new ArgumentException("Factory location code has to be a two-letter value");
            }

            if (manufacturingDate.Year < 1990 || manufacturingDate.Year > 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            string code = factoryLocationCode.ToUpper(CultureInfo.InvariantCulture);
            string month = $"{manufacturingDate.Month:d2}";
            string year = $"{manufacturingDate.Year}"[2..];

            return code + month[0] + year[0] + month[1] + year[1];
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingWeek">A manufacturing week number.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingWeek)
        {
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, "^[a-zA-Z]+$"))
            {
                throw new ArgumentException("Factory location code has to be a two-letter value");
            }

            if (manufacturingYear < 2007)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingWeek < 1 || manufacturingWeek > ISOWeek.GetWeeksInYear((int)manufacturingYear))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek));
            }

            string code = factoryLocationCode.ToUpper(CultureInfo.InvariantCulture);
            string week = $"{manufacturingWeek:d2}";
            string year = $"{manufacturingYear}"[2..];

            return code + week[0] + year[0] + week[1] + year[1];
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, "^[a-zA-Z]+$"))
            {
                throw new ArgumentException("Factory location code has to be a two-letter value");
            }

            if (manufacturingDate.Year < 2007)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            string code = factoryLocationCode.ToUpper(CultureInfo.InvariantCulture);
            string year = $"{ISOWeek.GetYear(manufacturingDate)}"[2..];
            int week = ISOWeek.GetWeekOfYear(manufacturingDate);

            return code + $"{week:d2}"[0] + year[0] + $"{week:d2}"[1] + year[1];
        }
    }
}
