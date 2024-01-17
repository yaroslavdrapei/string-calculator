using System.Xml;
using TestProjectApp;

namespace Assignment1;

public class Tokenizer
{
    public CustomQueue<string> Tokenize(string input)
    {
        string digits = "";
        CustomQueue<string> queue = new();
        foreach (var chr in input)
        {
            if (char.IsDigit(chr)) { digits += chr; }
            else if (chr == ' ')
            {
                if (digits == "") continue;
                queue.Enqueue(digits);
                digits = "";
            }
            else
            {
                if (digits != "")
                {
                    queue.Enqueue(digits);
                    digits = "";  
                };
                queue.Enqueue(chr.ToString());
            }
        }
        
        if (digits != "") queue.Enqueue(digits);

        return queue;
    }
}