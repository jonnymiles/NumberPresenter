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

            var romanService = dependencyContainer.GetService<IRomanService>();

            while (true)
            {
                Run(romanService);
            }
        }

        private static void Run(IRomanService romanService)
        {
            Console.WriteLine("Please enter the number (1-2000) that you would like to convert to Roman numerals:");

            var input = Console.ReadLine();

            var romanResult = romanService.NumericToRoman(input);

            Exit(romanResult.Success ? $"Result: {romanResult.Result}" : $"Error: {romanResult.ErrorMessage}");
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