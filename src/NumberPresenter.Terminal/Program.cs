using System.Diagnostics;
using NumberPresenter.Core;
using NumberPresenter.Terminal;

namespace NumberPresenter.Terminal
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var dependencyContainer = new DependencyContainer();

            var numberService = dependencyContainer.GetService<INumberService>();
            var romanService = dependencyContainer.GetService<IRomanService>();

            while (true)
            {
                Run(numberService, romanService);
            }
        }

        private static void Run(INumberService numberService, IRomanService romanService)
        {
            Console.WriteLine("Please enter the number (1-2000) that you would like to convert to Roman numerals:");

            var input = Console.ReadLine();

            var numberResult = numberService.ExtractNumber(input);

            if (!numberResult.Success)
            {
                Exit($"Error: {numberResult.ErrorMessage}");
                return;
            }

            if (!numberResult.Result.HasValue)
            {
                Exit("Unknown error");
                return;
            }

            var romanResult = romanService.NumericToRoman(numberResult.Result.Value);

            if (!romanResult.Success)
            {
                Exit($"Error: {romanResult.ErrorMessage}");
            }
            else
            {
                Exit($"Result: {romanResult.Result}");
            }
        }

        private static void Exit(string message = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(message);
            }
            
            Console.WriteLine();
        }
    }
}