using SimpleLexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCadConsole
{
    public class ClassCalc
    {
       public double Calc(List<Token> input)
        {

            Stack<double> digit = new Stack<double>();
            double var_1 = 0, var_2 = 0;
            double prom = 0;
            for (int i = 0; i < input.Count(); i++)
            {
                if (double.TryParse(input[i].Value, out prom))
                {
                    digit.Push(Convert.ToDouble(input[i].Value));
                }
                else if (input[i].Value == "+")
                {
                    digit.Push(digit.Pop() + digit.Pop());
                }
                else if (input[i].Value == "-")
                {
                    var_2 = digit.Pop();
                    var_1 = digit.Pop();
                    digit.Push(var_1 - var_2);
                }
                else if (input[i].Value == "*")
                {
                    digit.Push(digit.Pop() * digit.Pop());
                }
                else if (input[i].Value == "/")
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
    }
}
