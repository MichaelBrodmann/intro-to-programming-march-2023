
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        if (numbers.Contains(",")) {
            var commaAt = numbers.IndexOf(',');
            string x = numbers.Substring(0, commaAt);
            string y = numbers.Substring(commaAt+1);
            return int.Parse(x) + int.Parse(y);
        }
        
       
        if (numbers.Any(char.IsDigit)) {
            return int.Parse(numbers);
        }
        else
        {
            return 0;
        }
    }
}
