namespace NumberPresenter.Core
{
    /// <summary>
    /// Objecting representing the result of an attempted conversion to a string.
    /// </summary>
    public class TextResult : ResultRoot
    {
        /// <summary>
        /// Gets or sets the result of the attmped conversion.
        /// </summary>
        public string Result { get; set; }
    }
}
