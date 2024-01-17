namespace Assignment1;

public class ReversePolishNotation
{
    public CustomQueue<string> ToRPN(CustomQueue<string> tokens)
    {
        CustomQueue<string> result = new();
        CustomStack<string> stack = new();
        while (tokens.Count > 0)
        {
            string token = tokens.Dequeue();

            if (token.All(char.IsDigit))
            {
                result.Enqueue(token);
            }
            else
            {
                // If stack is empty
                if (stack.Peek() == null)
                {
                    stack.Push(token);
                    continue;
                }
                
                // if token is a left bracket
                if (token == "(")
                {
                    stack.Push(token);
                    continue;
                }
                
                // if token is a right bracket
                if (token == ")")
                {
                    var operatorr = stack.Pop();
                    while (operatorr != "(")
                    {
                        result.Enqueue(operatorr);
                        operatorr = stack.Pop();
                    }
                    continue;
                }

                // if token is a normal operator
                if (SimpleMath.GetPrecedence(stack.Peek()) >= SimpleMath.GetPrecedence(token))
                {
                    result.Enqueue(stack.Pop());
                    stack.Push(token);
                }
                else stack.Push(token);
            }
        }

        // Getting the operators out of stack
        while (stack.Peek() != null)
        {
            result.Enqueue(stack.Pop());
        }
        
        return result;
    }
    public int CalculateRPN(CustomQueue<string> postfixed)
    {
        CustomStack<string> numbers = new();
        while (postfixed.Count > 0)
        {
            string symbol = postfixed.Dequeue();

            if (symbol.All(char.IsDigit))
            {
                numbers.Push(symbol);
            }
            else
            {
                int num1 = Convert.ToInt32(numbers.Pop());
                int num2 = Convert.ToInt32(numbers.Pop());
                
                numbers.Push(SimpleMath.Calculation(num2, num1, symbol).ToString());
            }
        }

        return Convert.ToInt32(numbers.Pop());
    }
}