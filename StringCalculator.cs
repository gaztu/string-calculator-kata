namespace string_calculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers)) return 0;

        string[] delimiters = new string[] {",", "\n"};
        if (numbers.Contains("//"))
        {
            numbers = numbers.TrimStart('/');
            if (numbers.Contains('['))
            {
                var customDelimiter = numbers.Substring(1, numbers.IndexOf(']') - 1);
                delimiters = delimiters.Concat(new string[] { customDelimiter }).ToArray();
                numbers = numbers.Substring(customDelimiter.Length + 3);
            } else {
                delimiters = delimiters.Concat(new string[] { numbers[0].ToString() }).ToArray();
                numbers = numbers[2..];
            }
        }

        var numArray = numbers.Split(delimiters, StringSplitOptions.None).Select(int.Parse).Where(x => x <= 1000);
        var negativeNumbers = numArray.Where(x => x < 0);
        if (negativeNumbers.Any()) {
            string message = "Negatives not allowed: ";
            foreach(int num in negativeNumbers)
            {
                message += num.ToString() + ",";
            }
            message = message.TrimEnd(',');
            throw new Exception(message);
        }

        return numArray.Sum();;
    }
}