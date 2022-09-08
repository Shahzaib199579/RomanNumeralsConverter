using FluentAssertions;
using NUnit.Framework.Internal;

namespace RomanNumeralConsole.Tests;

public class NumeralToNumberConverterTests
{
    private NumeralToNumberConverter _numeralToNumberConverter;
    [SetUp]
    public void Setup()
    {
        _numeralToNumberConverter = new NumeralToNumberConverter();
    }

    [Test]
    public void Convert_Should_Return_Zero_When_Numeral_More_Than_3_Times_In_String()
    {
        _numeralToNumberConverter.Convert("XXXX").Should().Be(0);
        _numeralToNumberConverter.Convert("XXVVVVI").Should().Be(0);

    }

    [Test]
    public void Convert_Should_Return_Zero_When_Non_Numeral_Letters_In_String()
    {
        _numeralToNumberConverter.Convert("XXBBI").Should().Be(0);
        _numeralToNumberConverter.Convert("XXBBAAI").Should().Be(0);
    }

    [Test]
    public void Convert_Should_Return_Zero_When_VLD_Letters_Repeat_In_String()
    {
        _numeralToNumberConverter.Convert("VV").Should().Be(0);
        _numeralToNumberConverter.Convert("XXVLL").Should().Be(0);
        _numeralToNumberConverter.Convert("DD").Should().Be(0);
    }

    [Test]
    public void Convert_Should_Return_0_When_String_Null_Empty()
    {
        _numeralToNumberConverter.Convert("").Should().Be(0);
        _numeralToNumberConverter.Convert(null).Should().Be(0);
    }

    [Test]
    public void Convert_Should_Return_Number()
    {
        _numeralToNumberConverter.Convert("I").Should().Be(1);
        _numeralToNumberConverter.Convert("II").Should().Be(2);
        _numeralToNumberConverter.Convert("III").Should().Be(3);
        _numeralToNumberConverter.Convert("IV").Should().Be(4);
        _numeralToNumberConverter.Convert("V").Should().Be(5);
        _numeralToNumberConverter.Convert("VI").Should().Be(6);
        _numeralToNumberConverter.Convert("XXI").Should().Be(21);
        _numeralToNumberConverter.Convert("XXX").Should().Be(30);
        _numeralToNumberConverter.Convert("XC").Should().Be(90);
        _numeralToNumberConverter.Convert("C").Should().Be(100);
        _numeralToNumberConverter.Convert("D").Should().Be(500);
        _numeralToNumberConverter.Convert("M").Should().Be(1000);
        _numeralToNumberConverter.Convert("MMCCXXII").Should().Be(2222);
        _numeralToNumberConverter.Convert("MD").Should().Be(1500);
        _numeralToNumberConverter.Convert("CMXCIX").Should().Be(999);
    }
}