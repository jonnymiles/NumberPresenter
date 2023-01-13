namespace NumberPresenter.Core
{
    /// <summary>
    /// Root object result of attempted conversion.
    /// </summary>
    public class ResultRoot
    {
        /// <summary>
        /// Gets or sets a value indicating whether or not the conversion was a success.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the error message from the conversion if it was not successful.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
