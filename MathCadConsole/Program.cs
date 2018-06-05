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
        static List<Token> ProvUnarMinus(List<Token> tokens)
        {
            for(int i=0; i<tokens.Count; i++)
            {
                if((i==0) && (tokens[i].Value=="-"))
                {
                    tokens[i + 1].Value = Convert.ToString(-Convert.ToInt32(tokens[i + 1].Value)); 
                    tokens.Remove(tokens[i]);
                }
                else if (tokens[i].Value == "-" && (tokens[i - 1].Type == "(operator)" ||  tokens[i - 1].Value=="("))
                {
                    tokens[i + 1].Value = Convert.ToString(-Convert.ToInt32(tokens[i + 1].Value));
                    tokens.Remove(tokens[i]);
                }
            }
            return tokens;
        }

        static void Main(string[] args)
        {
            ClassObrpolsksap Obrpolsapis = new ClassObrpolsksap();
            ClassCalc Calcul = new ClassCalc();
            var lexer = new MathLexer();

            List<Token> tokens =  new List<Token>(lexer.Tokenize("-7-(-2)-(-3)-(-8)"));
            tokens = ProvUnarMinus(tokens);
            List<Token> result = Obrpolsapis.Obrpolsksap(tokens);
            foreach(Token c in result)
            {
                Console.WriteLine(c.Value);
            }

            Console.WriteLine(Calcul.Calc(result));
            Console.ReadLine();
        }
    }
}
