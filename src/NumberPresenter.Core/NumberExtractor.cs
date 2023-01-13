namespace NumberPresenter.Core
{
    public static class NumberExtractor
    {
        public static NumberResult ExtractNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new NumberResult
                {
                    Success = false,
                    ErrorMessage = "Please enter a value"
                };
            }

            if (int.TryParse(input, out var number))
            {
                return new NumberResult
                {
                    Success = true,
                    Result = number
                };
            }

            return new NumberResult
            {
                Success = false,
                ErrorMessage = "Please enter a valid number"
            };
        }
    }
}
