namespace NumberPresenter.Core
{
    /// <summary>
    /// Record for pairing a base 10 number with its Roman numeral.
    /// </summary>
    public record NumberNumeral(int Number, string Numeral)
    {
        /// <summary>
        /// Gets or sets the number in base 10 format.
        /// </summary>
        public int Number { get; set; } = Number;

        /// <summary>
        /// Gets or sets the matching Roman numeral for the number.
        /// </summary>
        public string Numeral { get; set; } = Numeral;
    }
}
