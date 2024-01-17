namespace Assignment1;
public static class SimpleMath
{
    public static int GetPrecedence(string oper)
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
    public static int Calculation(int n1, int n2, string action)
    {
        switch (action)
        {
            case "+":
                return n1 + n2;
            case "-":
                return n1 - n2;
            case "*":
                return n1 * n2;
            case "/":
                return n1 / n2;
            case "^":
                return (int)Math.Pow(n1, n2);
            default:
                return 0;
        }
    }
}