using MathCadConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibraryTest
{
    [TestClass]
    public class ClassObrpolsksapTest
    {
        void CheckTokens(List<Token> tokens, params string[] p)
        {
            Assert.AreEqual(p.Length, 2 * tokens.Count, "Неправильное число токенов");
            for (int i = 0; i < tokens.Count; i++)
            {
                Assert.AreEqual(p[2 * i], tokens[i].Type);
                Assert.AreEqual(p[2 * i + 1], tokens[i].Value);
            }
        }

        [TestMethod]
        public void TestMethodObrpolsk01()
        {
            ClassObrpolsksap Obrpolsapis = new ClassObrpolsksap();
            ClassCalc Calcul = new ClassCalc();
            var lexer = new MathLexer();
            List<Token> tokens = new List<Token>(lexer.Tokenize("(2+3)*5"));
            List<Token> result = Obrpolsapis.Obrpolsksap(tokens);
            CheckTokens(result, 
                "(literal)", "2",
                "(literal)", "3",
                "(operator)", "+",
                "(literal)", "5",
                "(operator)", "*");
        }
        [TestMethod]
        public void TestMethodObrpolsk02()
        {
            ClassObrpolsksap Obrpolsapis = new ClassObrpolsksap();
            ClassCalc Calcul = new ClassCalc();
            var lexer = new MathLexer();
            List<Token> tokens = new List<Token>(lexer.Tokenize("6*(2-(-1))"));
            List<Token> result = Obrpolsapis.Obrpolsksap(tokens);
            CheckTokens(result,
                "(literal)", "6",
                "(literal)", "2",
                "(literal)", "1",
                "(operator)", "-",
                "(operator)", "-",
                "(operator)", "*");
        }
    }
}
