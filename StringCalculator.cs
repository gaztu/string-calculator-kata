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

        var numArray = numbers.Split(delimiters).Select(int.Parse);
        var negativeNumbers = numArray.Where(x => x < 0);
        if (negativeNumbers.Count() > 0) {
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