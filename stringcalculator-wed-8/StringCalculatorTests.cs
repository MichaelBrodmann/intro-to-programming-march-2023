
namespace StringCalculator;

public class StringCalculatorTests
{
    [Theory]
    [InlineData(10,"10")]
    [InlineData(15, "15")]
    [InlineData(0, "")]
    [InlineData(10,"5,5")]
    [InlineData(8, "5,  3")]
    [InlineData(25, "12,13")]
    public void EmptyStringReturnsZero(int expected, string actual)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(actual);

        Assert.Equal(expected, result);
    }
}
