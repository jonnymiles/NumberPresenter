namespace NumberPresenter.Core
{
    public class RomanService : IRomanService
    {
        public PresentResult NumericToRoman(int numeric)
        {
            return new PresentResult
            {
                Success = true,
                Result = "Implement me please"
            };
        }
    }
}
