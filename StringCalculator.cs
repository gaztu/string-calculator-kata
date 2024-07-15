namespace string_calculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers)) return 0;

        string[] delimiters = GetDelimiters(numbers);
        if (numbers.Contains("//")) numbers = numbers[(numbers.IndexOf('\n') + 1)..];

        var numList = numbers.Split(delimiters, StringSplitOptions.None)
            .Select(int.Parse)
            .Where(x => x <= 1000);
        CheckNegatives(numList);

        return numList.Sum();
    }

    private string[] GetDelimiters(string numbers)
    {
        string[] result = new string[] { ",", "\n" };
        if (numbers.Contains("//"))
        {
            if (numbers.Contains('['))
            {
                var customDelimiter = numbers[3..numbers.IndexOf(']')];
                result = result.Concat(new string[] { customDelimiter }).ToArray();
            }
            else
            {
                result = result.Concat(new string[] { numbers[2].ToString() }).ToArray();
            }
        }
        return result;
    }

    private void CheckNegatives(IEnumerable<int> numArray)
    {
        var negativeNumbers = numArray.Where(x => x < 0);
        if (negativeNumbers.Any())
        {
            string message = "Negatives not allowed: ";
            foreach (int num in negativeNumbers)
            {
                message += num.ToString() + ",";
            }
            message = message.TrimEnd(',');
            throw new Exception(message);
        }
    }
}