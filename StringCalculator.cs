namespace string_calculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers)) return 0;

        string[] delimiters = GetDelimiters(numbers);
        if (numbers.Contains("//")) numbers = numbers[(numbers.IndexOf('\n') + 1)..];

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

        return numArray.Sum();
    }

    private string[] GetDelimiters(string numbers){
        string[] result = new string[] {",", "\n"};
        if (numbers.Contains("//"))
        {
            if (numbers.Contains('['))
            {
                var customDelimiter = numbers[3..numbers.IndexOf(']')];
                result = result.Concat(new string[] { customDelimiter }).ToArray();
            } else {
                result = result.Concat(new string[] { numbers[2].ToString() }).ToArray();
            }
        }
        return result;
    }

    private void CheckNegatives(){

    }
}