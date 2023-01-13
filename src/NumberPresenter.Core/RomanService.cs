using System.Text;

namespace NumberPresenter.Core
{
    public class RomanService : IRomanService
    {
        public PresentResult NumericToRoman(int numeric)
        {
            if (numeric <= 0 || numeric > 2000)
            {
                return new PresentResult
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

            var finalRoman = new StringBuilder();

            foreach (var numeral in numerals)
            {
                finalRoman.Append(numeral);
            }

            return new PresentResult
            {
                Success = true,
                Result = finalRoman.ToString()
            };
        }

        private string Romanise(int number)
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
