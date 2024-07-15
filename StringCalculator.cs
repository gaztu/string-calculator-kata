namespace string_calculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers)) return 0;

        char[] delimiters = new char[] {',', '\n'};
        if (numbers.Contains("//"))
        {
            numbers = numbers.TrimStart('/');
            delimiters = delimiters.Concat(new char[] { numbers[0] }).ToArray();
            numbers = numbers.Substring(2);
        }

        var result = numbers.Split(delimiters).Sum(x => int.Parse(x));
        return result;
    }
}