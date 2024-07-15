namespace string_calculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers)) return 0;

        return Int32.Parse(numbers);
    }
}