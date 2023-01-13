namespace NumberPresenter.Core
{
    /// <summary>
    /// Provides lookup methods for referencing Roman numerals.
    /// </summary>
    public static class RomanNumeralsLookup
    {
        private static readonly IEnumerable<NumberNumeral> KeyNumerals = new List<NumberNumeral>
        {
            new(1, "I"),
            new(5, "V"),
            new(10, "X"),
            new(50, "L"),
            new(100, "C"),
            new(500, "D"),
            new(1000, "M"),
        };

        private static readonly IEnumerable<NumberNumeral> SubtractionCases = new List<NumberNumeral>
        {
            new(4, "IV"),
            new(9, "IX"),
            new(40, "XL"),
            new(90, "XC"),
            new(400, "CD"),
            new(900, "CM"),
        };

        /// <summary>
        /// Takes a number and returns the first Roman numeral below it.
        /// </summary>
        /// <param name="input">The number to be checked.</param>
        /// <returns>The first Roman numeral below the input number.</returns>
        public static NumberNumeral RoundDown(int input)
        {
            if (KeyNumerals.Any(x => x.Number == input))
            {
                return KeyNumerals.First(x => x.Number == input);
            }

            return FindNextDown(input);
        }

        /// <summary>
        /// Takes a number and returns the second highest Roman numeral that goes into it.
        /// </summary>
        /// <param name="input">The number to be checked.</param>
        /// <returns>The second highest Roman numeral that goes into the number.</returns>
        public static NumberNumeral RoundDownTwice(int input)
        {
            var roundDown = RoundDown(input);

            return FindNextDown(roundDown.Number);
        }

        /// <summary>
        /// Checks if the number is a recognised subtraction case.
        /// </summary>
        /// <param name="input">The number to be checked.</param>
        /// <returns>True if the number is a subtraction case, false if not.</returns>
        public static bool IsSubtractionCase(int input)
        {
            return SubtractionCases.Any(x => x.Number == input);
        }

        /// <summary>
        /// Gets the Roman numeral for a subtraction case.
        /// </summary>
        /// <param name="input">The subtraction case number.</param>
        /// <returns>Roman numeral information for the number.</returns>
        public static NumberNumeral GetSubtractionCase(int input)
        {
            return SubtractionCases.First(x => x.Number == input);
        }

        private static NumberNumeral FindNextDown(int input)
        {
            foreach (var keyNumeral in KeyNumerals.OrderByDescending(x => x.Number))
            {
                if (keyNumeral.Number < input)
                {
                    return keyNumeral;
                }
            }

            throw new ArgumentException("Input number has no match on chart");
        }
    }
}
