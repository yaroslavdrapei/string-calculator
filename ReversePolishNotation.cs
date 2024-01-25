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
            
            if (SimpleMath.IsNumeric(token))
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
    public double CalculateRPN(CustomQueue<string> postfixed)
    {
        CustomStack<string> numbers = new();
        while (postfixed.Count > 0)
        {
            string symbol = postfixed.Dequeue();
            if (SimpleMath.IsNumeric(symbol))
            {
                numbers.Push(symbol);
            }
            else
            {
                // Replacing . with , to make ToDouble work
                double num1 = Convert.ToDouble(numbers.Pop().Replace('.', ','));
                double num2 = Convert.ToDouble(numbers.Pop().Replace('.', ','));
                
                numbers.Push(SimpleMath.Calculation(num2, num1, symbol).ToString());
            }
        }

        return Convert.ToDouble(numbers.Pop().Replace('.', ','));
    }
}

/*
 -10+3
 10-3
 10+-3
*/