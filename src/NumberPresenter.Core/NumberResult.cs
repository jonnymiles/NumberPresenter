namespace NumberPresenter.Core
{
    /// <summary>
    /// Objecting representing the result of an attempted conversion to a number.
    /// </summary>
    public class NumberResult : ResultRoot
    {
        /// <summary>
        /// Gets or results the result of the attempted conversion.
        /// </summary>
        public int? Result { get; set; }
    }
}
