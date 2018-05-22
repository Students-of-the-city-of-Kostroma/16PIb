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
        static void Main(string[] args)
        {
            var lexer = new MathLexer();

            var tokens = lexer.Tokenize("2*2.3e-03");

            foreach (var token in tokens)
                Console.WriteLine(token);

            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
