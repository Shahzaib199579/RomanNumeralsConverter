using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralConsole.Tests
{
    public class NumberToNumeralConverterTests
    {
        private NumberToNumeralConverter _numberToNumeralConverter;
        [SetUp]
        public void Setup()
        {
            _numberToNumeralConverter = new NumberToNumeralConverter();
        }

        [Test]
        public void Convert_Should_Return_Error_String_When_Number_zero()
        {
            _numberToNumeralConverter.Convert(0).Should().ToString().ToLower().Contains("error");
        }

        [Test]
        public void Convert_Should_Return_Error_When_Number_Greater_Than_3000()
        {
            _numberToNumeralConverter.Convert(3001).Should().ToString().ToLower().Contains("error");
        }

        [Test]
        public void Convert_Should_Return_Correct_Roman_Numeral_For_Numbers_Greater_Than_Or_Equal_1000()
        {
            _numberToNumeralConverter.Convert(3000).Should().Be("MMM");
            _numberToNumeralConverter.Convert(1000).Should().Be("M");
            _numberToNumeralConverter.Convert(2000).Should().Be("MM");
            _numberToNumeralConverter.Convert(1456).Should().Be("MCDLVI");
            _numberToNumeralConverter.Convert(2356).Should().Be("MMCCCLVI");
            _numberToNumeralConverter.Convert(2999).Should().Be("MMCMXCIX");
            _numberToNumeralConverter.Convert(2500).Should().Be("MMD");
            _numberToNumeralConverter.Convert(1500).Should().Be("MD");
            _numberToNumeralConverter.Convert(1700).Should().Be("MDCC");
        }

        [Test]
        public void Convert_Should_Return_Correct_Roman_Numeral_For_Numbers_Greater_Than_Or_Equal_100_Less_1000()
        {
            _numberToNumeralConverter.Convert(300).Should().Be("CCC");
            _numberToNumeralConverter.Convert(100).Should().Be("C");
            _numberToNumeralConverter.Convert(200).Should().Be("CC");
            _numberToNumeralConverter.Convert(145).Should().Be("CXLV");
            _numberToNumeralConverter.Convert(356).Should().Be("CCCLVI");
            _numberToNumeralConverter.Convert(999).Should().Be("CMXCIX");
            _numberToNumeralConverter.Convert(250).Should().Be("CCL");
            _numberToNumeralConverter.Convert(500).Should().Be("D");
            _numberToNumeralConverter.Convert(170).Should().Be("CLXX");
        }

        [Test]
        public void Convert_Should_Return_Correct_Roman_Numeral_For_Numbers_Greater_Than_Or_Equal_10_Less_100()
        {
            _numberToNumeralConverter.Convert(30).Should().Be("XXX");
            _numberToNumeralConverter.Convert(10).Should().Be("X");
            _numberToNumeralConverter.Convert(20).Should().Be("XX");
            _numberToNumeralConverter.Convert(45).Should().Be("XLV");
            _numberToNumeralConverter.Convert(56).Should().Be("LVI");
            _numberToNumeralConverter.Convert(99).Should().Be("XCIX");
            _numberToNumeralConverter.Convert(90).Should().Be("XC");
            _numberToNumeralConverter.Convert(50).Should().Be("L");
            _numberToNumeralConverter.Convert(55).Should().Be("LV");
            _numberToNumeralConverter.Convert(11).Should().Be("XI");
        }

        [Test]
        public void Convert_Should_Return_Correct_Roman_Numeral_For_Numbers_Greater_Than_Or_Equal_1_Less_10()
        {
            _numberToNumeralConverter.Convert(3).Should().Be("III");
            _numberToNumeralConverter.Convert(1).Should().Be("I");
            _numberToNumeralConverter.Convert(2).Should().Be("II");
            _numberToNumeralConverter.Convert(4).Should().Be("IV");
            _numberToNumeralConverter.Convert(5).Should().Be("V");
            _numberToNumeralConverter.Convert(9).Should().Be("IX");
            _numberToNumeralConverter.Convert(6).Should().Be("VI");
        }
    }
}
