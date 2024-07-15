namespace string_calculator;

public class StringCalculator_Add
{
    [Fact]
    public void Add_EmptyString_ReturnsZero()
    {
        // Arrange
        StringCalculator calc = new();

        // Act
        var result = calc.Add("");

        // Assert
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    public void Add_SingleNumber_ReturnsNumber(string numbers, int expectedResult)
    {
        StringCalculator calc = new();
        
        var result = calc.Add(numbers);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    public void Add_TwoNumbers_ReturnsSum(string numbers, int expectedResult)
    {
        StringCalculator calc = new();
        
        var result = calc.Add(numbers);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("2,4,6,8,9,7,5,3,1", 45)]
    public void Add_ManyNumbers_ReturnsSum(string numbers, int expectedResult)
    {
        StringCalculator calc = new();
        
        var result = calc.Add(numbers);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("2,4\n6", 12)]
    public void Add_StringWithNewlineChar_ReturnsSum(string numbers, int expectedResult)
    {
        StringCalculator calc = new();
        
        var result = calc.Add(numbers);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//;\n1;2,3", 6)]
    public void Add_StringWithCustomDelimiter_ReturnsSum(string numbers, int expectedResult)
    {
        StringCalculator calc = new();
        
        var result = calc.Add(numbers);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("-1", "Negatives not allowed: -1")]
    [InlineData("-1,-2", "Negatives not allowed: -1,-2")]
    [InlineData("-1,3,-2", "Negatives not allowed: -1,-2")]
    public void Add_NegativeNumbers_ReturnsException(string numbers, string expectedResult)
    {
        StringCalculator calc = new();

        Action actual = () => calc.Add(numbers);

        var ex = Assert.Throws<Exception>(actual);
        Assert.Equal(expectedResult, ex.Message);
    }

    [Theory]
    [InlineData("1000", 1000)]
    [InlineData("1001", 0)]
    [InlineData("1,1001", 1)]
    public void Add_NumbersAbove1000_ReturnsSumExcludingNumbersAbove1000(string numbers, int expectedResult)
    {
        StringCalculator calc = new();
        
        var result = calc.Add(numbers);

        Assert.Equal(expectedResult, result);
    }
}