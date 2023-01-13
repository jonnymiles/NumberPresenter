namespace NumberPresenter.Core
{
    public static class RomanNumeralsLookup
    {
        private static readonly IEnumerable<NumberNumeral> _keyNumerals = new List<NumberNumeral>
        {
            new(1, "I"),
            new(5, "V"),
            new(10, "X"),
            new(50, "L"),
            new(100, "C"),
            new(500, "D"),
            new(1000, "M"),
        };

        private static IEnumerable<NumberNumeral> _subtractionCases = new List<NumberNumeral>
        {
            new(4, "IV"),
            new(9, "IX"),
            new(40, "XL"),
            new(90, "XC"),
            new(400, "CD"),
            new(900, "CM"),
        };

        public static NumberNumeral RoundDown(int input)
        {
            if (_keyNumerals.Any(x => x.Number == input))
            {
                return _keyNumerals.First(x => x.Number == input);
            }

            return FindNextDown(input);
        }

        public static NumberNumeral RoundDownTwice(int input)
        {
            var roundDown = RoundDown(input);

            return FindNextDown(roundDown.Number);
        }

        public static bool IsSubtractionCase(int input)
        {
            return _subtractionCases.Any(x => x.Number == input);
        }

        public static NumberNumeral GetSubtractionCase(int input)
        {
            return _subtractionCases.First(x => x.Number == input);
        }

        private static NumberNumeral FindNextDown(int input)
        {
            foreach (var _keyNumeral in _keyNumerals.OrderByDescending(x => x.Number))
            {
                if (_keyNumeral.Number < input)
                {
                    return _keyNumeral;
                }
            }

            throw new ArgumentException("Input number has no match on chart");
        }
    }
}
