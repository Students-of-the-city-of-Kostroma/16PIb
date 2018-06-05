using SimpleLexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCadConsole
{
   public class ClassObrpolsksap
    {
       public List<Token> Obrpolsksap(List<Token> token)
       {
           List<Token> result = new List<Token>();
           Stack<Token> prom = new Stack<Token>();
           int i = 0;
           Token first = null;
           while (i < token.Count)
           {
               if (prom.Count != 0)
               {
                   first = prom.Peek();
               }
               if (token[i].Type == "(literal)") { result.Add(token[i]); i++; }
               else
                   if (token[i].Value == "+" || token[i].Value == "-")
                   {
                       if (first == null || first.Value == "(")
                       {
                           prom.Push(token[i]);
                           i++;
                       }
                       else if (first.Value == "+" || first.Value == "-" || first.Value == "*" || first.Value == "/")
                       {
                           result.Add(prom.Pop());
                           if (prom.Count == 0)
                               first = null;
                       }
                   }
                   else if (token[i].Value == "*" || token[i].Value == "/")
                   {
                       if (first == null || first.Value == "(" || first.Value == "+" || first.Value == "-")
                       {
                           prom.Push(token[i]);
                           i++;
                       }
                       else if (first.Value == "*" || first.Value == "/")
                       {
                           result.Add(prom.Pop());
                           if (prom.Count == 0)
                               first = null;
                       }
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
                                   result.Add(prom.Pop());
                                   if (prom.Count == 0)
                                       first = null;
                               }
                               else if (first.Value == "(") { prom.Pop(); i++; }

                           }

           }
           result.Add(prom.Pop());
           return result;
        }
    }
}
