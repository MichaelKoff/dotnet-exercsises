using System;
using System.Collections.Generic;

namespace LouVuiDateCode
{
    public static class CountryParser
    {
        private const string FranceCodes = "A0, A1, A2, AA, AAS (Special Order), AH, AN, AR, AS, BA, BJ, BU, DR, DU, DR, DT, CO, CT, CX, ET, FL, LA, LW, MB, MI, NO, RA, RI, SA, SD, SF, SL, SN, SP, SR, TA, TJ, TH, TN, TR, TS, VI, VX";
        private const string GermanyCodes = "LP, OL";
        private const string ItalyCodes = "BC, BO, CE, FN, FO, MA, NZ, OB, PL, RC, RE, SA, TD";
        private const string SpainCodes = "BC, CA, LO, LB, LM, LW, GI, UB";
        private const string SwitzerlandCodes = "DI, FA";
        private const string UsaCodes = "FC, FH, LA, OS, SD, FL, TX";

        /// <summary>
        /// Gets a an array of <see cref="Country"/> enumeration values for a specified factory location code. One location code can belong to many countries.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <returns>An array of <see cref="Country"/> enumeration values.</returns>
        public static Country[] GetCountry(string factoryLocationCode)
        {
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            List<Country> countries = new List<Country>();

            if (FranceCodes.Contains(factoryLocationCode, StringComparison.OrdinalIgnoreCase))
            {
                countries.Add(Country.France);
            }

            if (GermanyCodes.Contains(factoryLocationCode, StringComparison.OrdinalIgnoreCase))
            {
                countries.Add(Country.Germany);
            }

            if (ItalyCodes.Contains(factoryLocationCode, StringComparison.OrdinalIgnoreCase))
            {
                countries.Add(Country.Italy);
            }

            if (SpainCodes.Contains(factoryLocationCode, StringComparison.OrdinalIgnoreCase))
            {
                countries.Add(Country.Spain);
            }

            if (SwitzerlandCodes.Contains(factoryLocationCode, StringComparison.OrdinalIgnoreCase))
            {
                countries.Add(Country.Switzerland);
            }

            if (UsaCodes.Contains(factoryLocationCode, StringComparison.OrdinalIgnoreCase))
            {
                countries.Add(Country.USA);
            }

            return countries.ToArray();
        }
    }
}
