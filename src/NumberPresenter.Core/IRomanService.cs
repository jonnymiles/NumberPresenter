namespace NumberPresenter.Core
{
    public interface IRomanService
    {
        PresentResult NumericToRoman(string numeric);

        PresentResult NumericToRoman(int numeric);
    }
}
