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
}