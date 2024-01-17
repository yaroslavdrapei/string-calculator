﻿namespace Assignment1;

public class Program
{
    public static void Main(string[] args)
    {
        var tokenizer = new Tokenizer();
        var tokens = tokenizer.Tokenize(Console.ReadLine());
        
        var rpn = new ReversePolishNotation();  
        var rpnQueue = rpn.ToRPN(tokens);
    }
}