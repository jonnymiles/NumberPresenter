namespace NumberPresenter.Core
{
    /// <summary>
    /// Creates roman numerals from base 10 numbers
    /// </summary>
    public interface IRomanService
    {
        /// <summary>
        /// Creates a Roman numeral from a string.
        /// </summary>
        /// <param name="numeric">Number to be converted as a string.</param>
        /// <returns>The result of the conversion, successful or not.</returns>
        TextResult NumericToRoman(string numeric);

        /// <summary>
        /// Creates a Roman numeral from an integer.
        /// </summary>
        /// <param name="numeric">Number to be converted as a string.</param>
        /// <returns>The result of the conversion, successful or not.</returns>
        TextResult NumericToRoman(int numeric);
    }
}
