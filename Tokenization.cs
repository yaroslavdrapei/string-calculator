namespace Assignment1;
public class Tokenizer
{
    public CustomQueue<string> Tokenize(string input)
    {
        CustomQueue<char> digits = new();
        CustomQueue<string> result = new();
        foreach (var chr in input)
        {
            if (SimpleMath.IsNumeric(chr)) digits.Enqueue(chr);
            else if (chr == ' ')
            {
                if (digits.Count == 0) continue;
                result.Enqueue(digits.ToString());
                digits.Clear();
            }
            else
            {
                if (digits.Count != 0)
                {
                    result.Enqueue(digits.ToString());
                    digits.Clear();  
                };
                result.Enqueue(chr.ToString());
            }
        }
        
        if (digits.Count != 0) result.Enqueue(digits.ToString());

        return result;
    }
}