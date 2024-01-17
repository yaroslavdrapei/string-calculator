namespace Assignment1;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("> ");
        var input = Console.ReadLine();
        while ((input != "q") && (input != "quit"))
        {
            var tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize(input);
        
            var rpn = new ReversePolishNotation();  
            var rpnQueue = rpn.ToRPN(tokens);
            
            var result = rpn.CalculateRPN(rpnQueue);
            Console.WriteLine($"< {result}");
            Console.Write("> ");
            input = Console.ReadLine();
        }
    }
}