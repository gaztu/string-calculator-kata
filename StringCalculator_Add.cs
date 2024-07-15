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
}