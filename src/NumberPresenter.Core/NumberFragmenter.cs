namespace NumberPresenter.Core
{
    /// <summary>
    /// Contains methods that break numbers down into more manageable fragments.
    /// </summary>
    public static class NumberFragmenter
    {
        /// <summary>
        /// Decomposes a number into 1s, 10s, 100s etc
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> GetBaseTens(int input)
        {
            var result = new List<int>();

            var numericString = input.ToString();

            for (int i = 0; i < numericString.Length; i++)
            {
                var digit = GetDigit(i, numericString);

                if (digit.HasValue)
                {
                    result.Add(digit.Value);
                }
            }

            return result;
        }

        private static int? GetDigit(int iteration, string numericString)
        {
            var digit = numericString.Substring(iteration, 1);

            if (digit == "0")
            {
                return null;
            }

            var numberOfZerosNeeded = numericString.Length - 1 - iteration;

            for (int i = 0; i < numberOfZerosNeeded; i++)
            {
                digit = digit + "0";
            }

            return int.Parse(digit);
        }
    }
}
