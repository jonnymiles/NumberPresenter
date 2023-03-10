using System.Text;

namespace NumberPresenter.Core
{
    /// <inheritdoc/>
    public class RomanService : IRomanService
    {
        /// <inheritdoc/>
        public TextResult NumericToRoman(string numeric)
        {
            var numberResult = NumberExtractor.ExtractNumber(numeric);

            if (!numberResult.Success)
            {
                return new TextResult
                {
                    ErrorMessage = numberResult.ErrorMessage,
                    Success = false
                };
            }

            if (!numberResult.Result.HasValue)
            {
                return new TextResult
                {
                    ErrorMessage = $"Unknown error extracting number from {numeric}",
                    Success = false
                };
            }

            return NumericToRoman(numberResult.Result.Value);
        }

        /// <inheritdoc/>
        public TextResult NumericToRoman(int numeric)
        {
            if (numeric <= 0 || numeric > 2000)
            {
                return new TextResult
                {
                    Success = false,
                    ErrorMessage = "Number must be between 1 and 2000"
                };
            }

            var frags = NumberFragmenter.GetBaseTens(numeric);

            var numerals = new List<string>();

            foreach (var frag in frags)
            {
                var numeral = Romanise(frag);
                numerals.Add(numeral);
            }

            var finalRoman = string.Join("", numerals);

            return new TextResult
            {
                Success = true,
                Result = finalRoman
            };
        }

        private static string Romanise(int number)
        {
            if (RomanNumeralsLookup.IsSubtractionCase(number))
            {
                var subtractionResult = RomanNumeralsLookup.GetSubtractionCase(number);
                return subtractionResult.Numeral;
            }

            var runningTotal = 0;
            var roman = new StringBuilder();

            while (runningTotal != number)
            {
                var candidate = RomanNumeralsLookup.RoundDown(number);

                if (runningTotal + candidate.Number > number)
                {
                    candidate = RomanNumeralsLookup.RoundDownTwice(number);
                }

                roman.Append(candidate.Numeral);
                runningTotal += candidate.Number;
            }

            return roman.ToString();
        }
    }
}
