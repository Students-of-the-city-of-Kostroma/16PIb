using SimpleLexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCadConsole
{
    class Program
    {
        static string Obrpolsksap(List<Token> token)
        {
            string result="";
            Stack<Token> prom = new Stack<Token>();
            int i = 0;
            Token first = null;
            while (i<token.Count)
            {
                if (prom.Count != 0)
                {
                    first = prom.Peek();
                }
                if (token[i].Type == "(literal)") { result += token[i].Value + " "; i++; }
                else
                if (token[i].Value == "+" || token[i].Value == "-")
                {
                    if (first == null || first.Value == "(")
                    {
                        prom.Push(token[i]);
                        i++;
                    }
                    else if (first.Value == "+" || first.Value == "-" || first.Value == "*" || first.Value == "/")
                        result += prom.Pop().Value+" ";
                }
                else if (token[i].Value == "*" || token[i].Value == "/")
                {
                    if (first == null || first.Value == "(" || first.Value == "+" || first.Value == "-")
                    {
                        prom.Push(token[i]);
                        i++;
                    }
                    else if (first.Value == "*" || first.Value == "/")
                        result += prom.Pop().Value+" ";
                }
                else
                    if (token[i].Value == "(")
                {
                    prom.Push(token[i]);
                    i++;
                }
                else
                    if (token[i].Value == ")")
                {
                    if (first.Value == "+" || first.Value == "-" || first.Value == "*" || first.Value == "/")
                    {
                        result += prom.Pop().Value+" ";
                    }
                    else if (first.Value == "(") { prom.Pop(); i++; }

                }

            }
            result += prom.Pop().Value + " ";
            return result;
        }
        static float Calc(string input)
        {
            string[] post = input.Split(' ');
            Stack<float> digit = new Stack<float> ();
            float var_1=0, var_2=0;
            float prom = 0;
            for (int i = 0; i < post.Count(); i++)
            {
                if (float.TryParse(post[i], out prom))
                {
                    digit.Push((float)Convert.ToDouble(post[i]));
                }
                else if (post[i] == "+")
                {
                    digit.Push(digit.Pop() + digit.Pop());
                }
                else if (post[i] == "-")
                {
                    var_2 = digit.Pop();
                    var_1 = digit.Pop();
                    digit.Push(var_1 - var_2);
                }
                else if (post[i] == "*")
                {
                    digit.Push(digit.Pop() * digit.Pop());
                }
                else if (post[i] == "/")
                {
                    var_2 = digit.Pop();
                    var_1 = digit.Pop();
                    if (var_2 != 0)
                    {
                        digit.Push(var_1 / var_2);
                    }
                    else throw new Exception("Делить на 0 нельзя!");
                }
            }
            return digit.Pop();
        }
        static void Main(string[] args)
        {
            var lexer = new MathLexer();

            List<Token> tokens =  new List<Token>(lexer.Tokenize("(1+2)*4"));
            string result = Obrpolsksap(tokens);

            Console.WriteLine(result);
            Console.WriteLine(Calc(result));
            Console.ReadLine();
        }
    }
}
