namespace NumberPresenter.Core
{
    public record NumberNumeral
    {
        public NumberNumeral(int number, string numeral)
        {
            Number = number;
            Numeral = numeral;
        }

        public int Number { get; set; }

        public string Numeral { get; set; }
    }
}
