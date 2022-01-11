namespace _01.BalancedBrackets
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        /*
        Input
        3
        {[()]}
        {[(])}
        {{[[(())]]}}

        Output
        YES
        NO
        YES
        */
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] values = new string[n];

            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                values[i] = s;
            }

            Console.WriteLine(string.Join("\n", isBalanced(values)));
        }

        public static string[] isBalanced(string[] values)
        {
            string[] result = new string[values.Length];
            Stack<char> parantheses = new Stack<char>();

            if (values.Length == 1)
            {
                return new string[] { "No" };
            }

            List<char> openingParantheses = new List<char>() { '(', '{', '[' };
            List<char> closingParantheses = new List<char>() { ')', '}', ']' };

            string brackets = string.Empty;

            for(int i = 0; i < values.Length; i++)
            {
                parantheses = new Stack<char>();
                brackets = values[i];

                foreach (char bracket in brackets)
                {
                    if (openingParantheses.Contains(bracket))
                    {
                        parantheses.Push(bracket);
                    }
                    else
                    {
                        if (closingParantheses.Contains(bracket) && parantheses.Count != 0)
                        {
                            char lastParantheses = parantheses.Peek();
                            if (lastParantheses == '(' && bracket == ')' || lastParantheses == '{' && bracket == '}' || lastParantheses == '[' && bracket == ']')
                            {
                                parantheses.Pop();
                            }
                            else
                            {
                                result[i] = "NO";
                                break;
                            }
                        }
                        else
                        {
                            result[i] = "NO";
                        }
                    }
                }

                if (parantheses.Count > 0)
                {
                    result[i] = "NO";
                }
                else
                {
                    result[i] = "YES";
                }
            }

            return result;
        }
    }
}