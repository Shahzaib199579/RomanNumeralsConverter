using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralConsole
{
    public class NumeralToNumberConverter
    {
        private Dictionary<string, int> _romanNumeralDictionary;
        private string[] _romanNumeralArray;
        private int[] _numeralNumber;
        private const string ONE = "I";
        private const string FIVE = "V";
        private const string TEN = "X";
        private const string FIFTY = "L";
        private const string HUNDRED = "C";
        private const string FIVE_HUNDRED = "D";
        private const string THOUSAND = "M";

        public NumeralToNumberConverter()
        {
            _romanNumeralDictionary = new Dictionary<string, int>();
            _romanNumeralArray = new string[] { ONE, FIVE, TEN, FIFTY, HUNDRED, FIVE_HUNDRED, THOUSAND };
            _numeralNumber = new int[] { 1, 5, 10, 50, 100, 500, 1000 };
            EnterValuesInDictionary();
        }

        private void EnterValuesInDictionary()
        {

            for (int i = 0; i < _romanNumeralArray.Length; i++)
            {
                _romanNumeralDictionary[_romanNumeralArray[i]] = _numeralNumber[i];
            }
        }

        /// <summary>
        /// Converts the roman numeral to number. Returns 0 if conversion is unsuccessful.
        /// </summary>
        /// <param name="s">Roman numeral to be converted to number as a string.</param>
        /// <returns>Returns the converted roman numeral as a number greater than or equal to 1 or 0 
        /// in case of unsuccessful conversion.</returns>
        public int Convert(string s)
        {
            if (String.IsNullOrEmpty(s))
                return 0;

            // Check whether there are only Roman Numeral Letters I, V, X, L, C, D, M
            foreach (var l in s)
            {
                if (!_romanNumeralArray.Any(x => x.Equals(System.Convert.ToString(l))))
                    return 0;
            }

            try
            {
                var countDictionary = new Dictionary<string, int>();
                int value = 0;
                foreach (var letter in s)
                {
                    if (countDictionary.TryGetValue(System.Convert.ToString(letter), out value))
                    {
                        if (value > 3)
                            return 0;
                        countDictionary[System.Convert.ToString(letter)] = ++value;
                    }
                    else
                    {
                        countDictionary[System.Convert.ToString(letter)] = 1;
                    }
                    value = 0;
                }

                // No Roman Numeral should appear for more than 3 times.
                if (countDictionary.Values.Where(x => x > 3).Count() >= 1)
                    return 0;

                // Roman Numerals V, L, D can not repeat in string.
                if (countDictionary.Keys.Contains(FIVE))
                {
                    if (countDictionary[FIVE] > 1)
                        return 0;
                }
                if (countDictionary.Keys.Contains(FIFTY))
                {
                    if (countDictionary[FIFTY] > 1)
                        return 0;
                }
                if (countDictionary.Keys.Contains(FIVE_HUNDRED))
                {
                    if (countDictionary[FIVE_HUNDRED] > 1)
                        return 0;
                }

                // If there is a single roman numeral then return the value.
                if (s.Length == 1)
                    return _romanNumeralDictionary[s];

                var sum = 0;
                var previous = "";
                foreach (var l in s)
                {
                    if (String.IsNullOrEmpty(previous))
                    {
                        previous = System.Convert.ToString(l);
                        sum = _romanNumeralDictionary[previous];
                        continue;
                    }

                    if (_romanNumeralArray.ToList().IndexOf(System.Convert.ToString(l)) > _romanNumeralArray.ToList().IndexOf(previous))
                    {
                        sum = (sum - _romanNumeralDictionary[previous]) + (_romanNumeralDictionary[System.Convert.ToString(l)] - _romanNumeralDictionary[previous]);
                    }
                    else
                    {
                        sum += _romanNumeralDictionary[System.Convert.ToString(l)];
                    }
                    previous = System.Convert.ToString(l);
                }

                return sum;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
