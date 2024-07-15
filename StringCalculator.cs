namespace string_calculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers)) return 0;

        var numbersArray = numbers.Split(',');
        var result = 0;
        foreach (var number in numbersArray)
        {
            result += Int32.Parse(number);
        }
        return result;
    }
}