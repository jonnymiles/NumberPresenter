namespace NumberPresenter.Core
{
    /// <summary>
    /// Gets a number from a string if possible.
    /// </summary>
    public static class NumberExtractor
    {
        /// <summary>
        /// Gets a number from a string if possible.
        /// </summary>
        /// <param name="input">A string representing a number.</param>
        /// <returns>Result of the number conversion, successful or not.</returns>
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
