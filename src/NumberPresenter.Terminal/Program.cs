using NumberPresenter.Core;
using NumberPresenter.Terminal;

var dependencyContainer = new DependencyContainer();

var numberService = dependencyContainer.GetService<INumberService>();
var romanService = dependencyContainer.GetService<IRomanService>();

while (true)
{
    Console.WriteLine("Please enter the number (1-2000) that you would like to convert to Roman numerals:");

    var input = Console.ReadLine();

    var numberResult = numberService.ExtractNumber(input);

    if (!numberResult.Success)
    {
        Console.WriteLine($"Error: {numberResult.ErrorMessage}");
    }

    var romanResult = romanService.NumericToRoman(numberResult.Result);

    if (!romanResult.Success)
    {
        Console.WriteLine($"Error: {romanResult.ErrorMessage}");
    }

    Console.WriteLine(romanResult.Result);
}