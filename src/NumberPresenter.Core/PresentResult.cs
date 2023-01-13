namespace NumberPresenter.Core
{
    /// <summary>
    /// Object representing the result of an attempted conversion to a string.
    /// </summary>
    public class TextResult : ResultRoot
    {
        /// <summary>
        /// Gets or sets the result of the attempted conversion.
        /// </summary>
        public string Result { get; set; }
    }
}
