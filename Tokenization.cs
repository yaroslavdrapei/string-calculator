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
            else if (chr == '-')
            {
                if (digits.Count != 0)
                {
                    result.Enqueue(digits.ToString());
                    digits.Clear();  
                };
                // if (result.PeekLast() == null || !SimpleMath.IsNumeric(result.PeekLast()))
                // {
                //     digits.Enqueue(chr);
                // }
                Console.WriteLine(result.PeekLast());
                if (result.PeekLast() == null) digits.Enqueue(chr);
                else if (!SimpleMath.IsNumeric(result.PeekLast())) digits.Enqueue(chr);
                else result.Enqueue(chr.ToString());
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