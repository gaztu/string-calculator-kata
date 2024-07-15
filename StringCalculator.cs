namespace string_calculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers)) return 0;

        var result = numbers.Split(',','\n').Sum(x => int.Parse(x));
        return result;
    }
}