using System;
using System.Globalization;

namespace LouVuiDateCode
{
    public static class DateCodeParser
    {
        /// <summary>
        /// Parses a date code and returns a <see cref="manufacturingYear"/> and <see cref="manufacturingMonth"/>.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode) || string.IsNullOrWhiteSpace(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length > 4 || dateCode.Length < 3)
            {
                throw new ArgumentException("Date code is invalid");
            }

            uint year = uint.Parse(dateCode[..2], CultureInfo.InvariantCulture);
            uint month = uint.Parse(dateCode[2..], CultureInfo.InvariantCulture);

            if (year > 89 || year < 80)
            {
                throw new ArgumentException("Date code is invalid");
            }

            if (month < 1 || month > 12)
            {
                throw new ArgumentException("Date code is invalid");
            }

            manufacturingYear = 1900 + year;
            manufacturingMonth = month;
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode) || string.IsNullOrWhiteSpace(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length > 6 || dateCode.Length < 5)
            {
                throw new ArgumentException("Date code is invalid");
            }

            uint year = uint.Parse(dateCode[..2], CultureInfo.InvariantCulture);
            uint month = uint.Parse(dateCode[2..^2], CultureInfo.InvariantCulture);
            Country[] countries = CountryParser.GetCountry(dateCode[^2..]);

            if (year > 89 || year < 80)
            {
                throw new ArgumentException("Date code is invalid");
            }

            if (month < 1 || month > 12)
            {
                throw new ArgumentException("Date code is invalid");
            }

            if (countries.Length == 0)
            {
                throw new ArgumentException("Date code is invalid");
            }

            manufacturingYear = 1900 + year;
            manufacturingMonth = month;
            factoryLocationCountry = countries;
            factoryLocationCode = dateCode[^2..];
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode) || string.IsNullOrWhiteSpace(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("Date code is invalid");
            }

            Country[] countries = CountryParser.GetCountry(dateCode[..2]);
            uint year = uint.Parse(string.Concat(dateCode[3], dateCode[5]), CultureInfo.InvariantCulture);
            uint month = uint.Parse(string.Concat(dateCode[2], dateCode[4]), CultureInfo.InvariantCulture);

            if (countries.Length == 0)
            {
                throw new ArgumentException("Date code is invalid");
            }

            if (!dateCode[3].Equals('0') && year < 90)
            {
                throw new ArgumentException("Date code is invalid");
            }

            if (dateCode[3].Equals('0') && year > 6)
            {
                throw new ArgumentException("Date code is invalid");
            }

            if (month < 1 || month > 12)
            {
                throw new ArgumentException("Date code is invalid");
            }

            factoryLocationCode = dateCode[..2];
            factoryLocationCountry = countries;
            manufacturingMonth = month;

            if (!dateCode[3].Equals('0'))
            {
                manufacturingYear = 1900 + year;
            }
            else
            {
                manufacturingYear = 2000 + year;
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingWeek"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingWeek">A manufacturing week to return.</param>
        public static void Parse2007Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingWeek)
        {
            if (string.IsNullOrEmpty(dateCode) || string.IsNullOrWhiteSpace(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("Date code is invalid");
            }

            Country[] countries = CountryParser.GetCountry(dateCode[..2]);
            uint year = uint.Parse(string.Concat(dateCode[3], dateCode[5]), CultureInfo.InvariantCulture);
            uint week = uint.Parse(string.Concat(dateCode[2], dateCode[4]), CultureInfo.InvariantCulture);

            if (countries.Length == 0)
            {
                throw new ArgumentException("Date code is invalid");
            }

            if (year < 7)
            {
                throw new ArgumentException("Date code is invalid");
            }

            if (week > ISOWeek.GetWeeksInYear(2000 + (int)year) || week < 1)
            {
                throw new ArgumentException("Date code is invalid");
            }

            factoryLocationCode = dateCode[..2];
            factoryLocationCountry = countries;
            manufacturingYear = 2000 + year;
            manufacturingWeek = week;
        }
    }
}
