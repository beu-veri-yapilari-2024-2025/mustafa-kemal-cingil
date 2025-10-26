using System;
using System.Collections.Generic;
using System.Linq;

class InfixPrefixPostfixConverter
{
    static int GetPrecedence(char op)
    {
        if (op == '+' || op == '-')
            return 1;
        if (op == '*' || op == '/')
            return 2;
        if (op == '^')
            return 3;
        return 0;
    }

    static bool IsRightAssociative(char op)
    {
        return op == '^';
    }

    static string InfixToPostfix(string infix)
    {
        Stack<char> stack = new Stack<char>();
        string postfix = "";
        
        for (int i = 0; i < infix.Length; i++)
        {
            char c = infix[i];

            if (char.IsDigit(c) || char.IsLetter(c))
            {
                postfix += c;
            }
            else if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                {
                    postfix += stack.Pop();
                }
                if (stack.Count > 0)
                    stack.Pop();
            }
            else if ("+-*^/".Contains(c))
            {
                while (stack.Count > 0 &&
                       stack.Peek() != '(' &&
                       GetPrecedence(stack.Peek()) > GetPrecedence(c) ||
                       (GetPrecedence(stack.Peek()) == GetPrecedence(c) && !IsRightAssociative(c)))
                {
                    postfix += stack.Pop();
                }
                stack.Push(c);
            }
        }

        while (stack.Count > 0)
        {
            postfix += stack.Pop();
        }

        return postfix;
    }

    static string InfixToPrefix(string infix)
    {
        string reversed = new string(infix.Reverse().ToArray());
        
        reversed = reversed.Replace('(', '#').Replace(')', '(').Replace('#', ')');
        
        string postfix = InfixToPostfix(reversed);
        
        return new string(postfix.Reverse().ToArray());
    }

    static string PostfixToInfix(string postfix)
    {
        Stack<string> stack = new Stack<string>();

        for (int i = 0; i < postfix.Length; i++)
        {
            char c = postfix[i];

            if (char.IsDigit(c) || char.IsLetter(c))
            {
                stack.Push(c.ToString());
            }
            else if ("+-*^/".Contains(c))
            {
                string op2 = stack.Pop();
                string op1 = stack.Pop();
                stack.Push("(" + op1 + c + op2 + ")");
            }
        }

        return stack.Pop();
    }

    static void Main()
    {
        Console.WriteLine("=== İNFİX PREFIX POSTFİX DÖNÜŞÜMÜ ===\n");

        string[] testCases = {
            "2x(3+5)-7^2(2+1)",
            "(2+3)*5",
            "2*3+5-7^2+1"
        };

        foreach (string expr in testCases)
        {
            Console.WriteLine($"Orijinal İnfix: {expr}");
            
            string postfix = InfixToPostfix(expr);
            Console.WriteLine($"Postfix:        {postfix}");
            
            string prefix = InfixToPrefix(expr);
            Console.WriteLine($"Prefix:         {prefix}");
            
            string backToInfix = PostfixToInfix(postfix);
            Console.WriteLine($"Infix (Geri):   {backToInfix}\n");
        }
    }
}