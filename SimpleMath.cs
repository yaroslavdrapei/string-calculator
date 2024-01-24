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
    public static double Calculation(double n1, double n2, string action)
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
    public static bool IsNumeric(char chr)
    {
        return char.IsDigit(chr) || chr == '.';
    }
    public static bool IsNumeric(string str)
    {
        foreach (var chr in str)
        {
            if (!char.IsDigit(chr) && chr != '.') return false;
        }

        return true;
    }
}