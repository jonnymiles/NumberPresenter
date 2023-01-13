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

            var numeralTrackers = frags.Select(x => new NumberNumeral { Number = x });

            foreach (var numeralTracker in numeralTrackers)
            {
                numeralTracker.Numeral = Romanise(numeralTracker.Number);
            }

            var finalRoman = new StringBuilder();

            foreach (var numeralTracker in numeralTrackers)
            {
                finalRoman.Append(numeralTracker.Numeral);
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
