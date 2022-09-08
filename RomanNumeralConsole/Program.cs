// See https://aka.ms/new-console-template for more information
using RomanNumeralConsole;

var numeralConverter = new NumeralToNumberConverter();
Console.WriteLine(numeralConverter.Convert("LX"));

var numberToNumeralConverter = new NumberToNumeralConverter();
Console.WriteLine(numberToNumeralConverter.Convert(999));
Console.WriteLine(numberToNumeralConverter.Convert(2999));
Console.WriteLine(numberToNumeralConverter.Convert(2000));
Console.WriteLine(numberToNumeralConverter.Convert(2500));
Console.WriteLine(numberToNumeralConverter.Convert(90));
Console.WriteLine(numberToNumeralConverter.Convert(55));