using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralConsole
{
    public class NumberToNumeralConverter
    {
        private Dictionary<int, string> _numberToNumeralDictionary;
        private int[] _numberArray;
        private string[] _numberNumeral;
        private const int ONE = 1;
        private const int FOUR = 4;
        private const int FIVE = 5;
        private const int TEN = 10;
        private const int FIFTY = 50;
        private const int HUNDRED = 100;
        private const int FIVE_HUNDRED = 500;
        private const int THOUSAND = 1000;
        private const string ERROR_MESSAGE = "Error: Wrong Number entered. Roman Numerals go from 1 to 3000.";
        private const int MAX_ROMAN_NUMBER_ALLOWED = 3000;

        public NumberToNumeralConverter()
        {
            _numberToNumeralDictionary = new Dictionary<int, string>();
            _numberArray = new int[] { ONE, FIVE, TEN, FIFTY, HUNDRED, FIVE_HUNDRED, THOUSAND };
            _numberNumeral = new string[] { "I", "V", "X", "L", "C", "D", "M" };
            EnterValuesInDictionary();
        }

        private void EnterValuesInDictionary()
        {

            for (int i = 0; i < _numberArray.Length; i++)
            {
                _numberToNumeralDictionary[_numberArray[i]] = _numberNumeral[i];
            }
        }

        /// <summary>
        /// Method that converts numbers to roman numerals.
        /// </summary>
        /// <param name="num">The number that needs to be converted.</param>
        /// <returns>string representing the number in roman numerals.</returns>
        public string Convert(int num)
        {
            if (num == 0)
                return ERROR_MESSAGE;
            if (num > MAX_ROMAN_NUMBER_ALLOWED)
                return ERROR_MESSAGE;

            var numAsString = System.Convert.ToString(num);
            var romanNumeralString = "";

            for (int i = 0; i < numAsString.Length; i++)
            {
                if (numAsString.Length > 3)
                {
                    romanNumeralString += ConvertNumberGreaterThanOrEqualThousand(i, System.Convert.ToString(numAsString[i]));
                }
                else if (numAsString.Length > 2)
                {
                    romanNumeralString += ConvertNumberGreaterThanOrEqualHundred(i, System.Convert.ToString(numAsString[i]));
                }
                else if (numAsString.Length > 1)
                {
                    romanNumeralString += ConvertNumberGreaterThanOrEqualTenAndLessThanHundred(i, System.Convert.ToString(numAsString[i]));
                }
                else
                {
                    romanNumeralString += ConvertNumberGreaterThanOrEqualOneAndLessTen(i, System.Convert.ToString(numAsString[i]));
                }
            }
            return romanNumeralString;
        }

        /// <summary>
        /// Method that converts numbers greater than or equal to 1000.
        /// </summary>
        /// <param name="index">The index of the digit in string.
        /// The index points to thousand, hundred, Ten and Unit digit</param>
        /// <param name="digit">The digit that needs to be converted to Roman Numeral</param>
        /// <returns>string representing roman numeral of digit.</returns>
        private string ConvertNumberGreaterThanOrEqualThousand(int index, string digit)
        {
            if (index == 0)
            {
                return ProcessThousandDigit(digit);

            }
            else if (index == 1)
            {
                return ProcessHundredDigit(digit);
            }
            else if (index == 2)
            {
                return ProcessTenthDigit(digit);
            }
            else
            {
                return ProcessUnitDigit(digit);
            }
        }

        /// <summary>
        /// Method that converts numbers greater than or equal to 100.
        /// </summary>
        /// <param name="index">The index of the digit in string.
        /// The index points to thousand, hundred, Ten and Unit digit</param>
        /// <param name="digit">The digit that needs to be converted to Roman Numeral</param>
        /// <returns>string representing roman numeral of digit.</returns>
        private string ConvertNumberGreaterThanOrEqualHundred(int index, string digit)
        {
            if (index == 0)
            {
                return ProcessHundredDigit(digit);

            }
            else if (index == 1)
            {
                return ProcessTenthDigit(digit);
            }
            else
            {
                return ProcessUnitDigit(digit);
            }
        }

        /// <summary>
        /// Method that converts numbers greater than or equal to 10 and less than 100.
        /// </summary>
        /// <param name="index">The index of the digit in string.
        /// The index points to thousand, hundred, Ten and Unit digit</param>
        /// <param name="digit">The digit that needs to be converted to Roman Numeral</param>
        /// <returns>string representing roman numeral of digit.</returns>
        private string ConvertNumberGreaterThanOrEqualTenAndLessThanHundred(int index, string digit)
        {
            if (index == 0)
            {
                return ProcessTenthDigit(digit);

            }
            else
            {
                return ProcessUnitDigit(digit);
            }
        }

        /// <summary>
        /// Method that converts numbers greater than or equal to 1 and less than 10.
        /// </summary>
        /// <param name="index">The index of the digit in string.
        /// The index points to thousand, hundred, Ten and Unit digit</param>
        /// <param name="digit">The digit that needs to be converted to Roman Numeral</param>
        /// <returns>string representing roman numeral of digit.</returns>
        private string ConvertNumberGreaterThanOrEqualOneAndLessTen(int index, string digit)
        {
            return ProcessUnitDigit(digit);
        }

        private string ProcessThousandDigit(string digitToProcess)
        {
            var thousandNumeralString = "";
            for (int i = 0; i < System.Convert.ToInt64(digitToProcess); i++)
            {
                thousandNumeralString += _numberToNumeralDictionary[THOUSAND];
            }

            return thousandNumeralString;
        }

        private string ProcessHundredDigit(string digitToProcess)
        {
            var hundredNumeralString = "";
            switch (digitToProcess)
            {
                case "9":
                {
                    hundredNumeralString += _numberToNumeralDictionary[HUNDRED] + _numberToNumeralDictionary[THOUSAND];
                    break;
                }
                case "8":
                {
                    hundredNumeralString = ProcessDigitGreaterThan500AndLessThan900(digitToProcess);
                    break;
                }
                case "7":
                {
                    hundredNumeralString = ProcessDigitGreaterThan500AndLessThan900(digitToProcess);
                    break;
                }
                case "6":
                {
                    hundredNumeralString = ProcessDigitGreaterThan500AndLessThan900(digitToProcess);
                    break;
                }
                case "5":
                {
                    hundredNumeralString = _numberToNumeralDictionary[FIVE_HUNDRED];
                    break;
                }
                case "4":
                {
                    hundredNumeralString = ProcessDigitGreaterThan100AndLessThan500(digitToProcess);
                    break;
                }
                case "3":
                {
                    hundredNumeralString = ProcessDigitGreaterThan100AndLessThan500(digitToProcess);
                    break;
                }
                case "2":
                {
                    hundredNumeralString = ProcessDigitGreaterThan100AndLessThan500(digitToProcess);
                    break;
                }
                case "1":
                {
                    hundredNumeralString = ProcessDigitGreaterThan100AndLessThan500(digitToProcess);
                    break;
                }
                default:
                    break;
            }

            return hundredNumeralString;
        }

        private string ProcessDigitGreaterThan500AndLessThan900(string digit)
        {
            var stringToReturn = "";
            var loopCount = System.Convert.ToInt64(digit) - FIVE;
            for (int i = 0; i < loopCount; i++)
            {
                stringToReturn += _numberToNumeralDictionary[HUNDRED];
            }

            return _numberToNumeralDictionary[FIVE_HUNDRED] + stringToReturn;
        }

        private string ProcessDigitGreaterThan100AndLessThan500(string digit)
        {
            var stringToReturn = "";
            if (System.Convert.ToInt64(digit) == FOUR)
                return _numberToNumeralDictionary[HUNDRED] + _numberToNumeralDictionary[FIVE_HUNDRED];
            var loopCount = System.Convert.ToInt64(digit);
            for (int i = 0; i < loopCount; i++)
            {
                stringToReturn += _numberToNumeralDictionary[HUNDRED];
            }

            return stringToReturn;
        }

        private string ProcessTenthDigit(string digitToProcess)
        {
            var hundredNumeralString = "";
            switch (digitToProcess)
            {
                case "9":
                {
                    hundredNumeralString += _numberToNumeralDictionary[TEN] + _numberToNumeralDictionary[HUNDRED];
                    break;
                }
                case "8":
                {
                    hundredNumeralString = ProcessDigitGreaterThan50AndLessThan90(digitToProcess);
                    break;
                }
                case "7":
                {
                    hundredNumeralString = ProcessDigitGreaterThan50AndLessThan90(digitToProcess);
                    break;
                }
                case "6":
                {
                    hundredNumeralString = ProcessDigitGreaterThan50AndLessThan90(digitToProcess);
                    break;
                }
                case "5":
                {
                    hundredNumeralString = _numberToNumeralDictionary[FIFTY];
                    break;
                }
                case "4":
                {
                    hundredNumeralString = ProcessDigitGreaterThan10AndLessThan50(digitToProcess);
                    break;
                }
                case "3":
                {
                    hundredNumeralString = ProcessDigitGreaterThan10AndLessThan50(digitToProcess);
                    break;
                }
                case "2":
                {
                    hundredNumeralString = ProcessDigitGreaterThan10AndLessThan50(digitToProcess);
                    break;
                }
                case "1":
                {
                    hundredNumeralString = ProcessDigitGreaterThan10AndLessThan50(digitToProcess);
                    break;
                }
                default:
                    break;
            }

            return hundredNumeralString;
        }

        private string ProcessDigitGreaterThan50AndLessThan90(string digit)
        {
            var stringToReturn = "";
            var loopCount = System.Convert.ToInt64(digit) - FIVE;
            for (int i = 0; i < loopCount; i++)
            {
                stringToReturn += _numberToNumeralDictionary[TEN];
            }

            return _numberToNumeralDictionary[FIFTY] + stringToReturn;
        }

        private string ProcessDigitGreaterThan10AndLessThan50(string digit)
        {
            var stringToReturn = "";
            if (System.Convert.ToInt64(digit) == FOUR)
                return _numberToNumeralDictionary[TEN] + _numberToNumeralDictionary[FIFTY];
            var loopCount = System.Convert.ToInt64(digit);
            for (int i = 0; i < loopCount; i++)
            {
                stringToReturn += _numberToNumeralDictionary[TEN];
            }

            return stringToReturn;
        }

        private string ProcessUnitDigit(string digitToProcess)
        {
            var hundredNumeralString = "";
            switch (digitToProcess)
            {
                case "9":
                    {
                        hundredNumeralString += _numberToNumeralDictionary[ONE] + _numberToNumeralDictionary[TEN];
                        break;
                    }
                case "8":
                    {
                        hundredNumeralString = ProcessDigitGreaterThan5AndLessThan9(digitToProcess);
                        break;
                    }
                case "7":
                    {
                        hundredNumeralString = ProcessDigitGreaterThan5AndLessThan9(digitToProcess);
                        break;
                    }
                case "6":
                    {
                        hundredNumeralString = ProcessDigitGreaterThan5AndLessThan9(digitToProcess);
                        break;
                    }
                case "5":
                    {
                        hundredNumeralString = _numberToNumeralDictionary[FIVE];
                        break;
                    }
                case "4":
                    {
                        hundredNumeralString = ProcessDigitGreaterThan1AndLessThan5(digitToProcess);
                        break;
                    }
                case "3":
                    {
                        hundredNumeralString = ProcessDigitGreaterThan1AndLessThan5(digitToProcess);
                        break;
                    }
                case "2":
                    {
                        hundredNumeralString = ProcessDigitGreaterThan1AndLessThan5(digitToProcess);
                        break;
                    }
                case "1":
                    {
                        hundredNumeralString = ProcessDigitGreaterThan1AndLessThan5(digitToProcess);
                        break;
                    }
                default:
                    break;
            }

            return hundredNumeralString;
        }

        private string ProcessDigitGreaterThan5AndLessThan9(string digit)
        {
            var stringToReturn = "";
            var loopCount = System.Convert.ToInt64(digit) - FIVE;
            for (int i = 0; i < loopCount; i++)
            {
                stringToReturn += _numberToNumeralDictionary[ONE];
            }

            return _numberToNumeralDictionary[FIVE] + stringToReturn;
        }

        private string ProcessDigitGreaterThan1AndLessThan5(string digit)
        {
            var stringToReturn = "";
            if (System.Convert.ToInt64(digit) == FOUR)
                return _numberToNumeralDictionary[ONE] + _numberToNumeralDictionary[FIVE];
            var loopCount = System.Convert.ToInt64(digit);
            for (int i = 0; i < loopCount; i++)
            {
                stringToReturn += _numberToNumeralDictionary[ONE];
            }

            return stringToReturn;
        }
    }
}
