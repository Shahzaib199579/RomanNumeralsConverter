// See https://aka.ms/new-console-template for more information
using RomanNumeralConsole;

var numeralConverter = new NumeralToNumberConverter();

do
{
    Console.Write("Please enter a Roman Numeral: ");
    var numberToConvert = Console.ReadLine();
    var result = numeralConverter.Convert(numberToConvert.ToUpper().Trim());
    if (result != 0)
    {
        Console.Write("The Number is : ");
        Console.WriteLine(result);
    }
    else
    {
        Console.WriteLine("Please enter correct number.");
    }
} while (true);