namespace Assignment1;

public class ReversePolishNotation
{
    private int GetPrecedence(string oper)
    {
        switch (oper)
        {
            case "+":
                return 1;
            case "-":
                return 1;
            case "*":
                return 2;
            case "/":
                return 2;
            case "^":
                return 3;
            default:
                return 0;
        }
    }
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
                if (GetPrecedence(stack.Peek()) >= GetPrecedence(token))
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
}